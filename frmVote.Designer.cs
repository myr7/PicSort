namespace PicSort
{
    partial class frmVote
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
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.cmdSkip = new System.Windows.Forms.Button();
            this.cmdDupe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.cmdClearDupe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxLeft.Location = new System.Drawing.Point(1, 44);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(680, 680);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBoxLeft_Click);
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxRight.Location = new System.Drawing.Point(696, 44);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(680, 680);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Click += new System.EventHandler(this.pictureBoxRight_Click);
            // 
            // cmdSkip
            // 
            this.cmdSkip.Location = new System.Drawing.Point(1, 15);
            this.cmdSkip.Name = "cmdSkip";
            this.cmdSkip.Size = new System.Drawing.Size(75, 23);
            this.cmdSkip.TabIndex = 2;
            this.cmdSkip.Text = "Skip";
            this.cmdSkip.UseVisualStyleBackColor = true;
            this.cmdSkip.Click += new System.EventHandler(this.cmdSkip_Click);
            // 
            // cmdDupe
            // 
            this.cmdDupe.Enabled = false;
            this.cmdDupe.Location = new System.Drawing.Point(82, 15);
            this.cmdDupe.Name = "cmdDupe";
            this.cmdDupe.Size = new System.Drawing.Size(75, 23);
            this.cmdDupe.TabIndex = 3;
            this.cmdDupe.Text = "Dupes";
            this.cmdDupe.UseVisualStyleBackColor = true;
            this.cmdDupe.Click += new System.EventHandler(this.cmdDupe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(468, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Winner!";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(812, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Winner!";
            this.label2.Visible = false;
            // 
            // lblRank
            // 
            this.lblRank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRank.Location = new System.Drawing.Point(567, 24);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(239, 17);
            this.lblRank.TabIndex = 6;
            this.lblRank.Text = "                                                        ";
            this.lblRank.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmdClearDupe
            // 
            this.cmdClearDupe.Enabled = false;
            this.cmdClearDupe.Location = new System.Drawing.Point(163, 15);
            this.cmdClearDupe.Name = "cmdClearDupe";
            this.cmdClearDupe.Size = new System.Drawing.Size(75, 23);
            this.cmdClearDupe.TabIndex = 7;
            this.cmdClearDupe.Text = "Clear Dupe Flag";
            this.cmdClearDupe.UseVisualStyleBackColor = true;
            // 
            // frmVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 730);
            this.Controls.Add(this.cmdClearDupe);
            this.Controls.Add(this.lblRank);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdDupe);
            this.Controls.Add(this.cmdSkip);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.pictureBoxLeft);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmVote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVote_FormClosing);
            this.Load += new System.EventHandler(this.frmVote_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmVote_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button cmdSkip;
        private System.Windows.Forms.Button cmdDupe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.Button cmdClearDupe;
    }
}