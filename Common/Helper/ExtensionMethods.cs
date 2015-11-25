using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Common.Helper
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtensionMethods
    {
        #region 数据转换
        public static int ToInt(this object obj)
        {
            return CommonHelper.ObjToInt(obj);
        }

        public static string ToStr(this object obj)
        {
            return CommonHelper.ObjToStr(obj);
        }

        public static decimal ToDecimal(this object obj)
        {
            return CommonHelper.ObjToDecimal(obj);
        }


        public static int? ToIntNull(this object obj)
        {
            return CommonHelper.ObjToIntNull(obj);
        }

        public static decimal? ToDecimalNull(this object obj)
        {
            return CommonHelper.ObjToDecimalNull(obj);
        }

        public static bool ToBool(this object obj)
        {
            return CommonHelper.ObjToBool(obj);
        }



        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime? ToDateNull(this object obj)
        {
            return CommonHelper.ObjToDateNull(obj);
        }

        public static double ToDouble(this decimal value)
        {
            return Convert.ToDouble(value);
        }
        #endregion


        #region 常见判断扩展函数
        /// <summary>
        /// 判断一个整数是否为有效的 Id，增强代码可读性
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsId(this int value)
        {
            return value > 0;
        }

        /// <summary>
        /// 判断一个数值是否存在于集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool In<T>(this T t, IEnumerable<T> enumerable)
        {
            return enumerable.Contains(t);
        }

        /// <summary>
        /// 判断一个字符串是否存在于数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool In(this string str, params string[] args)
        {
            foreach (var arg in args)
            {
                if (arg.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断数值是否在指定的范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="minT"></param>
        /// <param name="maxT"></param>
        /// <returns></returns>
        public static bool InRange<T>(this IComparable<T> t, T minT, T maxT)
        {
            return t.CompareTo(minT) >= 0 && t.CompareTo(maxT) <= 0;
        }


        /// <summary>
        /// 根据字符串进行分隔
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitString"></param>
        /// <returns></returns>
        public static string[] Split(this string str, string splitString)
        {
            return str.Split(new[] { splitString }, StringSplitOptions.None);
        }

        /// <summary>
        /// 格式化字符串，等同于 string.Format()
        /// Luoly 090728
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string FormatString(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }


        /// <summary>
        /// 返回不带时间的日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ShortDateValue(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        #endregion

        #region TryCatch 扩展
        /// <summary>
        /// TryCatch 扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">要执行的动作</param>
        /// <param name="failureAction">失败的委托</param>
        /// <param name="successAction">成功的委托</param>
        /// <returns>如果成功返回 True</returns>
        public static bool TryCatch<T>(this T source, Action<T> action,
Action<Exception> failureAction, Action<T> successAction) where T : class
        {
            try
            {
                action.Invoke(source);
                successAction.Invoke(source);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(ex.StackTrace);
#endif
                failureAction.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// TryCatch 扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">要执行的动作，只能是表达式</param>
        /// <param name="failureAction">失败的委托</param>
        /// <returns>如果成功返回 True</returns>
        public static bool TryCatch<T>(this T source, Action<T> action, Action<Exception> failureAction) where T : class
        {
            return source.TryCatch<T>(action, failureAction, c => { });
        }

        /// <summary>
        /// TryCatch 扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source"></param>
        /// <param name="func">要执行的函数，只能是表达式</param>
        /// <param name="failureAction">失败的委托</param>
        /// <param name="successAction">成功的委托</param>
        /// <returns></returns>
        public static U TryCatch<T, U>(this T source, Func<T, U> func,
            Action<Exception> failureAction, Action<T> successAction) where T : class
        {
            try
            {
                var result = func.Invoke(source);
                successAction.Invoke(source);
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(ex.StackTrace);
#endif
                failureAction.Invoke(ex);
                return default(U);
            }
        }

        /// <summary>
        /// TryCatch 扩展
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="source"></param>
        /// <param name="func">要执行的函数，只能是表达式</param>
        /// <param name="failureAction">失败的委托</param>
        /// <returns></returns>
        public static U TryCatch<T, U>(this T source, Func<T, U> func, Action<Exception> failureAction) where T : class
        {
            return source.TryCatch<T, U>(func, failureAction);
        }

        #endregion


    }
}
