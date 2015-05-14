using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace PicSort
{
    public partial class frmDupes : Form
    {
        List<PicPic> myDupes = new List<PicPic>();
        public frmDupes()
        {
            InitializeComponent();
        }

        private void frmDupes_Load(object sender, EventArgs e)
        {
            if (GlobalVars.myPics.Count < 2)
            {
                MessageBox.Show("Not enough images to check for dupes");
                return;
            }
            CreateDupeList();

        }

        private void CreateDupeList()
        {
            lvlMsg.Text = "Refreshing list...";
            lvlMsg.Refresh();

            myDupes.Clear();
            PicPic p;
            for (int i = 0; i < GlobalVars.myPics.Count; i++)
            {
                p = GlobalVars.myPics[i];
                p.dupe = false;     //Reset the PARENT object value of dupe to false
                if (!p.deleted)
                {
                    myDupes.Add(p);
                }
            }

            myDupes = myDupes.OrderBy(x => x.id).ToList();


            /* Mark Dupes */
            for(int i = 0;  i < myDupes.Count; i++)
            {
                //if (myDupes[i].name.Contains("0543224nSz"))
                //{
                //    MessageBox.Show("");
                //}
                if (i == 0)
                {
                    //First Position
                    if (myDupes[i].id == myDupes[i + 1].id)
                    {
                        myDupes[i].dupe = true;
                    }
                }
                if (i == (myDupes.Count-1))
                {
                    //Last Position
                    if (myDupes[i].id == myDupes[i-1].id)
                    {
                        myDupes[i].dupe = true;
                    }

                }
                if (!(i == 0) && !(i == (myDupes.Count-1)))
                {
                    //Any other position
                    if (myDupes[i].id == myDupes[i + 1].id)
                    {
                        myDupes[i].dupe = true;
                    }
                    if (myDupes[i].id == myDupes[i - 1].id)
                    {
                        myDupes[i].dupe = true;
                    }
                }
            }

            //Remove Non Dupes
            for(int i=0; i<myDupes.Count;i++)
            {

                if(!myDupes[i].dupe) 
                { 
                    myDupes.RemoveAt(i);
                    i--;
                }
            }
      
            lstDupes.Items.Clear();

            for (int i = 0; i < myDupes.Count; i++)
            {
                lstDupes.Items.Add("{" + i.ToString()+ "}||" + myDupes[i].id.ToString().Substring(1, 10) + "|| " + myDupes[i].address);
            }


            lvlMsg.Text = "[F5] To refresh list.";

        }


        private void lstDupes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstDupes.SelectedIndex < 0) return;
            PicPic p = myDupes[ReturnListIndexVal(lstDupes.SelectedItem.ToString())];

            if (!p.Exists()) { return; }
            pictureBox1.Image = GlobalVars.myFunctions.ConvertFileAddressToImage(p.address);

        }

        private void lstDupes_DoubleClick(object sender, EventArgs e)
        {
 
            DeleteItem();
        }

        private void frmDupes_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void lstDupes_KeyUp(object sender, KeyEventArgs e)
        {
   
        }
        private void DeleteItem()
        {
            if (lstDupes.SelectedIndex < 0) return;
            PicPic p = myDupes[ReturnListIndexVal(lstDupes.SelectedItem.ToString())];

            string dupe;

            DialogResult dialogResult = MessageBox.Show("Delete this file? \r" + p.name, "Confirm Deletion", MessageBoxButtons.YesNo);
            
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                FileSystem.DeleteFile(p.address, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                for (int i = 0; i < lstDupes.Items.Count; i++)
                {
                    dupe = lstDupes.Items[i].ToString();
                    //if (dupe.Contains(ident))
                    if (dupe.Contains(p.id.Substring(1,10)))
                    {
                        lstDupes.Items.RemoveAt(i);
                        i--;
                    }
                }
                GlobalVars.dirty = true;
                p.deleted = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }




        }

        private void lstDupes_KeyDown(object sender, KeyEventArgs e)
        {
            int iSelectedIndex = lstDupes.SelectedIndex;
            if (e.KeyCode == Keys.Enter)
            {
                DeleteItem();
            }
            if (lstDupes.Items.Count > 2)
            {

                lstDupes.SelectedIndex = iSelectedIndex;
                lstDupes.Focus();

            }
        }

        private void frmDupes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //MessageBox.Show("f5");
                CreateDupeList();
            }
        }

        private int ReturnListIndexVal(string txt)
        {
            int val;
            string val_txt;
            val_txt = txt.Substring(1, txt.IndexOf('}') - 1);
            val = Convert.ToInt32(val_txt);
            return val;
        }
    }
}
