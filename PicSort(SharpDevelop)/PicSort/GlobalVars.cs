using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PicSort
{
    public static class GlobalVars
    {

        public static List<PicPic> myPics = new List<PicPic>();
        public static bool dirty = false;
        public static List<string> myFolders = new List<string>();
        public static List<Tracker> myTrackers = new List<Tracker>();
        public static string gAppPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        public static Funcs myFunctions = new Funcs();


           
    }
            




}
