using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using PagedList;
using Models;
using System.Data;
using System.Configuration;
using System.Text;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapvipCenterController : BaseWapController
    {

        private readonly BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
        private readonly BLL.RegionBase regbll = new BLL.RegionBase();
        private readonly BLL.NewsBase _newsBase = new BLL.NewsBase();
        ListModel model = new ListModel();
        //会员中心首页
        public ActionResult VipCenterIndex()
        {
            int mid = 0;
            Model.MemberInfo model = null;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                ViewData["isLogin"] = true; 
                model = new BLL.MemberBase().getMemberInfo(mid);
                var tjlist = _productRecommendDetail.GetTop4List(" order by prt_id desc");
                var models = new Models.ListModel();
                models.dt = tjlist;
                models.Minfo = model;

                return View(models);

            }
            else
            {
                ViewData["isLogin"] = false ;
            }
            return View();
        }

        //会员中心订单
        Model.OrderBase omodel = new Model.OrderBase();
        BLL.OrderBase obll = new BLL.OrderBase();
        Model.vw_Orderpinfo vomodel = new Model.vw_Orderpinfo();
        BLL.vw_Orderpinfo vobll = new BLL.vw_Orderpinfo();
        public ActionResult VipOrder()
        {
            int status = 0;
            int mid = 0;
            List<Model.OrderBase> order = new List<Model.OrderBase>();
            List<Model.vw_Orderpinfo> lvlist = new List<Model.vw_Orderpinfo>();
            if (!string.IsNullOrEmpty(RequestBase.GetString("status")))
            {
                status = Convert.ToInt32(RequestBase.GetString("status"));
                ViewData["status"] = status;
            }

            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                if (status == 0)
                {
                    order = new BLL.OrderBase().GetModelList(" m_ID=" + mid + " and o_IsDel=0 and o_StatusCode=" + status + " or o_StatusCode=5 ");
                    lvlist = vobll.GetModelList(" o_IsDel=0 and  m_ID=" + mid + " and o_StatusCode=" + status + " or o_StatusCode=5 ");//5是退货
                }
                else if (status ==23)
                {
                    order = new BLL.OrderBase().GetModelList(" m_ID=" + mid + " and o_IsDel=0 and o_StatusCode=2 or o_StatusCode=3");
                    lvlist = vobll.GetModelList(" o_IsDel=0 and  m_ID=" + mid + " and o_StatusCode=2 or o_StatusCode=3");
                }
                else
                {
                    order = new BLL.OrderBase().GetModelList(" m_ID=" + mid + " and o_IsDel=0 and o_StatusCode=" + status);
                    lvlist = vobll.GetModelList(" o_IsDel=0 and  m_ID=" + mid + " and o_StatusCode=" + status);
                }
                    ViewBag.order = order;
                return View(lvlist.ToList());
            }
            else
            {
                Response.Redirect("/wapLogin/Login");
                return View();
            }
        }
        //订单详情
        public ActionResult VipOrderDetail()
        {
            int oid = 0;
            int mid = 0;
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("oid")))
                {
                    oid = int.Parse(RequestBase.GetString("oid"));
                }
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                //订单信息
                ViewBag.orderinfo = obll.GetModel(oid);
                ViewData["status"] = ViewBag.orderinfo.o_StatusCode;
                Model.ConsigneeInfoBase conmodel = new Model.ConsigneeInfoBase();
                int? cid = obll.GetModel(oid).c_ID;
                //收货人信息
                ViewBag.coninfo = new BLL.ConsigneeInfoBase().GetModel(int.Parse(cid.ToString()));
                //订单商品明细
                var orderskulist = vobll.GetModelList(" m_ID=" + mid + " and o_ID=os_oID and o_Code='" + obll.GetModel(oid).o_Code + "'");
                if (orderskulist.Count > 0)
                {
                    ViewBag.ordersku = orderskulist;
                    string skulist = "";
                    string countlist = "";
                    decimal pricecount=0;
                    foreach (var sku in ViewBag.ordersku)
                    {
                        skulist += sku.sku_ID + ",";
                        countlist += sku.os_pCount + ",";
                        pricecount += sku.sku_Price * sku.os_pCount;
                    }
                    skulist = skulist.Substring(0, skulist.Length - 1);
                    countlist = countlist.Substring(0, countlist.Length - 1);
                    ViewData["skulist"] = skulist;
                    ViewData["countlist"] = countlist;
                    ViewData["yuanjia"] = pricecount;
                }
                ////支付方式
                ViewBag.payfor = new BLL.PaymentBase().GetModel(int.Parse(obll.GetModel(oid).pay_ID.ToString()));
                //配送方式
                ViewBag.stname = new BLL.ShipTypeBase().GetModel(int.Parse(obll.GetModel(oid).st_ID.ToString()));
                //订单追踪
                ViewBag.orderstatus = new BLL.OrderStatusBase().GetModelList(" o_ID=" + oid + " and os_IsDel=0");
                //折扣
                var member = new BLL.MemberBase().GetModel(mid);
                if (member != null)
                {
                    var ranklist = new BLL.VipRank().GetModelList(member.m_Score + " between r_score and r_upperscore ");
                    if (ranklist.Count > 0)
                    {
                        ViewData["zhek"] = ranklist[0].r_ZheK;
                    }
                }
                ViewData["maxstatus"] = new BLL.OrderStatusBase().Getmaxstatus(" o_ID=" + oid + " and os_IsDel=0");
                return View();
            }
            else
            {
                Response.Redirect("/wapLogin/Login");
                return View();
            }
        }

        public string cancelOrder()
        {
            int oid =0;
            int mid = 0;
            bool result = false;
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("oid")))
                {
                    oid = int.Parse(RequestBase.GetString("oid"));
                }
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                Model.OrderBase order = new BLL.OrderBase().GetModel(oid);
                if (order.o_StatusCode < 2)
                {
                    order.o_StatusCode = 5;//已取消
                    result = new BLL.OrderBase().Update(order);
                    if (result)
                    {
                        return "已取消";
                    }
                    else
                    {
                        return "系统异常，稍候再试";
                    }
                }
                else
                {
                    return "已付款，请至PC端申请退单";
                }
            }
            else
            {
                Response.Redirect("/wapLogin/Login");
                return "";
            };
        }

        //我的收藏
        public ActionResult VipMycollect()
        {
            var model = new ListModel();
            string where2 = "";
            int page = 1;
            string skulist = "";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

                ViewData["mid"] =mid;
                Model.VipCollectionBase cmodel = new Model.VipCollectionBase();
                var clist = new BLL.VipCollectionBase().GetModelList(" m_Id=" + mid + " and vc_IsDel=0");
                if (clist.Count > 0)
                {
                    ViewData["collect"] = true;
                    foreach (var item in clist)
                    {
                        skulist += item.sku_ID + ",";
                    }
                    skulist = skulist.Substring(0, skulist.Length - 1);
                    where2 = " and  sku_ID in(" + skulist + ")";

                    List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + where2);

                    return View(list.ToList());
                }
                else
                {
                    ViewData["collect"] = false;
                    return View();
                }
            }
            else
            {
                Response.Redirect("/wapLogin/Login");
                return View();
            }
        }

        //清空我的收藏
        public bool delcollect()
        {
            int mid=0;
            bool result = true;
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                mid = int.Parse(Request.QueryString["mid"]);
                result = new BLL.VipCollectionBase().DeleteList(" m_id =" + mid);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //历史浏览记录
        public ActionResult VipMyHistory()
        {
            HttpCookie history = Request.Cookies["history"];
            if (history != null)
            {
                history.Expires.AddMinutes(100);
                string[] skuid = history.Values.AllKeys;
                string where = "";
                if (skuid.Length > 0)
                {
                    for (int i = 0; i < skuid.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(skuid[i]))
                        {
                            int skuidint = int.Parse(skuid[i]);
                            where += skuidint + " ,";
                        }
                    }
                    where = where.Substring(0, where.Length - 1);
                    model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1 and sku_ID in( " + where + ")");//商品信息

                    ViewBag.history = model.vmpinfolist;
                    history.Expires.AddMinutes(100);
                    Response.Cookies.Add(history);
                }
            }
            else
            {
                ViewBag.history = null;
            }
            return View();
        }

        //清空历史浏览记录
        [HttpPost]
        public bool Delhistory()
        {
            var cookies = Response.Cookies["History"];
            if (cookies != null)
            {
                CookieHelper.RemovedCookie("History");
                return true;
            }

            return false;
        }
        //下方菜单
        public ActionResult bottomMenu()
        {
            int count = 0;
            BLL.ShoppingCartBase cart = new BLL.ShoppingCartBase();
            if (LoginMember != null)
            {
                var list = cart.GetModelList(" sc_IsDel = 0 and m_ID = " + LoginMember.m_ID);
                if (list != null)
                {
                    count = list.Sum(m => m.sc_pCount.Value);
                }
            }

                ViewData["count"] = count;
                return View();
        }
    }
}
