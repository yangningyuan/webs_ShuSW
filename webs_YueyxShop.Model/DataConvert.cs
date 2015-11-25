using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace webs_YueyxShop.Model
{
    public class DataConvert
    {
        protected DataConvert()
        {
        }

        public static object Null2DBNull(string sourceValue)
        {
            if (sourceValue == null || sourceValue.Length == 0)
                return DBNull.Value;
            else
                return (object)sourceValue;
        }

        public static object Null2DBNull(DateTime sourceValue)
        {
            if (sourceValue == DateTime.MinValue)
                return DBNull.Value;
            else
                return (object)sourceValue;
        }

        public static object Null2DBNull(decimal? sourceValue)
        {
            if (sourceValue == null)
                return DBNull.Value;
            else
                return (object)sourceValue;
        }

        public static object Null2DBNull(int? sourceValue)
        {
            if (sourceValue == null)
                return DBNull.Value;
            else
                return (object)sourceValue;
        }


        public static object Null2DBNull(DateTime? sourceValue)
        {
            if (sourceValue == null)
                return DBNull.Value;
            else
                return (object)sourceValue;
        }

        public static object Null2DBNull(object sourceValue)
        {
            if (sourceValue == null || sourceValue.Equals(DateTime.MinValue) || sourceValue.ToString().Length == 0)
                return "NULL";
            else
                return sourceValue;
        }



        public static int Object2Int(object sourceValue)
        {
            int v = 0;
            if (sourceValue == null || sourceValue == DBNull.Value)
                v = 0;
            else
            {
                int.TryParse(sourceValue.ToString(), out v);

            }
            return v;
        }

        public static long Object2Long(object sourceValue)
        {
            long v = 0;
            if (sourceValue == null || sourceValue == DBNull.Value)
                v = 0;
            else
            {
                long.TryParse(sourceValue.ToString(), out v);

            }
            return v;
        }

        public static string Object2String(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
                return string.Empty;
            else
                return sourceValue.ToString().Trim();
        }

        public static bool Object2Bool(object sourceValue)
        {
            //bool v = false;
            if (sourceValue == null || sourceValue == DBNull.Value)
                return false;
            else
            {
                //bool.TryParse(sourceValue.ToString(), out v);
                return Convert.ToBoolean(sourceValue);
            }

        }

        public static decimal Object2Decimal(object sourceValue)
        {
            decimal v = 0;
            if (sourceValue == null || sourceValue == DBNull.Value)
                v = 0;
            else
            {
                decimal.TryParse(sourceValue.ToString(), out v);

            }
            return v;
        }

        public static DateTime Object2DateTime(object sourceValue)
        {
            try
            {
                if (sourceValue == null || sourceValue == DBNull.Value)
                    return DateTime.MinValue;
                else
                    return Convert.ToDateTime(sourceValue);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }


        public static string ObjectTryDateString(object sourceValue)
        {
            string back = null;
            if (sourceValue != null)
            {
                DateTime time;
                DateTime.TryParse(sourceValue.ToString(), out time);
                if (time != null)
                    back = time.ToString();
            }
            return back;
        }

        public static string String2Empty(string sourceValue)
        {
            if (sourceValue == null || sourceValue.Length == 0)
                return "";
            else
                return sourceValue.Trim();
        }

        public static int String2Int(string sourceValue)
        {
            int result;
            if (sourceValue.Trim() == string.Empty)
                return 0;
            else
            {
                int.TryParse(sourceValue, out result);
                return result;
            }
        }

        public static decimal String2Decimal(string sourceValue)
        {
            decimal result;
            if (sourceValue.Trim() == string.Empty)
                return 0;
            else
            {
                decimal.TryParse(sourceValue, out result);
                return result;
            }
        }

        public static float String2Float(string sourceValue)
        {
            float result;
            float.TryParse(sourceValue, out result);
            return result;
        }

        public static DateTime String2DateTime(string sourceValue)
        {
            if (sourceValue.Trim() == string.Empty)
                return DateTime.MinValue;
            else
                return DateTime.Parse(sourceValue);
        }

        public static string DateTime2String(DateTime dateTime)
        {
            //if (dateTime == DateTime.MinValue || (dateTime.Year == 1900 && dateTime.Month == 1))
            //    return "";
            //else
            //    return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return DateTime2String(dateTime, "yyyy-MM-dd HH:mm:ss");
        }

        public static string DateTime2String(DateTime dateTime, string format)
        {
            if (dateTime == DateTime.MinValue || (dateTime.Year == 1900 && dateTime.Month == 1))
                return "";
            else
                return dateTime.ToString(format);
        }

        public static string DateTime2String(DateTime? dateTime, string format)
        {
            if (dateTime == null || dateTime.Value == DateTime.MinValue || (dateTime.Value.Year == 1900 && dateTime.Value.Month == 1))
                return "";
            else
                return dateTime.Value.ToString(format);
        }

        public static string TimeSpan2String(TimeSpan timeSpan)
        {

            string totalHours = "00";
            string totalMinutes = "00";

            if (timeSpan != null)
            {
                totalMinutes = timeSpan.Minutes.ToString("00");
                totalHours = decimal.Truncate((decimal)timeSpan.TotalHours).ToString("00");
            }

            return totalHours + ":" + totalMinutes;
        }

        //public static string DateTime2String(DateTime dateTime, string format, string globalization)
        //{
        //    CultureInfo ci = null;
        //    if (globalization.Length > 0)
        //        ci = new CultureInfo(globalization, false);

        //    if (dateTime == DateTime.MinValue || (dateTime.Year == 1900 && dateTime.Month == 1))
        //        return "";
        //    else
        //        return dateTime.ToString(format, ci);
        //}

        public static string DateTime2ShortString(DateTime dateTime)
        {
            //if (dateTime == DateTime.MinValue || (dateTime.Year == 1900 && dateTime.Month == 1))
            //    return "";
            //else
            //    return dateTime.ToString("yyyy-MM-dd");
            return DateTime2String(dateTime, "yyyy-MM-dd");
        }



        public static DateTime DateTime2DateTime(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue || (dateTime.Year == 1900 && dateTime.Month == 1))
                dateTime = DateTime.Now;
            return dateTime;
        }



        public static bool Int2Bool(int sourceValue)
        {
            if (sourceValue > 0)
                return true;
            else
                return false;
        }

        public static string Int2String(int sourceValue)
        {
            if (sourceValue == 0)
                return "0";
            else
                return sourceValue.ToString();
        }

        public static string Decimal2String(decimal sourceValue)
        {
            if (sourceValue == 0)
                return "0";
            else
                return sourceValue.ToString();
        }

        public static string Decimal2String(int sourceValue, string format)
        {
            return sourceValue.ToString(format);
        }

        public static string Decimal2String(decimal sourceValue, string format)
        {
            return sourceValue.ToString(format);
        }

        public static string Bool2String(bool sourceValue, string val)
        {
            if (sourceValue)
                return val;
            else
                return "";
        }

        public static int Bool2Int(bool sourceValue)
        {
            if (sourceValue)
                return 1;
            else
                return 0;
        }

        public static string Dr2String(IDataReader dr, int position)
        {
            //return dr.IsDBNull(position) ? "" : dr.GetString(position);
            return dr[position] == DBNull.Value ? "" : dr[position].ToString();
        }

        public static string Dr2String(IDataReader dr, string fieldname)
        {
            //return dr.IsDBNull(position) ? "" : dr.GetString(position);
            return dr[fieldname] == DBNull.Value ? "" : dr[fieldname].ToString();
        }

        public static int Dr2Int(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? 0 : dr.GetInt32(position);
        }

        public static decimal Dr2Decimal(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? 0 : dr.GetDecimal(position);
        }

        public static int Dr2DecimalInt(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? 0 : (int)dr.GetDecimal(position);
        }

        public static bool Dr2DecimalBool(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? false : Object2Bool(dr.GetDecimal(position));
        }

        public static DateTime Dr2DateTime(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? DateTime.MinValue : dr.GetDateTime(position);
        }

        public static DateTime? Dr2DateTimeEx(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? null : (Nullable<DateTime>)dr.GetDateTime(position);
        }

        public static bool Dr2Bool(IDataReader dr, int position)
        {
            return dr.IsDBNull(position) ? false : dr.GetBoolean(position);
        }

        public static string StringSubString(string sourceValue, int startIndex, int length)
        {
            if (sourceValue.Length > length + startIndex)
                return sourceValue.Substring(startIndex, length);
            else
                return sourceValue;
        }

        public static bool Null2Bool(Nullable<bool> sourceValue)
        {
            bool dvalue = false;
            if (sourceValue == null)
                dvalue = false;
            else
                dvalue = sourceValue.Value;

            return dvalue;
        }

        public static int Null2Int(Nullable<int> sourceValue)
        {
            int dvalue = 0;
            if (sourceValue == null)
                dvalue = 0;
            else
                dvalue = sourceValue.Value;

            return dvalue;
        }

        public static decimal Null2Decimal(Nullable<decimal> sourceValue)
        {
            decimal dvalue = 0;
            if (sourceValue == null)
                dvalue = 0;
            else
                dvalue = sourceValue.Value;

            return dvalue;
        }

        //public static object GetMemberValue(object dataSource, string propertyName)
        //{
        //    object data = null;
        //    MemberInfo[] mis;
        //    MemberInfo mi = null;

        //    mis = dataSource.GetType().GetMember(propertyName);
        //    if (mis.Length > 0)
        //        mi = mis[0];
        //    if (mi != null)
        //    {
        //        if (mi.MemberType == MemberTypes.Property)
        //        {
        //            data = ((PropertyInfo)mi).GetValue(dataSource, null);
        //        }
        //        else if (mi.MemberType == MemberTypes.Field)
        //        {
        //            data = ((FieldInfo)mi).GetValue(dataSource);
        //        }
        //    }

        //    return data;
        //}


        /// <summary>
        /// 将数字金额转换成大写金额
        /// </summary>
        /// <param name="decimalChargeTotal"></param>
        /// <returns></returns>
        public static string Number2Capital(decimal decimalChargeTotal)
        {
            if (decimalChargeTotal == 0)
            {
                return "零元整";
            }
            string strDecimal = decimalChargeTotal.ToString("0.00");
            string strChargeTotal = "";

            for (int i = 0; i < strDecimal.Length - 3; i++)
            {
                if (strDecimal[i] != '0')
                {
                    if (i > 0)
                    {
                        if (strDecimal[i - 1] == '0')
                        {
                            strChargeTotal += "零";
                        }
                    }
                }
                else
                {
                    if (strDecimal.Length - 3 - i == 5)
                    {
                        strChargeTotal += "万";
                    }
                    else if (strDecimal.Length - 3 - i == 9)
                    {
                        strChargeTotal += "亿";
                    }
                    continue;
                }
                strChargeTotal += Number2Capital(strDecimal[i]);
                switch (strDecimal.Length - 3 - i)
                {
                    case 9:
                        strChargeTotal += "亿";
                        break;
                    case 5:
                        strChargeTotal += "万";
                        break;
                    case 12:
                    case 8:
                    case 4:
                        strChargeTotal += "仟";
                        break;
                    case 11:
                    case 7:
                    case 3:
                        strChargeTotal += "佰";
                        break;
                    case 10:
                    case 6:
                    case 2:
                        strChargeTotal += "拾";
                        break;
                }
            }
            strChargeTotal += "元";

            if (strDecimal[strDecimal.Length - 2] != '0')
            {
                strChargeTotal += Number2Capital(strDecimal[strDecimal.Length - 2]);
                strChargeTotal += "角";
                if (strDecimal[strDecimal.Length - 1] != '0')
                {
                    strChargeTotal += Number2Capital(strDecimal[strDecimal.Length - 1]);
                    strChargeTotal += "分";
                }
                else
                {
                    strChargeTotal += "整";
                }
            }
            else
            {
                if (strDecimal[strDecimal.Length - 1] != '0')
                {
                    strChargeTotal += "零";
                    strChargeTotal += Number2Capital(strDecimal[strDecimal.Length - 1]);
                    strChargeTotal += "分";
                }
                else
                {
                    strChargeTotal += "整";
                }
            }

            return strChargeTotal;
        }

        /// <summary>
        /// 将数字转换成大写
        /// </summary>
        /// <param name="Money">数字</param>
        /// <returns>大写</returns>
        public static string Number2Capital(char num)
        {
            string strCapital = "";
            switch (num)
            {
                case '0':
                    strCapital = "零";
                    break;
                case '1':
                    strCapital = "壹";
                    break;
                case '2':
                    strCapital = "贰";
                    break;
                case '3':
                    strCapital = "叁";
                    break;
                case '4':
                    strCapital = "肆";
                    break;
                case '5':
                    strCapital = "伍";
                    break;
                case '6':
                    strCapital = "陆";
                    break;
                case '7':
                    strCapital = "柒";
                    break;
                case '8':
                    strCapital = "捌";
                    break;
                case '9':
                    strCapital = "玖";
                    break;
            }
            return strCapital;
        }

        public static string Number2Chinese(char num)
        {
            string strCapital = "";
            switch (num)
            {
                case '0':
                    strCapital = "〇";
                    break;
                case '1':
                    strCapital = "一";
                    break;
                case '2':
                    strCapital = "二";
                    break;
                case '3':
                    strCapital = "三";
                    break;
                case '4':
                    strCapital = "四";
                    break;
                case '5':
                    strCapital = "五";
                    break;
                case '6':
                    strCapital = "六";
                    break;
                case '7':
                    strCapital = "七";
                    break;
                case '8':
                    strCapital = "八";
                    break;
                case '9':
                    strCapital = "九";
                    break;
            }
            return strCapital;
        }

        public static string Number2Chinese(int num)
        {
            string nums = num.ToString();
            string numc = string.Empty;
            foreach (char c in nums)
            {
                numc += Number2Chinese(c);
            }

            return numc;
        }

        public static bool IsNullOrZero(Type type, object fieldValue)
        {
            bool nz = false;
            if (type.Equals(typeof(System.Nullable<int>)) || type.Equals(typeof(int)))
            {
                if (Object2Int(fieldValue) == 0)
                    nz = true;
            }
            else if (type.Equals(typeof(System.Nullable<decimal>)) || type.Equals(typeof(decimal)))
            {
                if (Object2Decimal(fieldValue) == 0)
                    nz = true;
            }
            else if (type.Equals(typeof(System.Nullable<DateTime>)) || type.Equals(typeof(DateTime)))
            {
                if (Object2DateTime(fieldValue) == DateTime.MinValue)
                    nz = true;
            }
            else
            {
                if (Object2String(fieldValue).Length == 0)
                    nz = true;
            }
            return nz;
        }


        public static object GetFieldValue(Type type, string fieldValue)
        {
            object fieldObject = null;
            if (type.Equals(typeof(System.Nullable<int>)) || type.Equals(typeof(int)))
            {
                fieldObject = DataConvert.String2Int(fieldValue);
            }
            else if (type.Equals(typeof(System.Nullable<decimal>)) || type.Equals(typeof(decimal))
                || type.Equals(typeof(System.Nullable<double>)) || type.Equals(typeof(double)))
            {
                fieldObject = DataConvert.String2Decimal(fieldValue);
            }
            else if (type.Equals(typeof(System.Nullable<DateTime>)) || type.Equals(typeof(DateTime)))
            {
                fieldObject = DataConvert.String2DateTime(fieldValue);
            }
            else
            {
                fieldObject = fieldValue;
            }
            return fieldObject;
        }


        //public static void SetValue(ref CourseInfo obj, string fieldName, string fieldValue)
        //{
        //    System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(fieldName);
        //    if (pi != null)
        //    {
        //        if (pi.PropertyType.Equals(typeof(System.Nullable<int>)) || pi.PropertyType.Equals(typeof(int)))
        //        {
        //            pi.SetValue(obj, Object2Int(fieldValue), null);
        //        }
        //        else if (pi.PropertyType.Equals(typeof(System.Nullable<decimal>)) || pi.PropertyType.Equals(typeof(decimal))
        //                || pi.PropertyType.Equals(typeof(System.Nullable<double>)) || pi.PropertyType.Equals(typeof(double)))
        //        {
        //            pi.SetValue(obj, Object2Decimal(fieldValue), null);
        //        }
        //        else if (pi.PropertyType.Equals(typeof(System.Nullable<DateTime>)) || pi.PropertyType.Equals(typeof(DateTime)))
        //        {
        //            pi.SetValue(obj, Object2DateTime(fieldValue), null);
        //        }
        //        else
        //        {
        //            pi.SetValue(obj, Object2String(fieldValue), null);
        //        }
        //    }
        //}

        /// <summary>
        /// 转换成 Oracle 数据库时间格式

        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string DateTime2OracleDateTime(DateTime dateTime)
        {
            return DateTime2String(dateTime, "dd-MM-yyyy HH:mm:ss");
        }

        public static string DateTime2OracleDateTime(string dateTime)
        {
            return DateTime2OracleDateTime(String2DateTime(dateTime));
        }

        public static string String2LikeString(string str)
        {
            return "%" + DataConvert.String2Empty(str) + "%";
        }

        //public static List<SelectInfo2> String2TextValue(string DataString, char split1, char split2)
        //{
        //    List<SelectInfo2> list = new List<SelectInfo2>();
        //    if (DataString != null && DataString != "")
        //    {
        //        List<string> listData = DataString.Split(split1).ToList();
        //        foreach (string data in listData)
        //        {
        //            SelectInfo2 item = new SelectInfo2(data.Split(split2).First(), data.Split(split2).Last());

        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}

        //时间段分钟转换为小时分钟
        public static string ToHourMinutes(double minutes)
        {
            string ret = "";
            if (minutes < 1)
            {
                ret = "小于1分钟";
            }
            else
            {
                int h = (int)(minutes / 60);
                if (h == 0)
                {
                    ret = minutes.ToString("0.00") + "分钟";
                }
                else
                {
                    ret = h.ToString() + "小时" + (minutes - h * 60).ToString("0.00") + "分钟";
                }
            }
            return ret;
        }
    }
}
