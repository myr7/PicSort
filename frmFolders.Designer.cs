namespace PicSort
{
    partial class frmFolders
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
            this.lstFolders = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstIncluded = new System.Windows.Forms.ListBox();
            this.cmdAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFolders
            // 
            this.lstFolders.FormattingEnabled = true;
            this.lstFolders.HorizontalScrollbar = true;
            this.lstFolders.Location = new System.Drawing.Point(12, 45);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(555, 160);
            this.lstFolders.TabIndex = 0;
            this.lstFolders.DoubleClick += new System.EventHandler(this.lstFolders_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folders In Application Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Included Folders";
            // 
            // lstIncluded
            // 
            this.lstIncluded.FormattingEnabled = true;
            this.lstIncluded.Location = new System.Drawing.Point(12, 243);
            this.lstIncluded.Name = "lstIncluded";
            this.lstIncluded.Size = new System.Drawing.Size(555, 121);
            this.lstIncluded.TabIndex = 3;
            this.lstIncluded.DoubleClick += new System.EventHandler(this.lstIncluded_DoubleClick);
            // 
            // cmdAll
            // 
            this.cmdAll.Location = new System.Drawing.Point(184, 211);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(165, 23);
            this.cmdAll.TabIndex = 4;
            this.cmdAll.Text = "Move All Folders to Included";
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // frmFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 367);
            this.Controls.Add(this.cmdAll);
            this.Controls.Add(this.lstIncluded);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFolders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFolders";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folders";
            this.Activated += new System.EventHandler(this.frmFolders_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFolders_FormClosing);
            this.Load += new System.EventHandler(this.frmFolders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstIncluded;
        private System.Windows.Forms.Button cmdAll;
    }
}