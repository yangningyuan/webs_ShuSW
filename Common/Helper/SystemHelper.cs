using System.Net;
using System.Web;

namespace Common.Helper
{
    /// <summary>
    /// 系统工具类,用于获取系统各种参数
    /// </summary>
    public static class SystemHelper
    {

        /*
         * 客户端IP：Page.Request.UserHostAddress
用户信息：Page.User;
服务器电脑名称：Page.Server.MachineName
当前用户电脑名称： System.Net.Dns.GetHostName()
当前电脑名： System.Environment.MachineName
当前电脑所属网域： System.Environment.UserDomainName
当前电脑用户： System.Environment.UserName

浏览器类型：Request.Browser.Browser
浏览器标识：Request.Browser.Id
浏览器版本号：Request.Browser.Version
浏览器是不是测试版本：Request.Browser.Beta
浏览器的分辨率(像素)：Request["width"].ToString() + "*" + Request["height"].ToString();//1280/1024

客户端的操作系统：Request.Browser.Platform
是不是win16系统：Request.Browser.Win16
是不是win32系统：Request.Browser.Win32

//获取真实IP
string GetIp()
{
//可以隔过代理IP获得真实IP
string userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
//没有代理服务器,如果有代理服务器获取的是代理服务器的IP
if (userIP == null || userIP == "")
{
userIP = Request.ServerVariables["REMOTE_ADDR"];
}
return userIP;
}
         */
        /// <summary>
        /// 获取电脑在局域网内的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp(System.Web.UI.Page page)
        {
            return page.Request.UserHostAddress;
        }

        /// <summary>
        /// 获取客户端机器名
        /// </summary>
        /// <returns></returns>
        public static string GetClientMachineName()
        {
            return System.Net.Dns.GetHostName();
        }

        /// <summary>
        /// 获取客户端 浏览器类型
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientBrowerType(HttpRequest request)
        {
            return request.Browser.Browser;
        }

        /// <summary>
        /// 获取客户端浏览器版本
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientBrowerVersion(HttpRequest request)
        {
            return request.Browser.Version;
        }

        /// <summary>
        /// 获取客户端电脑系统
        /// </summary>
        /// <returns></returns>
        public static string GetClientOS(HttpRequest request)
        {
            return request.Browser.Platform;
        }
        
        /// <summary>
        ///获取真实IP 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetIp(HttpRequest request)
        {
            //可以隔过代理IP获得真实IP
            string userIP = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //没有代理服务器,如果有代理服务器获取的是代理服务器的IP
            if (userIP == null || userIP == "")
            {
                userIP = request.ServerVariables["REMOTE_ADDR"];
            }
            return userIP;
        }
    }
}
