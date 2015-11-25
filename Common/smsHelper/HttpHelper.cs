using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Common.smsHelper
{
    public class HttpHelper
    {
        /// <summary>
        /// 返回get请求资源
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetJsonStr(string url)
        {
            var myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Timeout = 12000;
            myReq.Method = "GET";
            myReq.ContentType = "application/json;";
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();
            if (myStream == null) return null;
            var sr = new StreamReader(myStream, Encoding.GetEncoding("UTF-8"));
            var tempString = sr.ReadToEnd();
            return tempString;
        }
        /// <summary>
        /// 返回post请求资源
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string PostJsonStr(string url)
        {
            var myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Timeout = 12000;
            myReq.Method = "POST";
            myReq.ContentType = "application/json;";
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();
            if (myStream == null) return null;
            var sr = new StreamReader(myStream, Encoding.GetEncoding("UTF-8"));
            var tempString = sr.ReadToEnd();
            return tempString;
        }
        /// <summary>
        /// 提交put请求资源
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string PutJsonStr(string url)
        {
            var myReq = (HttpWebRequest)WebRequest.Create(url);
            myReq.Timeout = 12000;
            myReq.Method = "PUT";
            myReq.ContentType = "application/json;";
            var httpWResp = (HttpWebResponse)myReq.GetResponse();
            var myStream = httpWResp.GetResponseStream();
            if (myStream == null) return null;
            var sr = new StreamReader(myStream, Encoding.Default);
            var tempString = sr.ReadToEnd();
            return tempString;
        }

        /// <summary>
        /// 返回post请求资源
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static string PostXmlStr(string url, string param)
        {
            var bs = Encoding.UTF8.GetBytes(param);
            var myReq = (HttpWebRequest)WebRequest.Create(string.Format("{0}?{1}", url, param));
            myReq.Timeout = 12000;
            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded;";
            myReq.ContentLength = bs.Length;
            using (var reqStream = myReq.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Flush();
            }
            using (var wr = myReq.GetResponse())
            {
                var strm = wr.GetResponseStream();
                if (strm == null) return null;
                var sr = new StreamReader(strm, Encoding.UTF8);
                string line;
                var sb = new StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line + System.Environment.NewLine);
                }
                sr.Close();
                strm.Close();
                return sb.ToString();
            }
        }

        /// <summary>
        /// 获取post返回来的数据
        /// </summary>
        /// <returns></returns>
        public static string GetXmlInput()
        {
            var s = HttpContext.Current.Request.InputStream;
            var b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            return Encoding.UTF8.GetString(b);
        }

    }
}
