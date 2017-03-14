namespace MediaTest
{
    partial class GuideForm
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
            this.btnAllTextQuery = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllTextQuery
            // 
            this.btnAllTextQuery.Location = new System.Drawing.Point(12, 12);
            this.btnAllTextQuery.Name = "btnAllTextQuery";
            this.btnAllTextQuery.Size = new System.Drawing.Size(126, 58);
            this.btnAllTextQuery.TabIndex = 0;
            this.btnAllTextQuery.Text = "全文检索";
            this.btnAllTextQuery.UseVisualStyleBackColor = true;
            this.btnAllTextQuery.Click += new System.EventHandler(this.btnAllTextQuery_Click);
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(163, 12);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(126, 58);
            this.btnMake.TabIndex = 1;
            this.btnMake.Text = "片单制作";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // GuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 84);
            this.Controls.Add(this.btnMake);
            this.Controls.Add(this.btnAllTextQuery);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuideForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuideForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAllTextQuery;
        private System.Windows.Forms.Button btnMake;
    }
}