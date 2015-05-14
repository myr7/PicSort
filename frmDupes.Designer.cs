namespace PicSort
{
    partial class frmDupes
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
            this.lstDupes = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvlMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstDupes
            // 
            this.lstDupes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDupes.FormattingEnabled = true;
            this.lstDupes.HorizontalScrollbar = true;
            this.lstDupes.ItemHeight = 14;
            this.lstDupes.Location = new System.Drawing.Point(3, 23);
            this.lstDupes.Name = "lstDupes";
            this.lstDupes.Size = new System.Drawing.Size(537, 564);
            this.lstDupes.TabIndex = 0;
            this.lstDupes.SelectedIndexChanged += new System.EventHandler(this.lstDupes_SelectedIndexChanged);
            this.lstDupes.DoubleClick += new System.EventHandler(this.lstDupes_DoubleClick);
            this.lstDupes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstDupes_KeyDown);
            this.lstDupes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstDupes_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(546, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(629, 563);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dupes";
            // 
            // lvlMsg
            // 
            this.lvlMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lvlMsg.Location = new System.Drawing.Point(47, 4);
            this.lvlMsg.Name = "lvlMsg";
            this.lvlMsg.Size = new System.Drawing.Size(150, 17);
            this.lvlMsg.TabIndex = 4;
            this.lvlMsg.Text = "[F5] To refresh list.";
            // 
            // frmDupes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 594);
            this.Controls.Add(this.lvlMsg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstDupes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDupes";
            this.Text = "Dupes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDupes_FormClosing);
            this.Load += new System.EventHandler(this.frmDupes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDupes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDupes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lvlMsg;
    }
}