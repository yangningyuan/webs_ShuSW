using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace webs_YueyxShop.Web.Controllers.Wap
{
    public class wapAddressController : BaseWapController
    {
        private readonly BLL.RegionBase _regionBase = new BLL.RegionBase();
        private readonly BLL.ConsigneeInfoBase _consigneeInfoBase = new BLL.ConsigneeInfoBase();

        /// <summary>
        /// 收货地址列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressList()
        {
            if (LoginMember == null)
            {
                Response.Redirect("/wapLogin/Login", true);
            }
            else
            {
                var list = _consigneeInfoBase.GetModelList(" c_StatusCode = 0 and c_IsDel = 0 and m_ID = " + LoginMember.m_ID);
                if (list != null && list.Any())
                {
                    ViewData["addressList"] = list;
                }
                else
                {
                    ViewData["addressList"] = null;
                }
            }
            return View();
        }

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressAdd()
        {
            Model.ConsigneeInfoBase ci = new Model.ConsigneeInfoBase();
            string cID = RequestBase.GetString("cID");
            GetProvice();
            if (!string.IsNullOrWhiteSpace(cID))
            {//修改
                ci = _consigneeInfoBase.GetModel(Convert.ToInt32(cID));
                ViewData["CityList"] = GetCity(ci.c_Provice.Value, "City");
                ViewData["CountList"] = GetCity(ci.c_City.Value, "Count");
                ViewData["ProviceTxt"] = ci.c_CProvice;
                ViewData["Provice"] = ci.c_Provice;
                ViewData["CityTxt"] = ci.c_CCity;
                ViewData["City"] = ci.c_City;
                ViewData["CountTxt"] = ci.c_CCount;
                ViewData["Count"] = ci.c_Count;
                ViewData["name"] = ci.c_Name;
                ViewData["phone"] = ci.c_Mobilephone;
                ViewData["zipCode"] = ci.c_Zipcode;
                ViewData["address"] = ci.c_FullAddress;
            }
            ViewData["cID"] = cID;

            return View();
        }

        /// <summary>
        /// 加载省
        /// </summary>
        /// <returns></returns>
        private object GetProvice()
        {
            ViewData["ProviceList"] = GetRegoin(0);
            return ViewData["ProviceList"];
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        public string GetCity(int regid,string region)
        {
            string html = "";
            var model = _regionBase.GetModel(regid);
            var list = GetRegoin(model.reg_Code);
            if (list != null)
            {
                foreach (var reg in list)
                {
                    html += string.Format("<li><a href=\"javascript:void(0)\" onclick=\"choseAddress({0},'{1}','{2}')\"><span>{1}</span></a></li>", reg.reg_ID, reg.reg_Name, region);
                }
            }

            return html;
        }

        /// <summary>
        /// 获取地区
        /// </summary>
        /// <param name="pid">父ID</param>
        private List<Model.RegionBase> GetRegoin(int pid)
        {
            var list = _regionBase.GetModelList(" reg_PId = " + pid);
            if (list != null && list.Any())
            {
                return list;
            }
            return null;
        }

        /// <summary>
        /// 地区选择
        /// </summary>
        /// <returns></returns>
        public ActionResult ChoseRegion()
        {
            string pID = "";
            string id = RequestBase.GetString("id");
            if (!string.IsNullOrWhiteSpace(id) || id == "0")
            {
                pID = "0";
            }
            else
            {
                var model = _regionBase.GetModel(Convert.ToInt32(id));
                pID = model.reg_Code.ToString();
            }
            var subList = _regionBase.GetModelList(" reg_PId = " + pID);
            if (subList == null || !subList.Any())
            {
                subList = null;
            }

            return View(subList);
        }
    }
}