using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webs_YueyxShop.Web
{
    public static class DateTimeExtemsions
    {
        /// <summary>
        /// 生成Unix时间戳 + 4位随机数
        /// </summary>
        /// <returns></returns>
        public static string ToUnixTimeStamp(this DateTime dt)
        {
            var time = (dt.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            
            string timeStamp = time.ToString();
            Random rd = new Random();
            timeStamp += rd.Next(10);
            timeStamp += rd.Next(10);
            timeStamp += rd.Next(10);
            timeStamp += rd.Next(10);

            return timeStamp;
        }
    }
}