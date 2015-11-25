using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Common.DEncrypt
{
    public class MD5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="MDstr">要加密的字符串</param>
        /// <returns></returns>
        public static string strToMD5(string MDstr)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(MDstr, "MD5");
        }
        
    }
}
