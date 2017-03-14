using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MediaTest
{
    public partial class MediaInfoGetting : Form
    {
        private FileStream fs = null;
        private StreamWriter sw = null;
        private Thread thread;
        private MediaInfoUtil mediaInfoUtil;

        private ProgressForm progerssForm = null;
        private string lastPathSelected;            //上次浏览的目录

         
        public MediaInfoGetting()
        {
            InitializeComponent();
        }

        private void btnGetting_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Equals(""))
            {
                MessageBox.Show("请选中视频的路径后再进行获取。3Q");
                return;
            }

            if (cmbDisk.Text.Equals(""))
            {
                MessageBox.Show("请选择所属磁盘再进行获取。3Q");
                return;
            }

            if (txtOutTitle.Text.Equals(""))
            {
                MessageBox.Show("请输入标题后再进行获取。3Q");
                return;
            }

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }

            //写入历史
            string categoryTxt = txtOutTitle.Text.Trim().PadRight(20,' ');
            string diskTxt = cmbDisk.Text.Trim().PadRight(20,' ');
            string pathTxt = txtPath.Text.Trim();
            string historyTxt = String.Format("分类：{0} 磁盘：{1} 路径：{2}", categoryTxt, diskTxt, pathTxt);
            lstHistory.Items.Add(historyTxt);

            //多线程启动
            mediaInfoUtil = new MediaInfoUtil();
            mediaInfoUtil.NoFolderFlag = chkNoFolderFlg.Checked;
            mediaInfoUtil.MediaPath = txtPath.Text.Trim();
            mediaInfoUtil.DataArrival += onDataArrival;
            mediaInfoUtil.Finished += onFinished;

            thread = new Thread(mediaInfoUtil.Run);
            thread.Start();

            progerssForm = new ProgressForm();
            progerssForm.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (lastPathSelected != null)
                fbd.SelectedPath = lastPathSelected;
            fbd.ShowDialog();
            txtPath.Text = fbd.SelectedPath;
            lastPathSelected = fbd.SelectedPath;
        }

        private void createOutputCsv(string disk)
        {
            try
            {
                string csvName = disk + ".csv";
                if (System.IO.File.Exists(csvName))
                    System.IO.File.Delete(csvName);

                //创建CSV输出文件
                fs = new FileStream(csvName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);

                string header = "No,分类,中文文件名,文件大小,画面尺寸,视频时长,视频码率,字幕,文件名称,文件字节数,磁盘,完整路径";
                sw.WriteLine(header);

                for (int i = 0; i < dgvMediaInfos.Rows.Count; i++)
                {
                    string data = dgvMediaInfos.Rows[i].Cells["SeqNo"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["category"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["filenameOfChn"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["fileSize"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["videoSize"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["videoTime"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["videoBitrate"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["subTitle"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["fileName"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["fileLength"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["disk"].Value.ToString() + ",";
                    data += dgvMediaInfos.Rows[i].Cells["completeName"].Value.ToString();
                    sw.WriteLine(data);
                }

                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void onDataArrival(Exception ex, MediaInfoEntity mediaInfo)
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new MediaInfoUtil.OnDataArrival(onDataArrival), ex, mediaInfo);
            }
            else
            {
                actionOnDataArrival(ex, mediaInfo);
            }
        }

        private void actionOnDataArrival(Exception ex, MediaInfoEntity mediaInfo)
        {
            if (ex != null)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            //画面尺寸
            String videoSize = mediaInfo.VideoWidth + " * " + mediaInfo.VideoHeight;
            //视频时长
            string[] times = mediaInfo.VideoTime.Trim().ToUpper().Split(' ');
            int hour = 0;
            int.TryParse(times[0].Replace("H", ""),out hour);
            int min = 0;
            int.TryParse(times[1].Replace("MN", ""), out min);
            string vedioTime = String.Format("{0}:{1}",hour.ToString(),min.ToString().PadLeft(2,'0'));
            //文件大小
            string fileSize = mediaInfo.FileSize.ToUpper().Replace("GIB", "G");

            int index = dgvMediaInfos.Rows.Add();
            dgvMediaInfos.Rows[index].Cells["SeqNo"].Value = dgvMediaInfos.RowCount;
            dgvMediaInfos.Rows[index].Cells["category"].Value = txtOutTitle.Text;
            dgvMediaInfos.Rows[index].Cells["filenameOfChn"].Value = mediaInfo.FileNameOfChn;
            dgvMediaInfos.Rows[index].Cells["fileSize"].Value = fileSize;
            dgvMediaInfos.Rows[index].Cells["videoSize"].Value = videoSize;
            dgvMediaInfos.Rows[index].Cells["videoTime"].Value = vedioTime;
            dgvMediaInfos.Rows[index].Cells["videoBitrate"].Value = mediaInfo.VideoBitRate;
            dgvMediaInfos.Rows[index].Cells["subTitle"].Value = mediaInfo.Subtitles;
            dgvMediaInfos.Rows[index].Cells["fileName"].Value = mediaInfo.FileName;
            dgvMediaInfos.Rows[index].Cells["fileLength"].Value = mediaInfo.FileLength;
            dgvMediaInfos.Rows[index].Cells["disk"].Value = cmbDisk.Text.Trim();
            dgvMediaInfos.Rows[index].Cells["completeName"].Value = mediaInfo.CompletePath;

            //if (sw == null && fs == null)
            //{
            //    //创建CSV输出文件
            //    createOutputCsv(mediaInfo.FileRoot);
            //}

            //outputDataToCsv(mediaInfo, dgvMediaInfos.RowCount);
        }

        private void onFinished()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MediaInfoUtil.OnFinished(onFinished));
            }
            else
            {
                progerssForm.Close();
                progerssForm = null;

                //通知完毕
                //MessageBox.Show("视频文件信息获取完毕，请注意查收。");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutTitle.Text = "";
            lstHistory.Items.Clear();
            dgvMediaInfos.Rows.Clear();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {

            createOutputCsv(cmbDisk.Text);
        }

        private void MediaInfoGetting_Load(object sender, EventArgs e)
        {
            string keyTmp = "Disk";
            for (int i = 1; i < 100; i++)
            {
                string key = keyTmp + i.ToString();
                string value = ConfigHelper.getValue(key);
                if (value == null || value.Trim() == "") break;

                //填充磁盘列表
                cmbDisk.Items.Add(value);
            }   
        }
    }
}
