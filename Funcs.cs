using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace PicSort
{
    public class Funcs
    {
        public Image ConvertFileAddressToImage(string addr)
        {
            /*
             *  This function was created to prevent system file locking on images.   
             *   Instead we are copying the raw file data into memory and then writing it to an image object.
             */


            Image result;

            long size = (new FileInfo(addr)).Length;
            FileStream fs = new FileStream(addr, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[size];
            try
            {
                fs.Read(data, 0, (int)size);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
            }

            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, (int)size);
            result = new Bitmap(ms);
            ms.Close();


            return result;
        }

    }
}
