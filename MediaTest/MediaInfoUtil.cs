using System;
using System.Text;
using System.IO;

using MediaInfoLib;
using System.Collections;
using System.Collections.Generic;

namespace MediaTest
{
    public class MediaInfoUtil
    {
        public delegate void OnDataArrival(Exception ex, MediaInfoEntity mediaInfo);
        public delegate void OnFinished();

        public event OnDataArrival DataArrival;
        public event OnFinished Finished;

        private String mediaPath;
        private bool noFolderFlag;

        public bool NoFolderFlag
        {
            get { return noFolderFlag; }
            set { noFolderFlag = value; }
        }

        public String MediaPath
        {
            get { return mediaPath; }
            set { mediaPath = value; }
        }

        public void Run()
        {
            getMediaInfo(mediaPath, null);
            if (Finished != null)
            {
                Finished();
            }
        }

        private void getMediaInfo(String dir,String rootName) 
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            //例外目录
            bool isExcept = isException(dir);
            if (isExcept) return;

            String rootName_out = getFileRoot(dir);

            string[] dirs = Directory.GetDirectories(dir);//得到子目录
            IEnumerator iter = dirs.GetEnumerator();
            while (iter.MoveNext())
            {
                string str = (string)(iter.Current);
                rootName = getFileRoot(str);
                getMediaInfo(str, rootName);
            }

            FileInfo[] files = new DirectoryInfo(dir).GetFiles();
            if (files.Length > 0)
            {
                MediaInfoEntity mediaInfo = null;

                for (int i = 0; i < files.Length; i++)
                {
                    //跳过隐藏文件
                    String attString = files[i].Attributes.ToString();
                    Boolean isHidden = attString.ToUpper().Contains("HIDDEN");
                    if (isHidden) continue;

                    if (files[i].Name.ToUpper().EndsWith("SRT") ||
                        files[i].Name.ToUpper().EndsWith("ASS") ||
                        files[i].Name.ToUpper().EndsWith("SSA"))
                    { 
                        //字幕文件

                    }
                    
                    if (files[i].Name.ToUpper().EndsWith("MKV") ||
                        files[i].Name.ToUpper().EndsWith("AVI") ||
                        files[i].Name.ToUpper().EndsWith("MOV") ||
                        files[i].Name.ToUpper().EndsWith("MP4") ||
                        files[i].Name.ToUpper().EndsWith("MPG") ||
                        files[i].Name.ToUpper().EndsWith("MPEG") ||
                        files[i].Name.ToUpper().EndsWith("RM") ||
                        files[i].Name.ToUpper().EndsWith("FLV") ||
                        files[i].Name.ToUpper().EndsWith("TS") ||
                        files[i].Name.ToUpper().EndsWith("VOB") ||
                        files[i].Name.ToUpper().EndsWith("DAT") ||
                        files[i].Name.ToUpper().EndsWith("RMVB"))
                    {
                        Exception e = null;

                        try
                        {
                            MediaInfo mi = new MediaInfo();
                            mi.Open(files[i].FullName);
                            mi.Option("Complete");

                            String s = mi.Inform();
                            mi.Close();

                            mediaInfo = generateInfo(s);
                            mediaInfo.FileName = files[i].Name;
                            mediaInfo.FileParent = files[i].Directory.Name;
                            mediaInfo.FileRoot = rootName_out;
                            mediaInfo.FileLength = files[i].Length;

                            if (noFolderFlag)
                            {
                                mediaInfo.FileNameOfChn = getFileNameOfChn(files[i].Name);
                                mediaInfo.Subtitles = getSubTitle(null);
                            }
                            else
                            {
                                if (rootName_out != null && rootName_out.Contains("【") && rootName_out.Contains("】"))
                                {
                                    mediaInfo.FileNameOfChn = rootName_out;
                                }
                                else
                                {
                                    mediaInfo.FileNameOfChn = getFileNameOfChn(files[i].Directory.Name);
                                }
                                mediaInfo.Subtitles = getSubTitle(files[i]);
                            }
                        }
                        catch (Exception ex)
                        {
                            e = ex;
                        }

                        if (DataArrival != null)
                        {
                            DataArrival(e, mediaInfo);
                        }
                    }
                }
            }
        }

