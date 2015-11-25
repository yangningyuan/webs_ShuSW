using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Common
{
    public class ImageUtils
    {
        /// <summary>
        /// 将图片转换成二进制数据流
        /// </summary>
        /// <param name="picUrl"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(string picUrl)
        {
            byte[] photo;
            Image img = new Bitmap(picUrl);
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Bmp);

            photo = stream.ToArray();
            stream.Close();

            return photo;
        }

               //
        /// <summary>
        /// 根据图片路径返回图片的字节流byte[]
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <returns>返回的字节流</returns>
        public static byte[] getImageByte(string imagePath)
        {
            FileStream files = new FileStream(imagePath, FileMode.Open);
            byte[] imgByte = new byte[files.Length];
            files.Read(imgByte, 0, imgByte.Length);
            files.Close();
            return imgByte;
        } 
    }
}
