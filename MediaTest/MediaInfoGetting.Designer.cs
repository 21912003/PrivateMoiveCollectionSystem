namespace MediaTest
{
    partial class MediaInfoGetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGetting = new System.Windows.Forms.Button();
            this.txtOutTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkNoFolderFlg = new System.Windows.Forms.CheckBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDisk = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvMediaInfos = new System.Windows.Forms.DataGridView();
            this.SeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filenameOfChn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "视频文件路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(140, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(257, 21);
            this.txtPath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(420, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGetting
            // 
            this.btnGetting.Location = new System.Drawing.Point(747, 46);
            this.btnGetting.Name = "btnGetting";
            this.btnGetting.Size = new System.Drawing.Size(116, 30);
            this.btnGetting.TabIndex = 3;
            this.btnGetting.Text = "获取文件信息";
            this.btnGetting.UseVisualStyleBackColor = true;
            this.btnGetting.Click += new System.EventHandler(this.btnGetting_Click);
            // 
            // txtOutTitle
            // 
            this.txtOutTitle.Location = new System.Drawing.Point(140, 88);
            this.txtOutTitle.Name = "txtOutTitle";
            this.txtOutTitle.Size = new System.Drawing.Size(257, 21);
            this.txtOutTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "输出文件标题：";
            // 
            // chkNoFolderFlg
            // 
            this.chkNoFolderFlg.AutoSize = true;
            this.chkNoFolderFlg.Location = new System.Drawing.Point(140, 123);
            this.chkNoFolderFlg.Name = "chkNoFolderFlg";
            this.chkNoFolderFlg.Size = new System.Drawing.Size(180, 16);
            this.chkNoFolderFlg.TabIndex = 10;
            this.chkNoFolderFlg.Text = "同一类型文件在同一文件夹下";
            this.chkNoFolderFlg.UseVisualStyleBackColor = true;
            // 
            // lstHistory
            // 
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 12;
            this.lstHistory.Location = new System.Drawing.Point(0, 152);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(1328, 76);
            this.lstHistory.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(889, 46);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 30);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "清除列表";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(1023, 46);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(74, 30);
            this.btnOutput.TabIndex = 13;
            this.btnOutput.Text = "导出数据";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "视频所属磁盘：";
            // 
            // cmbDisk
            // 
            this.cmbDisk.FormattingEnabled = true;
            this.cmbDisk.Location = new System.Drawing.Point(140, 50);
            this.cmbDisk.Name = "cmbDisk";
            this.cmbDisk.Size = new System.Drawing.Size(257, 20);
            this.cmbDisk.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.lstHistory);
            this.panel1.Controls.Add(this.cmbDisk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.btnOutput);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.btnGetting);
            this.panel1.Controls.Add(this.chkNoFolderFlg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOutTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1328, 228);
            this.panel1.TabIndex = 16;
            // 
            // dgvMediaInfos
            // 
            this.dgvMediaInfos.AllowUserToAddRows = false;
            this.dgvMediaInfos.AllowUserToDeleteRows = false;
            this.dgvMediaInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMediaInfos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqNo,
            this.category,
            this.filenameOfChn,
            this.fileSize,
            this.videoSize,
            this.videoTime,
            this.videoBitrate,
            this.subTitle,
            this.fileName,
            this.fileLength,
            this.disk,
            this.completeName});
            this.dgvMediaInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMediaInfos.Location = new System.Drawing.Point(0, 228);
            this.dgvMediaInfos.Name = "dgvMediaInfos";
            this.dgvMediaInfos.RowHeadersVisible = false;
            this.dgvMediaInfos.RowTemplate.Height = 23;
            this.dgvMediaInfos.Size = new System.Drawing.Size(1328, 402);
            this.dgvMediaInfos.TabIndex = 17;
            // 
            // SeqNo
            // 
            this.SeqNo.HeaderText = "No";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.Width = 30;
            // 
            // category
            // 
            this.category.HeaderText = "分类";
            this.category.Name = "category";
            // 
            // filenameOfChn
            // 
            this.filenameOfChn.HeaderText = "中文文件名";
            this.filenameOfChn.Name = "filenameOfChn";
            this.filenameOfChn.ReadOnly = true;
            // 
            // fileSize
            // 
            this.fileSize.HeaderText = "文件大小";
            this.fileSize.Name = "fileSize";
            this.fileSize.Width = 80;
            // 
            // videoSize
            // 
            this.videoSize.HeaderText = "画面尺寸";
            this.videoSize.Name = "videoSize";
            this.videoSize.Width = 80;
            // 
            // videoTime
            // 
            this.videoTime.HeaderText = "视频时长";
            this.videoTime.Name = "videoTime";
            this.videoTime.Width = 80;
            // 
            // videoBitrate
            // 
            this.videoBitrate.HeaderText = "视频码率";
            this.videoBitrate.Name = "videoBitrate";
            this.videoBitrate.Width = 80;
            // 
            // subTitle
            // 
            this.subTitle.HeaderText = "字幕";
            this.subTitle.Name = "subTitle";
            // 
            // fileName
            // 
            this.fileName.HeaderText = "文件名称";
            this.fileName.Name = "fileName";
            this.fileName.Width = 350;
            // 
            // fileLength
            // 
            this.fileLength.HeaderText = "字节数";
            this.fileLength.Name = "fileLength";
            this.fileLength.Width = 150;
            // 
            // disk
            // 
            this.disk.HeaderText = "所属磁盘";
            this.disk.Name = "disk";
            this.disk.Width = 150;
            // 
            // completeName
            // 
            this.completeName.HeaderText = "完整路径";
            this.completeName.Name = "completeName";
            this.completeName.Width = 500;
            // 
            // MediaInfoGetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 630);
            this.Controls.Add(this.dgvMediaInfos);
            this.Controls.Add(this.panel1);
            this.Name = "MediaInfoGetting";
            this.Text = "MediaInfoGetting";
            this.Load += new System.EventHandler(this.MediaInfoGetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaInfos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGetting;
        private System.Windows.Forms.TextBox txtOutTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkNoFolderFlg;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDisk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvMediaInfos;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn filenameOfChn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoBitrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn disk;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeName;
    }
}