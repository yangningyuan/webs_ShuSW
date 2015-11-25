using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace webs_YueyxShop.Web
{
    public class RegexHelper
    {
        /// <summary>
        /// 验证正则表达式
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="regx">正则表达式</param>
        private static bool ValidateRegex(string text,string regx)
        {
            if(Regex.IsMatch(text, regx))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public static bool IsPhone(string text)
        {
            string regx = @"^[0-9]{11,11}$";

            return ValidateRegex(text,regx);
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public static bool IsEmail(string text)
        {
            string regx = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            
            return ValidateRegex(text,regx);
        }

        /// <summary>
        /// 判断输入的字符串只包含汉字
        /// </summary>
        public static bool IsChineseCh(string text)
        {
            string regx = @"^[\u4e00-\u9fa5]+$";

            return ValidateRegex(text, regx);
        }
        
        /// <summary>
        /// 匹配3位或4位区号的电话号码，其中区号可以用小括号括起来，
        /// 也可以不用，区号与本地号间可以用连字号或空格间隔，
        /// 也可以没有间隔
        /// \(0\d{2}\)[- ]?\d{8}|0\d{2}[- ]?\d{8}|\(0\d{3}\)[- ]?\d{7}|0\d{3}[- ]?\d{7}
        /// </summary>
        public static bool IsTelePhone(string text)
        {
            string regx = @"^\\(0\\d{2}\\)[- ]?\\d{8}$|^0\\d{2}[- ]?\\d{8}$|^\\(0\\d{3}\\)[- ]?\\d{7}$|^0\\d{3}[- ]?\\d{7}$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串是否是一个合法的手机号
        /// </summary>
        public static bool IsMobilePhone(string text)
        {
            string regx = @"^13\\d{9}$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串只包含数字
        /// 可以匹配整数和浮点数
        /// ^-?\d+$|^(-?\d+)(\.\d+)?$
        /// </summary>
        public static bool IsNumber(string text)
        {
            string regx = @"^-?\\d+$|^(-?\\d+)(\\.\\d+)?$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 匹配非负整数
        /// </summary>
        public static bool IsNotNagtive(string text)
        {
            string regx = @"^\d+$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 匹配正整数
        /// </summary>
        public static bool IsUint(string text)
        {
            string regx = @"^[0-9]*[1-9][0-9]*$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串字包含英文字母
        /// </summary>
        public static bool IsEnglisCh(string text)
        {
            string regx = @"^[A-Za-z]+$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串是否只包含数字和英文字母
        /// </summary>
        public static bool IsNumAndEnCh(string text)
        {
            string regx = @"^[A-Za-z0-9]+$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串是否是一个超链接
        /// </summary>
        public static bool IsURL(string text)
        {
            //string regx = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            string regx = @"^[a-zA-Z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";

            return ValidateRegex(text, regx);
        }

        /// <summary>
        /// 判断输入的字符串是否是表示一个IP地址
        /// </summary>
        /// <param name="text">被比较的字符串</param>
        /// <returns>是IP地址则为True</returns>
        public static bool IsIPv4(string text)
        {
            string[] IPs = text.Split('.');
            string regx = @"^\d+$";
            for (int i = 0; i < IPs.Length; i++)
            {
                if (!ValidateRegex(IPs[i], regx))
                {
                    return false;
                }
                if (Convert.ToUInt16(IPs[i]) > 255)
                {
                    return false;
                }
            }
            return true;
        }

        ///// <summary>
        ///// 计算字符串的字符长度，一个汉字字符将被计算为两个字符
        ///// </summary>
        ///// <param name="text">需要计算的字符串</param>
        ///// <returns>返回字符串的长度</returns>
        //public static int GetCount(string text)
        //{
        //    string regx = @"^[A-Za-z]+$";

        //    return ValidateRegex(text, regx);
        //    return Regex.Replace(text, @"[\u4e00-\u9fa5/g]", "aa").Length;
        //}

        /// <summary>
        /// 调用Regex中IsMatch函数实现一般的正则表达式匹配
        /// </summary>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <param name="text">要搜索匹配项的字符串</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        public static bool IsMatch(string pattern, string text)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text);
        }

        /// <summary>
        /// 从输入字符串中的第一个字符开始，用替换字符串替换指定的正则表达式模式的所有匹配项。
        /// </summary>
        /// <param name="pattern">模式字符串</param>
        /// <param name="text">输入字符串</param>
        /// <param name="replacement">用于替换的字符串</param>
        /// <returns>返回被替换后的结果</returns>
        public static string Replace(string pattern, string text, string replacement)
        {
            Regex regex = new Regex(pattern);
            return regex.Replace(text, replacement);
        }

        /// <summary>
        /// 在由正则表达式模式定义的位置拆分输入字符串。
        /// </summary>
        /// <param name="pattern">模式字符串</param>
        /// <param name="text">输入字符串</param>
        /// <returns></returns>
        public static string[] Split(string pattern, string text)
        {
            Regex regex = new Regex(pattern);
            return regex.Split(text);
        }
        ///// <summary>
        ///// 判断输入的字符串是否是合法的IPV6 地址
        ///// </summary>
        ///// <param name="text"></param>
        ///// <returns></returns>
        //public static bool IsIPV6(string text)
        //{
        //    string pattern = "";
        //    string temp = text;
        //    string[] strs = temp.Split(':');
        //    if (strs.Length > 8)
        //    {
        //        return false;
        //    }
        //    int count = MetarnetRegex.GetStringCount(text, "::");
        //    if (count > 1)
        //    {
        //        return false;
        //    }
        //    else if (count == 0)
        //    {
        //        pattern = @"^([\da-f]{1,4}:){7}[\da-f]{1,4}$";

        //        Regex regex = new Regex(pattern);
        //        return regex.IsMatch(text);
        //    }
        //    else
        //    {
        //        pattern = @"^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$";
        //        Regex regex1 = new Regex(pattern);
        //        return regex1.IsMatch(text);
        //    }

        //}
        /* *******************************************************************
         * 1、通过“:”来分割字符串看得到的字符串数组长度是否小于等于8
         * 2、判断输入的IPV6字符串中是否有“::”。
         * 3、如果没有“::”采用 ^([\da-f]{1,4}:){7}[\da-f]{1,4}$ 来判断
         * 4、如果有“::” ，判断"::"是否止出现一次
         * 5、如果出现一次以上 返回false
         * 6、^([\da-f]{1,4}:){0,5}::([\da-f]{1,4}:){0,5}[\da-f]{1,4}$
         * ******************************************************************/
        /// <summary>
        /// 判断字符串compare 在 text字符串中出现的次数
        /// </summary>
        /// <param name="text">源字符串</param>
        /// <param name="compare">用于比较的字符串</param>
        /// <returns>字符串compare 在 text字符串中出现的次数</returns>
        private static int GetStringCount(string text, string compare)
        {
            int index = text.IndexOf(compare);
            if (index != -1)
            {
                return 1 + GetStringCount(text.Substring(index + compare.Length), compare);
            }
            else
            {
                return 0;
            }

        }
    }
}