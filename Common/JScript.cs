using System.Web.UI;

namespace Common
{
    public class JScript
    {
        public JScript()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        #region Alert相关
        /// <summary>
        /// 弹出提示
        /// </summary>
        public static void Alert(string text, string type, Page page)
        {
            SCAlert(text, type, "", page);
        }
        /// <summary>
        /// 弹出提示
        /// </summary>
        public static void Alert(string text, string type, string oComplete, Page page)
        {
            SCAlert(text, type, oComplete, page);
        }
        /// <summary>
        /// 弹出并跳转
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="URL"></param>
        /// <param name="page"></param>
        public static void AlertAndRedirect(string text, string type, string URL, Page page)
        {
            SCAlert(text, type, "window.location.href=\"" + URL+"\";", page);
        }
        /// <summary>
        /// 弹出
        /// </summary>
        /// <param name="text"></param>
        /// <param name="page"></param>
        public static void SCAlert(string message, string type, string oComplete, Page page)
        {
            string functionName = "notify";
            switch (type)
            {
                case "Success":
                    functionName = "notify_s";
                    break;
                case "Info":
                    functionName = "notify_i";
                    break;
                case "Error":
                    functionName = "notify_e";
                    break;
                default:
                    functionName = "notify";
                    break;
            }
            string Script = "";
            if (!string.IsNullOrEmpty(oComplete))
                Script = "<Script language='JavaScript'>$(document).ready(function () {" + functionName + "('" + type + "', '" + message + "');setTimeout('" + oComplete + "',2000);});</Script>";
            else
                Script ="<Script language='JavaScript'>$(document).ready(function () {"+functionName+"('"+type+"', '"+message+"');});</Script>";


            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", Script);
        }

        #endregion
    }
}
