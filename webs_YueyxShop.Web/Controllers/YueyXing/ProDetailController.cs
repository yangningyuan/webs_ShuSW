using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using PagedList;
using webs_YueyxShop.Model;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class ProDetailController : MasterPageController
    {
        //
        // GET: /ProDetail/

        BLL.BrandBase bbll = new BLL.BrandBase();
        BLL.ProductBase pbll = new BLL.ProductBase();
        BLL.ProductTypeBase ptbll = new BLL.ProductTypeBase();
        private BLL.NewsBase _newsBase = new BLL.NewsBase();
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
            model.pimglist = new BLL.ProductImgBase().GetModelList(" sku_ID=" + int.Parse(skuid)+" and pi_IsDel=0 and pi_StatusCode=0");//图片列表
            model.productinfo = new BLL.ProductInfoBase().GetModelList(" p_ID=(select p_ID from SKUBase where sku_ID=" + skuid + ") and pin_StatusCode=0 and pin_IsDel=0 and pin_Type='商品介绍'");//商品介绍
            model.proattr = new BLL.ProductAttributesBase().GetModelListByskuId(" pad.sku_ID= " + int.Parse(skuid));//属性
            model.proattr2 = new BLL.ProductAttributesBase().GetModelListByPid(" and pa.pa_Type=2 and pa.pa_ID in(select pa_ID from ProductAttributeDetails where  sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + int.Parse(skuid) + "))) and sku.sku_ID in (select sku_ID from SKUBase where p_ID=(select p_ID from SKUBase where sku_ID=" + int.Parse(skuid) + "))");//规格
            model.zhoupaihang = new BLL.vw_PInfo().getmodelListPH();
            //评论
            model.pinglun = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid) + "and pa_StatusCode=0 and pa_IsDel=0");
            if (model.pinglun.Count > 0)
            {
                ViewData["pingluncount"] = model.pinglun.Count;
                ViewData["tiao"] = int.Parse(model.pinglun[0].pavg.ToString()) * 20;//显示满意度的箭头所指的地方
                ViewData["xing"] = int.Parse(model.pinglun[0].pavg.ToString()) * 68 / 5;//显示满意度的箭头所指的地方
            }
            else
            {
                ViewData["pingluncount"] = "0";
            }


            //咨询
            model.prozixunall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + "and pc_StatusCode=0 and pc_IsDel=0");
            var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid));
            ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["all"] = model.prozixunall.Count;

            model.prozixunp1 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='促销活动提问'");
            var zx1 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='促销活动提问'");
            ViewBag.zx1 = zx1.ToPagedList(zixunpageNumber, zixunpageSize);

            model.prozixunp2 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='库存及物流提问'");
            var zx2 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='库存及物流提问'");
            ViewBag.zx2 = zx2.ToPagedList(zixunpageNumber, zixunpageSize);

            model.prozixunp3 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='售后提问'");
            var zx3 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='售后提问'");
            ViewBag.zx3 = zx3.ToPagedList(zixunpageNumber, zixunpageSize);

            model.prozixunp4 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='商品提问'");
            var zx4 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='商品提问'");
            ViewBag.zx4 = zx4.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["p1"] = model.prozixunp1.Count;
            ViewData["p2"] = model.prozixunp2.Count;
            ViewData["p3"] = model.prozixunp3.Count;
            ViewData["p4"] = model.prozixunp4.Count;
            if (model.vmpinfolist.Any())
            {
                ViewData["youhui"] = model.vmpinfolist[0].sku_scPric - model.vmpinfolist[0].sku_Price;
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
            }
            else
            {
                ViewData["youhui"] = 0;
            }
            var groupbuy = new BLL.GroupPurchaseBase().GetModelList(" sku_ID=" + skuid + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'");
            if (groupbuy.Count > 0)
            {
                ViewBag.tuan = groupbuy[0];
            }
            else
            {
                ViewBag.tuan = null; ;
            }

            

            var zixunshuoming = _newsBase.GetModelList(" n_Title='咨询说明'  and n_StatusCode=0 and n_IsDel=0");
            if (zixunshuoming != null && zixunshuoming.Any())
            {
                ViewBag.zixunshuoming = zixunshuoming[0].n_Content;
            }
            else
            {
                ViewBag.zixunshuoming = "暂无咨询说明";
            }
            return View(model);
        }

        #region 评论
        public ActionResult ProPinglun()
        {
            int pinglunpageSize = 2;//每一页的行数
            int pinglunpageNumber = 1;//当前页数 
            //评论
            model.pinglun = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid) + "and pa_StatusCode=0 and pa_IsDel=0 order by pa_CreatedOn desc");
            model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + int.Parse(skuid));//商品信息
            ViewBag.vmpinfolist = model.vmpinfolist[0];
            if (model.pinglun.Count > 0)
            {
                ViewData["midcount"] = model.pinglun[0].member.midcount;
                ViewData["pinglunscore"] = model.pinglun[0].pavg;
                ViewData["tiao"] = int.Parse(model.pinglun[0].pavg.ToString()) * 20;//显示满意度的箭头所指的地方
                ViewData["xing"] = int.Parse(model.pinglun[0].pavg.ToString()) * 68 / 5;//显示满意度的箭头所指的地方
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
            var pl = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID=" + int.Parse(skuid)+" and pa_IsDel=0 and pa_StatusCode=0 order by pa_CreatedOn desc");
            ViewBag.pinlun = pl.ToPagedList(pinglunpageNumber, pinglunpageSize);

            ViewData["pingluncount"] = model.pinglun.Count;
            ViewData["pagerows"] = pinglunpageSize;
            ViewData["page"] = pinglunpageNumber;
            var pinglunshuoming = _newsBase.GetModelList(" n_Title='商品评论说明'  and n_StatusCode=0 and n_IsDel=0");
            if (pinglunshuoming != null && pinglunshuoming.Any())
            {
                ViewBag.pinglunshuoming = pinglunshuoming[0].n_Content;
            }
            else
            {
                ViewBag.pinglunshuoming = "暂无商品评论说明";
            }
            return View(ViewBag.pinlun);
        }
        //异步加载评论分页
        [HttpPost]
        public string ProPinglun2()
        {
            int pinglunpageSize = 2;//每一页的行数
            int pinglunpageNumber = 1;//当前页数 
            string html = "";
            int xing = 0;
            string skuid = "";
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pinglunpageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
            {
                skuid = RequestBase.GetString("skuid").ToString();
            }
            var pl = new BLL.ProductAppraiseBase().GetModelListByskuId(" sku_ID= " + int.Parse(skuid) + " order by pa_CreatedOn desc");
            ViewBag.pinlun = pl.ToPagedList(pinglunpageNumber, pinglunpageSize);
            html += "<ul class=\"vip-pj-list\">";
            if (pl.Count > 0)
            {
                xing = int.Parse(pl[0].pavg.ToString()) * 68 / 5; 
            }
            
            foreach (var item in ViewBag.pinlun)
            {
                var fen = item.pa_Satisfied;
                var width = fen * 1 * 68 / 5;
                
                html += "<li><div class=\"head-img\"><dl><dt><img name=\"page_cnt_1\" _src=\"" + item.member.m_HeadImg + "\" alt=\"会员头像\" /></dt><dd>" + item.member.m_UserName + "</dd></dl></div><div class=\"borders vip-pj\"><div class=\"dashed-div\"><div class=\"pj-star alignleft\"><span><em class=\"showstart\" value=\""+item.pa_Satisfied+"\" style=\"width:"+width+"px\"></em></span></div><div class=\"say-time alignright\">" + item.pa_CreatedOn + "</div><div class=\"clear\"></div></div><!--dashed-div end--><div class=\"dashed-div\"><div class=\"pj-font\">评价：</div><div class=\"pj-fonts\"><p>" + item.pa_Content + "</p></div></div><!--dashed-div end--><div class=\"button-pointer\"><div class=\"hands\"></div><span value=\"@item.pa_ID\">赞（<i>" + item.pa_PraiseCount + "</i>）</span></div></div></li>";
            }
            html += " </ul>";
            return html;

        }
        #endregion

        #region  咨询
        //咨询 全部
        public ActionResult Zixunall()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 

            //咨询
            model.prozixunall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + "and pc_StatusCode=0 and pc_IsDel=0");
            var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid));
            ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["all"] = model.prozixunall.Count;
            ViewData["zxcount"] = model.prozixunall.Count;
            ViewData["zxpagerows"] = zixunpageSize;
            ViewData["zxpage"] = zixunpageNumber;
            return View(ViewBag.zxall);
        }
        //咨询 类1
        public ActionResult Zixunp1()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 

            //咨询
            model.prozixunp1 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='促销活动提问'");
            var zx1 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='促销活动提问'");
            ViewBag.zx1 = zx1.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["p1"] = model.prozixunp1.Count;
            ViewData["p1count"] = model.prozixunp1.Count;
            ViewData["p1pagerows"] = zixunpageSize;
            ViewData["p1page"] = zixunpageNumber;
            return View(ViewBag.zx1);
        }
        //咨询  类2
        public ActionResult Zixunp2()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 

            //咨询
            model.prozixunp2 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='库存及物流提问'");
            var zx2 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='库存及物流提问'");
            ViewBag.zx2 = zx2.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["p2"] = model.prozixunp2.Count;
            ViewData["zxp2count"] = model.prozixunp2.Count;
            ViewData["zxp2pagerows"] = zixunpageSize;
            ViewData["zxp2page"] = zixunpageNumber;
            return View(ViewBag.zx2);
        }
        //咨询  类3
        public ActionResult Zixunp3()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 

            //咨询
            model.prozixunp3 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='售后提问'");
            var zx3 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='售后提问'");
            ViewBag.zx3 = zx3.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["p3"] = model.prozixunp3.Count;
            ViewData["zxp3count"] = model.prozixunp3.Count;
            ViewData["zxp3pagerows"] = zixunpageSize;
            ViewData["zxp3page"] = zixunpageNumber;
            return View(ViewBag.zx3);
        }
        //咨询  类4
        public ActionResult Zixunp4()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 

            //咨询
            model.prozixunp4 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='商品提问'");
            var zx4 = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='商品提问'");
            ViewBag.zx4 = zx4.ToPagedList(zixunpageNumber, zixunpageSize);
            ViewData["p4"] = model.prozixunp4.Count;
            ViewData["zxp4count"] = model.prozixunp4.Count;
            ViewData["zxp4pagerows"] = zixunpageSize;
            ViewData["zxp4page"] = zixunpageNumber;
            return View(ViewBag.zx4);
        }
        //异步加载 全部咨询 分页
        [HttpPost]
        public string all()
        {
            int zixunpageSize = 2;//每一页的个数
            int zixunpageNumber = 1;//当前页数 
            string html = "";
            string skuid = "";
            int type = 0;
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                zixunpageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("skuid")))
            {
                skuid = RequestBase.GetString("skuid").ToString();
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("type")))
            {
                type = Convert.ToInt32(RequestBase.GetString("type"));
            }
            if (type == 1)
            {
                var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='促销活动提问'");
                ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
                foreach (var item in ViewBag.zxall)
                {
                    html += "<li><dl><dt><div class=\"q-icon\"></div><div class=\"q-cont\"><p><span class=\"alignleft\">" + item.member.m_UserName + "</span><font class=\"alignright\">" + item.pc_CreatedOn + "</font></p><p>" + item.pc_Content + "</p></div></dt><dd><div class=\"a-icon\"></div><div class=\"a-cont\"><p><span class=\"alignleft\">月月兴食品商行客服回复：</span><font class=\"alignright\">" + item.preply.pr_CreatedOn + "</font></p><p>" + item.preply.pr_Content + "</p></div></dd></dl></li>";
                }
                return html;
            }
            else if (type == 2)
            {
                var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='库存及物流提问'");
                ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
                foreach (var item in ViewBag.zxall)
                {
                    html += "<li><dl><dt><div class=\"q-icon\"></div><div class=\"q-cont\"><p><span class=\"alignleft\">" + item.member.m_UserName + "</span><font class=\"alignright\">" + item.pc_CreatedOn + "</font></p><p>" + item.pc_Content + "</p></div></dt><dd><div class=\"a-icon\"></div><div class=\"a-cont\"><p><span class=\"alignleft\">月月兴食品商行客服回复：</span><font class=\"alignright\">" + item.preply.pr_CreatedOn + "</font></p><p>" + item.preply.pr_Content + "</p></div></dd></dl></li>";
                }
                return html;
            }
            else if (type == 3)
            {
                var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='售后提问'");
                ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
                foreach (var item in ViewBag.zxall)
                {
                    html += "<li><dl><dt><div class=\"q-icon\"></div><div class=\"q-cont\"><p><span class=\"alignleft\">" + item.member.m_UserName + "</span><font class=\"alignright\">" + item.pc_CreatedOn + "</font></p><p>" + item.pc_Content + "</p></div></dt><dd><div class=\"a-icon\"></div><div class=\"a-cont\"><p><span class=\"alignleft\">月月兴食品商行客服回复：</span><font class=\"alignright\">" + item.preply.pr_CreatedOn + "</font></p><p>" + item.preply.pr_Content + "</p></div></dd></dl></li>";
                }
                return html;
            }
            else if (type == 4)
            {
                var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid) + " and pc.pc_Type='商品提问'");
                ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
                foreach (var item in ViewBag.zxall)
                {
                    html += "<li><dl><dt><div class=\"q-icon\"></div><div class=\"q-cont\"><p><span class=\"alignleft\">" + item.member.m_UserName + "</span><font class=\"alignright\">" + item.pc_CreatedOn + "</font></p><p>" + item.pc_Content + "</p></div></dt><dd><div class=\"a-icon\"></div><div class=\"a-cont\"><p><span class=\"alignleft\">月月兴食品商行客服回复：</span><font class=\"alignright\">" + item.preply.pr_CreatedOn + "</font></p><p>" + item.preply.pr_Content + "</p></div></dd></dl></li>";
                }
                return html;
            }
            else
            {
                var zxall = new BLL.ProductConsultBase().GetModelListByskuId(" and sku_ID= " + int.Parse(skuid));
                ViewBag.zxall = zxall.ToPagedList(zixunpageNumber, zixunpageSize);
                foreach (var item in ViewBag.zxall)
                {
                    html += "<li><dl><dt><div class=\"q-icon\"></div><div class=\"q-cont\"><p><span class=\"alignleft\">" + item.member.m_UserName + "</span><font class=\"alignright\">" + item.pc_CreatedOn + "</font></p><p>" + item.pc_Content + "</p></div></dt><dd><div class=\"a-icon\"></div><div class=\"a-cont\"><p><span class=\"alignleft\">月月兴食品商行客服回复：</span><font class=\"alignright\">" + item.preply.pr_CreatedOn + "</font></p><p>" + item.preply.pr_Content + "</p></div></dd></dl></li>";
                }
                return html;
            }

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
                    return "请输入200个以内的字符";
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
                    pamodel.m_ID = mid;
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
                    return "提交成功";
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

        //最终购买
        public ActionResult zuizhongDetail()
        {
            List<Model.ProductBase> pinfo = pbll.GetpInfoByRecommendTypeId(1);
            ViewBag.zuizhong = pinfo.ToList();
            var groupbuy = new BLL.GroupPurchaseBase().GetModelList("  gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'");
            return View(groupbuy.ToList());
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
                    List<Model.VipCollectionBase> coll = new BLL.VipCollectionBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + skuid+" and vc_IsDel=0");
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
                else {
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
            bool result2=false;
            string mm = "";
            decimal pric = 0;
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
                Model.SKUBase skumodel = new BLL.SKUBase().GetModelList(" sku_ID=" + skuid)[0];
                if (skumodel.sku_Stock > 0)
                {
                    model.vmpinfolist = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1  and sku_ID= " + skuid);//商品信息
                    var sclist = new BLL.ShoppingCartBase().GetModelList(" m_ID=" + mid + " and sku_ID=" + skuid + " and sc_IsDel=0");
                    if (sclist.Count > 0)
                    {
                        Model.ShoppingCartBase upmodel = new BLL.ShoppingCartBase().GetModel(sclist[0].sc_ID);
                        //改数量
                        string sql = " sku_ID=" + skuid + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'";
                        var gplist = new BLL.GroupPurchaseBase().GetModelList(sql);
                        if (gplist.Count > 0)
                        {
                            upmodel.sc_pPric = decimal.Parse(gplist[0].gp_pPric.ToString());
                            upmodel.sc_IsGP = true;
                        }
                        else
                        {
                            if (model.vmpinfolist.Count>0)
                            upmodel.sc_pPric = decimal.Parse(model.vmpinfolist[0].sku_Price.ToString());
                            upmodel.sc_IsGP = false;
                        }
                        upmodel.sc_pCount += count;
                        //upmodel.sc_pPric = model.vmpinfolist[0].sku_Price;
                        upmodel.sc_CreateOn = DateTime.Now;
                        result2 = new BLL.ShoppingCartBase().Update(upmodel);

                    }
                    else
                    {
                        //添加
                        string sql = " sku_ID=" + skuid + " and gp_StatusCode=0 and gp_IsDel=0 and gp_EndTime > '" + DateTime.Now + "'";
                        var gplist = new BLL.GroupPurchaseBase().GetModelList(sql);
                        if (gplist.Count > 0)
                        {
                            scmodel.sc_pPric = decimal.Parse(gplist[0].gp_pPric.ToString());
                            scmodel.sc_IsGP = true;
                        }
                        else
                        {
                            if (model.vmpinfolist.Count > 0)
                                scmodel.sc_pPric = decimal.Parse(model.vmpinfolist[0].sku_Price.ToString());
                            scmodel.sc_IsGP = false;
                        }
                        scmodel.m_ID = mid;
                        scmodel.sc_pCount = count;
                        //scmodel.sc_pPric = pric;
                        scmodel.sc_CreateOn = DateTime.Now;
                        scmodel.sku_ID = skuid;
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
                            pcount = item.sc_pCount;
                            ppric = item.sc_pPric;
                            pricecount += decimal.Parse(((double)pcount * (double)ppric).ToString());
                            allpcount += pcount;
                        }
                        string html = "<div class=\"modal\" id=\"chart-modal\"><a class=\"close\"   id=\"close\" onclick=\"closeit()\">X</a><div class=\"yes-chart\"><div class=\"yes-icon alignleft\"></div><div class=\"chart-font alignright\"><dl><dt><strong>添加成功！</strong></dt><dd>购物车共有<span> " + allpcount + "</span>件商品，商品总价：<span>¥ " + pricecount + " </span></dd></dl><div class=\"clear\"></div><a class=\"total-chart\" href=\"/Chart/Chart\" style=\"width:140px;\">去购物车结算 ></a><a class=\"go-shop\" href=\"javascript:void(0)\" id=\"keepshopping\" onclick=\"closeit()\">继续购物</a></div><!--chart-font end--></div><!--yes-chart end-->";
                        return html;
                    }
                    else
                    {
                        mm = "fail";
                        return mm;
                    }
                }
                else
                {
                    string html = "<div class=\"modal\" id=\"chart-modal\"><a class=\"close\"   id=\"close\" onclick=\"closeit()\">X</a><div class=\"yes-chart\"><div class=\"yes-icon alignleft\"></div><div class=\"chart-font alignright\"><dl><dt><strong>库存不足，添加失败！</strong></dt></dl><div class=\"clear\"></div><a class=\"total-chart\" href=\"/Chart/Chart\" style=\"width:140px;\">去购物车结算 ></a><a class=\"go-shop\" href=\"javascript:void(0)\" id=\"keepshopping\" onclick=\"closeit()\">继续购物</a></div><!--chart-font end--></div><!--yes-chart end-->";
                    return html;
                    //<div class=\"clear\"></div><div class=\"shop-cont\"><h2>购买该商品的用户还购买了</h2><ul class=\"shop-list\"><li><div class=\"pro-img\"><a href=\"#\"><img src=\"images/products/proList_ad_01.jpg\" alt=\"产品图片\" /></a></div><p><a href=\"#\">SUMACO素玛哥牌多口味进口 ...</a></p><p><span>￥23.90</span><del>￥23.90</del></p></li><li><div class=\"pro-img\"><a href=\"#\"><img src=\"images/products/proList_ad_02.jpg\" alt=\"产品图片\" /></a></div><p><a href=\"#\">SUMACO素玛哥牌多口味进口 ...</a></p><p><span>￥23.90</span><del>￥23.90</del></p></li><li><div class=\"pro-img\"><a href=\"#\"><img src=\"images/products/proList_ad_03.jpg\" alt=\"产品图片\" /></a></div><p><a href=\"#\">SUMACO素玛哥牌多口味进口 ...</a></p><p><span>￥23.90</span><del>￥23.90</del></p></li><li><div class=\"pro-img\"><a href=\"#\"><img src=\"images/products/proList_ad_04.jpg\" alt=\"产品图片\" /></a></div><p><a href=\"#\">SUMACO素玛哥牌多口味进口 ...</a></p><p><span>￥23.90</span><del>￥23.90</del></p></li></ul></div><!--shop-cont end--></div><!--chart-modal end-->
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