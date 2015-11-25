using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public class AjaxHelper
    {

        #region 发送数据到客户端
        /// <summary>
        /// 发送数据到客户端
        /// </summary>
        /// <param name="message"></param>
        public static void ResponseWrite(string message)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/html";
            HttpContext.Current.Response.Write(message.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 发送数据到客户端
        /// </summary>
        /// <param name="message"></param>
        public static void ResponseWriteXML(string xml)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(xml);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 发送JSon数据到客户端
        /// </summary>
        /// <param name="json"></param>
        public static void ResponseWriteJson(string json)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.Write(json);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
        #endregion

        #region 返回Json格式数据到客户端
        /// <summary>
        /// 返回Json格式数据到客户端
        /// </summary>
        /// <param name="arrItems"></param>
        public static void ResponseWriteForJson(ArrayList arrItems)
        {
            StringBuilder JsonString = new StringBuilder();
            try
            {
                if (arrItems != null)
                {
                    JsonString.Append("{\"totalCount\":" + (arrItems.Count + 1) + ",");
                    JsonString.Append("\"JsonData\":[");
                    JsonString.Append("{'result':'success'},");
                    int i = 0;
                    foreach (object item in arrItems)
                    {
                        if (i == arrItems.Count - 1)
                            JsonString.Append("{ 'option':'" + item.ToString() + "'}");
                        else
                            JsonString.Append("{ 'option':'" + item.ToString() + "'},");

                        i++;
                    }
                    JsonString.Append("]}");
                }
                else
                {
                    JsonString.Append("{\"totalCount\":1,");
                    JsonString.Append("\"JsonData\":[");
                    JsonString.Append("{'result':'error'}");
                    JsonString.Append("]}");
                }
            }
            catch (Exception err)
            {
                JsonString.Append(err.Message);
            }
            finally
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(JsonString.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }

        #endregion

        #region 返回Json格式数据到客户端
        /// <summary>
        /// 返回Json格式数据到客户端
        /// </summary>
        /// <param name="arrItems"></param>
        public static void ResponseWriteForJson2(ArrayList arrItems)
        {
            StringBuilder JsonString = new StringBuilder();
            try
            {
                if (arrItems != null)
                {
                    JsonString.Append("[");
                    int i = 0;
                    foreach (object item in arrItems)
                    {
                        if (i == arrItems.Count - 1)
                            JsonString.Append("{" + item.ToString() + "}");
                        else
                            JsonString.Append("{" + item.ToString() + "},");

                        i++;
                    }
                    JsonString.Append("]");
                }
            }
            catch (Exception err)
            {
                JsonString.Append(err.Message);
            }
            finally
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(JsonString.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }
        #endregion

        #region 处理XML中的特殊字符
        /// <summary>
        /// 处理XML中的特殊字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string DisposeXML(string content)
        {
            content = content.Replace("<", "&lt;").Replace("&", "&amp;").Replace(">", "&gt;");
            return content;
        }
        #endregion
    }
}
