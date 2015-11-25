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

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class VipscoreController : MasterPageController
    {
        private BLL.RegionBase _regionBase = new BLL.RegionBase();
        BLL.ConsigneeInfoBase _consigneeInfo = new BLL.ConsigneeInfoBase();
        # region 我的积分
        public ActionResult vipscore()
        {
            int pageSize = 6;//每一页的行数
            int pageNumber = 1;//当前页数 
            DateTime from, to;
            string where = "";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

                Model.MemberBase mmodel = new Model.MemberBase();
                Model.OrderBase omodel = new Model.OrderBase();
                int fen = 0;
                decimal fenj = 0;
                var list = new BLL.OrderBase().GetModelListbypric(" m_ID=" + mid + " and o_StatusCode=4 and o_IsDel=0 order by o_CreateOn desc");
                foreach (var i in list)
                {
                    fen += int.Parse(i.o_Score.ToString());
                }
                var pagelist = list.ToPagedList(pageNumber, pageSize);
                var mlist = new BLL.MemberBase().GetModel(mid);
                ViewData["mScore"] = mlist.m_Score;
                ViewData["mid"] = mid;
                ViewData["count"] = list.Count;
                ViewData["pagerows"] = pageSize;
                ViewData["page"] = pageNumber;
                var jifen = new BLL.NewsBase().GetModelList(" n_Title='积分规则' and n_StatusCode=0 and n_IsDel=0");
                ViewBag.jifen = jifen[0].n_Content;
                ViewBag.orderinfo = pagelist.ToList();
                List<Model.RejectionBase> lvlist = new BLL.RejectionBase().GetModelList("  m_ID=" + mid + " and r_Status=2 and r_Isdelete=0");

                foreach (var i in lvlist)
                {
                    if ((i.r_Price.ToString()).IndexOf('.') > 0)
                    {
                        fenj += int.Parse((i.r_Price.ToString()).Substring(0, (i.r_Price.ToString()).IndexOf('.')));
                    }
                }
                if (fen - int.Parse(fenj.ToString()) > 0)
                {
                    ViewData["jifenshu"] = fen - int.Parse(fenj.ToString());
                }
                else
                {
                    ViewData["jifenshu"] = 0;
                }
                return View(lvlist.ToList());
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }

        //异步加载积分来源
        [HttpPost]
        public string vipscorepage()
        {
            int pageSize = 6;//每一页的行数
            int pageNumber = 1;//当前页数 
            string html = "";
            string skuid = "";
            DateTime from, to;
            string where = "";
            int mid = 0;

            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("m_ID")))
            {
                skuid = RequestBase.GetString("m_ID").ToString();
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("from")))
            {
                from = DateTime.Parse(RequestBase.GetString("from"));
                where += " and o_CreateOn >='" + from + "'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("to")))
            {
                to = DateTime.Parse(RequestBase.GetString("to")).AddDays(1);
                where += " and o_CreateOn <='" + to + "'";
            } if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

                var list = new BLL.OrderBase().GetModelListbypric(" m_ID="+mid+  where +" and o_StatusCode=4 and o_IsDel=0 order by o_CreateOn desc");
                ViewData["count"] = list.Count;
                ViewData["pagerows"] = pageSize;
                ViewData["page"] = pageNumber;
                var pagelist = list.ToPagedList(pageNumber, pageSize);
                List<Model.RejectionBase> lvlist = new BLL.RejectionBase().GetModelList("  m_ID=" + mid + " and r_Status=2");
                html = "<tr><th>时间</th><th>积分</th><th>类型</th><th>来源订单</th></tr>";
                foreach (var item in pagelist)
                {
                    html += "<tr><td>" + item.o_CreateOn + "</td>";
                        if(lvlist.Where(o => o.o_ID == item.o_ID).Count()==1)
                            { 
                                html += "<td>- "+item.o_Score+"</td><td>减少</td>";
                                
                            }
                            else
                            {
                                html += "<td>+ "+item.o_Score+"</td><td>增加</td>";
                            }           

                     html +=    "<td>" + item.o_Code + "</td></tr>";
                }
                return html;
            }
            else
            {
                Response.Redirect("/Index/Index");
                return "";
            }

        }
        //获取时间段内信息总数，返回给前台
        [HttpPost]
        public int getcount()
        {
            string html = "";
            string skuid = "";
            string ocode = "";
            DateTime from, to;
            string where = "";
            int mid = 0;

            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("from")))
            {
                from = DateTime.Parse(RequestBase.GetString("from"));
                where += " and o_CreateOn >='" + from + "'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("to")))
            {
                to = DateTime.Parse(RequestBase.GetString("to")).AddDays(1);
                where += " and o_CreateOn <='" + to + "'";
            }
            var list = new BLL.OrderBase().GetModelListbypric(" m_ID=" + mid + where + " and  o_IsDel=0  ");
            return list.Count;

        }
        # endregion

        # region 左侧菜单和下方推荐商品 会员中心通用 分部视图
        public ActionResult LeftMenu()
        {
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                Model.MemberBase mbmodel = new Model.MemberBase();
                mbmodel = new BLL.MemberBase().GetModel(mid);
                if (mbmodel.m_UserType == 0)
                {
                    ViewData["Iscompany"] = false;
                }
                else
                {
                    ViewData["Iscompany"] = true;
                }
            }

            return View();
        }

        //推荐商品
        public ActionResult Tuijian()
        {
            List<Model.ProductBase> pinfo = new BLL.ProductBase().GetpInfoByRecommendTypeId(1);
            return View(pinfo.ToList());
        }
        #endregion

        public ActionResult index()
        {
            Model.MemberInfo model = null;
            model = new BLL.MemberBase().getMemberInfo((CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID);
            var models = new Models.ListModel();
            models.Minfo = model;

            return View(model);
        }

        #region 我的收藏
        public ActionResult vipCollect()
        {
            var model = new ListModel();
            string where = "";
            string where2 = "";
            string sortby = "";
            int page = 1;
            int pagerows = 2;
            string skulist = "";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

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
                    where = " and  vw.sku_ID in(" + skulist + ")";
                    where2 = " and  sku_ID in(" + skulist + ")";

                    model.vmpinfolist = new BLL.vw_PInfo().GetModelListVC(" vc.m_ID=" + mid + " and p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and vw.sku_ID = vc.sku_ID and vc.vc_IsDel=0 " + where, page, pagerows, sortby);
                    List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + where2);

                    ViewData["count"] = list.Count;
                    ViewData["pagerows"] = pagerows;
                    ViewData["page"] = page;

                    return View(model.vmpinfolist);
                }
                else
                {
                    ViewData["collect"] = false;
                    return View();
                }
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }

        //异步加载收藏夹分页
        [HttpPost]
        public string collectpage()
        {
            int pageSize = 2;//每一页的行数
            int pageNumber = 1;//当前页数 
            string html = "";
            string skuid = "";
            string where = "";
            string where2 = "";
            string skulist = "";
            string sortby = "";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            Model.VipCollectionBase cmodel = new Model.VipCollectionBase();
            var clist = new BLL.VipCollectionBase().GetModelList(" m_Id=" + mid + " and vc_IsDel=0");
            if (clist.Count > 0)
            {
                foreach (var item in clist)
                {
                    skulist += item.sku_ID + ",";
                }
                skulist = skulist.Substring(0, skulist.Length - 1);
                where = " and sku_ID in(" + skulist + ")";
                where2 = " and  vw.sku_ID in(" + skulist + ")";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + where);
            ViewBag.collect = new BLL.vw_PInfo().GetModelListVC(" vc.m_ID=" + mid + " and p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and vw.sku_ID = vc.sku_ID and vc.vc_IsDel=0 " + where2, pageNumber, pageSize, sortby);
            //ViewBag.collect = list.ToPagedList(pageNumber, pageSize);
            foreach (var item in ViewBag.collect)
            {
                html += "<li><table class=\"order-list\"><tbody><tr><td width=\"345\"><div class=\"pro-imgs\"><a href=\"/ProDetail/ProDetail?skuid="+item.sku_ID+"\"><img name=\"page_cnt_1\" src=\""+item.pi_Url+"\" alt=\""+item.p_Name+"\" /></a></div><p><a href=\"/ProDetail/ProDetail?skuid="+item.sku_ID+"\">"+item.p_Name+" "+item.shuxing+"</a></p></td><td width=\"100\" align=\"center\">"+item.sku_Price+"</td><td width=\"80\" align=\"center\">"+item.vc_CreateOn+"</td><td width=\"90\" align=\"center\"><a href=\"javascript:void(0)\"  onclick=\"delcollect("+item.vc_id+")\">删除</a><br /><a href=\"javascript:void(0)\"  onclick=\"TuiinsertintoCart("+item.sku_ID+")\">添加到购物车</a><br /></td></tr></tbody></table></li>";
            }
            return html;

        }
        //删除收藏夹里的商品
        public bool delcollect()
        {
            string vcid = "";


            if (!string.IsNullOrEmpty(RequestBase.GetString("id")))
            {
                vcid = RequestBase.GetString("id").ToString();
            }
            Model.VipCollectionBase vcmodel = new Model.VipCollectionBase();
            bool result = new BLL.VipCollectionBase().Delete(int.Parse(vcid));

            return result;
        }

        #endregion

        #region  安全中心
        public ActionResult SafeCenter()
        {
            Model.MemberBase model = null;
            if (LoginMember != null)
            {
                model = new BLL.MemberBase().GetModel((CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID);
                var models = new Models.ListModel();
                models.member = model;
                if (model.m_mailyanzheng)
                {
                    ViewData["Isshenpi"] = true;
                }
                else
                {
                    ViewData["Isshenpi"] = false;
                }
                ViewData["email"] = "http://www." + model.m_Email.Substring(model.m_Email.IndexOf('@') + 1, model.m_Email.Length - model.m_Email.IndexOf('@') - 1);
                ViewData["mid"] = model.m_ID;
                return View(model);
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }

        }
        [HttpPost]
        public string sendemail()
        {
            int mid = 0;

            if (!string.IsNullOrEmpty(RequestBase.GetString("mid")))
            {
                mid = int.Parse(RequestBase.GetString("mid"));
            }
            string successemailpage = ConfigurationManager.AppSettings["RegisterSuccessPage"].ToString();
            string mailAccount = ConfigurationManager.AppSettings["mailAccount"].ToString();//发送者邮箱
            string mima = ConfigurationManager.AppSettings["mailPassWord"].ToString();//发送者邮箱密码
            string mailShowName = ConfigurationManager.AppSettings["mailShowName"].ToString();//邮件主题
            string url = GetUrl();
            Model.MemberBase model = new BLL.MemberBase().GetModel(mid);

            string body = "欢迎注册月月兴会员！请点击<div><a href='http://" + url + "?username=" + model.m_UserName + "&usertype=0'>月月兴验证</a>链接完成验证！(若不是本人操作，请忽略此邮件)</div>";
            if (MailMessageExtensions.SendMail(mailShowName, body, mailAccount, model.m_Email, mima))
            {
                return "http://www.mail." + model.m_Email.Substring(model.m_Email.IndexOf('@') + 1, model.m_Email.Length - model.m_Email.IndexOf('@') - 1); ;
            }
            else
            {
                return "";
            }
        }

        public string GetUrl()
        {
            string url = HttpContext.Request.Url.Authority;//域名

            string path = ConfigurationManager.AppSettings["RegisterSuccessPage"].ToString();//物理路径
            string stringurl = url + path;
            return stringurl;
        }
        #endregion

        #region 我的订单
        Model.OrderBase omodel = new Model.OrderBase();
        BLL.OrderBase obll = new BLL.OrderBase();
        Model.vw_Orderpinfo vomodel = new Model.vw_Orderpinfo();
        BLL.vw_Orderpinfo vobll = new BLL.vw_Orderpinfo();
        public ActionResult vipMyOrder()
        {

            int pageSize = 4;//每一页的行数
            int pageNumber = 1;//当前页数 
            int mid = 0;
            if (LoginMember != null)
            {

                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                var orderlist = obll.GetModelList(" m_ID=" + mid + " and o_IsDel=0 order by o_CreateOn desc");
                ViewBag.order = orderlist.ToPagedList(pageNumber, pageSize);
                ViewData["count"] = orderlist.Count;
                ViewData["pagerows"] = pageSize;
                ViewData["page"] = pageNumber;
                List<Model.vw_Orderpinfo> lvlist = vobll.GetModelList(" o_IsDel=0 and o_Id=os_oId and pi_IsDel=0 and  m_ID=" + mid + " order by o_CreateOn desc");
                
                return View(lvlist.ToList());
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }

        //异步加载订单分页
        [HttpPost]
        public string orderpage()
        {
            int pageSize = 4;//每一页的行数
            int pageNumber = 1;//当前页数 
            string html = "";
            string ocode = "";
            string where = "";
            DateTime from, to;
            int mid = 0;
            Model.OrderBase omodel = new Model.OrderBase();
            BLL.OrderBase obll = new BLL.OrderBase();
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("ocode")))
            {
                ocode = RequestBase.GetString("ocode").ToString();
                where += " and o_Code like '%" + ocode + "%'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("from")))
            {
                from = DateTime.Parse(RequestBase.GetString("from"));
                where += " and o_CreateOn >='" + from + "'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("to")))
            {
                to = DateTime.Parse(RequestBase.GetString("to")).AddDays(1);
                where += " and o_CreateOn <='" + to + "'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            var orderlist = obll.GetModelList(" o_IsDel=0 and m_ID=" + mid + where+" order by o_CreateOn desc");
            ViewBag.order = orderlist.ToPagedList(pageNumber, pageSize);
            List<Model.vw_Orderpinfo> lvlist = vobll.GetModelList(" o_IsDel=0 and o_Id=os_oId and m_ID=" + mid + " order by o_CreateOn desc");
            foreach (var i in ViewBag.order)
            {
                html += "<li><table class=\"order-list\"><tbody><tr><td width=\"140\"><p>" + i.o_Code + "</p><br /><p><strong>" + i.o_CreateOn + "</strong></p></td><td colspan=\"3\" width=\"510\"><table><tbody>";
                foreach (var ii in lvlist.Where(c => c.o_Code == i.o_Code))
                {
                    html += "<tr><td width=\"330\"><div class=\"pro-imgs\"><a href=\"/ProDetail/ProDetail?skuid=" + ii.sku_ID + "\"><img name=\"page_cnt_1\" src=\"" + ii.pi_Url + "\" alt=\"" + ii.p_Name + "\" /></a></div><p><a href=\"/ProDetail/ProDetail?skuid=" + ii.sku_ID + "\">" + ii.p_Name + "</a></p></td><td width=\"100\" align=\"center\">" + ii.sku_Price + "</td><td width=\"80\" align=\"center\">" + ii.os_pCount + "</td></tr>";
                }
                html += "</tbody></table></td><td width=\"90\" align=\"center\">" + i.o_Pric + "</td><td width=\"90\" align=\"center\">" + @i.o_StatusCode.ToString().Replace("0", "提交订单").Replace("1", "付款成功").Replace("2", "商品出库").Replace("3", "等待收货").Replace("4", "完成") + "</td><td width=\"90\" align=\"center\"><a  href=\"javascript:void(0)\" onclick=\"buyagain(" + i.o_ID + ")\">再次购买</a><br /><a href=\"/Vipscore/vipApplyForReturnOrder?centerindex=0&oid=" + i.o_ID + "\">申请退单</a><br /><a href=\"/Vipscore/vipMyOrderDetail?centerindex=0&oid=" + i.o_ID + "\">查看订单详情</a><br /></td></tr></tbody></table></li>";
            }
            return html;

        }
        //获取时间段内信息总数，返回给前台
        [HttpPost]
        public int getordercount()
        {
            string html = "";
            int mid = 0;
            string ocode = "";
            DateTime from, to;
            string where = "";

            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("ocode")))
            {
                ocode = RequestBase.GetString("ocode").ToString();
                where += " and o_Code like '%" + ocode + "%'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("from")))
            {
                from = DateTime.Parse(RequestBase.GetString("from"));
                where += " and o_CreateOn >='" + from + "'";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("to")))
            {
                to = DateTime.Parse(RequestBase.GetString("to")).AddDays(1);
                where += " and o_CreateOn <='" + to + "'";
            }
            var orderlist = obll.GetModelList(" o_IsDel=0 and m_ID=" + mid + where + " order by o_CreateOn desc");
            return orderlist.Count;

        }
        #endregion

        #region 订单详情

        public ActionResult vipMyOrderDetail()
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
                Model.ConsigneeInfoBase conmodel = new Model.ConsigneeInfoBase();
                int? cid = obll.GetModel(oid).c_ID;
                //收货人信息
                ViewBag.coninfo = new BLL.ConsigneeInfoBase().GetModel(int.Parse(cid.ToString()));
                //订单商品明细
                var orderskulist = vobll.GetModelList(" m_ID=" + mid + " and o_ID=os_oID  and pi_IsDel=0 and o_Code='" + obll.GetModel(oid).o_Code + "'");
                if (orderskulist.Count > 0)
                {
                    ViewBag.ordersku = orderskulist;
                    string skulist = "";
                    string countlist = "";
                    foreach (var sku in ViewBag.ordersku)
                    {
                        skulist += sku.sku_ID + ",";
                        countlist += sku.os_pCount + ",";
                    }
                    skulist = skulist.Substring(0, skulist.Length - 1);
                    countlist = countlist.Substring(0, countlist.Length - 1);
                    ViewData["skulist"] = skulist;
                    ViewData["countlist"] = countlist;
                }
                ////支付方式
                ViewBag.payfor = new BLL.PaymentBase().GetModel(int.Parse(obll.GetModel(oid).pay_ID.ToString()));
                //配送方式
                ViewBag.stname = new BLL.ShipTypeBase().GetModel(int.Parse(obll.GetModel(oid).st_ID.ToString()));
                //订单追踪
                ViewBag.orderstatus = new BLL.OrderStatusBase().GetModelList(" o_ID=" + oid+" and os_IsDel=0");
                //折扣
                var member = new BLL.MemberBase().GetModel(mid);
                if (member!=null)
                {
                    ViewData["zhek"] = member.m_ZheK;
                }
                ViewData["maxstatus"] = new BLL.OrderStatusBase().Getmaxstatus(" o_ID=" + oid + " and os_IsDel=0");
                return View();
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }
        //再次购买
        [HttpPost]
        public string buyagain()
        {
            string message = "";
            int oid = 0;
            string where = "";
            int mid = 0;
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("oid")))
                {
                    oid = int.Parse(RequestBase.GetString("oid"));
                }
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                ViewBag.ordersku = vobll.GetModelList(" m_ID=" + mid + " and o_ID=os_oID and o_Code='" + obll.GetModel(oid).o_Code+"'");
                string skulist = "";
                string countlist = "";
                foreach (var sku in ViewBag.ordersku)
                {
                    skulist += sku.sku_ID + ",";
                    countlist += sku.os_pCount + ",";
                }
                skulist = skulist.Substring(0, skulist.Length - 1);
                countlist = countlist.Substring(0, countlist.Length - 1);
                string[] skuid = skulist.Split(',');
                string[] count = countlist.Split(',');
                int skuinsert = 0;
                for (int i = 0; i < skuid.Length; i++)
                {
                    Model.ShoppingCartBase scmodel = new Model.ShoppingCartBase();
                    Model.SKUBase skumodel =new BLL.SKUBase().GetModel(int.Parse(skuid[i]));
                    if (skumodel.sku_Stock > 0)
                    {
                        skuinsert += 1;
                    }
                }

                if (skuinsert == skuid.Length)
                {
                    int rn = 0;
                    int result = 0;
                    bool result2 = false;
                    for (int i = 0; i < skuid.Length; i++)
                    {
                        Model.ShoppingCartBase scmodel = new Model.ShoppingCartBase();
                        var shopsku = new BLL.ShoppingCartBase().GetModelList(" m_ID="+mid+" and sku_ID="+skuid[i]+" and sc_IsDel=0");
                        Model.SKUBase skumodel = new BLL.SKUBase().GetModel(int.Parse(skuid[i]));
                        if (shopsku.Count > 0)
                        {
                            scmodel = new BLL.ShoppingCartBase().GetModel(shopsku[0].sc_ID);
                            scmodel.sc_pCount =shopsku[0].sc_pCount+ int.Parse(count[i]);
                            result2 = new BLL.ShoppingCartBase().Update(scmodel);
                        }
                        else
                        {
                            scmodel.m_ID = mid;
                            scmodel.sc_pCount = int.Parse(count[i]);
                            scmodel.sku_ID = int.Parse(skuid[i]);
                            scmodel.sc_CreateOn = DateTime.Now;
                            scmodel.sc_pPric = skumodel.sku_Price;
                            result = new BLL.ShoppingCartBase().Add(scmodel);
                        }
                        if (result > 0||result2)
                        {
                            rn += 1;
                        }
                    }
                    if (rn == skuid.Length)
                    {
                        message = "添加成功";
                    }
                    else
                    {
                        message = "添加失败";
                    }
                }
                else
                {
                    message = "库存不足";
                }
                    return message;
            }
            else
            {
                Response.Redirect("/Index/Index");
                return message;
            }
        }

        //申请退单
        public ActionResult vipApplyForReturnOrder()
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
                var tuidanshuoming = new BLL.NewsBase().GetModelList(" n_Title='退单说明' and n_StatusCode=0 and n_IsDel=0");
                ViewBag.shuoming = tuidanshuoming[0].n_Content;

            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
            return View();
        }

        // 是否可退
        [HttpPost]
        public string shenqingtuidan()
        {
            string oid = "";
            string rmark = "";
            int mid = 0;
            string message = "";
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("oid")))
                {
                    oid = RequestBase.GetString("oid").ToString();
                }
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                List<Model.RejectionBase> rejmodel = new BLL.RejectionBase().GetModelList(" r_IsDelete =0 and m_ID=" + mid + " and o_ID=" + oid);
                Model.OrderBase oinfo = new BLL.OrderBase().GetModel(int.Parse(oid));
                if (rejmodel.Count > 0&&oinfo.o_StatusCode!=4)
                {
                    message = "already";
                }
                else
                {
                    message = "ok";
                }
            }
            else
            {
                message = "nologon";
            }
            return message;
        }
        
        //退货单插入数据
        [HttpPost]
        public string inserttui()
        {
            string code = "";
            string rmark = "";
            int mid = 0;
            string message = "";
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("code")))
                {
                    code = RequestBase.GetString("code").ToString();
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("rmark")))
                {
                    rmark = RequestBase.GetString("rmark").ToString(); ;
                }
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                //订单信息
                var olist = obll.GetModelList(" o_IsDel=0 and o_Code='"+code+"'");
                if (olist[0].o_StatusCode >= 1)
                {
                    Model.RejectionBase reorder = new Model.RejectionBase();
                    reorder.m_ID = mid;
                    reorder.o_ID = olist[0].o_ID;
                    reorder.r_Code = code;
                    reorder.r_Date = DateTime.Now;
                    reorder.r_Price = (int)olist[0].o_Score;
                    reorder.r_Status = 0;
                    int result = new BLL.RejectionBase().Add(reorder);
                    if (result > 0)
                    {
                        message = "OK";
                    }
                    else {
                        message = "fail";
                    }
                }
                else
                {
                    message = "nopay";
                }
            }
            else
            {
                message = "nologon";
            }

            return message;
        }
        #endregion


        #region 退货订单
        public ActionResult vipMyReturnOrder()
        {
            int pageSize = 1;//每一页的行数
            int pageNumber = 1;//当前页数 
            int mid = 0;
            if (LoginMember != null)
            {

                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                var orderlist = obll.GetregList(" and o.o_IsDel=0 and o.m_ID=" + mid + " order by o_CreateOn desc");
                ViewBag.order = orderlist.ToPagedList(pageNumber, pageSize);
                ViewData["count"] = orderlist.Count;
                ViewData["pagerows"] = pageSize;
                ViewData["page"] = pageNumber;
                List<Model.vw_Orderpinfo> lvlist = vobll.GetModelList(" o_IsDel=0 and o_Id=os_oId and m_ID=" + mid + " and o_ID in(select o_ID from RejectionBase where m_ID=" + mid + "  and r_IsDelete=0)  ");
                return View(lvlist.ToList());
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }
        }

        //异步加载退货订单分页
        [HttpPost]
        public string returnorderpage()
        {
            int pageSize = 1;//每一页的行数
            int pageNumber = 1;//当前页数 
            string html = "";
            string ocode = "";
            string where = "";
            DateTime from, to;
            int mid = 0;
            Model.OrderBase omodel = new Model.OrderBase();
            BLL.OrderBase obll = new BLL.OrderBase();
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            var orderlist = obll.GetregList(" and o.o_IsDel=0  and o.m_ID=" + mid + " order by o_CreateOn desc");
            ViewBag.order = orderlist.ToPagedList(pageNumber, pageSize);
            List<Model.vw_Orderpinfo> lvlist = vobll.GetModelList(" o_IsDel=0 and o_Id=os_oId and  m_ID=" + mid + " and o_ID in(select o_ID from RejectionBase where m_ID=" + mid + " and r_IsDelete=0)");
            foreach (var i in ViewBag.order)
            {
                html += "<li><table class=\"order-list\"><tbody><tr><td width=\"140\"><p>" + i.o_Code + "</p><br /><p><strong>" + i.o_CreateOn + "</strong></p></td><td colspan=\"3\" width=\"510\"><table><tbody>";
                foreach (var ii in lvlist.Where(c => c.o_Code == i.o_Code))
                {
                    html += "<tr><td width=\"330\"><div class=\"pro-imgs\"><a href=\"/ProDetail/ProDetail?skuid=" + ii.sku_ID + "\"><img name=\"page_cnt_1\" src=\"" + ii.pi_Url + "\" alt=\"" + ii.p_Name + "\" /></a></div><p><a href=\"/ProDetail/ProDetail?skuid=" + ii.sku_ID + "\">" + ii.p_Name + "</a></p></td><td width=\"100\" align=\"center\">" + ii.sku_Price + "</td><td width=\"80\" align=\"center\">" + ii.os_pCount + "</td></tr>";
                }
                html += "</tbody></table></td><td width=\"90\" align=\"center\">" + i.o_Pric + "</td><td width=\"90\" align=\"center\">" + i.o_StatusCode.ToString().Replace("0", "提交订单").Replace("1", "付款成功").Replace("2", "商品出库").Replace("3", "等待收货").Replace("4", "完成") + "</td><td width=\"90\" align=\"center\"><a href=\"#\">删除</a><br /><a  href=\"javascript:void(0)\" onclick=\"buyagain(" + i.o_ID + ")\">再次购买</a><br /><a href=\"/Vipscore/vipApplyForReturnOrder?centerindex=0&oid=" + i.o_ID + "\">申请退单</a><br /><a href=\"/Vipscore/vipMyOrderDetail?centerindex=0&oid=" + i.o_ID + "\">查看订单详情</a><br /></td></tr></tbody></table></li>";
            }
            return html;

        }

        #endregion
        # region 收货地址管理

        public ActionResult vipGoodsAddress()
        {
            if (LoginMember == null)
            {
                Response.Redirect("/Logon/Logon", true);
            }
            GetConsigneeInfo();

            var modelList = _regionBase.GetModelList(" reg_PId = 0");

            List<SelectListItem> selectType = new List<SelectListItem>();
            selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            foreach (var model in modelList)
            {
                selectType.Add(new SelectListItem
                {
                    Value = model.reg_ID.ToString(),
                    Text = model.reg_Name
                });
            }
            ViewData["selectType"] = new SelectList(selectType, "Value", "Text", "请选择");
            List<SelectListItem> selectType2 = new List<SelectListItem>();
            selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", "请选择");
            List<SelectListItem> selectType3 = new List<SelectListItem>();
            selectType3 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
            ViewData["selectType3"] = new SelectList(selectType3, "Value", "Text", "请选择");
            return View();
        }

        /// <summary>
        /// 收货人信息
        /// </summary>
        public void GetConsigneeInfo()
        {
            //根据登录用户ID获取收货人列表
            BLL.ConsigneeInfoBase conInfoBase = new BLL.ConsigneeInfoBase();
            var list = conInfoBase.GetModelList(" c_StatusCode = 0 and c_IsDel = 0 and m_ID = " + LoginMember.m_ID);
            ViewData["ConsigneeInfo"] = list;
        }

        //地区联动下拉菜单
        [HttpGet]
        public string GetCity(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = _regionBase.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCity = _regionBase.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");
                for (int i = 0; i < modelCity.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCity[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCity[i].reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }

        [HttpGet]
        public string GetCountry(string id)
        {
            StringBuilder attr = new StringBuilder();
            if (RequestBase.GetString("code") != "")
            {
                id = RequestBase.GetString("code");
            }
            if (id == "chose")
            {
                return "refresh";
            }
            else
            {
                List<SelectListItem> selectattrP = new List<SelectListItem>();
                Model.RegionBase rmodel = _regionBase.GetModel(int.Parse(id));
                List<Model.RegionBase> modelCountry = _regionBase.GetModelList(" reg_PId = " + rmodel.reg_Code);
                StringBuilder sbGoodsName = new StringBuilder();
                attr.Append("[[\"chose\",\"请选择\"]");

                for (int i = 0; i < modelCountry.Count; i++)
                {
                    attr.Append(",[");
                    attr.Append("\"" + modelCountry[i].reg_ID.ToString() + "\",");
                    attr.Append("\"" + modelCountry[i].reg_Name + "\"");
                    attr.Append("]");
                }

                attr.Append("]");

                return attr.ToString();
            }
        }

        public string DeleteConsigneeInfo()
        {
            string result = "系统异常";
            try
            {
                string cid = "";
                if (!string.IsNullOrWhiteSpace(RequestBase.GetString("cid")))
                {
                    cid = RequestBase.GetString("cid");
                }
                var model = _consigneeInfo.GetModel(Convert.ToInt32(cid));
                if (model != null)
                {
                    model.c_IsDel = 1;
                    if (_consigneeInfo.Update(model))
                    {
                        result = "删除成功！";
                    }
                }
            }
            catch { }

            return result;
        }

        public string AddConsigneeInfo()
        {
            string result = "";
            int cid = 0;
            bool isAdd = true;
            if (RequestBase.GetString("otype") == "modify")
            {
                cid = Convert.ToInt32(RequestBase.GetString("cid"));
                isAdd = false;
            }
            var name = RequestBase.GetString("name");
            var selectType = RequestBase.GetString("selectType");
            var selectType2 = RequestBase.GetString("selectType2");
            var selectType3 = RequestBase.GetString("selectType3");
            var Address = RequestBase.GetString("Address");
            var phone = RequestBase.GetString("phone");
            var tphone = RequestBase.GetString("tphone");
            var zipcode = RequestBase.GetString("zipcode");

            var model = new Model.ConsigneeInfoBase();
            if (!isAdd)
            {
                model = _consigneeInfo.GetModel(cid);
            }
            else
            {
                model.c_IsDel = 0;
                model.c_Moren = 0;
                model.c_StatusCode = 0;
                model.m_ID = LoginMember.m_ID;
            }
            model.c_Provice = Convert.ToInt32(selectType);
            model.c_City = Convert.ToInt32(selectType2);
            model.c_Count = Convert.ToInt32(selectType3);
            model.c_FullAddress = Address;
            model.c_Mobilephone = phone;
            model.c_Telephone = tphone;
            model.c_Name = name;
            model.c_Zipcode = zipcode;
            try
            {
                if (isAdd)
                {
                    int id = _consigneeInfo.Add(model);
                    model = _consigneeInfo.GetModel(id);
                }
                else
                {
                    if (_consigneeInfo.Update(model))
                    {
                        model = _consigneeInfo.GetModel(model.c_ID);
                    }
                }
            }
            catch
            {
                model = null;
            }
            if (model != null)
            {
                result = string.Format(@"
                                        <li id='cliId_{0}'>
                                            <p class='alignleft'>
                                                <span>{1}</span>
                                                <span>{2}</span>
                                                <span>{3}</span>
                                                <span>{4}</span>
                                            </p>
                                            <p class='alignright'>
                                                <a href='javascript:void(0)' onclick='EditConsigneeInfo({0},{1})'>编辑</a>丨<a href='javascript:void(0)' onclick='DeleteConsigneeInfo({0})'>删除</a>
                                            </p>
                                        </li>", model.c_ID, model.c_Name, model.c_CProvice + model.c_CCity + model.c_CCount + model.c_FullAddress, model.c_Mobilephone, model.c_Zipcode);
            }
            return result;
        }

        # endregion
    }
}
