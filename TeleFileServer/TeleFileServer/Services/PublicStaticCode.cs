using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TeleFileServer.ViewModels;

namespace TeleFileServer.Services
{
    public class PublicStaticCode
    {
        public static int Jurisdiction { get; set; }

        public static int Iden { get; set; }

        public static List<int> pids { get; set; }=new List<int>();

        public static OrderManagerViewModel father { get; set; }

        //将图片保存为byte数组
        public static byte[] GetPictureData(string imagepath)
        {
            FileStream file = new FileStream(imagepath, FileMode.Open);
            byte[] Photobytes = new byte[file.Length];
            file.Read(Photobytes, 0, Photobytes.Length);
            file.Close();
            return Photobytes;
        }

        //将byte数组转换为图片
        public static BitmapImage ByteArrayToBitmapImage(byte[] byteArray)
        {
            BitmapImage bmp = null;
            try
            {
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = new MemoryStream(byteArray);
                bmp.EndInit();
            }
            catch
            {
                bmp = null;
            }
            return bmp;
        }

        internal static string GetKind(int numOfKind)
        {
            string kind;
            switch (numOfKind)
            {
                case 0:
                    {
                        kind = "视频";
                        return kind;
                    }
                case 1:
                    {
                        kind = "音乐";
                        return kind;
                    }
                case 2:
                    {
                        kind = "图片";
                        return kind;
                    }
                case 3:
                    {
                        kind = "其他";
                        return kind;
                    }
                default:
                    {
                        kind = "NULL";
                        return kind;
                    }
            }
        }
    }
}
