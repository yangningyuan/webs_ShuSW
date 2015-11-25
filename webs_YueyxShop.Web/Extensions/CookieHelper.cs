using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webs_YueyxShop.Model;



/// <summary>
///CookieHelper 的摘要说明
/// </summary>
public class CookieHelper
{
	public CookieHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 添加商品信息到Cookie
    /// </summary>
    /// <param name="CookieName"></param>
    /// <param name="skuNum"></param>
    /// <param name="goodInfo"></param>
    public static void AddandRepairGoodsToCookie(string CookieName, string skuNum, string goodInfo)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];

        if (cookie == null)
        {
            cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Values.Add(skuNum, goodInfo);
            HttpContext.Current.Response.Cookies.Add(cookie);
            
        }

        else if (cookie.Values.AllKeys.Contains(skuNum))
        {
            cookie.Expires = DateTime.Now.AddYears(10);
            try
            {
                int Goodsnum = Int32.Parse(cookie.Values[skuNum]) + Int32.Parse(goodInfo);
                cookie.Values[skuNum] = Goodsnum.ToString();
            }
            catch
            {
                cookie.Values[skuNum] = goodInfo;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        else
        {
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Values.Add(skuNum, goodInfo);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }

    /// <summary>
    /// 添加商品信息到Cookie
    /// </summary>
    /// <param name="CookieName"></param>
    /// <param name="skuNum"></param>
    /// <param name="goodInfo"></param>
    public static void AddandRepairGoodsToCookie(string CookieName, string skuNum)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];

        if (cookie == null)
        {
            cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Values.Add(skuNum,"");
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        else 
        {
            if (cookie.Values.AllKeys.Contains(skuNum))
            {
            }
            else
            {
                cookie.Expires = DateTime.Now.AddYears(10);
                cookie.Values.Add(skuNum, "");
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
           
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
    /// <summary>
    /// 删除指定的cookie
    /// </summary>
    /// <param name="CookieName"></param>
    /// <param name="skuNum"></param>
    /// <param name="goodsInfo"></param>
    public static void RelGoodsOfCookie(string CookieName, string skuNum)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
        if (cookie != null)
        {
            if (cookie.Values.AllKeys.Contains(skuNum))
            {
                cookie.Values.Remove(skuNum);
                if (cookie.Value == "")
                {
                    cookie.Expires = DateTime.Now.AddDays(-10);
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }


    public static void RemovedCookie(string cookieName)
    {
        HttpCookie cookie = new HttpCookie(cookieName);

        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }


    /// <summary>
    /// 修改cookie中商品购买数量
    /// </summary>
    /// <param name="cookieName">cookie名</param>
    /// <param name="skuId">skuid</param>
    /// <param name="goodsCount">修改后商品数量</param>
    public static void UpdateCookie(string cookieName, string skuId, string goodsCount)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
        if (cookie != null)
        { 
            if(cookie.Values.AllKeys.Contains(skuId))
            {
                cookie.Values[skuId] = goodsCount;
                cookie.Expires = DateTime.Now.AddYears(10);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}