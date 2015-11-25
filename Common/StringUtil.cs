using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Common
{
	/// <summary>
	/// �ַ����������߼�
	/// </summary>
	public class StringUtil
	{					
		public StringUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//			
		}

		/// <summary>
		/// ���ַ����е�β��ɾ��ָ�����ַ���
		/// </summary>
		/// <param name="sourceString"></param>
		/// <param name="removedString"></param>
		/// <returns></returns>
		public static string Remove(string sourceString,string removedString)
		{
			try
			{
				if(sourceString.IndexOf(removedString)<0)
					throw new Exception("ԭ�ַ����в������Ƴ��ַ�����");
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
		/// ��ȡ��ַ��ұߵ��ַ���
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
		/// ��ȡ��ַ���ߵ��ַ���
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
		/// ȥ�����һ������
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
		/// ɾ�����ɼ��ַ�
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
		/// ��ȡ����Ԫ�صĺϲ��ַ���
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
		///		��ȡĳһ�ַ������ַ��������г��ֵĴ���
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
		///     ��ȡĳһ�ַ������ַ����г��ֵĴ���
		/// </summary>
		/// <param name="stringArray" type="string">
		///     <para>
		///         ԭ�ַ���
		///     </para>
		/// </param>
		/// <param name="findString" type="string">
		///     <para>
		///         ƥ���ַ���
		///     </para>
		/// </param>
		/// <returns>
		///     ƥ���ַ�������
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
		/// ��ȡ��startString��ʼ��ԭ�ַ�����β�������ַ�   
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
		/// ���ֽ���ȡ���ַ����ĳ���
		/// </summary>
		/// <param name="strTmp">Ҫ������ַ���</param>
		/// <returns>�ַ������ֽ���</returns>
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
		/// ���ֽ���Ҫ���ַ�����λ��
		/// </summary>
		/// <param name="intIns">�ַ�����λ��</param>
		/// <param name="strTmp">Ҫ������ַ���</param>
		/// <returns>�ֽڵ�λ��</returns>
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
        /// �ж������Ƿ�Ϊ��ֵ����
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
        #region ������֤��
        /// <summary>
        /// ������֤��
        /// </summary>
        /// <param name="len">����</param>
        /// <param name="OnlyNum">�Ƿ��Ϊ����</param>
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
        /// ������֤��
        /// </summary>
        /// <param name="len">����</param>
        /// <returns>��֤��</returns>
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

        #region ��ȡIP
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

        #region ����Σ�����ݿ��ַ�
        /// <summary>
        /// ����Σ�����ݿ��ַ�
        /// </summary>
        /// <param name="objString">Ҫ���˵�Σ���ַ�</param>
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

        #region HTML �������
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

            text = regex1.Replace(text, string.Empty);                    //����<script></script>��� 
            text = regex2.Replace(text, string.Empty);                    //����href=javascript: (<A>) ���� 
            text = regex3.Replace(text, " _disibledevent=");    //���������ؼ���on...�¼� 
            text = regex4.Replace(text, string.Empty);                    //����iframe 
            text = regex5.Replace(text, string.Empty);                    //����frameset 
            text = regex6.Replace(text, string.Empty);                    //����frameset 
            text = regex7.Replace(text, string.Empty);                    //����frameset 
            text = regex8.Replace(text, string.Empty);                    //����frameset 
            text = regex9.Replace(text, string.Empty);
            text = regex10.Replace(text, " ");                            //�������߸���Ŀո�
            text = regex11.Replace(text, string.Empty);                   //<br>
            text = regex12.Replace(text, " ");                            //&nbsp;
            text = regex13.Replace(text, string.Empty);                   // �������
            text = regex14.Replace(text, string.Empty);                   // �������
            text = regex15.Replace(text, string.Empty);                   // �������
            text = regex16.Replace(text, string.Empty);                   // �������


            text = text.Replace(" ", "");
            text = text.Replace("</strong>", "");
            text = text.Replace("<strong>", "");

            return text;
        }
        #endregion 

        #region ��ӡ��ҳ
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
        #region ���У��ǻԣ�
        public static string LineBreak(string sourceString, int lineLength)
        {
            //charConvert(sourceString.ToLower());
            char[] tempChar = sourceString.ToCharArray();
            int Count = 0, length = 0;
            string tempStr = "";
            int DoubleNumber = 0;
            int i_number = 0;                           //�ԡ�i����I����j���������⴦��
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
                            #region ��switchʵ�ֹ���
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
        
        //�Ҹĵ� 2006-2-23
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
        ///��ȡ�ַ�����ʵ�ʳ���
        ///</summary>
        ///<param name="sourceString">Դ�ַ���</param>
        public static int realLenth(string sourceString)
        {
            Byte[] tLength = System.Text.Encoding.Default.GetBytes(sourceString);
            return tLength.Length;
        }
        #endregion

        /// <summary>
        /// ��֤�ַ����б����Ƿ������Ӧ���ַ�����ȫƥ��
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
