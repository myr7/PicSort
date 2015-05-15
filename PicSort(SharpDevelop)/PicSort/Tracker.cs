using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicSort
{
    public class Tracker
    {
        private string m_hash;
        private bool m_isdupe;
        private int m_votes;
        private int m_votes_total;
        private bool m_used;
        private string m_tags;
        private bool m_delete;

        public Tracker()
        {
            m_hash = "";
            m_isdupe = false;
            m_votes = 0;
            m_votes_total = 0;
            m_used = false;
            m_tags = "";
            m_delete = false;

        }

        public string hash
        {
            get { return m_hash; }
            set { m_hash = value; }
        }
        public bool delete
        {
            get { return m_delete; }
            set { m_delete = value; m_used = true; }
        }

        public bool dupe
        {
            get { return m_isdupe; }
            set { m_isdupe = value; m_used = true; }
        }

        public string dupe_text
        {
            get
            {
                if (m_isdupe) return "true";
                if (!m_isdupe) return "false";
                return "";
            }
        }

        public bool used
        {
            get { return m_used; }
            set { m_used = value;}
        }

        public int votes
        {
            get { return m_votes; }
            set { m_votes = value; }
        }

        public int votes_total
        {
            get { return m_votes_total; }
            set { m_votes_total = value; }
        }
        public string tags
        {
            get { return m_tags; }
            set { m_tags = value; }
        }
        public void Vote(int var)
        {
            m_used = true;
            m_votes_total++;
            m_votes += var;
        }

        

    }
}
