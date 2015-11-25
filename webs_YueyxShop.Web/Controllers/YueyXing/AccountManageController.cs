using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using Models;
using Common;

namespace webs_YueyxShop.Web.Controllers.YueyXing
{
    public class AccountManageController : MasterPageController
    {
        private BLL.MemberBase mbbll = new BLL.MemberBase();
        private BLL.RegionBase _regionBase = new BLL.RegionBase();
        //
        // GET: /AccountManage/

        /// <summary>
        /// 账户管理-账户资料页面
        /// </summary>
        /// <returns></returns>
        public ActionResult vipAccountData() 
        {
            //Model.MemberBase mbmodel = new Model.MemberBase();
            //mbmodel=mbbll.GetModel(2);

            
            //if (mbmodel.m_Provice != null && mbmodel.m_City != null && mbmodel.m_Count != null)

            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
                Model.MemberBase mbmodel = new Model.MemberBase();
                mbmodel = mbbll.GetModel(mid);

                #region 绑定居住地址

                if (mbmodel.m_Provice != null && mbmodel.m_City != null && mbmodel.m_Count != null)
                {
                    var modelList = _regionBase.GetModelList(" reg_PId = 0");

                    List<SelectListItem> selectType = new List<SelectListItem>();
                    selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                    foreach (var model in modelList)
                    {
                        selectType.Add(new SelectListItem
                        {
                            Value = model.reg_Code.ToString(),
                            Text = model.reg_Name
                        });
                    }
                    var modelList2 = _regionBase.GetModelList(" reg_PId=" + mbmodel.m_Provice);
                    List<SelectListItem> selectType2 = new List<SelectListItem>();
                    selectType2 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                    foreach (var model in modelList2)
                    {
                        selectType2.Add(new SelectListItem
                        {
                            Value = model.reg_Code.ToString(),
                            Text = model.reg_Name
                        });
                    }
                    var modelList3 = _regionBase.GetModelList(" reg_PId=" + mbmodel.m_City);
                    List<SelectListItem> selectType3 = new List<SelectListItem>();
                    selectType3 = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                    foreach (var model in modelList3)
                    {
                        selectType3.Add(new SelectListItem
                        {
                            Value = model.reg_Code.ToString(),
                            Text = model.reg_Name
                        });
                    }
                    ViewData["selectType"] = new SelectList(selectType, "Value", "Text", mbmodel.m_Provice);

                    ViewData["selectType2"] = new SelectList(selectType2, "Value", "Text", mbmodel.m_City);

                    ViewData["selectType3"] = new SelectList(selectType3, "Value", "Text", mbmodel.m_Count);
                }
                else
                {
                    var modelList = _regionBase.GetModelList(" reg_PId = 0");

                    List<SelectListItem> selectType = new List<SelectListItem>();
                    selectType = new List<SelectListItem> { new SelectListItem { Text = "请选择", Value = "chose" } };
                    foreach (var model in modelList)
                    {
                        selectType.Add(new SelectListItem
                        {
                            Value = model.reg_Code.ToString(),
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
                }
                #endregion

                ViewData["sex"] = mbmodel.m_Sex;
                ViewData["headimg"] = mbmodel.m_HeadImg;
                return View(mbmodel);
            }
            else
            {
                Response.Redirect("/Logon/Logon");
                return View();
            }

        }

        /// <summary>
        /// 账户管理-账户资料方法
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult vipAccountDataSave(Model.MemberBase memodel)
        {
            bool result = false;
            try
            {
                string sheng =Request.Form["selectType"];
                string shi = Request.Form["selectType2"];
                string xian =Request.Form["selectType3"];
                string sex = Request.Form["sex"];//性别
                
                //添加图片
                HttpPostedFileBase file = Request.Files["imageUpLoad"];
                string filename = Path.GetFileName(file.FileName);//文件名与后缀
                
                if (filename != "") 
                {
                    int imgmax = 1024000;
                    if (file.InputStream.Length < imgmax)
                    {
                        string riqiurl = DateTime.Now.ToString("yyyyMMddHHmmss") + new DateTime().Millisecond.ToString();

                        string baocunurl = Server.MapPath("/_filebase/uploadImg/" + riqiurl + filename);
                        file.SaveAs(baocunurl);
                        memodel.m_HeadImg = "/_filebase/uploadImg/" + riqiurl + filename;
                    }
                    else {
                        return Content("<script>alert('上传图片过大，请检查！');location.href='vipAccountData'</script>");
                    }
                }
                
                if (sex == "secret") 
                {
                    memodel.m_Sex = 2;
                }
                else if (sex == "male")
                {
                    memodel.m_Sex = 0;
                }
                else {
                    memodel.m_Sex = 1;
                }

                if (sheng != "chose") 
                {
                    memodel.m_Provice = int.Parse(Request.Form["selectType"]);
                }
                if (shi != "chose") 
                {
                    memodel.m_City = int.Parse(Request.Form["selectType2"]);
                }
                if (xian!= "chose")
                {
                    memodel.m_Count = int.Parse(Request.Form["selectType3"]);
                }
                 
                result = mbbll.Update(memodel);
                if (result)
                {
                    return Content("<script>alert('保存成功！');location.href='vipAccountData'</script>");
                    //return RedirectToAction("vipAccountData", "AccountManage");
                }
                else {
                    return Content("<script>alert('数据异常，请检查数据！');location.href='vipAccountData'</script>");
                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 账户管理-商品评价页面
        /// </summary>
        /// <returns></returns>
        public ActionResult vipMyEvaluation()
        {
           // Model.MemberBase model = null;

            var model = new ListModel();
            string where = "";
            string where2 = "";
            string sortby = " order by pa.pa_Id";
            int page = 1;
            int pagerows = 2;
            string skulist = "";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;

                Model.ProductAppraiseBase cmodel = new Model.ProductAppraiseBase();
                var clist = new BLL.ProductAppraiseBase().GetModelList(" m_Id=" + mid + " and pa_IsDel=0 and pa_StatusCode=0");
                if (clist.Count > 0)
                {
                    ViewData["Appraise"] = true;
                    foreach (var item in clist)
                    {
                        skulist += item.sku_ID + ",";
                    }
                    skulist = skulist.Substring(0, skulist.Length - 1);
                    where = " and  vw.sku_ID in(" + skulist + ")";
                    where2 = " and  sku_ID in(" + skulist + ")";

                    model.vmpinfolist = new BLL.vw_PInfo().GetModelListPA(" pa.m_ID=" + mid + " and p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   and pa.pa_IsDel=0 " + where, page, pagerows, sortby);

                    ViewData["count"] = clist.Count;
                    ViewData["pagerows"] = pagerows;
                    ViewData["page"] = page;

                    return View(model.vmpinfolist);
                }
                else
                {
                    ViewData["Appraise"] = false;
                    return View();
                }
            }
            else
            {
                Response.Redirect("/Index/Index");
                return View();
            }

           
        }

        //异步加载商品评价分页
        [HttpPost]
        public string evapage()
        {
            int pageSize = 2;//每一页的行数
            int pageNumber = 1;//当前页数 
            string html = "";
            string skuid = "";
            string where = "";
            string where2 = "";
            string skulist = "";
            string sortby = " order by pa.pa_Id";
            int mid = 0;
            if (LoginMember != null)
            {
                mid = (CookieEncrypt.DeserializeObject(System.Web.HttpContext.Current.Request.Cookies["UserInfo"].Value) as Model.MemberBase).m_ID;
            }
            Model.ProductAppraiseBase cmodel = new Model.ProductAppraiseBase();
            var clist = new BLL.ProductAppraiseBase().GetModelList(" m_Id=" + mid + " and pa_IsDel=0 and pa_StatusCode=0");
            if (clist.Count > 0)
            {
                foreach (var item in clist)
                {
                    skulist += item.sku_ID + ",";
                }
                skulist = skulist.Substring(0, skulist.Length - 1);
                where2 = " and  vw.sku_ID in(" + skulist + ")";
                where = " and  sku_ID in(" + skulist + ")";
            }
            if (!string.IsNullOrEmpty(RequestBase.GetString("pageNum")))
            {
                pageNumber = Convert.ToInt32(RequestBase.GetString("pageNum"));
            }
            List<Model.vw_PInfo> list = new BLL.vw_PInfo().GetModelList(" p_IsDel=0 and p_SellStatus=1 and p_StatusCode=0   " + where);
            ViewBag.collect = new BLL.vw_PInfo().GetModelListPA(" pa.m_ID=" + mid + " and p_IsDel=0 and p_StatusCode=0 and p_SellStatus=1   and pa.pa_IsDel=0 " + where2, pageNumber, pageSize, sortby);
            //ViewBag.collect = list.ToPagedList(pageNumber, pageSize);
            foreach (var item in ViewBag.collect)
            {
                html += " <li><table class=\"order-list\"><tbody><tr><td width=\"345\"><div class=\"pro-imgs\"><a href=\"/ProDetail/ProDetail?skuid="+item.sku_ID+"\"><img name=\"page_cnt_1\" _src=\""+item.pi_Url+"\" alt=\""+item.p_Name+"\" /></a></div><p><a href=\"/ProDetail/ProDetail?skuid="+item.sku_ID+"\">"+item.p_Name+" "+ item.shuxing+"</a></p></td><td width=\"200\" align=\"center\">";
                if (item.pa_Satisfied == 1)
                {  html += "<div class=\"stars star-icon1\"></div>";}
                else if (item.pa_Satisfied == 2)
                {  html +="<div class=\"stars star-icon2\"></div>";}
                else if (item.pa_Satisfied == 3)
                {html +="<div class=\"stars star-icon3\"></div>";}
                else if (item.pa_Satisfied == 4)
                { html +="<div class=\"stars star-icon4\"></div>";}
                else if (item.pa_Satisfied == 5)
                {html += "<div class=\"stars star-icon5\"></div>";}
                else
                {
                    html += "<div class=\"stars star-icon5\"></div>";
                }
                html += "</td><td width=\"320\">" + item.pa_Content + "</td></tr></tbody></table></li>";
            }
            return html;

        }
    }
}
