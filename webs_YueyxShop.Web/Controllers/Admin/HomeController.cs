using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.BLL;
using webs_YueyxShop.Model;
using System.ServiceModel;
using System.Net;
using System.Net.Sockets;
using Common;
using System.Text;
using System.Threading;
using System.Data;

namespace webs_YueyxShop.Web
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 功能：菜单显示，信息提醒
        /// </summary>
        SocketClient client = new SocketClient();
        byte[] recBuffer = new byte[24];
        public ActionResult Index()
        {
            List<Model.MenuBase> menuList = new List<Model.MenuBase>(); ;
            BLL.MenuBase mbBLL = new BLL.MenuBase();
            ViewData["UserName"] = base.EmployeeBase.e_MingC;
            ViewData["UserId"] = base.EmployeeBase.e_ID;
            if (EmployeeBase.e_ID == Guid.Parse("7A571A64-EF3D-46D2-9B90-6356315ACFD1"))
            {
                menuList = mbBLL.GetModelList(" m_DeleteStateCode=0 and m_StateCode=0   order by m_PaiX ASC");
            }
            else
            {
                menuList = mbBLL.GetModelList(" m_DeleteStateCode=0 and m_StateCode=0 and m_ID in(select m_ID from RolesMenuDetails where r_ID in(select r_ID from EmpRolesDetails where e_ID='" + base.EmployeeBase.e_ID + "'))  order by m_PaiX ASC");
            }
            return View(menuList);
        }

        public ActionResult Exception()
        {
            //if (TempData["ExceptionAttributeMessages"] != null)
            //{
            //    ViewData["ExceptionMessages"] = TempData["ExceptionAttributeMessages"];
            //}
            //else
            //{
            //    ViewData["ExceptionMessages"] = "未知...";
            //}
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetBianMa()
        {
            dataWork dw = new dataWork();
            StringBuilder str = new StringBuilder();
            str.Append(" select  top 1* from BuildingEquipmentBase ");
            str.Append(" where be_DeleteStateCode=0  and b_ID>87 order by b_ID asc ");
            string sql = string.Format(str.ToString());
            DataTable dt = dw.GetDS(sql.ToString()).Tables[0];
            return dt;
        }


        public void ReceiveMessage(IAsyncResult ar)
        {
            var socket = ar.AsyncState as Socket;
            //方法参考：http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.endreceive.aspx
            var length = socket.EndReceive(ar);
            byte[] newbyte = recBuffer;
            //处理
            int count = Convert.ToInt32(Session["s_count"]);
            int i = Convert.ToInt32(Session["s_i"]);
            if (i < count)
            {
                socket.BeginReceive(newbyte, 0, newbyte.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
                i++;
            }
        }

        public string GetLocalHostIP()
        {
            IPHostEntry localhost = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress address = localhost.AddressList[0];

            string IP = address.ToString();
            return IP;
        }

    }
}
