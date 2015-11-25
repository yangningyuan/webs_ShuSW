using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace webs_YueyxShop.Model
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus : int
    {
        提交订单 = 0,

        付款成功 = 1,
        
        商品出库 = 2,
        
        等待收货 = 3,
       
        交易完成 = 4,
        申请退单 = 5
	}
}