namespace MediaTest
{
    partial class MovieQuery
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnQuery = new System.Windows.Forms.RadioButton();
            this.rbtnCategory = new System.Windows.Forms.RadioButton();
            this.rbtnDisk = new System.Windows.Forms.RadioButton();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtMovieName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.tabControl_data = new System.Windows.Forms.TabControl();
            this.page_result = new System.Windows.Forms.TabPage();
            this.dgvMediaInfo = new System.Windows.Forms.DataGridView();
            this.SeqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filenameOfChn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.videoBitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl_data.SuspendLayout();
            this.page_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnQuery);
            this.panel1.Controls.Add(this.rbtnCategory);
            this.panel1.Controls.Add(this.rbtnDisk);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.txtMovieName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 48);
            this.panel1.TabIndex = 0;
            // 
            // rbtnQuery
            // 
            this.rbtnQuery.AutoSize = true;
            this.rbtnQuery.Location = new System.Drawing.Point(984, 19);
            this.rbtnQuery.Name = "rbtnQuery";
            this.rbtnQuery.Size = new System.Drawing.Size(71, 16);
            this.rbtnQuery.TabIndex = 5;
            this.rbtnQuery.TabStop = true;
            this.rbtnQuery.Text = "检索浏览";
            this.rbtnQuery.UseVisualStyleBackColor = true;
            this.rbtnQuery.CheckedChanged += new System.EventHandler(this.rbtnQuery_CheckedChanged);
            // 
            // rbtnCategory
            // 
            this.rbtnCategory.AutoSize = true;
            this.rbtnCategory.Location = new System.Drawing.Point(1182, 19);
            this.rbtnCategory.Name = "rbtnCategory";
            this.rbtnCategory.Size = new System.Drawing.Size(71, 16);
            this.rbtnCategory.TabIndex = 4;
            this.rbtnCategory.TabStop = true;
            this.rbtnCategory.Text = "分类浏览";
            this.rbtnCategory.UseVisualStyleBackColor = true;
            this.rbtnCategory.CheckedChanged += new System.EventHandler(this.rbtnCategory_CheckedChanged);
            // 
            // rbtnDisk
            // 
            this.rbtnDisk.AutoSize = true;
            this.rbtnDisk.Location = new System.Drawing.Point(1083, 19);
            this.rbtnDisk.Name = "rbtnDisk";
            this.rbtnDisk.Size = new System.Drawing.Size(71, 16);
            this.rbtnDisk.TabIndex = 3;
            this.rbtnDisk.TabStop = true;
            this.rbtnDisk.Text = "磁盘浏览";
            this.rbtnDisk.UseVisualStyleBackColor = true;
            this.rbtnDisk.CheckedChanged += new System.EventHandler(this.rbtnDisk_CheckedChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(598, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(165, 29);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "全文检索";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtMovieName
            // 
            this.txtMovieName.Location = new System.Drawing.Point(74, 14);
            this.txtMovieName.Name = "txtMovieName";
            this.txtMovieName.Size = new System.Drawing.Size(509, 21);
            this.txtMovieName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "影片名字：";
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSummary.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSummary.Location = new System.Drawing.Point(0, 714);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ReadOnly = true;
            this.txtSummary.Size = new System.Drawing.Size(1273, 26);
            this.txtSummary.TabIndex = 2;
            // 
            // tabControl_data
            // 
            this.tabControl_data.Controls.Add(this.page_result);
            this.tabControl_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_data.Location = new System.Drawing.Point(0, 48);
            this.tabControl_data.Name = "tabControl_data";
            this.tabControl_data.SelectedIndex = 0;
            this.tabControl_data.Size = new System.Drawing.Size(1273, 666);
            this.tabControl_data.TabIndex = 3;
            this.tabControl_data.SelectedIndexChanged += new System.EventHandler(this.tabControl_data_SelectedIndexChanged);
            // 
            // page_result
            // 
            this.page_result.Controls.Add(this.dgvMediaInfo);
            this.page_result.Location = new System.Drawing.Point(4, 22);
            this.page_result.Name = "page_result";
            this.page_result.Size = new System.Drawing.Size(1265, 640);
            this.page_result.TabIndex = 8;
            this.page_result.Text = "检索结果";
            this.page_result.UseVisualStyleBackColor = true;
            // 
            // dgvMediaInfo
            // 
            this.dgvMediaInfo.AllowUserToAddRows = false;
            this.dgvMediaInfo.AllowUserToDeleteRows = false;
            this.dgvMediaInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMediaInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeqNo,
            this.category,
            this.filenameOfChn,
            this.videoSize,
            this.videoTime,
            this.videoBitrate,
            this.fileSize,
            this.subTitle,
            this.fileLength,
            this.disk,
            this.fileName,
            this.completeName});
            this.dgvMediaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMediaInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvMediaInfo.Name = "dgvMediaInfo";
            this.dgvMediaInfo.RowHeadersVisible = false;
            this.dgvMediaInfo.RowTemplate.Height = 23;
            this.dgvMediaInfo.Size = new System.Drawing.Size(1265, 640);
            this.dgvMediaInfo.TabIndex = 6;
            // 
            // SeqNo
            // 
            this.SeqNo.HeaderText = "No";
            this.SeqNo.Name = "SeqNo";
            this.SeqNo.Width = 40;
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
            this.filenameOfChn.Width = 150;
            // 
            // videoSize
            // 
            this.videoSize.HeaderText = "画面尺寸";
            this.videoSize.Name = "videoSize";
            this.videoSize.Width = 90;
            // 
            // videoTime
            // 
            this.videoTime.HeaderText = "视频时长";
            this.videoTime.Name = "videoTime";
            this.videoTime.Width = 90;
            // 
            // videoBitrate
            // 
            this.videoBitrate.HeaderText = "视频码率";
            this.videoBitrate.Name = "videoBitrate";
            this.videoBitrate.Width = 80;
            // 
            // fileSize
            // 
            this.fileSize.HeaderText = "文件大小";
            this.fileSize.Name = "fileSize";
            this.fileSize.Width = 80;
            // 
            // subTitle
            // 
            this.subTitle.HeaderText = "字幕";
            this.subTitle.Name = "subTitle";
            this.subTitle.Width = 120;
            // 
            // fileLength
            // 
            this.fileLength.HeaderText = "字节数";
            this.fileLength.Name = "fileLength";
            // 
            // disk
            // 
            this.disk.HeaderText = "所属磁盘";
            this.disk.Name = "disk";
            // 
            // fileName
            // 
            this.fileName.HeaderText = "文件名称";
            this.fileName.Name = "fileName";
            this.fileName.Width = 500;
            // 
            // completeName
            // 
            this.completeName.HeaderText = "完整路径";
            this.completeName.Name = "completeName";
            this.completeName.Width = 500;
            // 
            // MovieQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 740);
            this.Controls.Add(this.tabControl_data);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.panel1);
            this.Name = "MovieQuery";
            this.Text = "MovieQuery";
            this.Load += new System.EventHandler(this.MovieQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl_data.ResumeLayout(false);
            this.page_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediaInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtMovieName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnQuery;
        private System.Windows.Forms.RadioButton rbtnCategory;
        private System.Windows.Forms.RadioButton rbtnDisk;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TabControl tabControl_data;
        private System.Windows.Forms.TabPage page_result;
        private System.Windows.Forms.DataGridView dgvMediaInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn filenameOfChn;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn videoBitrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn disk;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeName;
    }
}