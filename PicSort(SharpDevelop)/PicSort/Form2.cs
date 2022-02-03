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
    public partial class frmTasks : Form
    {
        public frmTasks()
        {
            InitializeComponent();
        }
        public void WriteLog(string msg)
        {
            //txtLog.Text += msg;
            txtLog.AppendText(msg);
        }
        public void NewLine()
        {
            txtLog.AppendText("\r\n");
        }
    }
}
