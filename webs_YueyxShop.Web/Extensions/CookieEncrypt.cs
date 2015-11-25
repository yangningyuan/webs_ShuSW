using System;
using System.Data;
using System.Security.Cryptography;  
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;

namespace webs_YueyxShop.Web
{
    /// <summary>
    /// Summary description for CookieEncrypt
    /// </summary>
    public class CookieEncrypt
    {
        public CookieEncrypt()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void SetCookie(HttpCookie cookie)
        {
            //����Cookie 
            HttpContext.Current.Response.Cookies.Set(cookie);
        }
        public static void SetCookie(String key, String valueString)
        {
            //���ü��ܺ��Cookie 
            key = HttpContext.Current.Server.UrlEncode(key);
            valueString = HttpContext.Current.Server.UrlEncode(valueString);
            HttpCookie cookie = new HttpCookie(key, valueString);
            SetCookie(cookie);
        }
        public static void SetCookie(String key, String valueString, DateTime expires)
        {
            //���ü��ܺ��Cookie��������Cookie����Чʱ�� 
            key = HttpContext.Current.Server.UrlEncode(key);
            valueString = HttpContext.Current.Server.UrlEncode(valueString);
            HttpCookie cookie = new HttpCookie(key, valueString);
            cookie.Expires = expires;
            SetCookie(cookie);
        }

        public static HttpCookie GetCookie(String key)
        {
            //ͨ���ؼ��ֻ�ȡCookie 
            key = HttpContext.Current.Server.UrlEncode(key);
            return (HttpContext.Current.Request.Cookies.Get(key));
        }
        public static String GetCookieValue(String key)
        {
            //ͨ���ؼ��ֻ�ȡCookie��value 
            String valueString = GetCookie(key).Value;
            valueString = HttpContext.Current.Server.UrlDecode(valueString);
            return (valueString);
        }
        /// <summary>
        /// �����󣩡�����ֻ�õ�cookie�� ���л�
        /// </summary>
        /// <param name="obj">����</param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {

            System.Runtime.Serialization.IFormatter bf = new BinaryFormatter();

            string result = string.Empty;

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {

                bf.Serialize(ms, obj);

                byte[] byt = Encoding.UTF8.GetBytes(ms.ToString());//new byte[ms.length];Ҳ��

                byt = ms.ToArray();

                result = System.Convert.ToBase64String(byt);

                ms.Flush();

            }

            return result;

        }
        /// <summary>
        ///  �����󣩡�����ֻ�õ�cookie�� �����л�
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static object DeserializeObject(string str)
        {

            object obj;


            byte[] byt = Convert.FromBase64String(str);

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byt, 0, byt.Length))
            {

                System.Runtime.Serialization.IFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(ms);

            }

            return obj;

        }

        #region ========����========

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "MATICSOFT");
        }
        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========����========


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "MATICSOFT");
        }
        /// <summary> 
        /// �������� 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}