        private MediaInfoEntity generateInfo(String s)
        {
            MediaInfoEntity mediaInfo = new MediaInfoEntity();

            String[] v = s.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < v.Length; i++)
            {
                if (mediaInfo.FileSize != null && mediaInfo.VideoTime != null &&
                    mediaInfo.VideoHeight != null && mediaInfo.VideoWidth != null &&
                    mediaInfo.VideoBitRate != null && mediaInfo.CompletePath != null)
                    break;

                if (v[i].Replace(" ","").ToUpper().Contains("FileSize".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (mediaInfo.FileSize == null) mediaInfo.FileSize = tv[1];
                    continue;
                }
                if (v[i].Replace(" ","").ToUpper().Contains("Duration".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (mediaInfo.VideoTime == null) mediaInfo.VideoTime = tv[1];
                    continue;
                }
                if (v[i].Replace(" ", "").ToUpper().Contains("BitRate".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (mediaInfo.VideoBitRate == null && tv[1].Contains("Kbps"))
                        mediaInfo.VideoBitRate = tv[1].ToUpper().Replace(" ","").Replace("KBPS"," Kbps");
                    continue;
                }
                if (v[i].Replace(" ", "").ToUpper().Contains("Width".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (mediaInfo.VideoWidth == null) mediaInfo.VideoWidth = tv[1].ToUpper().Replace(" ", "").Replace("PIXELS","");
                    continue;
                }
                if (v[i].Replace(" ", "").ToUpper().Contains("Height".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    if (mediaInfo.VideoHeight == null) mediaInfo.VideoHeight = tv[1].ToUpper().Replace(" ", "").Replace("PIXELS","");
                    continue;
                }
                if (v[i].Replace(" ", "").ToUpper().Contains("Completename".ToUpper()))
                {
                    String[] tv = v[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] paths = tv[2].Split('\\');
                    Array.Resize(ref paths, paths.Length - 1);
                    string path = string.Join("\\", paths);
                    if (mediaInfo.CompletePath == null) mediaInfo.CompletePath = path;
                    continue;
                }
            }

            return mediaInfo;
        }

        private String getFileRoot(String filePath)
        {
            String rootName = null;

            String[] v = filePath.Split(new String[] { "\\" }, StringSplitOptions.None);
            if (v.Length > 0)
            {
                for (int i = 0; i < v.Length; i++)
                {
                    if (v[i].Contains("【") && v[i].Contains("】"))
                    {
                        int index = v[i].IndexOf("】");
                        rootName = v[i].Substring(0, index + 1);
                        break;
                    }
                }
            }

            return rootName;
        }

        private String getFileNameOfChn(String parentName)
        {
            String[] v = parentName.Split(new String[] { "." }, StringSplitOptions.None);
            return v[0];
        }

        private bool isException(String dir)
        {
            ////系统
            //if (attributes.LastIndexOf("System") != -1)
            //    return true;
            //是否为隐藏文件
            //if (attributes.LastIndexOf("Hidden") != -1)
            //    return true;
            ////是否为临时文件
            //if (attributes.LastIndexOf("Temporary") != -1)
            //    return true;

            if (dir.Trim().ToUpper().Contains("RECYCLE.BIN"))
                return true;
            if (dir.Contains("System Volume Information"))
                return true;

            return false;
        }

        private String getSubTitle(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return "无字幕或内嵌字幕";
            }

            List<String> subTitles = new List<string>();
            String fileName = fileInfo.Name;
            fileName = fileName.Replace(fileInfo.Extension, "").ToUpper();

            FileInfo[] subTitleFiles = fileInfo.Directory.GetFiles();
            for (int i = 0; i < subTitleFiles.Length; i++)
            {
                String name = subTitleFiles[i].Name.ToUpper();

                if ((name.EndsWith("SRT") ||
                name.EndsWith("ASS") ||
                name.EndsWith("SSA")) && 
                    (name.Contains(fileName)))
                {
                    //字幕文件
                    String[] values = name.Split(new char[1] { '.' });
                    List<String> vList = new List<string>(values);
                    if (vList.Contains("CHS") || vList.Contains("CHN"))
                    {
                        if (vList.Contains("ENG"))
                        {
                            if (!subTitles.Contains("外挂中英"))
                            {
                                subTitles.Add("外挂中英");
                            }
                            
                        }
                        else
                        {
                            if (!subTitles.Contains("外挂中文"))
                            {
                                subTitles.Add("外挂中文");
                            }
                        }
                    }
                    else
                    {
                        if (vList.Contains("ENG"))
                        {
                            if (!subTitles.Contains("外挂英文"))
                            {
                                subTitles.Add("外挂英文");
                            }
                        }
                        else
                        {
                            if (!subTitles.Contains("未知字幕"))
                            {
                                subTitles.Add("未知字幕");
                            }
                        }
                    }
                }
            }

            if (subTitles.Count == 0)
            {
                return "无字幕或内嵌字幕";
            }
            else
            {
                String subTitle = "";
                for (int i = 0; i < subTitles.Count; i++)
                {
                    subTitle += subTitles[i] + "|";
                }

                subTitle = subTitle.Substring(0, subTitle.Length - 1);
                return subTitle;
            }
            
        }
    }
}
