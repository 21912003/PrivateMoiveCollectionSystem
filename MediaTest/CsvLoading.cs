using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MediaTest
{
    public class CsvLoading
    {
        public delegate void OnDataArrival(string disk,string[] mediaInfo);
        public delegate void OnFinished();
        public delegate void OnPartFinished();

        public event OnDataArrival DataArrival;
        public event OnFinished Finished;
        public event OnPartFinished PartFinished;

        private List<string> diskList;

        public CsvLoading()
        {
            //取得磁盘列表
            diskList = getCategory();
        }

        public int getCsvCount()
        {
            return diskList.Count;
        }

        public void Run()
        {
            //加载数据
            loadCsv(diskList);
            //结束通知
            if (Finished != null)
            {
                Finished();
            }
        }

        private List<string> getCategory()
        {
            List<string> diskList = new List<string>();

            string keyTmp = "Disk";
            for (int i = 1; i < 100; i++)
            {
                string key = keyTmp + i.ToString();
                string value = ConfigHelper.getValue(key);
                if (value == null || value.Trim() == "") break;

                //填充磁盘列表
                diskList.Add(value);
            }

            return diskList;
        }

        private void loadCsv(List<string> diskList)
        {
            try
            {
                for (int i = 0; i < diskList.Count; i++)
                {
                    string csvName = diskList[i] + ".csv";

                    if (!File.Exists(csvName)) continue;

                    //创建CSV输出文件
                    FileStream fs = new FileStream(csvName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

                    int row = 0;
                    String line = "";
                    while((line=sr.ReadLine()) != null)
                    {
                        row++;
                        //过滤首行
                        if (row == 1) continue;

                        string[] mediaInfo = line.Split(',');
                        DataArrival(diskList[i],mediaInfo);
                    }

                    //出发事件
                    if (PartFinished != null)
                        PartFinished();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
