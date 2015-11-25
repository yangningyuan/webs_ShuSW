using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace webs_YueyxShop.Web._ashx
{
    /// <summary>
    /// AreaManager 的摘要说明
    /// </summary>
    public class AreaManager : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.QueryString["type"].ToString();
            if(type == "getshi")
                getarea(context);
            if(type == "getxian")
                getxian(context);
        }

        public void getxian(HttpContext context)
        {
            string id = context.Request.QueryString["id"].ToString();
            if (string.IsNullOrEmpty(id))
                return;
            BLL.RegionBase bll = new BLL.RegionBase();
            List<Model.RegionBase> list = bll.GetModelList(" reg_PID='" + id + "'");
            StringBuilder strhtml = new StringBuilder();
            foreach (Model.RegionBase model in list)
            {
                strhtml.Append("<li onclick=\"bindxianname(" + model.reg_Code + ",'" + model.reg_Name + "');\">" + model.reg_Name + "</li>");
            }
            context.Response.Write(strhtml.ToString());
        }

        public void getarea(HttpContext context)
        {
            string id = context.Request.QueryString["id"].ToString();
            if (string.IsNullOrEmpty(id))
                return;
            BLL.RegionBase bll = new BLL.RegionBase();
            List<Model.RegionBase> list = bll.GetModelList(" reg_PID='" + id + "'");
            StringBuilder strhtml = new StringBuilder();
            foreach (Model.RegionBase model in list)
            {
                strhtml.Append("<li onclick=\"bindxian(" + model.reg_Code + ",'" + model.reg_Name + "');\">" + model.reg_Name + "</li>");
            }
            context.Response.Write(strhtml.ToString());
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}