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
    public partial class frmVote : Form
    {
        PicPic pic1;
        PicPic pic2;
        public frmVote()
        {
            InitializeComponent();
        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;

            MapTrackerToPics();
            GlobalVars.myTrackers[pic2.tracker_index].Vote(0);
            GlobalVars.myTrackers[pic1.tracker_index].Vote(1);

            PickTwo();
            DisplayPics();

        }

        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label1.Visible = false;

            
            GlobalVars.myTrackers[pic2.tracker_index].Vote(1);
            GlobalVars.myTrackers[pic1.tracker_index].Vote(0);
            
            PickTwo();
            DisplayPics();
        }

        private void MapTrackerToPics()
        {
            bool isNew = true;
            Tracker tmp;
            pic1.LoadHashValue();
            pic2.LoadHashValue();
            //Search for Pic1s Tracker Match or create if unfound
            if (pic1.tracker_index < 0)
            {
                for (int i = 0; i<GlobalVars.myTrackers.Count; i++)
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
        }

        private void frmVote_Load(object sender, EventArgs e)
        {
            if (GlobalVars.myPics.Count < 2)
            {
                MessageBox.Show("You must have more than one image in the selected folders.");
                this.Close();
            }

            PickTwo();
            DisplayPics();
        }

        private void PickTwo()
        {
            Random rng = new Random();
            int max = GlobalVars.myPics.Count;
            int n1=0;
            int n2=0;

            while (n1 == n2)
            {
                n1 = rng.Next(0, max);
                
                n2 = rng.Next(0, max);
            }

            pic1 = null;
            pic2 = null;
            pic1 = GlobalVars.myPics[n1];
            pic2 = GlobalVars.myPics[n2];

            MapTrackerToPics();
        }

        private void DisplayPics()
        {
            pictureBoxLeft.Load(pic1.address);
            pictureBoxRight.Load(pic2.address);
            int p1votes;
            int p1total;
            int p2votes;
            int p2total;

            p1votes = GlobalVars.myTrackers[pic1.tracker_index].votes;
            p1total = GlobalVars.myTrackers[pic1.tracker_index].votes_total;
            p2votes = GlobalVars.myTrackers[pic2.tracker_index].votes;
            p2total = GlobalVars.myTrackers[pic2.tracker_index].votes_total;
            
            lblRank.Text = p1votes + "/" + p1total + " <----> " + p2votes + "/" + p2total;


        }

        private void cmdSkip_Click(object sender, EventArgs e)
        {
            PickTwo();
            DisplayPics();
        }

        private void cmdDupe_Click(object sender, EventArgs e)
        {
            GlobalVars.myTrackers[pic1.tracker_index].dupe = true;
            GlobalVars.myTrackers[pic2.tracker_index].dupe = true;

            PickTwo();
            DisplayPics();

        }

        private void frmVote_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                pictureBoxLeft_Click(null,null);
            }
            if (e.KeyCode == Keys.Right)
            {
                pictureBoxRight_Click(null, null);
            }
        }

        private void frmVote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Bitmap bp = new Bitmap(1, 1);
            bp.SetPixel(0, 0, Color.White);

            pictureBoxLeft.InitialImage = bp;
            pictureBoxLeft.Image = bp;
            pictureBoxLeft.Invalidate();

            pictureBoxRight.InitialImage = bp;
            pictureBoxRight.Image = bp;
            pictureBoxRight.Invalidate();


        }
    }
}
