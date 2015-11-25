using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using PagedList;
using webs_YueyxShop.Model;
using Common;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapProDetailController : BaseWapController
    {
        BLL.BrandBase bbll = new BLL.BrandBase();
        BLL.ProductBase pbll = new BLL.ProductBase();
        BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        ListModel model = new ListModel();

        string skuid = RequestBase.GetString("skuid");//"1";
        public ActionResult ProDetail()
        {
            ViewData["skuid"] = skuid;
            string where = "";


            //添加历史浏览记录
            CookieHelper.AddandRepairGoodsToCookie("History", skuid);

            int zixunpageSize = 2;//每一页的行数
            int zixunpageNumber = 1;//当前页数 
            if (skuid != "")
            {
                where = "  and sku_ID=" + int.Parse(skuid);
            }
            model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   " + where);//商品信息
            model.pimglist = new BLL.ProductImgBase().GetModelList(" sku_ID=" + int.Parse(skuid));//图片列表
            model.productinfotuijian = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + skuid + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='推荐理由'");//推荐理由 
            model.productinfo = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + skuid + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='商品介绍'");//商品介绍
            model.proattr = new BLL.ProductAttributesBase().GetModelListByskuId(" pad.sku_ID= " + int.Parse(skuid));//属性
            model.proattr2 = new BLL.ProductAttributesBase().GetModelListByPid(" and pa.pa_Type=2 and pa.pa_ID in(select pa_ID from ProductAttributeDetails where  sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + int.Parse(skuid) + "))) and sku.sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + int.Parse(skuid) + "))");//规格


            //促销活动
            var huodong = new BLL.ProductRecommendDetail().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + skuid + ") and prd_Status=0 and prd_IsDelete=0 ");
            var groupbuy = new BLL.GroupPurchaseBase().GetModelList(" sku_ID=" + skuid + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'");
            if (huodong.Count > 0)
            {
                var huodongming = new BLL.ProductRecommendTypeBase().GetModel(int.Parse(huodong[0].prt_ID.ToString()));
                if (huodongming.prt_Title != "手机专享")
                {
                    ViewBag.huodongming = huodongming;
                }
                else
                {
                    ViewBag.huodongming = null;
                }
                
            }
            else
            {
                ViewBag.huodongming = null;
            }
            if (groupbuy.Count > 0)
            {
                ViewBag.tuan = groupbuy[0];
            }
            else
            {
                ViewBag.tuan = null;;
            }



            if (model.vmpinfolist.Any())
            {
                ViewData["youhui"] = model.vmpinfolist[0].sku_scPric - model.vmpinfolist[0].sku_Price;
            }
            else
            {
                ViewData["youhui"] = 0;
            }
            if (LoginMember != null)
            {
                var clist = new BLL.VipCollectionBase().GetModelList(" m_ID=" + (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID + " and sku_ID=" + model.vmpinfolist[0].sku_ID + " and vc_IsDel=0");
                if (clist.Count > 0)
                {
                    ViewData["collect"] = true;
                }
                else
                {
                    ViewData["collect"] = false;
                }
                ViewData["logon"] = true;
            }
            else
            {
                ViewData["collect"] = false;
                ViewData["logon"] = false;
            }
            return View(model);
        }

        #region 评论
        public ActionResult ProPinglun()
        {
            int pinglunpageSize = 2;//每一页的行数
            int haopageNumber = 1;//当前页数 
            int zhongpageNumber = 1;//当前页数 
            int chapageNumber = 1;//当前页数 
            //评论
            model.pinglun = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid)+" and pa_StatusCode=0 and pa_IsDel=0");
            model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + int.Parse(skuid));//商品信息
            ViewBag.vmpinfolist = model.vmpinfolist[0];
            if (model.pinglun.Count > 0)
            {
                ViewData["midcount"] = model.pinglun[0].member.midcount;
                ViewData["pinglunscore"] = model.pinglun[0].pavg;
            }
            else
            {
                ViewData["midcount"] = "0";
                ViewData["pinglunscore"] = "0";
            }
            if (LoginMember != null)
            { ViewData["logon"] = true; }
            else
            { ViewData["logon"] = false; }
            var pah = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid) + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied<=5 and pa_Satisfied>=4");
            var paz = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid) + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied=3");
            var pac = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid) + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied<=2 and pa_Satisfied>=0");
            ViewData["hao"] = pah.Count();
            ViewData["haopagecount"] = Math.Ceiling((double)pah.Count / (double)pinglunpageSize);
            ViewData["haopage"] = haopageNumber;
            ViewData["zhong"] = paz.Count();
            ViewData["zhongpagecount"] = Math.Ceiling((double)pah.Count / (double)pinglunpageSize);
            ViewData["zhongpage"] = zhongpageNumber;
            ViewData["cha"] = pac.Count();
            ViewData["chapagecount"] = Math.Ceiling((double)pah.Count / (double)pinglunpageSize);
            ViewData["chapage"] = chapageNumber;
            ViewData["pagerows"] = pinglunpageSize;
            ViewData["skuid"] = skuid;
            ViewBag.pinlunh = pah.ToPagedList(haopageNumber, pinglunpageSize);
            ViewBag.pinlunz = paz.ToPagedList(zhongpageNumber, pinglunpageSize);
            ViewBag.pinlunc = pac.ToPagedList(chapageNumber, pinglunpageSize);

            return View();
        }
        //异步加载评论分页
        [HttpPost]
        public string getpinglun()
        {
            int pinglunpageSize = 2;//每一页的行数
            int pinglunpageNumber = 1;//当前页数 
            string html = "";
            int typeid = 0;
            int skuid = 0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pinglunpageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("id")))
            {
                typeid = Convert.ToInt32(RequestBase.GetString("id").ToString());
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
            {
                skuid = Convert.ToInt32(RequestBase.GetString("skuid").ToString());
            }
            if (typeid == 1)
            {
                var pah = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + skuid + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied<=5 and pa_Satisfied>=4");
                ViewBag.pinlun = pah.ToPagedList(pinglunpageNumber, pinglunpageSize);
                ViewData["haopage"] = pinglunpageNumber;
                ViewData["haopagecount"] = Math.Ceiling((double)pah.Count / (double)pinglunpageSize);
                html = "<ul>";
                foreach (var item in ViewBag.pinlun)
                {
                    html += "<li><dl><dt>"+item.pa_Content+"</dt><dd><div class=\"stars star-icon5 alignleft\"></div><div class=\"times alignright\">"+item.pa_CreatedOn+"</div></dd></dl></li>";
                }
                html+="</ul><div class=\"page\"><a href=\"javascript:void(0)\" onclick=\"prepage(1)\">上一页</a><span id=\"pageforfenye1\">"+ViewData["haopage"]+"/"+ViewData["haopagecount"]+"</span><a href=\"javascript:void(0)\" onclick=\"nextpage(1)\">下一页</a></div>";
                return html;
            }
            else if (typeid == 2)
            {
                var paz = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + skuid + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied=3");
                ViewBag.pinlun = paz.ToPagedList(pinglunpageNumber, pinglunpageSize);
                ViewData["zhongpage"] = pinglunpageNumber;
                ViewData["zhongpagecount"] = Math.Ceiling((double)paz.Count / (double)pinglunpageSize);
                html = "<ul>";
                foreach (var item in ViewBag.pinlun)
                {
                    html += "<li><dl><dt>"+item.pa_Content+"</dt><dd><div class=\"stars star-icon5 alignleft\"></div><div class=\"times alignright\">"+item.pa_CreatedOn+"</div></dd></dl></li>";
                }
                html += "</ul><div class=\"page\"><a href=\"javascript:void(0)\" onclick=\"prepage(2)\">上一页</a><span id=\"pageforfenye2\">" + ViewData["zhongpage"] + "/" + ViewData["zhongpagecount"] + "</span><a href=\"javascript:void(0)\" onclick=\"nextpage(1)\">下一页</a></div>";
                return html;
            }
            else if (typeid == 3)
            {
                var pac = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + skuid + " and pa_StatusCode=0 and pa_IsDel=0 and pa_Satisfied<=2 and pa_Satisfied>=0");
                ViewBag.pinlun = pac.ToPagedList(pinglunpageNumber, pinglunpageSize);
                ViewData["chapage"] = pinglunpageNumber;
                ViewData["chapagecount"] = Math.Ceiling((double)pac.Count / (double)pinglunpageSize);
                html = "<ul>";
                foreach (var item in ViewBag.pinlun)
                {
                    html += "<li><dl><dt>"+item.pa_Content+"</dt><dd><div class=\"stars star-icon5 alignleft\"></div><div class=\"times alignright\">"+item.pa_CreatedOn+"</div></dd></dl></li>";
                }
                html += "</ul><div class=\"page\"><a href=\"javascript:void(0)\" onclick=\"prepage(3)\">上一页</a><span id=\"pageforfenye3\">" + ViewData["chapage"] + "/" + ViewData["chapagecount"] + "</span><a href=\"javascript:void(0)\" onclick=\"nextpage(1)\">下一页</a></div>";
                return html;
            }
            return html;

        }
   
        #endregion


        //提交 评论type=pinglun/ 咨询type=zixun
        public string Tijiao()
        {
            string message = "";
            string type = "";
            string content = "";
            int skuid = 0;
            string radio = "0";
            int result = 0;
            HttpCookie user = Request.Cookies["UserInfo"];
            int mid = 0;
            string name = user.Value;
            if (LoginMember != null)//如果已登陆
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                if (!string.IsNullOrEmpty(RequestBase.GetString("type")))
                {
                    type = RequestBase.GetString("type").ToString();
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("content")))
                {
                    content = RequestBase.GetString("content").ToString();
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
                {
                    skuid = Convert.ToInt32(RequestBase.GetString("skuid"));
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("radio")))
                {
                    radio = RequestBase.GetString("radio").ToString();
                }
                if (content == "")
                {
                    message = "请输入200个以内的字符";
                }
                if (type == "zixun")
                {
                    Model.ProductConsultBase pcmodel = new ProductConsultBase();
                    pcmodel.pc_Content = content;
                    pcmodel.pc_CreatedOn = DateTime.Now;
                    pcmodel.pc_CreatedBy = mid;//用户ID
                    pcmodel.sku_ID = skuid;
                    pcmodel.pc_huifu = 0;
                    if (radio == "1")
                        pcmodel.pc_Type = "商品提问";
                    if (radio == "2")
                        pcmodel.pc_Type = "促销活动提问";
                    if (radio == "3")
                        pcmodel.pc_Type = "库存及物流提问";
                    if (radio == "4")
                        pcmodel.pc_Type = "售后提问";
                    if (radio == "undefined")
                        return "请选择提问类别";
                    result = new BLL.ProductConsultBase().Add(pcmodel);
                }
                else if (type == "pinglun")
                {
                    Model.ProductAppraiseBase pamodel = new ProductAppraiseBase();
                    pamodel.pa_Content = content;
                    pamodel.pa_CreatedOn = DateTime.Now;
                    pamodel.pa_CreatedBy = mid;
                    pamodel.m_ID = 2;
                    pamodel.sku_ID = skuid;
                    if (radio == "0")
                        return "请给商品评分";
                    else
                    {
                        pamodel.pa_Satisfied = int.Parse(radio);//满意度
                    }
                    result = new BLL.ProductAppraiseBase().Add(pamodel);
                }
                if (result > 0)
                {
                    return result.ToString();
                }
                else
                {
                    message = "提交失败，请稍后重试";
                }
                return message;
            }
            else
            {
                return "不登陆没有发言权";
            }
        }


        #region 历史浏览记录
        public ActionResult History()
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
            return View(ViewBag.history);
        }
        #endregion

        public ActionResult ProInfo()
        {
            string skuid = "";
            string where = "";
            if (RequestBase.GetString("skuid") != null)
            {
                skuid = RequestBase.GetString("skuid");//"1";
            }
            if (skuid != "")
            {
                where = "  and sku_ID=" + int.Parse(skuid);
            }
            model.productinfo = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + skuid + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='商品介绍'");//商品介绍
            model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   " + where);//商品信息
            return View(model);
        }


        //加入收藏夹
        public string InsertintoCollect()
        {
            string skuid = "";
            string type = ""; bool result = false;
            if (LoginMember != null)
            {
                if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
                {
                    skuid = RequestBase.GetString("skuid").ToString();
                }
                if (!string.IsNullOrEmpty(RequestBase.GetString("type")))
                {
                    type = RequestBase.GetString("type").ToString();
                }
                Model.VipCollectionBase cmodel = new VipCollectionBase();
                int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                if (type == "cancel")
                {
                    result = new BLL.VipCollectionBase().Deletebyskuid(mid, int.Parse(skuid));
                }
                else if (type == "insert")
                {
                    List<Model.VipCollectionBase> coll = new BLL.VipCollectionBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + skuid + " and vc_IsDel=0");
                    if (coll.Count > 0)
                    {
                        return "已收藏";
                    }
                    else
                    {
                        cmodel.sku_ID = int.Parse(skuid);
                        cmodel.m_ID = mid;
                        cmodel.vc_CreateOn = DateTime.Now;
                        result = new BLL.VipCollectionBase().Add(cmodel);
                    }
                }
                if (result)
                {
                    return "操作成功";
                }
                else
                {
                    return "操作失败";
                }
            }
            else
            {
                return "未登陆";
            }
        }


        //加入购物车
        [HttpPost]
        public string insertintoCart()
        {
            int skuid = 0;
            int count = 0;
            int result = 0;
            bool result2 = false;
            string mm = "";
            string skuidlist = "";
            if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
            {
                skuid = int.Parse(RequestBase.GetString("skuid").ToString());
            }

            if (!string.IsNullOrEmpty(RequestBase.GetString("count")))
            {
                count = int.Parse(RequestBase.GetString("count").ToString());
            }
            if (LoginMember != null)
            {
                int mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                Model.ShoppingCartBase scmodel = new ShoppingCartBase();

                var groupbuy = new BLL.GroupPurchaseBase().GetModelList(" sku_ID=" + skuid + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "' and gp_pCount-gp_SaleCount>0");
                if (groupbuy.Count>0)//是团购
                {
                    #region
                    var gplist = groupbuy[0];
                        model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + skuid);//商品信息
                        var sclist = new BLL.ShoppingCartBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + skuid + " and sc_IsDel=0 and sc_IsGP=1");
                        if (sclist.Count > 0)
                        {
                            Model.ShoppingCartBase upmodel = new BLL.ShoppingCartBase().GetModel(sclist[0].sc_ID);
                            //改数量
                            upmodel.sc_pCount += count;
                            upmodel.sc_pPric = gplist.gp_pPric;
                            upmodel.sc_CreateOn = DateTime.Now;
                            upmodel.sc_IsGP = true;
                            result2 = new BLL.ShoppingCartBase().Update(upmodel);

                        }
                        else
                        {
                            //添加
                            scmodel.m_ID = mid;
                            scmodel.sc_pCount = count;
                            scmodel.sc_pPric = gplist.gp_pPric;
                            scmodel.sc_CreateOn = DateTime.Now;
                            scmodel.sku_ID = skuid;
                            scmodel.sc_IsGP = true;
                            result = new BLL.ShoppingCartBase().Add(scmodel);
                        }
                        if (result > 0 || result2)
                        {
                            int? pcount = 0;
                            decimal? ppric;
                            decimal pricecount = 0;
                            int? allpcount = 0;
                            var scalllist = new BLL.ShoppingCartBase().GetModelList("  m_ID=" + mid + "and sc_IsDel=0");
                            //ViewData["pcount"] = sclist.Count;
                            foreach (var item in scalllist)
                            {
                                skuidlist += item.sku_ID + ",";
                                pcount = item.sc_pCount;
                                ppric = item.sc_pPric;
                                pricecount += decimal.Parse(((double)pcount * (double)ppric).ToString());
                                allpcount += pcount;
                            }
                            string skuids = skuidlist.Substring(0, skuidlist.Length - 1);
                            return skuids;
                        }
                        else
                        {
                            mm = "fail";
                            return mm;
                        }
                    #endregion
                }
                else//不是团购
                {
                    #region
                    Model.SKUBase skumodel = new BLL.SKUBase().GetModelList(" sku_ID=" + skuid)[0];
                    if (skumodel.sku_Stock > 0)
                    {
                        model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + skuid);//商品信息
                        var sclist = new BLL.ShoppingCartBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + skuid + " and sc_IsDel=0  and sc_IsGP=0");
                        if (sclist.Count > 0)
                        {
                            Model.ShoppingCartBase upmodel = new BLL.ShoppingCartBase().GetModel(sclist[0].sc_ID);
                            //改数量
                            upmodel.sc_pCount += count;
                            upmodel.sc_pPric = model.vmpinfolist[0].sku_Price;
                            upmodel.sc_CreateOn = DateTime.Now;
                            upmodel.sc_IsGP = false;
                            result2 = new BLL.ShoppingCartBase().Update(upmodel);

                        }
                        else
                        {
                            //添加
                            scmodel.m_ID = mid;
                            scmodel.sc_pCount = count;
                            scmodel.sc_pPric = model.vmpinfolist[0].sku_Price;
                            scmodel.sc_CreateOn = DateTime.Now;
                            scmodel.sku_ID = skuid;
                            scmodel.sc_IsGP = false;
                            result = new BLL.ShoppingCartBase().Add(scmodel);
                        }
                        if (result > 0 || result2)
                        {
                            int? pcount = 0;
                            decimal? ppric;
                            decimal pricecount = 0;
                            int? allpcount = 0;
                            var scalllist = new BLL.ShoppingCartBase().GetModelList("  m_ID=" + mid + "and sc_IsDel=0");
                            //ViewData["pcount"] = sclist.Count;
                            foreach (var item in scalllist)
                            {
                                skuidlist += item.sku_ID + ",";
                                pcount = item.sc_pCount;
                                ppric = item.sc_pPric;
                                pricecount += decimal.Parse(((double)pcount * (double)ppric).ToString());
                                allpcount += pcount;
                            }
                            string skuids = skuidlist.Substring(0, skuidlist.Length - 1);
                            return skuids;
                        }
                        else
                        {
                            mm = "fail";
                            return mm;
                        }
                    }
                    else
                    {
                        string html = "库存不足，无法购买！";
                        return html;

                    }
                    #endregion
                }
            }
            else
            {
                mm = "nologon";

                return mm;
            }
        }

    }
}