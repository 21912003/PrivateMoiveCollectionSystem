using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MediaTest
{
    public partial class MovieQuery : Form
    {
        private const string CATEGORY_PAGE_PREFIX = "C_PAGE_";
        private const string DISK_PAGE_PREFIX = "D_PAGE_";
        private const string GRID_NAME_IN_PAGE = "dgv";

        List<string> categoryList = new List<string>();
        List<string> diskList = new List<string>();

        private List<TabPage> categoryPages = new List<TabPage>();
        private List<TabPage> diskPages = new List<TabPage>();

        ProgressForm progerssForm = null;

        public MovieQuery()
        {
            InitializeComponent();
        }

        private void MovieQuery_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //多线程启动
            CsvLoading csvLoading = new CsvLoading();
            csvLoading.DataArrival += onDataArrival;
            csvLoading.Finished += onFinished;
            csvLoading.PartFinished += onPartFinished;

            Thread thread = new Thread(csvLoading.Run);
            thread.Start();

            progerssForm = new ProgressForm();
            progerssForm.BaseNum = csvLoading.getCsvCount();
            progerssForm.ShowDialog();
        }

        private void onDataArrival(string disk, string[] mediaInfo)
        {
             
            if (this.InvokeRequired)
            {
                this.Invoke(new CsvLoading.OnDataArrival(onDataArrival), disk, mediaInfo);
            }
            else
            {
                actionOnDataArrival(disk, mediaInfo);
            }
        }

        private void actionOnDataArrival(string disk, string[] mediaInfo)
        {
            DataGridView dgv = null;
            string category = mediaInfo[1];

            string pageName = DISK_PAGE_PREFIX + disk;
            if (!diskList.Contains(disk))
            {
                diskList.Add(disk);
                dgv = addPage(pageName, disk);
            }
            else
            {
                dgv = (DataGridView)diskPages[diskList.IndexOf(disk)].Controls[GRID_NAME_IN_PAGE];
            }

            addDataToGrid(mediaInfo,dgv);

            pageName = CATEGORY_PAGE_PREFIX + category;
            if (!categoryList.Contains(category))
            {
                categoryList.Add(category);
                dgv = addPage(pageName, category);
            }
            else
            {
                dgv = (DataGridView)categoryPages[categoryList.IndexOf(category)].Controls[GRID_NAME_IN_PAGE];
            }

            addDataToGrid(mediaInfo, dgv);
        }

        private void onFinished()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CsvLoading.OnFinished(onFinished));
            }
            else
            {
                progerssForm.Close();
                progerssForm = null;

                //设置默认值
                rbtnQuery.Checked = true;
            }
        }

        private void onPartFinished()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CsvLoading.OnPartFinished(onPartFinished));
            }
            else
            {
                progerssForm.partFinished();
            }
        }

        private DataGridView addPage(string pageName, string pageText)
        {
            Boolean showCategory = pageName.Contains(CATEGORY_PAGE_PREFIX) ? true : false ;
            Boolean showDisk = pageName.Contains(DISK_PAGE_PREFIX) ? true : false;

            //实例化PAGE
            TabPage tabPage = new TabPage();
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = pageName;
            tabPage.Text = pageText;
            tabPage.UseVisualStyleBackColor = true;

            if (showCategory)
            {
                categoryPages.Add(tabPage);
            }
            if (showDisk)
            {
                diskPages.Add(tabPage);
            }

            //实例化GRID
            return addGridView(tabPage);
        }

        private DataGridView addGridView(TabPage tabPage)
        { 
            DataGridViewTextBoxColumn SeqNo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn filenameOfChn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn videoSize = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn videoTime = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn videoBitrate = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn fileSize = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTitle = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn fileLength = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn fileName = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disk = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn category = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn completeName = new DataGridViewTextBoxColumn();

            // 
            // SeqNo
            // 
            SeqNo.HeaderText = "No";
            SeqNo.Name = "SeqNo";
            SeqNo.Width = 40;
            // 
            // filenameOfChn
            // 
            filenameOfChn.HeaderText = "中文文件名";
            filenameOfChn.Name = "filenameOfChn";
            filenameOfChn.ReadOnly = true;
            filenameOfChn.Width = 200;
            // 
            // videoSize
            // 
            videoSize.HeaderText = "画面尺寸";
            videoSize.Name = "videoSize";
            videoSize.Width = 90;
            // 
            // videoTime
            // 
            videoTime.HeaderText = "视频时长";
            videoTime.Name = "videoTime";
            videoTime.Width = 90;
            // 
            // videoBitrate
            // 
            videoBitrate.HeaderText = "视频码率";
            videoBitrate.Name = "videoBitrate";
            videoBitrate.Width = 80;
            // 
            // fileSize
            // 
            fileSize.HeaderText = "文件大小";
            fileSize.Name = "fileSize";
            fileSize.Width = 80;
            // 
            // subTitle
            // 
            subTitle.HeaderText = "字幕";
            subTitle.Name = "subTitle";
            subTitle.Width = 140;
            // 
            // fileLength
            // 
            fileLength.HeaderText = "字节数";
            fileLength.Name = "fileLength";
            fileLength.Visible = true;
            fileLength.Width = 130;
            // 
            // fileName
            // 
            fileName.HeaderText = "文件名称";
            fileName.Name = "fileName";
            fileName.Width = 450;
            // 
            // disk
            // 
            disk.HeaderText = "所属磁盘";
            disk.Name = "disk";
            disk.Visible = true;
            // 
            // category
            // 
            category.HeaderText = "所属分类";
            category.Name = "category";
            category.Visible = true;
            // 
            // completeName
            // 
            completeName.HeaderText = "完整路径";
            completeName.Name = "completeName";
            completeName.Visible = true;

            DataGridView dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            SeqNo,
            filenameOfChn,
            videoSize,
            videoTime,
            videoBitrate,
            fileSize,
            subTitle,
            fileLength,
            fileName,
            disk,
            category,
            completeName});
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.Location = new System.Drawing.Point(0, 0);
            dgv.Name = GRID_NAME_IN_PAGE;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 23;
            dgv.Tag = 0;

            tabPage.Controls.Add(dgv);
            return dgv;
        }

        private void addDataToGrid(string[] aryLine, DataGridView dgv)
        {
            //加载数据
            int index = dgv.Rows.Add();
            dgv.Rows[index].Cells["SeqNo"].Value = dgv.RowCount;
            dgv.Rows[index].Cells["category"].Value = aryLine[1];
            dgv.Rows[index].Cells["filenameOfChn"].Value = aryLine[2];
            dgv.Rows[index].Cells["fileSize"].Value = aryLine[3];
            dgv.Rows[index].Cells["videoSize"].Value = aryLine[4];
            dgv.Rows[index].Cells["videoTime"].Value = aryLine[5];
            dgv.Rows[index].Cells["videoBitrate"].Value = aryLine[6];
            dgv.Rows[index].Cells["subTitle"].Value = aryLine[7];
            dgv.Rows[index].Cells["fileName"].Value = aryLine[8];
            long fileLength = 0;
            long.TryParse(aryLine[9],out fileLength);
            dgv.Rows[index].Cells["fileLength"].Value = fileLength.ToString("#,###");
            dgv.Rows[index].Cells["disk"].Value = aryLine[10];
            //TODO:
            dgv.Rows[index].Cells["completeName"].Value = "";
            
            //累计文件大小
            long tmp = 0;
            long.TryParse(dgv.Tag.ToString(), out tmp);
            dgv.Tag = (tmp + fileLength).ToString();
        }

        private void rbtnQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnQuery.Checked)
            {
                btnQuery.Enabled = true;

                for (int i = 0; i < diskPages.Count; i++)
                {
                    if(tabControl_data.Controls.Contains(diskPages[i]))
                    {
                        tabControl_data.Controls.Remove(diskPages[i]);
                    }
                }
                for (int i = 0; i < categoryPages.Count; i++)
                {
                    if (tabControl_data.Controls.Contains(categoryPages[i]))
                    {
                        tabControl_data.Controls.Remove(categoryPages[i]);
                    }
                }
            }
        }

        private void rbtnDisk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDisk.Checked)
            {
                btnQuery.Enabled = false;

                for (int i = 0; i < diskPages.Count; i++)
                {
                    if (!tabControl_data.Controls.Contains(diskPages[i]))
                    {
                        tabControl_data.Controls.Add(diskPages[i]);
                    }
                }
                for (int i = 0; i < categoryPages.Count; i++)
                {
                    if (tabControl_data.Controls.Contains(categoryPages[i]))
                    {
                        tabControl_data.Controls.Remove(categoryPages[i]);
                    }
                }
            }
        }

        private void rbtnCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCategory.Checked)
            {
                btnQuery.Enabled = false;

                for (int i = 0; i < diskPages.Count; i++)
                {
                    if (tabControl_data.Controls.Contains(diskPages[i]))
                    {
                        tabControl_data.Controls.Remove(diskPages[i]);
                    }
                }
                for (int i = 0; i < categoryPages.Count; i++)
                {
                    if (!tabControl_data.Controls.Contains(categoryPages[i]))
                    {
                        tabControl_data.Controls.Add(categoryPages[i]);
                    }
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtMovieName.Text == "") return;

            dgvMediaInfo.Rows.Clear();
            dgvMediaInfo.Tag = 0;

            int k = 0;

            for (int i = 0; i < diskPages.Count; i++)
            {
                DataGridView dgv = (DataGridView)diskPages[i].Controls[GRID_NAME_IN_PAGE];
                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                    if (dgv.Rows[j].Cells["filenameOfChn"].Value.ToString().ToUpper().Contains(txtMovieName.Text.ToUpper()) ||
                        dgv.Rows[j].Cells["fileName"].Value.ToString().ToUpper().Contains(txtMovieName.Text.ToUpper()) ||
                        dgv.Rows[j].Cells["category"].Value.ToString().ToUpper().Contains(txtMovieName.Text.ToUpper()))
                    {
                        k++;
                        int index = dgvMediaInfo.Rows.Add();
                        dgvMediaInfo.Rows[index].Cells["SeqNo"].Value = k;
                        dgvMediaInfo.Rows[index].Cells["category"].Value = dgv.Rows[j].Cells["category"].Value;
                        dgvMediaInfo.Rows[index].Cells["filenameOfChn"].Value = dgv.Rows[j].Cells["filenameOfChn"].Value;
                        dgvMediaInfo.Rows[index].Cells["fileSize"].Value = dgv.Rows[j].Cells["fileSize"].Value;
                        dgvMediaInfo.Rows[index].Cells["videoSize"].Value = dgv.Rows[j].Cells["videoSize"].Value;
                        dgvMediaInfo.Rows[index].Cells["videoTime"].Value = dgv.Rows[j].Cells["videoTime"].Value;
                        dgvMediaInfo.Rows[index].Cells["videoBitrate"].Value = dgv.Rows[j].Cells["videoBitrate"].Value;
                        dgvMediaInfo.Rows[index].Cells["subTitle"].Value = dgv.Rows[j].Cells["subTitle"].Value;
                        dgvMediaInfo.Rows[index].Cells["fileName"].Value = dgv.Rows[j].Cells["fileName"].Value;
                        dgvMediaInfo.Rows[index].Cells["fileLength"].Value = dgv.Rows[j].Cells["fileLength"].Value;
                        dgvMediaInfo.Rows[index].Cells["disk"].Value = dgv.Rows[j].Cells["disk"].Value;
                        dgvMediaInfo.Rows[index].Cells["completeName"].Value = dgv.Rows[j].Cells["completeName"].Value;

                        long fileLength = 0;
                        long.TryParse(dgv.Rows[j].Cells["fileLength"].Value.ToString().Replace(",", ""), out fileLength);
                        long tag = 0;
                        long.TryParse(dgvMediaInfo.Tag.ToString(), out tag);
                        dgvMediaInfo.Tag = (tag + fileLength).ToString();
                    }
                }
            }

            //显示合计信息
            tabControl_data_SelectedIndexChanged(sender, e);
        }

        private void tabControl_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tb = tabControl_data.SelectedTab;
            foreach (Control ctl in tb.Controls)
            {
                if (ctl.GetType() == typeof(DataGridView))
                {
                    DataGridView dgv = (DataGridView)ctl;
                    if (dgv.Tag == null) dgv.Tag = "0";

                    long fileLength = 0;
                    long.TryParse(dgv.Tag.ToString(), out fileLength);
                    float gib = fileLength / 1024 / 1024 / 1024;
                    int rows = dgv.Rows.Count;

                    List<string> disks = new List<string>();
                    List<string> categorys = new List<string>();

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (!disks.Contains(dgv.Rows[i].Cells["disk"].Value.ToString()))
                            disks.Add(dgv.Rows[i].Cells["disk"].Value.ToString());
                        if (!categorys.Contains(dgv.Rows[i].Cells["category"].Value.ToString()))
                            categorys.Add(dgv.Rows[i].Cells["category"].Value.ToString());
                    }

                    if (ctl.Name == "dgvMediaInfo")
                    {
                        string summary = String.Format("关键字 = \"{0}\"      文件数量(个) = {1}      字节数 = {2}      容量(G) = {3}      磁盘分布数量 = {4}      种别分布数量 = {5}",
                            txtMovieName.Text, rows.ToString(), fileLength.ToString("#,###"), gib.ToString("0.00"), disks.Count.ToString(), categorys.Count.ToString());
                        txtSummary.Text = summary;
                    }
                    else
                    {
                        string summary = String.Format("文件数量(个) = {0}      字节数 = {1}      容量(G) = {2}      磁盘分布数量 = {3}      种别分布数量 = {4}",
                            rows.ToString(), fileLength.ToString("#,###"), gib.ToString("0.00"), disks.Count.ToString(), categorys.Count.ToString());
                        txtSummary.Text = summary;
                    }

                    break;
                }
            }
        }

        private void showSummary(int diskCount,int categoryCount)
        {
            
        }
    
    }
}
