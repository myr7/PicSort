using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PicSort
{
    public partial class frmElimination : Form
    {
        PicPic pic1;
        PicPic pic2;
        PicPic pic3;
        PicPic pic4;
        frmView frmVw;
        int skip_counter = 999;
        int new_skip = 1;
        public frmElimination()
        {
            InitializeComponent();
        }

        private void PickFour()
        {
            Random rng = new Random();
            int max = GlobalVars.myPics.Count;
            int n1 = 0;
            int n2 = 0;
            int n3 = 0;
            int n4 = 0;

            while (!CheckNums(n1,n2,n3,n4))
            {
                n1 = rng.Next(0, max);
                n2 = rng.Next(0, max);
                n3 = rng.Next(0, max);
                n4 = rng.Next(0, max);

            }

            pic1 = null;
            pic2 = null;
            pic3 = null;
            pic4 = null;
            pic1 = GlobalVars.myPics[n1];
            pic2 = GlobalVars.myPics[n2];
            pic3 = GlobalVars.myPics[n3];
            pic4 = GlobalVars.myPics[n4];

            MapTrackerToPics();
        }
        private bool CheckNums(int i1, int i2, int i3, int i4)
        {
            bool bPass = true;
            if(i1==i2 || i1==i3 || i1==i4) bPass = false;

            if (i2 == i1 || i2 == i3 || i2 == i4) bPass = false;

            if (i3 == i1 || i3 == i2 || i3 == i4) bPass = false;

            if (i4 == i1 || i4 == i2 || i4 == i3) bPass = false;

            return bPass;
        }

        private void DisplayPics()
        {

            ColorValue();

            pictureBox1.Image = GlobalVars.myFunctions.ConvertFileAddressToImage(pic1.address);
            pictureBox2.Image = GlobalVars.myFunctions.ConvertFileAddressToImage(pic2.address);
            pictureBox3.Image = GlobalVars.myFunctions.ConvertFileAddressToImage(pic3.address);
            pictureBox4.Image = GlobalVars.myFunctions.ConvertFileAddressToImage(pic4.address);


        }

        private void MapTrackerToPics()
        {
            bool isNew = true;
            Tracker tmp;
            pic1.LoadHashValue();
            pic2.LoadHashValue();
            pic3.LoadHashValue();
            pic4.LoadHashValue();
            //Search for Pic1s Tracker Match or create if unfound
            if (pic1.tracker_index < 0)
            {
                for (int i = 0; i < GlobalVars.myTrackers.Count; i++)
                {
                    if (pic1.id.ToString() == GlobalVars.myTrackers[i].hash.ToString())
                    {
                        isNew = false;
                        pic1.tracker_index = i;
                        break;
                    }
                }

                if (isNew)
                {
                    tmp = new Tracker();
                    tmp.hash = pic1.id;
                    GlobalVars.myTrackers.Add(tmp);
                    pic1.tracker_index = GlobalVars.myTrackers.Count - 1;
                    //MessageBox.Show("New Tracker Added");
                }

            }

            isNew = true;
            tmp = null;
            //Search for Pic2s Tracker Match or create if unfound
            if (pic2.tracker_index < 0)
            {
                for (int i = 0; i < GlobalVars.myTrackers.Count; i++)
                {
                    if (pic2.id.ToString() == GlobalVars.myTrackers[i].hash.ToString())
                    {
                        isNew = false;
                        pic2.tracker_index = i;
                        break;
                    }
                }
                if (isNew)
                {
                    tmp = new Tracker();
                    tmp.hash = pic2.id;
                    GlobalVars.myTrackers.Add(tmp);
                    pic2.tracker_index = GlobalVars.myTrackers.Count - 1;
                    //MessageBox.Show("New Tracker Added");
                }

            }

            isNew = true;
            tmp = null;
            //Search for Pic2s Tracker Match or create if unfound
            if (pic3.tracker_index < 0)
            {
                for (int i = 0; i < GlobalVars.myTrackers.Count; i++)
                {
                    if (pic3.id.ToString() == GlobalVars.myTrackers[i].hash.ToString())
                    {
                        isNew = false;
                        pic3.tracker_index = i;
                        break;
                    }
                }
                if (isNew)
                {
                    tmp = new Tracker();
                    tmp.hash = pic3.id;
                    GlobalVars.myTrackers.Add(tmp);
                    pic3.tracker_index = GlobalVars.myTrackers.Count - 1;
                    //MessageBox.Show("New Tracker Added");
                }

            }

            isNew = true;
            tmp = null;
            //Search for Pic2s Tracker Match or create if unfound
            if (pic4.tracker_index < 0)
            {
                for (int i = 0; i < GlobalVars.myTrackers.Count; i++)
                {
                    if (pic4.id.ToString() == GlobalVars.myTrackers[i].hash.ToString())
                    {
                        isNew = false;
                        pic4.tracker_index = i;
                        break;
                    }
                }
                if (isNew)
                {
                    tmp = new Tracker();
                    tmp.hash = pic4.id;
                    GlobalVars.myTrackers.Add(tmp);
                    pic4.tracker_index = GlobalVars.myTrackers.Count - 1;
                    //MessageBox.Show("New Tracker Added");
                }

            }

        }



        private void frmElimination_Load(object sender, EventArgs e)
        {

            if (GlobalVars.myPics.Count < 50)
            {
                MessageBox.Show("You must have at least 50 images to use this feature.");
                this.Close();
            }

            PickFour();
            DisplayPics();
        }

        private void frmElimination_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                if (skip_counter < 1) return;
                PickFour();
                DisplayPics();
                skip_counter--;
                lblSkip.Text = skip_counter.ToString();
            }
        }


        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frmVw = new frmView();
                frmVw.Tag = pic1.address;
                frmVw.ShowDialog();
                return;
            }
            if (pictureBox1.BackColor != Color.Red)
            {
                ColorValue();
                pictureBox1.BackColor = Color.Red;
                return;
            }

            if (pictureBox1.BackColor == Color.Red)
            {
                if (GlobalVars.myTrackers[pic1.tracker_index].delete)
                {
                    MessageBox.Show("Already marked delete.");
                }
                GlobalVars.myTrackers[pic1.tracker_index].delete = true;
                if (new_skip == 3)
                {
                    skip_counter++;
                    new_skip = 1;
                }
                else
                {
                    new_skip++;
                }
                lblSkip.Text = skip_counter.ToString();
                PickFour();
                DisplayPics();
                return;
            }
        }

        private void pictureBox2_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frmVw = new frmView();
                frmVw.Tag = pic2.address;
                frmVw.ShowDialog();
                return;
            }
            if (pictureBox2.BackColor != Color.Red)
            {
                ColorValue();
                pictureBox2.BackColor = Color.Red;
                return;
            }

            if (pictureBox2.BackColor == Color.Red)
            {
                if (GlobalVars.myTrackers[pic2.tracker_index].delete)
                {
                    MessageBox.Show("Already marked delete.");
                }
                GlobalVars.myTrackers[pic2.tracker_index].delete = true;
                if (new_skip == 3)
                {
                    skip_counter++;
                    new_skip = 1;
                }
                else
                {
                    new_skip++;
                }
                lblSkip.Text = skip_counter.ToString();
                PickFour();
                DisplayPics();
                return;
            }
        }

        private void pictureBox3_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frmVw = new frmView();
                frmVw.Tag = pic3.address;
                frmVw.ShowDialog();
                return;
            }
            if (pictureBox3.BackColor != Color.Red)
            {
                ColorValue();
                pictureBox3.BackColor = Color.Red;
                return;
            }

            if (pictureBox3.BackColor == Color.Red)
            {
                if (GlobalVars.myTrackers[pic3.tracker_index].delete)
                {
                    MessageBox.Show("Already marked delete.");
                }
                GlobalVars.myTrackers[pic3.tracker_index].delete = true;
                if (new_skip == 3)
                {
                    skip_counter++;
                    new_skip = 1;
                }
                else
                {
                    new_skip++;
                }
                lblSkip.Text = skip_counter.ToString();
                PickFour();
                DisplayPics();
                return;
            }
        }

        private void pictureBox4_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                frmVw = new frmView();
                frmVw.Tag = pic4.address;
                frmVw.ShowDialog();
                return;
            }
            if (pictureBox4.BackColor != Color.Red)
            {
                ColorValue();
                pictureBox4.BackColor = Color.Red;
                return;
            }

            if (pictureBox4.BackColor == Color.Red)
            {
                if (GlobalVars.myTrackers[pic4.tracker_index].delete)
                {
                    MessageBox.Show("Already marked delete.");
                }
                GlobalVars.myTrackers[pic4.tracker_index].delete = true;
                if (new_skip == 3)
                {
                    skip_counter++;
                    new_skip = 1;
                }
                else
                {
                    new_skip++;
                }
                lblSkip.Text = skip_counter.ToString();
                PickFour();
                DisplayPics();
                return;
            }
        }

        private void ColorValue()
        {
            decimal dVotePer=0;
            int iVotePer = 0;
            //Picture Box 1

            if (GlobalVars.myTrackers[pic1.tracker_index].votes_total <10)
            {
                pictureBox1.BackColor = Color.White;
            }
            else
            {
                dVotePer=(decimal)GlobalVars.myTrackers[pic1.tracker_index].votes / (decimal)GlobalVars.myTrackers[pic1.tracker_index].votes_total;
                iVotePer = Convert.ToInt16(dVotePer * 100);
  
                if (iVotePer == 100)
                {
                    pictureBox1.BackColor = Color.DodgerBlue;
                }
                else
                {
                    if (iVotePer >= 75)
                    {
                        pictureBox1.BackColor = Color.Green;
                    }
                    else
                    {
                        if (iVotePer >= 50)
                        {
                            pictureBox1.BackColor = Color.Yellow;
                        }
                        else
                        {
                            pictureBox1.BackColor = Color.Orange;
                        }
                    }
                }
            }

            //Picture Box 2

            if (GlobalVars.myTrackers[pic2.tracker_index].votes_total < 10)
            {
                pictureBox2.BackColor = Color.White;
            }
            else
            {
                dVotePer = (decimal)GlobalVars.myTrackers[pic2.tracker_index].votes / (decimal)GlobalVars.myTrackers[pic2.tracker_index].votes_total;
                iVotePer = Convert.ToInt16(dVotePer * 100);

                if (iVotePer == 100)
                {
                    pictureBox2.BackColor = Color.DodgerBlue;
                }
                else
                {
                    if (iVotePer >= 75)
                    {
                        pictureBox2.BackColor = Color.Green;
                    }
                    else
                    {
                        if (iVotePer >= 50)
                        {
                            pictureBox2.BackColor = Color.Yellow;
                        }
                        else
                        {
                            pictureBox2.BackColor = Color.Orange;
                        }
                    }
                }
            }

            //Picture Box 3

            if (GlobalVars.myTrackers[pic3.tracker_index].votes_total < 10)
            {
                pictureBox3.BackColor = Color.White;
            }
            else
            {
                dVotePer = (decimal)GlobalVars.myTrackers[pic3.tracker_index].votes / (decimal)GlobalVars.myTrackers[pic3.tracker_index].votes_total;
                iVotePer = Convert.ToInt16(dVotePer * 100);

                if (iVotePer == 100)
                {
                    pictureBox3.BackColor = Color.DodgerBlue;
                }
                else
                {
                    if (iVotePer >= 75)
                    {
                        pictureBox3.BackColor = Color.Green;
                    }
                    else
                    {
                        if (iVotePer >= 50)
                        {
                            pictureBox3.BackColor = Color.Yellow;
                        }
                        else
                        {
                            pictureBox3.BackColor = Color.Orange;
                        }
                    }
                }
            }

            //Picture Box 4

            if (GlobalVars.myTrackers[pic4.tracker_index].votes_total < 10)
            {
                pictureBox4.BackColor = Color.White;
            }
            else
            {
                dVotePer = (decimal)GlobalVars.myTrackers[pic4.tracker_index].votes / (decimal)GlobalVars.myTrackers[pic4.tracker_index].votes_total;
                iVotePer = Convert.ToInt16(dVotePer * 100);

                if (iVotePer == 100)
                {
                    pictureBox4.BackColor = Color.DodgerBlue;
                }
                else
                {
                    if (iVotePer >= 75)
                    {
                        pictureBox4.BackColor = Color.Green;
                    }
                    else
                    {
                        if (iVotePer >= 50)
                        {
                            pictureBox4.BackColor = Color.Yellow;
                        }
                        else
                        {
                            pictureBox4.BackColor = Color.Orange;
                        }
                    }
                }
            }


        }

        private void frmElimination_FormClosing(object sender, FormClosingEventArgs e)
        {
  
        }
    }
}
