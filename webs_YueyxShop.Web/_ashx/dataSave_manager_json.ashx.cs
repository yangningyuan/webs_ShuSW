using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Web.Security;
using System.Data;
using webs_YueyxShop.Model;

namespace webs_YueyxShop.Web._ashx
{
    /// <summary>
    /// dataSave_manager_json 的摘要说明
    /// </summary>
    public class dataSave_manager_json : IHttpHandler
    {
        private readonly System.Collections.Specialized.NameValueCollection Form = System.Web.HttpContext.Current.Request.Params;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = "";

            switch (context.Request.QueryString["type"])
            { 
                case"ProductRecommendDetail":
                    SaveProductRecommendDetail();
                    break;
                case "saveGPdetails":
                    saveGPdetails(context);
                    break;
                case "savePCdetails":
                    savePCdetails(context);
                    break;
                case "submitOrder":
                    SubmitOrder();
                    break;
                case "addConsigneeInfo":
                    AddConsigneeInfo();
                    break;
                case "SaveUserInfo":
                    SaveUserInfo(context);
                    break;
                case "pcregister":
                    result= SavePCRegister();
                    break;
                case "pclogin":
                    result= pcLogin(context);
                    break;
                case "removecookie":
                    result = removecookie(context);
                    break;
                case "shopcart":
                    result = shopcartMethod();
                    break;
                case "removeshop":
                    result = removeshop();
                    break;
            }
            context.Response.Write(result);
        }
        /// <summary>
        /// 删除购物车单个物品信息
        /// </summary>
        /// <returns></returns>
        private string removeshop()
        {
            string result = "";
            string scid = Form["sc_id"];
            try
            {
                Model.ShoppingCartBase scmodel = new BLL.ShoppingCartBase().GetModel(int.Parse(scid));
                scmodel.sc_IsDel = true;
                bool re = new BLL.ShoppingCartBase().Update(scmodel);
                if (re)
                {
                    result = "1";
                }
                else {
                    result = "0";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return result;
        }
        /// <summary>
        /// 购物车
        /// </summary>
        /// <returns></returns>
        private string shopcartMethod()
        {
            string result = "";
            string pid = Form["p_id"];
            string p_chima = Form["p_chima"];
            string p_yanse = Form["p_yanse"];
            string p_commoditynum = Form["p_commoditynum"];
            DataTable dtsku = new BLL.SKUBase().GetList(" sku_IsDel=0 and p_ID= "+pid).Tables[0];
            string  pt_id= new BLL.ProductBase().GetModel(int.Parse(pid)).pt_ID.ToString();//商品小类型
            string ptp_id= new BLL.ProductTypeBase().GetModel(int.Parse(pt_id)).pt_ParentId.ToString();//商品大类型
            if (System.Web.HttpContext.Current.Request.Cookies[":userlogin"] == null || System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value == "")//如果没有用户登录
            {
                result = "{'result':'error_login'}";
            }
            else {//如果有用户登录

                Model.MemberBase mbmodel = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies[":userlogin"].Value) as MemberBase;

                if (ptp_id == "488" || ptp_id == "489") //是男鞋或女鞋
                {
                    if (p_chima == "0")
                    {
                        result = "{'result':'error_chima'}";
                    }
                    else if (p_yanse == "0")
                    {
                        result = "{'result':'error_yanse'}";
                    }
                    else
                    { //尺码 颜色都选择后  写入购物车


                        Model.ShoppingCartBase scmodel = new ShoppingCartBase();
                        scmodel.sku_ID = int.Parse(dtsku.Rows[0]["sku_ID"].ToString());
                        scmodel.m_ID = mbmodel.m_ID;
                        scmodel.sc_pCount =int.Parse( p_commoditynum);
                        scmodel.sc_pPric = Convert.ToDecimal(dtsku.Rows[0]["sku_Price"]);
                        scmodel.sc_CreateOn = DateTime.Now;
                        scmodel.sc_IsDel = false;
                        scmodel.sc_Status = false;
                        scmodel.sc_IsGP = false;
                        scmodel.sc_chima = p_chima;
                        scmodel.sc_yanse = p_yanse;

                        int re= new BLL.ShoppingCartBase().Add(scmodel);
                        if (re > 0)
                        {
                            result = "{'result':'success'}";
                        }
                        else {
                            result = "{'result':'error_data'}";
                        }
                    }
                }
                else//如果选择的商品不是鞋子那么尺码颜色设为0
                {
                    Model.ShoppingCartBase scmodel = new ShoppingCartBase();
                    scmodel.sku_ID = int.Parse(dtsku.Rows[0]["sku_id"].ToString());
                    scmodel.m_ID = mbmodel.m_ID;
                    scmodel.sc_pCount = int.Parse(p_commoditynum);
                    scmodel.sc_pPric = Convert.ToDecimal(dtsku.Rows[0]["sku_Price"]);
                    scmodel.sc_CreateOn = DateTime.Now;
                    scmodel.sc_IsDel = false;
                    scmodel.sc_Status = false;
                    scmodel.sc_IsGP = false;
                    scmodel.sc_chima = p_chima;
                    scmodel.sc_yanse = p_yanse;

                    int re = new BLL.ShoppingCartBase().Add(scmodel);
                    if (re > 0)
                    {
                        result = "{'result':'success'}";
                    }
                    else
                    {
                        result = "{'result':'error_data'}";
                    }
                }
            }
            return result;
        }
        public string removecookie(HttpContext context)
        {
            string result = "";
            context.Response.Cookies[":userlogin"].Value = "";
            return result;

        }
        private string pcLogin(HttpContext context)
        {
            string result = "";
            string username = Form["username"];
            string password = Form["password"];
            try
            {
                string md5pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password,"MD5");
                
                DataSet ds= new BLL.MemberBase().GetList("m_UserName='"+username+"' and m_Password='"+md5pwd+"' and m_UserType=0 and m_StatusCode=0 and m_ShenPstatus=1 ");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    //DateTime ckExpires = DateTime.Now.AddHours(1);
                    //ckExpires = DateTime.Now.AddDays(7);
                    Model.MemberBase model = new BLL.MemberBase().GetModel(int.Parse(dr["m_id"].ToString()));
                    //context.Response.Cookies["UserInfo"].Value = CookieEncrypt.SerializeObject(model);
                    //context.Response.Cookies["UserInfo"].Expires = ckExpires;


                    context.Response.Cookies[":userlogin"].Value = CookieEncrypt.SerializeObject(model);
                    context.Response.Cookies[":userlogin"].Expires.AddDays(2);


                    //string url = context.Request.UrlReferrer.AbsoluteUri;
                    //context.Response.Write("1");
                    result = "{'result':'保存成功！'}";
                }
                else {
                    result = "{'result':'保存失败！'}";
                }
                
            }
            catch (Exception)
            {
                result = "{'result':'保存失败！'}";
                throw;
            }
            return result;
        }

        

        private string SavePCRegister()
        {
            string nickname = Form["nickname"];
            string phone = Form["phone"];
            string address = Form["address"];
            string email = Form["email"];
            string password = Form["password"];
            string result = "";
            try
            {

                DataSet ds = new BLL.MemberBase().GetList(" m_StatusCode!=2 and m_UserName='" + email + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = "{'result':'被注册！'}";
                }
                else
                {
                    Model.MemberBase mb = new Model.MemberBase();
                    mb.m_NickName = nickname;
                    mb.m_Phone = phone;
                    mb.m_GongSiAddress = address;
                    mb.m_UserName = email;
                    string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                    mb.m_Password = pwd;
                    mb.m_Email = email;
                    mb.m_UserType = 0;
                    mb.m_ZheK = 1;
                    mb.m_ShenPstatus = 1;
                    mb.m_Rank = 1;
                    mb.m_Score = 0;
                    int flog = new BLL.MemberBase().Add(mb);

                    if (flog > 0)
                    {
                        result = "{'result':'保存成功！'}";
                    }
                    else
                    {
                        result = "{'result':'保存失败！'}";
                    }
                }
                return result;
            }
            catch (Exception)
            {
                result = "{'result':'保存失败！'}";
                throw;
            }
        }

        public void SaveUserInfo(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            var form = context.Request.QueryString;
            Model.MemberBase model = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase;
            model.m_City = int.Parse(form["shiid"]);
            model.m_Count = int.Parse(form["xianid"]);
            model.m_GDPhone = form["phone"];
            model.m_GongSiAddress = form["xxadress"];
            model.m_GongSiName = form["gsname"];
            model.m_Phone = form["phone"];
            model.m_Provice = int.Parse(form["shengid"]);
            model.m_QQ = form["qq"];
            model.m_RealName = form["lxname"];
            model.m_YingYZZ = form["yyzz"];
            model.m_Introduction = form["qyjianjie"];
            if (new BLL.MemberBase().Update(model))
                context.Response.Write("<script>alert('保存成功');location.href='/userinfo/CompanyData';</script>");
            else
                context.Response.Write("<script>alert('保存失败,请检查内容合法性');location.href='/userinfo/CompanyData';</script>");
        }

        public webs_YueyxShop.Model.EmployeeBase EmployeeInfo
        {
            get
            {
                return GetParaValue();
            }
        }
        /// <summary>
        /// 获取页面参数的值
        /// </summary>
        public webs_YueyxShop.Model.EmployeeBase GetParaValue()
        {
            webs_YueyxShop.Model.EmployeeBase _employeeBase = null;
            //如果Session中能够找到相应的参数值，则返回参数值
            try
            {
                _employeeBase = CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["Energy"].Value) as webs_YueyxShop.Model.EmployeeBase;
            }
            catch (Exception err)
            {
                _employeeBase = null;
            }

            return _employeeBase;
        }
        public void savePCdetails(HttpContext context)
        {
            bool isok = false;

            string result = isok ? "保存成功" : "保存失败";
            context.Response.Write(result);
        }

        public void saveGPdetails(HttpContext context)
        {
            BLL.GroupPurchaseBase bll = new BLL.GroupPurchaseBase();
            
            bool isok = false;
            string pid, gpcount, gpprice, starttime, endtime, gplogo, gpslogan;
            pid = context.Request.QueryString["pid"].ToString();
            gpcount = context.Request.QueryString["gpcount"].ToString();
            gpprice = context.Request.QueryString["gpprice"].ToString();
            starttime = context.Request.QueryString["starttime"].ToString();
            endtime = context.Request.QueryString["endtime"].ToString();
            gplogo = context.Request.QueryString["gplogo"].ToString();
            gpslogan = context.Request.QueryString["gpslogan"].ToString();
            string otype = context.Request.QueryString["otype"].ToString();
            
            if (otype == "add")
            {
                Model.GroupPurchaseBase model = new Model.GroupPurchaseBase();
                model.gp_CreateBy = EmployeeInfo.e_ID;
                model.gp_CreateOn = DateTime.Now;
                model.gp_IsDel = false;
                model.gp_StatusCode = 0;
                model.sku_ID = int.Parse(pid);
                model.gp_EndTime = DateTime.Parse(endtime);
                model.gp_StartTime = DateTime.Parse(starttime);
                model.gp_pCount = int.Parse(gpcount);
                model.gp_pPric = decimal.Parse(gpprice);
                model.gp_SaleCount = 0;
                model.gp_Slogan = gpslogan;
                model.gp_Logo = gplogo;
                isok = bll.Add(model);
            }
            else
            {
                int id = int.Parse(context.Request.QueryString["id"].ToString());
                Model.GroupPurchaseBase model = bll.GetModel(id);
                model.gp_StartTime = DateTime.Parse(starttime);
                model.gp_EndTime = DateTime.Parse(endtime);
                model.gp_pCount = int.Parse(gpcount);
                model.gp_pPric = decimal.Parse(gpprice);
                model.sku_ID = int.Parse(pid);
                model.gp_Slogan = gpslogan;
                model.gp_Logo = gplogo;
                isok = bll.Update(model);
            }
            string result = isok ? "保存成功" : "保存失败";
            context.Response.Write(result);
        }

        public void SaveProductRecommendDetail()
        {
            var context = System.Web.HttpContext.Current;
            BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
            string pids = context.Request.Params["pids"];
            string prtID = context.Request.Params["prtID"];
            string result = "";
            if (!string.IsNullOrWhiteSpace(pids) && !string.IsNullOrWhiteSpace(prtID))
            {
                try
                {
                    string[] pidss = pids.Split(',');
                    if (pidss.Length == 0 && string.IsNullOrWhiteSpace(pidss[0]))
                    {
                        result = "请选择商品！";
                    }
                    else
                    {
                        Model.ProductRecommendDetail model = new Model.ProductRecommendDetail();
                        model.prd_IsDelete = false;
                        model.prd_Status = false;
                        using (var scope = new TransactionScope())
                        {
                            foreach (string id in pidss)
                            {
                                if (!string.IsNullOrWhiteSpace(id))
                                {
                                    model.prt_ID = Convert.ToInt32(prtID);
                                    model.p_ID = Convert.ToInt32(id);
                                    _productRecommendDetail.Add(model);
                                }
                            }
                            result = "保存成功！";
                            scope.Complete();
                        }
                    }
                }
                catch
                {
                    result = " 保存失败！";
                }
            }

            var a = new { result };
            var json = Common.JOSN.JSONHelper.ToJSON(a);
            context.Response.Write(json);
        }

        /// <summary>
        /// 订单提交
        /// </summary>
        public void SubmitOrder()
        {
            var context = System.Web.HttpContext.Current;

            string result = "";
            string payID = context.Request.Params["payID"];
            string resultUrl = "";
            if (!string.IsNullOrWhiteSpace(payID)) 
            {
                var model = new BLL.PaymentBase().GetModel(Convert.ToInt32(payID));
                resultUrl = model.pay_Url;
            }

            try
            {
                //生成订单
                int orderID = 0;
                using (var scope = new TransactionScope())
                {
                    orderID = CreateOrder();
                    CreateOrderSKUDetail(orderID);
                    scope.Complete();
                }
                result = "{'result':'保存成功！','orderId':'" + orderID + "','url':'" + resultUrl + "'}";
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
            }

            context.Response.Write(result);
        }

        /// <summary>
        /// 生成订单详细
        /// </summary>
        public void CreateOrderSKUDetail(int orderID)
        {
            try
            {
                var context = System.Web.HttpContext.Current;
                string mID = context.Request.Params["mID"];
                string ids = context.Request.Params["ids"];
                BLL.ShoppingCartBase shop = new BLL.ShoppingCartBase();
                string idslist = ids.Trim(',');
                var list = shop.GetModelList(" sc_IsDel = 0 and m_ID = " + mID + " and sku_ID in (" + idslist + ")");
                BLL.OrderSKUDetail bos = new BLL.OrderSKUDetail();
                BLL.ShoppingCartBase bscb = new BLL.ShoppingCartBase();
                BLL.GroupPurchaseBase bgpb = new BLL.GroupPurchaseBase();
                BLL.SKUBase bskuB = new BLL.SKUBase();

                foreach (var model in list)
                {
                    //生成订单详情
                    Model.OrderSKUDetail mosd = new Model.OrderSKUDetail();
                    mosd.o_ID = orderID;
                    mosd.os_pCount = model.sc_pCount;
                    mosd.sku_ID = model.sku_ID;
                    mosd.os_IsGP = model.sc_IsGP;
                    mosd.os_Price = model.sc_pPric;
					mosd.os_chima=model.sc_chima;
					mosd.os_yanse=model.sc_yanse;
                    //更改购物车状态
                    bscb.ChangeStatus(true, Convert.ToInt32(mID), model.sku_ID.ToString());
                    //减少库存,增加售出数量
                    var msku = bskuB.GetModel(model.sku_ID.Value);
                    msku.sku_Stock = msku.sku_Stock - model.sc_pCount;
                    msku.sku_SalesCount = msku.sku_SalesCount+ model.sc_pCount.Value;
                    //判断库存
                    if (msku.sku_Stock < 0)
                    {
                        throw new Exception("库存不足");
                    }

                    bskuB.Update(msku);
                    if (model.sc_IsGP)
                    {
                        //增加团购卖出数量
                        string sql = " sku_ID = " + model.sku_ID.Value + " and gp_IsDel = 0 and gp_StatusCode = 0 and gp_StartTime <= '" + DateTime.Now + "' and gp_EndTime >= '" + DateTime.Now + "'";
                        var mgp = bgpb.GetModelList(sql).FirstOrDefault();
                        if (mgp != null)
                        {
                            mgp.gp_SaleCount += model.sc_pCount.Value;
                            if (mgp.gp_SaleCount > mgp.gp_pCount.Value)
                            {
                                throw new Exception("库存不足");
                            }
                            bgpb.Update(mgp);
                        }
                    }
                    bos.Add(mosd);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 生成订单
        /// </summary>
        public int CreateOrder()
        {
            int result=0;
            try
            {
                var context = System.Web.HttpContext.Current;
                string cID, mID, payID, stID, remarks, oprice,score;
                cID = context.Request.Params["cID"];
                mID = context.Request.Params["mID"];
                payID = context.Request.Params["payID"];
                stID = context.Request.Params["stID"];
                remarks = context.Request.Params["remarks"];
                oprice = context.Request.Params["oPrice"];
                score = context.Request.Params["score"];
                Model.MemberBase memberbase = new BLL.MemberBase().GetModel(Convert.ToInt32(mID));
                Model.OrderBase order = new Model.OrderBase();
                order.c_ID = Convert.ToInt32(cID);
                order.m_ID = Convert.ToInt32(mID);
                order.pay_ID = Convert.ToInt32(payID);
                order.st_ID = Convert.ToInt32(stID);
                order.o_CreateOn = DateTime.Now;
                order.o_Code = order.o_CreateOn.Value.ToUnixTimeStamp() + order.m_ID;
                order.o_IsDel = false;
                order.o_Mark = remarks;
                order.o_Pric = Convert.ToDecimal(oprice);
                order.o_StatusCode = 0;
                order.o_Score = Convert.ToInt32(score);
                order.o_Zhek = memberbase.m_ZheK;
                result = new BLL.OrderBase().Add(order);
                
                return result;
            }
            catch 
            {
                throw new Exception("订单出错");
            }
        }

        public void AddConsigneeInfo()
        {
            var context = System.Web.HttpContext.Current;
            BLL.ProductRecommendDetail _productRecommendDetail = new BLL.ProductRecommendDetail();
            string pids = context.Request.Params["pids"];
            string prtID = context.Request.Params["prtID"];
            string result = "";

            var a = new { result };
            var json = Common.JOSN.JSONHelper.ToJSON(a);
            context.Response.Write(json);
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