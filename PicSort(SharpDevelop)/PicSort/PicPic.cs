using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;


namespace PicSort
{
    public class PicPic
    {
        private string m_id;          //Hash
        private string m_name;        //Filename
        private string m_address;     //Local Computer Address

        private string m_date;
        private long m_size;

        private bool m_include;
        private int m_sortid;
        private int m_key;            //Session Key

        private bool m_deleted;
        private bool m_dupe;

        private int m_tracker_index;

        //Constructor
        public PicPic()
        {
            m_include = true;
            m_deleted = false;
            m_dupe = false;

        }
        public PicPic(string addr, int key)
        {

            m_include = true;
            m_deleted = false;
            m_dupe = false;


            //Caller provided file address
            //Process and load all variables
            FileInfo fi = new FileInfo(addr);

            if (fi.Exists)
            {
                this.m_size = fi.Length;
                this.m_address = fi.FullName.ToString();
                this.m_date = fi.CreationTime.ToShortDateString();
                this.m_name = fi.Name;

                this.m_key = key;

                this.m_tracker_index = -1;


            }
            else
            {
            }

        }

        public bool Exists()
        {
            FileInfo fi = new FileInfo(m_address);
            return fi.Exists;
        }

        public void LoadHashValue()
        {

            if (this.m_id==null)
            {

                //Get hash for file
                //HashAlgorithm hash = HashAlgorithm.Create("SHA1");
                HashAlgorithm hash = HashAlgorithm.Create("MD5");
                byte[] fileHash;
                FileStream fs = new FileStream(this.m_address, FileMode.Open,FileAccess.Read,FileShare.Read);
                fileHash = hash.ComputeHash(fs);
                this.m_id = BitConverter.ToString(fileHash);
                fs.Close();

            }

        }
        public string id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        public string name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        public string address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        public string date
        {
            get { return m_date; }
            set { m_date = value; }
        }
        public long size
        {
            get { return m_size; }
            set { m_size = value; }
        }

        public bool deleted
        {
            get { return m_deleted; }
            set { m_deleted = value; }
        }

        public bool dupe
        {
            get { return m_dupe; }
            set { m_dupe = value; }
        }


        public bool results_include
        {
            get { return m_include; }
            set { m_include = value; }
        }
        public int sort_id
        {
            get { return m_sortid; }
            set { m_sortid = value; }
        }
        public int tracker_index
        {
            get { return m_tracker_index; }
            set { m_tracker_index = value; }
        }

        public int key
        {
            get { return m_key; }
        }



    }

}
