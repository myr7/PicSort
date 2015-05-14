using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using Microsoft.VisualBasic.FileIO;


namespace PicSort
{

    delegate bool AsyncDelegateLoadHash(int delay);
    delegate void SetDupeMenuCallBack(int value);

    public partial class frmMain : Form
    {
        //Class Scope Variables
        
        frmTasks frmLog;
        frmView frmVw;
        frmFolders frmF;
        frmDupes frmDupe;
        frmVote frmV;
        frmElimination frmE;

        public const int DupeUpdateDisable = 1;
        public const int DupeUpdateInProgress = 2;
        public const int DupeUpdateReady = 3;

        


        public frmMain()
        {
            InitializeComponent();
            frmLog = new frmTasks();
            frmVw = new frmView();
       
        
        }

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
            Application.Idle += new EventHandler(OnLoaded);
        }

        private void OnLoaded(object sender, EventArgs args)
        {
            Application.Idle -= new EventHandler(OnLoaded);
            toolStripStatusLabel1.Text = "";
            //Do One Time Startup Stuff with form open and ready
            frmF = new frmFolders();
            frmF.ShowDialog();
            frmF.Dispose();

            LoadInfo2();
            LoadTrackers();

            if (GlobalVars.myPics.Count < 1)
            {
                MessageBox.Show("Please place me in a folder with images.  Thanks!");
                frmLog.Close();
                this.Close();
            }
            Thread.Sleep(1000);
            DupeMenuUpdate(DupeUpdateDisable);
            //LoadResults(); //Load Image List
            
        }



        private void LoadInfo2()
        {
            string[] extensions = new[] { ".bmp", ".jpg", ".jpeg", ".png" };        //Gif's created GDI crash errors
            DirectoryInfo di;
            FileInfo[] files;
            PicPic tmpPic;
            int iKey = -1;
            GlobalVars.myPics.Clear();

            DupeMenuUpdate(DupeUpdateDisable);

            for(int i=0;i<GlobalVars.myFolders.Count;i++)
            {
                di = new DirectoryInfo(GlobalVars.myFolders[i]);
                files = di.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                for (int ii = 0; ii < files.Count(); ii++)
                {
                    iKey++;
                    tmpPic = new PicPic(files[ii].FullName, iKey);
                    //if (tmpPic.size < 4000000)
                    //{
                    //Image must be under 4mb to be included
                    //GlobalVars.myPics.Add(i, tmpPic);
                    GlobalVars.myPics.Add(tmpPic);
                    //}
                }
            }
            GlobalVars.dirty = false;
            toolStripStatusLabel1.Text = ("Found: " + GlobalVars.myPics.Count.ToString() + " files");

            //Adding Async Processing of Hash Values
            AsyncDelegateLoadHash AsyncHash = new AsyncDelegateLoadHash(UpdateHashes);
            IAsyncResult AsyncHashResult = AsyncHash.BeginInvoke(10,  new AsyncCallback(UpdateHashesCallBackHandler), AsyncHash);
            

            
        }
        

        private void UpdateHashesCallBackHandler(IAsyncResult result)
        {
            bool done;
            AsyncDelegateLoadHash AsyncHash = (AsyncDelegateLoadHash)result.AsyncState;
            done = AsyncHash.EndInvoke(result);
            if (done)
            {
                //MessageBox.Show("done");
                DupeMenuUpdate(DupeUpdateReady);
                //this.DupeMenuUpdate();
                
            }
        }


        private bool UpdateHashes(int delay)

        {
            //Thread.Sleep(20000);
            DupeMenuUpdate(DupeUpdateInProgress);
            if (GlobalVars.myPics.Count <= 1)
            {
                DupeMenuUpdate(DupeUpdateDisable);
                return false;
            }
            //Load Hashes
            for (int i = 0; i < GlobalVars.myPics.Count; i++)
            {
                GlobalVars.myPics[i].LoadHashValue();
                //tmp = GlobalVars.myPics[i];
                //tmp.LoadHashValue();
            }
            return true;
        }


