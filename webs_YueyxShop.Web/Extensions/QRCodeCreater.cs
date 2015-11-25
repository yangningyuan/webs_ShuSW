using System.Drawing;
using PK.BLL;

namespace webs_YueyxShop.Web
{
    /// <summary>
    /// 生成二维码
    /// </summary>
    public class QRCodeCreater
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="linkUrl">链接地址</param>
        /// <param name="color">颜色</param>
        /// <param name="size">大小</param>
        /// <param name="imgUrl">图片路径</param>
        /// <param name="savePath">二维码保存路径</param>
        /// <returns></returns>
        public static bool CreateQRCode(string linkUrl, string color, int size, string imgUrl, string savePath)
        {
            bool result = false;
            try
            {
                aboutMark.CreateImag(linkUrl, color, size, imgUrl, savePath);
                result = true;
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="linkUrl">链接地址</param>
        /// <param name="color">颜色</param>
        /// <param name="size">大小</param>
        /// <param name="savePath">二维码保存路径</param>
        /// <returns></returns>
        public static bool CreateQRCode(string linkUrl, string color, int size, string savePath)
        {
            bool result = false;
            try
            {
                //aboutMark.CreateImag(linkUrl, color, size, savePath);
                aboutMark.CreateImag(linkUrl, color, size, savePath);
                result = true;
            }
            catch
            {
            }

            return result;
        }
    }
}