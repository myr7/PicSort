using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PicSort
{
    public partial class frmView : Form
    {
        public frmView()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void frmView_Load(object sender, EventArgs e)
        {

            //Image img = Image.FromFile(this.Tag.ToString());
            Image img = GlobalVars.myFunctions.ConvertFileAddressToImage(this.Tag.ToString());
            

            pictureBox1.Image = null;
            //pictureBox1.Load(this.Tag.ToString());
            lblAddress.Text = this.Tag.ToString();

            bool stretch = false;
            //if (img.Width > (this.Width - 1)) stretch = true;
            if (img.Width > (pictureBox1.Width - 1)) stretch = true;
            //if (img.Height > (this.Height - 1)) stretch = true;
            if (img.Height > (pictureBox1.Height - 1)) stretch = true;

            if (stretch)
            {
                pictureBox1.Height = this.Height - 1;
                pictureBox1.Width = this.Width - 1;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = img;
                
            }
            else
            {
                pictureBox1.Height = this.Height - 1;
                pictureBox1.Width = this.Width - 1;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.Image = img;

            }
            
            
            //this.Width = SystemInformation.VirtualScreen.Width;
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

  
            this.Hide();
        }

        private void frmView_Activated(object sender, EventArgs e)
        {

        }

        private void frmView_FormClosing(object sender, FormClosingEventArgs e)
        {

        }





    }
}
