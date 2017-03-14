namespace MediaTest
{
    partial class ProgressForm
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
            this.components = new System.ComponentModel.Container();
            this.progressBarTip = new System.Windows.Forms.ProgressBar();
            this.timerLoop = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBarTip
            // 
            this.progressBarTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarTip.Location = new System.Drawing.Point(0, 0);
            this.progressBarTip.Name = "progressBarTip";
            this.progressBarTip.Size = new System.Drawing.Size(496, 45);
            this.progressBarTip.TabIndex = 0;
            // 
            // timerLoop
            // 
            this.timerLoop.Enabled = true;
            this.timerLoop.Interval = 1000;
            this.timerLoop.Tick += new System.EventHandler(this.timerLoop_Tick);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 45);
            this.Controls.Add(this.progressBarTip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressForm";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarTip;
        private System.Windows.Forms.Timer timerLoop;
    }
}