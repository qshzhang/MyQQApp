using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class CommonTools
    {
        public static Image GetImageByType(int type)
        {
            switch(type)
            {
                case 0:
                    return Properties.Resources.QMe;
                case 1:
                    return Properties.Resources.OnLine;
                case 2:
                    return Properties.Resources.Away;
                case 3:
                    return Properties.Resources.Busy;
                case 4:
                    return Properties.Resources.Dont_Disturb;
                case 5:
                    return Properties.Resources.OffLine; 
            }
            return Properties.Resources._null;
        }

        public static Image GetImageByPicName(string name)
        {
            try
            {
                return Image.FromFile("head/" + name);
            }
            catch(Exception ex)
            {

            }
            return Image.FromFile("head/default.jpg");
        }

        public static string SaveImageToFile(Image image)
        {
            string path = @"head/";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            UInt32 fileNum = (UInt32)dir.GetFiles().Length;

            string filename = fileNum.ToString().PadLeft(10, '0') + ".png";

            image.Save("head/" + filename);

            return filename;
        }

    }
}
