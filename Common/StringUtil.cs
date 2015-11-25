using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Common
{
	/// <summary>
	/// 字符串操作工具集
	/// </summary>
	public class StringUtil
	{					
		public StringUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//			
		}

		/// <summary>
		/// 从字符串中的尾部删除指定的字符串
		/// </summary>
		/// <param name="sourceString"></param>
		/// <param name="removedString"></param>
		/// <returns></returns>
		public static string Remove(string sourceString,string removedString)
		{
			try
			{
				if(sourceString.IndexOf(removedString)<0)
					throw new Exception("原字符串中不包含移除字符串！");
				string result = sourceString;
				int lengthOfSourceString = sourceString.Length;
				int lengthOfRemovedString = removedString.Length;
				int startIndex = lengthOfSourceString - lengthOfRemovedString;
				string tempSubString = sourceString.Substring(startIndex);
				if(tempSubString.ToUpper() == removedString.ToUpper())
				{					
					result = sourceString.Remove(startIndex,lengthOfRemovedString);
				}
				return result;
			}
			catch
			{
				return sourceString;
			}
		}

		/// <summary>
		/// 获取拆分符右边的字符串
		/// </summary>
		/// <param name="sourceString"></param>
		/// <param name="splitChar"></param>
		/// <returns></returns>
		public static string RightSplit(string sourceString, char splitChar)
		{
			string result=null;
			string[] tempString = sourceString.Split(splitChar);
			if(tempString.Length >0)
			{
				result = tempString[tempString.Length-1].ToString();
			}
			return result;
		}
		
		/// <summary>
		/// 获取拆分符左边的字符串
		/// </summary>
		/// <param name="sourceString"></param>
		/// <param name="splitChar"></param>
		/// <returns></returns>
		public static string LeftSplit(string sourceString, char splitChar)
		{
			string result=null;
			string[] tempString = sourceString.Split(splitChar);
			if(tempString.Length >0)
			{
				result = tempString[0].ToString();
			}
			return result;
		}

		/// <summary>
		/// 去掉最后一个逗号
		/// </summary>
		/// <param name="origin"></param>
		/// <returns></returns>
		public static string DelLastComma(string origin)
		{
			if(origin.IndexOf(",") == -1)
			{
				return origin;
			}
			return origin.Substring(0,origin.LastIndexOf(","));
		}

		/// <summary>
		/// 删除不可见字符
		/// </summary>
		/// <param name="sourceString"></param>
		/// <returns></returns>
		public static string DeleteUnVisibleChar(string sourceString)
		{
			System.Text.StringBuilder sBuilder = new System.Text.StringBuilder(131);
			for(int i = 0;i < sourceString.Length; i++)
			{
				int Unicode = sourceString[i];
				if(Unicode >= 16)
				{
					sBuilder.Append(sourceString[i].ToString());
				}				
			}
			return sBuilder.ToString();
		}

		/// <summary>
		/// 获取数组元素的合并字符串
		/// </summary>
		/// <param name="stringArray"></param>
		/// <returns></returns>
		public static string GetArrayString(string[] stringArray)
		{
			string totalString = null;
			for(int i=0;i<stringArray.Length;i++)
			{
				totalString = totalString + stringArray[i];				
			}
			return totalString;
		}

		/// <summary>
		///		获取某一字符串在字符串数组中出现的次数
		/// </summary>
		/// <param name="stringArray" type="string[]">
		///     <para>
		///         
		///     </para>
		/// </param>
		/// <param name="findString" type="string">
		///     <para>
		///         
		///     </para>
		/// </param>
		/// <returns>
		///     A int value...
		/// </returns>
		public static int GetStringCount(string[] stringArray,string findString)
		{
			int count = -1;						
			string totalString = GetArrayString(stringArray);		
			string subString = totalString;

			while(subString.IndexOf(findString)>=0)
			{
				subString = totalString.Substring(subString.IndexOf(findString));
				count += 1;
			}
			return count;
		}

		/// <summary>
		///     获取某一字符串在字符串中出现的次数
		/// </summary>
		/// <param name="stringArray" type="string">
		///     <para>
		///         原字符串
		///     </para>
		/// </param>
		/// <param name="findString" type="string">
		///     <para>
		///         匹配字符串
		///     </para>
		/// </param>
		/// <returns>
		///     匹配字符串数量
		/// </returns>
		public static int GetStringCount(string sourceString,string findString)
		{
			int count = 0;	
			int findStringLength = findString.Length;
			string subString = sourceString;

			while(subString.IndexOf(findString)>=0)
			{
				subString = subString.Substring(subString.IndexOf(findString)+findStringLength);
				count += 1;
			}
			return count;
		}

		/// <summary>
		/// 截取从startString开始到原字符串结尾的所有字符   
		/// </summary>
		/// <param name="sourceString" type="string">
		///     <para>
		///         
		///     </para>
		/// </param>
		/// <param name="startString" type="string">
		///     <para>
		///         
		///     </para>
		/// </param>
		/// <returns>
		///     A string value...
		/// </returns>
		public static string GetSubString(string sourceString,string startString)
		{
			try
			{
				int index = sourceString.ToUpper().IndexOf(startString);
				if(index>0)
				{
					return sourceString.Substring(index);
				}
				return sourceString;
			}
			catch
			{
				return "";
			}
		}

		public static string GetSubString(string sourceString,string beginRemovedString,string endRemovedString)
		{
			try
			{
				if(sourceString.IndexOf(beginRemovedString)!=0)
					beginRemovedString = "";

				if(sourceString.LastIndexOf(endRemovedString,sourceString.Length - endRemovedString.Length)<0)
					endRemovedString = "";

                int startIndex = beginRemovedString.Length;
				int length     = sourceString.Length - beginRemovedString.Length - endRemovedString.Length ;
				if(length>0)
				{
					return sourceString.Substring(startIndex,length);
				}
				return sourceString;
			}
			catch
			{
				return sourceString;;
			}
		}
		
		/// <summary>
		/// 按字节数取出字符串的长度
		/// </summary>
		/// <param name="strTmp">要计算的字符串</param>
		/// <returns>字符串的字节数</returns>
		public static int GetByteCount(string strTmp)
		{
			int intCharCount=0;
			for(int i=0;i<strTmp.Length;i++)
			{
				if(System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i,1))==3)
				{
					intCharCount=intCharCount+2;
				}
				else
				{
					intCharCount=intCharCount+1;
				}
			}
			return intCharCount;
		}

		/// <summary>
		/// 按字节数要在字符串的位置
		/// </summary>
		/// <param name="intIns">字符串的位置</param>
		/// <param name="strTmp">要计算的字符串</param>
		/// <returns>字节的位置</returns>
		public static int GetByteIndex(int intIns,string strTmp)
		{
			int intReIns=0;
			if(strTmp.Trim()=="")
			{
				return intIns;
			}
			for(int i=0;i<strTmp.Length;i++)
			{
				if(System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i,1))==3)
				{
					intReIns=intReIns+2;
				}
				else
				{
					intReIns=intReIns+1;
				}
				if(intReIns>=intIns)
				{
					intReIns=i+1;
					break;
				}			
			}
			return intReIns;
        }
        /// <summary>
        /// 判断数据是否为数值类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool isNumber(string s)
        {
            int Flag = 0;
            char[] str = s.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsNumber(str[i]))
                {
                    Flag++;
                }
                else
                {
                    Flag = -1;
                    break;
                }
            }
            if (Flag > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #region 产生验证码
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="OnlyNum">是否仅为数字</param>
        /// <returns></returns>
        public static string CreateAuthStr(int len, bool OnlyNum)
        {
            if (!OnlyNum)
            {
                return CreateAuthStr(len);
            }
            int number;
            StringBuilder checkCode = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < len; i++)
            {
                number = random.Next();
                checkCode.Append((char)('0' + (char)(number % 10)));
            }

            return checkCode.ToString();
        }
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="len">长度</param>
        /// <returns>验证码</returns>
        public static string CreateAuthStr(int len)
        {
            int number;
            StringBuilder checkCode = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < len; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                {
                    checkCode.Append((char)('0' + (char)(number % 10)));
                }
                else
                {
                    checkCode.Append((char)('A' + (char)(number % 26)));
                }

            }

            return checkCode.ToString();
        }
        #endregion

        #region 获取IP
        public static string GetUserIpAddress(System.Web.HttpContext context)
        {
            string result = String.Empty;
            if (context == null) return result;

            result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            return result;
        }
        #endregion

        #region 过滤危险数据库字符
        /// <summary>
        /// 过滤危险数据库字符
        /// </summary>
        /// <param name="objString">要过滤的危险字符</param>
        public static string ReplaceDangerString(string objString)
        {
            objString = objString.Trim();
            objString = objString.Replace("%", "");
            objString = objString.Replace("'", "");
            objString = objString.Replace("=", "");
            objString = objString.Replace(">", "");
            objString = objString.Replace("<", "");
            objString = objString.Replace("+", "");
            objString = objString.Replace("&", "");
            objString = objString.Replace("\"", "");
            return objString;
        }
        #endregion

        #region HTML 代码过滤
        public static string ClearHtmlCode(string text)
        {
            Regex regex1 = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(@" href *= *[\s\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(@" no[\s\S]*=", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex(@"<iframe[\s\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex(@"<frameset[\s\S]+</frameset *>", RegexOptions.IgnoreCase);
            Regex regex6 = new Regex(@"\<img[^\>]+\>", RegexOptions.IgnoreCase);
            Regex regex7 = new Regex(@"</p>", RegexOptions.IgnoreCase);
            Regex regex8 = new Regex(@"<p>", RegexOptions.IgnoreCase);
            Regex regex9 = new Regex(@"<[^>]*>", RegexOptions.IgnoreCase);

            Regex regex10 = new Regex(@"[\s]{2,}", RegexOptions.IgnoreCase);
            Regex regex11 = new Regex(@"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", RegexOptions.IgnoreCase);
            Regex regex12 = new Regex(@"(\s*&[n|N][b|B][s|S][p|P];\s*)+", RegexOptions.IgnoreCase);
            Regex regex13 = new Regex(@"<(.|\n)*?>", RegexOptions.IgnoreCase);
            Regex regex14 = new Regex(@"/<\/?[^>]*>/g", RegexOptions.IgnoreCase);
            Regex regex15 = new Regex(@"/[    | ]* /g", RegexOptions.IgnoreCase);
            Regex regex16 = new Regex(@"/ [\s| |    ]* /g", RegexOptions.IgnoreCase);

            text = regex1.Replace(text, string.Empty);                    //过滤<script></script>标记 
            text = regex2.Replace(text, string.Empty);                    //过滤href=javascript: (<A>) 属性 
            text = regex3.Replace(text, " _disibledevent=");    //过滤其它控件的on...事件 
            text = regex4.Replace(text, string.Empty);                    //过滤iframe 
            text = regex5.Replace(text, string.Empty);                    //过滤frameset 
            text = regex6.Replace(text, string.Empty);                    //过滤frameset 
            text = regex7.Replace(text, string.Empty);                    //过滤frameset 
            text = regex8.Replace(text, string.Empty);                    //过滤frameset 
            text = regex9.Replace(text, string.Empty);
            text = regex10.Replace(text, " ");                            //两个或者更多的空格
            text = regex11.Replace(text, string.Empty);                   //<br>
            text = regex12.Replace(text, " ");                            //&nbsp;
            text = regex13.Replace(text, string.Empty);                   // 其他标记
            text = regex14.Replace(text, string.Empty);                   // 其他标记
            text = regex15.Replace(text, string.Empty);                   // 其他标记
            text = regex16.Replace(text, string.Empty);                   // 其他标记


            text = text.Replace(" ", "");
            text = text.Replace("</strong>", "");
            text = text.Replace("<strong>", "");

            return text;
        }
        #endregion 

        #region 打印分页
        public static string sub_realLength(string source, int startIndex, int Length)
        {
            int count = 0;
            string tempStr = "";
            char[] tempChar = source.ToCharArray();
            for (int i = 0; i < tempChar.Length; i++)
            {
                if (isDoubleByte(tempChar[i]))
                {
                    count += 2;
                }
                else
                {
                    count += 1;
                }
                if ((count >= startIndex) && (realLenth(tempStr) < Length))
                {
                    tempStr += tempChar[i];
                }
            }
            return tempStr;
        }
        public static string print_page(string sourceString, int lineLength, int pageLineCount, string breakText, bool IsBreak)
        {
            string[] FirstAsunder = newLineToArray(sourceString);
            return Left(pageBreak(FirstAsunder, breakText, pageLineCount, lineLength, IsBreak), 0);
        }
        public static string pageBreak(string[] sourceString, string breakText, int pageLineCount, int lineLength, bool IsBreak)
        {
            string tempStr = "";
            for (int i = 0; i < sourceString.Length; i++)
            {
                if (IsBreak)
                {
                    tempStr += LineBreak(sourceString[i], lineLength) + "\n";
                }
                else
                {
                    tempStr += sourceString[i] + "\n";
                }
            }
            tempStr = Left(tempStr, 1);
            string[] tempArray = tempStr.Split('\n');
            tempStr = "";
            for (int i = 0; i < tempArray.Length; i++)
            {
                //tempStr+=i.ToString();
                tempStr += tempArray[i];
                if ((i + 1) % pageLineCount == 0)
                {
                    tempStr += breakText;
                }
                else
                {
                    tempStr += "\n";
                }
            }
            return tempStr;
        }
        public static string Left(string sourceString, int i)
        {
            if (sourceString.Length > 0)
            {
                return sourceString.Substring(0, sourceString.Length - i);
            }
            else
            {
                return "";
            }
        }
        public static string CutString(string sourceString, int star, int len)
        {
            if (star == 0)
            {
                if (sourceString.Trim().Length < star + len)
                    return sourceString;
                else
                    return sourceString.Substring(star, len);
            }
            else
            {
                if (sourceString.Trim().Length - star <= 0)
                    return "";
                else
                    return sourceString.Substring(star, sourceString.Length - star);
            }
        }
        public static bool isDoubleByte(char sourceChar)
        {
            int i = realLenth(sourceChar.ToString());

            if (sourceChar >= 'A' && sourceChar <= 'Z')
            {
                if (sourceChar != 'I' && sourceChar != 'J')
                    return true;
            }
            if (i == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region 分行（亚辉）
        public static string LineBreak(string sourceString, int lineLength)
        {
            //charConvert(sourceString.ToLower());
            char[] tempChar = sourceString.ToCharArray();
            int Count = 0, length = 0;
            string tempStr = "";
            int DoubleNumber = 0;
            int i_number = 0;                           //对‘i’‘I’‘j’进行特殊处理
            for (int i = 0; i < tempChar.Length; i++)
            {
                if (isDoubleByte(tempChar[i]) == true)
                {
                    Count += 2;
                    length += 18;
                }
                else
                {
                    if (tempChar[i] == '@' || tempChar[i] == '%')
                    {
                        Count += 2;
                        length += 18;
                    }
                    else
                    {
                        if (tempChar[i] <= 'Z' && tempChar[i] >= 'A')
                        {
                            #region 用switch实现功能
                            switch (tempChar[i])
                            {
                                //								case 'J':Count++;break;
                                case 'W': Count += 2; length += 18; break;
                                case 'X': Count += 2; length += 18; break;
                                case 'U': Count += 2; break;
                                case 'M': Count += 2; length += 18; break;
                                case 'I':
                                    {
                                        Count++;
                                        i_number++;
                                        if (i_number == 3)
                                        {
                                            i_number = 0;
                                        }
                                        else
                                        {
                                            Count++;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        DoubleNumber++;
                                        switch (DoubleNumber)
                                        {
                                            case 1: Count += 2; break;
                                            case 2: Count += 1; break;
                                            case 3: Count += 2; break;
                                            case 4: Count += 1; DoubleNumber = 0; break;
                                            default: break;
                                        }
                                        //									Count++;
                                        break;
                                    }
                            }
                            #endregion

                        }
                        else
                        {
                            if (tempChar[i] == 'i' || tempChar[i] == 'j' || tempChar[i] == ' ')
                            {
                                i_number++;
                                if (i_number == 3)
                                {
                                    i_number = 0;
                                }
                                else
                                {
                                    Count++;
                                }
                            }
                            else
                            {
                                Count += 1;
                            }
                        }
                    }
                }
                tempStr += tempChar[i];
                if ((Count % lineLength) == (lineLength - 1))
                {
                    if (i < (tempChar.Length - 1))
                    {
                        if (isDoubleByte(tempChar[i + 1]))
                        {
                            tempStr += "|";
                            DoubleNumber = 0;
                        }
                    }
                }
                if ((Count % lineLength) == 0 && (Count != 0))
                {
                    tempStr += "|";
                    DoubleNumber = 0;
                }
            }
            return tempStr;
        }
        #endregion
        
        //我改的 2006-2-23
        public static string lineHtmBreak(string sourceString, int lineLength, string rowBreak)
        {
            charConvert(sourceString);
            char[] tempChar = sourceString.ToCharArray();
            int Count = 0;
            string tempStr = "";
            int DoubleNumber = 0;
            for (int i = 0; i < tempChar.Length; i++)
            {
                if (isDoubleByte(tempChar[i]) == true)
                {
                    Count += 2;
                }
                else
                {
                    if (tempChar[i] == '@' || tempChar[i] == '%')
                    {
                        Count += 2;
                    }
                    else
                    {
                        if (tempChar[i] <= 'Z' || tempChar[i] >= 'A')
                        {
                            DoubleNumber++;
                            switch (DoubleNumber)
                            {
                                case 1: Count += 2; break;
                                case 2: Count += 2; break;
                                case 3: Count += 2; break;
                                case 4: Count += 1; DoubleNumber = 0; break;
                                default: break;
                            }
                        }
                        else
                        {
                            Count += 1;
                        }
                    }
                }
                tempStr += tempChar[i];
                if ((Count % lineLength) == (lineLength - 1))
                {
                    if (i < (tempChar.Length - 1))
                    {
                        if (isDoubleByte(tempChar[i + 1]))
                        {
                            tempStr += rowBreak;
                        }
                    }
                }
                if ((Count % lineLength) == 0 && (Count != 0))
                {
                    tempStr += rowBreak;
                }
            }
            return tempStr;
        }
        public static string charConvert(string sourceString)
        {
            return sourceString.Replace("\t", "");
        }
        public static string[] newLineToArray(string sourceString)
        {
            return sourceString.Split('\n');
        }
        ///<summary>
        ///获取字符串的实际长度
        ///</summary>
        ///<param name="sourceString">源字符串</param>
        public static int realLenth(string sourceString)
        {
            Byte[] tLength = System.Text.Encoding.Default.GetBytes(sourceString);
            return tLength.Length;
        }
        #endregion

        /// <summary>
        /// 验证字符串列表中是否包含对应的字符串，全匹配
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static bool IsInList(List<string> _list,string _obj)
        {
            bool bl = false;
            foreach (string item in _list)
            {
                if (item.Trim() == _obj.Trim())
                {
                    bl = true;
                    return bl;
                }
            }
            return bl;
        }
    }
}
