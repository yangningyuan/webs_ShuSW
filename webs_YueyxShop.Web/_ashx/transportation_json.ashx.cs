using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webs_YueyxShop.Web._ashx
{
    /// <summary>
    /// transportation_json 的摘要说明
    /// 运费计算
    /// </summary>
    public class transportation_json : IHttpHandler
    {
        private readonly BLL.SKUBase _skuBase = new BLL.SKUBase();
        private readonly BLL.ProductBase _productBase = new BLL.ProductBase();
        private readonly BLL.CarriageBase _carriageBase = new BLL.CarriageBase();
        private readonly BLL.ConsigneeInfoBase _consigneeInfoBase = new BLL.ConsigneeInfoBase();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string result = "";
            decimal sumPrice = 0;
            //商品SKUID
            string skuID = context.Request.Params["skuID"].ToString();
            //数量
            int count = Convert.ToInt32(context.Request.Params["count"].ToString());
            //收货人主键
            string cID = context.Request.Params["cID"].ToString();
            //配送方式ID
            string stID = context.Request.Params["stID"].ToString();
            //市代码
            int cityId = _consigneeInfoBase.GetModel(Convert.ToInt32(cID)).c_City.Value;
            //商品Id
            int pId = _skuBase.GetModel(Convert.ToInt32(skuID)).p_ID.Value;
            //运费模版主键
            int ctID = _productBase.GetModel(pId).ct_ID.Value;
            Model.CarriageBase carriage = null;
            var list = _carriageBase.GetModelList(" ct_ID = " + ctID + " and st_ID = " + stID);
            if (list.Count == 0)
            {
                result = "未设置运费模版";
            }
            else if (list.Count == 1)
            {
                carriage = list.First();
            }
            else
            {
                //查找是否特殊设置
                var temp = list.Where(m => m.car_area.Contains(cityId.ToString()));
                if (temp.Any())
                {
                    carriage = temp.First();
                }
                else//无特殊设置则为默认
                {
                    carriage = list.Where(m => m.car_Ismoren == true).FirstOrDefault();
                }
            }
            if (carriage == null)
            {
                result = "未找到对应运费模版";
            }
            else//计算运费
            {
                sumPrice = carriage.car_shouCarriage.Value;
                int diffCount = count - carriage.car_shouCount.Value;
                if (diffCount > 0)
                {
                    int unitC = diffCount / carriage.car_xuCount.Value;
                    //不足一个单位按一个单位计算
                    unitC += ((diffCount % carriage.car_xuCount.Value) == 0 ? 0 : 1);
                    sumPrice += unitC * carriage.car_xuCarriage.Value;
                }
                result = sumPrice.ToString();
            }

            context.Response.Write(result);
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