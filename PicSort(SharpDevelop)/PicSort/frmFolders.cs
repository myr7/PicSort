using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PicSort
{
    public partial class frmFolders : Form
    {
        public frmFolders()
        {
            InitializeComponent();
        }

        private void frmFolders_Load(object sender, EventArgs e)
        {
            //Identify All Folders under Application Directory Hierarchy
            string dirPath = GlobalVars.gAppPath.ToString();
            
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(dirPath,"*",SearchOption.AllDirectories));

            dirs.Add(GlobalVars.gAppPath.ToString());
            dirs.Sort();

            foreach (var dir in dirs)
            {
                lstFolders.Items.Add(dir);
            }
            
            //Load Current Folder Roster
            for(int i=0;i<GlobalVars.myFolders.Count;i++)
            {
                lstIncluded.Items.Add(GlobalVars.myFolders[i]);
            }
            AddAll();

        }

        private void lstFolders_DoubleClick(object sender, EventArgs e)
        {
            string folder="";
            if (lstFolders.SelectedIndex >= 0)
            {
                folder=lstFolders.Items[lstFolders.SelectedIndex].ToString();
                AddFolderToIncluded(folder);
            }
            GlobalVars.dirty = true;

        }

        private void AddFolderToIncluded(string str)
        {
            bool isNew = true;
            for (int i = 0; i < lstIncluded.Items.Count; i++)
            {
                if (lstIncluded.Items[i].ToString() == str.ToString())
                    isNew = false;
            }
            if (isNew)
                lstIncluded.Items.Add(str);

        }
        private void frmFolders_FormClosing(object sender, FormClosingEventArgs e)
        {

            //Clear Folders
            GlobalVars.myFolders.Clear();
            //Save New Folder Roster
            for (int i = 0; i<lstIncluded.Items.Count; i++)
            {
                GlobalVars.myFolders.Add(lstIncluded.Items[i].ToString());
            }
            GlobalVars.myFolders.Sort();
        }

        private void lstIncluded_DoubleClick(object sender, EventArgs e)
        {
            if (lstIncluded.SelectedIndex >= 0)
            {
                lstIncluded.Items.RemoveAt(lstIncluded.SelectedIndex);
            }
            GlobalVars.dirty = true;
 
        }

        private void cmdAll_Click(object sender, EventArgs e)
        {
            AddAll();
        }

        private void frmFolders_Activated(object sender, EventArgs e)
        {
            
        }

        private void AddAll()
        {
            string folder = "";
            for (int i = 0; i < lstFolders.Items.Count; i++)
            {
                folder = lstFolders.Items[i].ToString();
                AddFolderToIncluded(folder);
            }
            GlobalVars.dirty = true;

        }
      
    }
}
