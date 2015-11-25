using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;

namespace Common
{
    /// <summary>
    /// DWZ Ui框架字符串服务类
    /// </summary>
    public class DWZUtil
    {
        /// <summary>
        /// 移除翻页参数中的首位逗号
        /// </summary>
        /// <param name="str">翻页参数名称</param>
        /// <returns></returns>
        public static string RemoveCommaPager(string parmName)
        {
            string temp = RequestBase.GetString(parmName) + "#";
            temp = temp.Replace(",#", "").Replace("#", "");
            ///如果存在多个参数值 则返回第一个，排序字段参数除外
            if (temp.IndexOf(",") >= 0)
            {
                return temp.Split(',')[0];
            }
            return temp;
        }

        /// <summary>
        /// 返回Json格式数据到客户端
        /// </summary>
        /// <param name="result"></param>
        public static void ReturnAjaxResult(string result)
        {
            StringBuilder JsonString = new StringBuilder();
            try
            {
                JsonString.Append(result);
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

        /// <summary>
        /// 生成ajax表单提交结果Json数据集
        /// </summary>
        /// <param name="statusCode">statusCode=DWZ.statusCode.ok表示操作成功, 做页面跳转等操作. statusCode=DWZ.statusCode.error表示操作失败, 提示错误原因. statusCode=DWZ.statusCode.timeout表示session超时，下次点击时跳转到DWZ.loginUrl</param>
        /// <param name="message">提示信息</param>
        /// <param name="navTabId">服务器转回navTabId可以把那个navTab标记为reloadFlag=1, 下次切换到那个navTab时会重新载入内容.</param>
        /// <param name="forwardUrl">只有callbackType="forward"时需要forwardUrl值</param>
        /// <param name="callbackType">callbackType如果是closeCurrent就会关闭当前tab</param>
        /// <returns></returns>
        public static string GetResultJson(string statusCode, string message, string navTabId, string forwardUrl, string callbackType)
        {
            string strJson = "";
            switch (statusCode)
            {
                case "200":
                    strJson = "{\"statusCode\":\"200\", \"message\":\"" + message + "\", \"navTabId\":\"" + navTabId + "\", \"forwardUrl\":\"" + forwardUrl + "\", \"callbackType\":\"" + callbackType + "\"}";
                    break;
                case "300":
                    strJson = "{\"statusCode\":\"300\", \"message\":\"" + message + "\"}";
                    break;
                case "301":
                    strJson = "{\"statusCode\":\"301\", \"message\":\"" + message + "\"}";
                    break;
            }
            return strJson;
        }

        // {
        //    "statusCode":"200",
        //    "message":"\u64cd\u4f5c\u6210\u529f",
        //    "navTabId":"",
        //    "rel":"jbsxBox",
        //    "callbackType":"",
        //    "forwardUrl":"",
        //    "confirmMsg":""
        //}
        /// <summary>
        /// AjaxTodo 返回值
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="navTabId"></param>
        /// <param name="forwardUrl"></param>
        /// <param name="callbackType"></param>
        /// <param name="rel"></param>
        /// <param name="confirmMsg"></param>
        /// <returns></returns>
        public static string GetAjaxTodoJson(string statusCode, string message, string navTabId, string forwardUrl, string callbackType, string rel, string confirmMsg)
        {
            string strJson = "";
            strJson = "{\"statusCode\":\"200\", \"message\":\"" + message + "\", \"navTabId\":\"" + navTabId + "\",\"rel\":\"" + rel + "\", \"callbackType\":\"" + callbackType + "\", \"forwardUrl\":\"" + forwardUrl + "\", \"confirmMsg\":\"" + confirmMsg + "\"}";
            return strJson;
        }
        /// <summary>
        /// Json字符串通用格式，用户下拉菜单绑定，页面绑定 [控件ID，控件值，控件类型，回调函数]
        /// [[a,b,c,*],[d,e,f,*]]
        /// </summary>
        public static string JsonStr1 = "[\"{0}\",\"{1}\",\"{2}\",\"{3}\"]";

        /// <summary>
        /// [操作人：刘文杰]
        /// [操作时间：2012/8/1]
        /// AjaxTodo 返回值 如需执行回调函数(navTabPageBreak除外)，请将callbackIsFun=true
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="navTabId"></param>
        /// <param name="forwardUrl"></param>
        /// <param name="callbackType"></param>
        /// <param name="rel"></param>
        /// <param name="confirmMsg"></param>
        /// <param name="callbackIsFun">callbackIsFun=true 执行回调函数，例如callbackType="getJS()"</param>
        /// <returns></returns>
        public static string GetAjaxTodoJsonCallBack(string statusCode, string message, string navTabId, string forwardUrl, string callbackType, string rel, string confirmMsg, string callbackIsFun)
        {
            string strJson = "";
            strJson = "{\"statusCode\":\"200\", \"message\":\"" + message + "\", \"navTabId\":\"" + navTabId + "\",\"rel\":\"" + rel + "\", \"callbackType\":\"" + callbackType + "\", \"forwardUrl\":\"" + forwardUrl + "\", \"confirmMsg\":\"" + confirmMsg + "\", \"callbackIsFun\":\"" + callbackIsFun + "\"}";
            return strJson;
        }

    }
}