        private void DupeMenuUpdate(int value)
        {
            if (this.menuStrip1.InvokeRequired)
            {
                SetDupeMenuCallBack d = new SetDupeMenuCallBack(DupeMenuUpdate);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                switch (value)
                {
                    case DupeUpdateDisable:
                        identifyDupesToolStripMenuItem.Text = "Identify Dupes";
                        identifyDupesToolStripMenuItem.Enabled = false;
                        break;
                    case DupeUpdateInProgress:
                        identifyDupesToolStripMenuItem.Text = "Identify Dupes (Processing)";
                        identifyDupesToolStripMenuItem.Enabled = false;
                        break;
                    case DupeUpdateReady:
                        identifyDupesToolStripMenuItem.Text = "Identify Dupes";
                        identifyDupesToolStripMenuItem.Enabled = true;
                        break;
                }
            }

        }


        private void SaveTrackers()
        {
            string path = GlobalVars.gAppPath.ToString() + "\\picsort.vts";
            FileInfo file = new FileInfo(path);
            //if (File.Exists(path))
            if(true)
            {
                StreamWriter sw = file.CreateText();
                sw.WriteLine("hash|dupe(true or false)|votes|votes_total|tags");
                for (int i = 0; i < GlobalVars.myTrackers.Count; i++)
                {
                    
                    if (GlobalVars.myTrackers[i].used)
                    {
                        sw.WriteLine
                                (
                                    GlobalVars.myTrackers[i].hash + "|" +
                                    GlobalVars.myTrackers[i].dupe_text + "|" +
                                    GlobalVars.myTrackers[i].votes + "|" +
                                    GlobalVars.myTrackers[i].votes_total + "|" +
                                    "" + "|"
                                );
                    }
                }
                sw.Close();

            }
        }

        private void LoadTrackers()
        {
            string path = GlobalVars.gAppPath.ToString() + "\\picsort.vts";
            List<string> rows = new List<string>();
            FileInfo file = new FileInfo(path);
            
            if (!File.Exists(path)) return;
            
            StreamReader sr = file.OpenText();
            string read = null;
            while ((read = sr.ReadLine()) != null)
            {
                rows.Add(read);
            }

            Tracker tmp;
            string[] arr;
            int num;
            for (int i = 0; i < rows.Count; i++)
            {
                tmp = null;
                tmp = new Tracker();
                arr=rows[i].Split('|');
                tmp.hash = arr[0];
                if (arr[1] == "true") tmp.dupe = true;
                if (arr[1] == "false") tmp.dupe = false;
                if (Int32.TryParse(arr[2], out num))
                {
                    tmp.votes = num;
                }
                else
                {
                    tmp.votes = 0;
                }
                if (Int32.TryParse(arr[3], out num))
                {
                    tmp.votes_total = num;
                }
                else
                {
                    tmp.votes_total = 0;
                }
                tmp.tags = arr[4];
                if (tmp.hash != "hash")
                {
                    GlobalVars.myTrackers.Add(tmp);
                }
            }
            sr.Close();
        }

        
        private void Clickity(object sender, MouseEventArgs e)
        {

               
        }





        private void folderSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmF = new frmFolders();
            frmF.ShowDialog();
            frmF.Dispose();

            if (GlobalVars.dirty)
            {
                LoadInfo2();
            }
        }

        private void identifyDupesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDupe = new frmDupes();      
            frmDupe.ShowDialog();
            frmDupe.Dispose();

            if (GlobalVars.dirty)
            {
                LoadInfo2();
            }
        }

        private void voteToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            frmV = new frmVote();
            frmV.ShowDialog();
            frmV.Dispose();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save Votes and Flags by Hash ID
            frmVw.Dispose();
            SaveTrackers();
            MoveEliminated();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void eliminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmE = new frmElimination();
            frmE.ShowDialog();
            frmE.Dispose();
        }

        private void MoveEliminated()
        {
            int ti;
            string addr;
            for (int i = 0; i < GlobalVars.myPics.Count - 1; i++)
            {
                if (GlobalVars.myPics[i].tracker_index < 0) continue;
                ti = GlobalVars.myPics[i].tracker_index;
                addr = GlobalVars.myPics[i].address;
                if (GlobalVars.myTrackers[ti].delete)
                {
                    //File.Delete(addr);
                    //File.
                    FileSystem.DeleteFile(addr,UIOption.OnlyErrorDialogs,RecycleOption.SendToRecycleBin);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
