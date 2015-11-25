using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common.smsHelper
{
    public class smsHelper
    {
        private readonly static Encoding Encoding = Encoding.GetEncoding("GB2312");
        private readonly static string UserName = HttpUtility.UrlEncode(ConfigHelper.GetConfigString("smsUserName"), Encoding);
        private readonly static string PassWord = HttpUtility.UrlEncode(ConfigHelper.GetConfigString("smsPassWord"), Encoding);

        /// <summary>
        /// http://www.sms1086.com/plan/api/Send.aspx
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string SendSms10086(string mobile, string content)
        {
            if (!Regex.IsMatch(mobile, @"^1[358]\d{9}$", RegexOptions.IgnoreCase)) return "手机号码格式不正确";
            var url = string.Format("http://www.sms1086.com/plan/api/Send.aspx?username={0}&password={1}&mobiles={2}&content={3}", UserName, PassWord,
                HttpUtility.UrlEncode(mobile, Encoding), HttpUtility.UrlEncode(content, Encoding));
            var result = HttpHelper.PostJsonStr(url);
            var response = DecodeResponse(result);
            return response["description"];
        }

        /// <summary>
        /// http://www.139000.com/send/gsend.asp
        /// </summary>
        /// <param name="dstMobiles"></param>
        /// <param name="smsMsg"></param>
        /// <returns></returns>
        public static string Send139000(string dstMobiles, string smsMsg)
        {
            if (!Regex.IsMatch(dstMobiles, @"^1[358]\d{9}$", RegexOptions.IgnoreCase)) return "手机号码格式不正确";
            var url = string.Format("http://www.139000.com/send/gsend.asp?name={0}&pwd={1}&dst={2}&msg={3}", UserName, PassWord,
           dstMobiles, HttpUtility.UrlEncode(smsMsg, Encoding));
            var rs = (HttpWebResponse)WebRequest.Create(url).GetResponse();
            var sr = new StreamReader(rs.GetResponseStream(), Encoding.Default);
            var response = DecodeResponse(sr.ReadToEnd());
            return response["err"];
        }

        public static Dictionary<string, string> DecodeResponse(string result)
        {
            var responses = result.Split('&');
            var response = new Dictionary<string, string>();
            foreach (var pair in responses)
            {
                var kv = pair.Split('=');
                if (kv.Length == 2)
                {
                    response[kv[0]] = HttpUtility.UrlDecode(kv[1], Encoding.GetEncoding("GB2312"));
                }
            }
            return response;
        }
    }
}
