using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Models
{

    public class ListModel
    {

        public List<webs_YueyxShop.Model.RegionBase> regList;

        public List<webs_YueyxShop.Model.Adert> adlist;
        /// <summary>
        /// 当前路径
        /// </summary>
        public string path = "";
        /// <summary>
        /// 会员信息
        /// </summary>
        public webs_YueyxShop.Model.MemberInfo Minfo;
        public webs_YueyxShop.Model.MemberBase member;
        /// <summary>
        /// 商品分类
        /// </summary>
        public List<webs_YueyxShop.Model.ProductTypeBase> ptlist;

        /// <summary>
        /// 品牌
        /// </summary>
        public List<webs_YueyxShop.Model.BrandBase> blist;
        /// <summary>
        /// 团购详情视图
        /// </summary>
        public List<webs_YueyxShop.Model.vm_GBDetails> vmgblist;
        /// <summary>
        /// 团购详情视图
        /// </summary>
        public List<webs_YueyxShop.Model.vm_GPDetails> vmgplist;

        /// <summary>
        /// 团购信息
        /// </summary>
        public webs_YueyxShop.Model.vm_GBDetails gbmodel;
        /// <summary>
        /// 商品信息介绍列表
        /// </summary>
        public List<webs_YueyxShop.Model.ProductInfoBase> pinfoList;
        /// <summary>
        ///商品详情视图
        /// </summary>
        public List<webs_YueyxShop.Model.vw_PInfo> vmpinfolist;
        /// <summary>
        ///商品图片
        /// </summary>
        public List<webs_YueyxShop.Model.ProductImgBase> pimglist;
        /// <summary>
        ///商品信息
        /// </summary>
        public List<webs_YueyxShop.Model.ProductInfoBase> productinfo;
        /// <summary>
        public List<webs_YueyxShop.Model.ProductInfoBase> productinfotuijian;
        ///商品属性
        /// </summary>
        public List<webs_YueyxShop.Model.ProductAttributesBase> proattr;
        /// <summary>
        ///商品规格
        /// </summary>
        public List<webs_YueyxShop.Model.ProductAttributesBase> proattr2;
        /// <summary>
        ///商品颜色
        /// </summary>
        public List<webs_YueyxShop.Model.ProductAttributesBase> proattr3;
        /// <summary>
        ///商品咨询和回复 全部
        /// </summary>
        public List<webs_YueyxShop.Model.ProductConsultBase> prozixunall;
        /// <summary>
        ///商品咨询和回复 类别1
        /// </summary>
        public List<webs_YueyxShop.Model.ProductConsultBase> prozixunp1;
        /// <summary>
        ///商品咨询和回复 类别2
        /// </summary>
        public List<webs_YueyxShop.Model.ProductConsultBase> prozixunp2;
        /// <summary>
        ///商品咨询和回复 类别3
        /// </summary>
        public List<webs_YueyxShop.Model.ProductConsultBase> prozixunp3;
        /// <summary>
        ///商品咨询和回复 类别4
        /// </summary>
        public List<webs_YueyxShop.Model.ProductConsultBase> prozixunp4;

        /// <summary>
        ///商品评论
        /// </summary>
        public List<webs_YueyxShop.Model.ProductAppraiseBase> pinglun;
        /// <summary>
        /// 数据集
        /// </summary>
        public DataSet ds;
        /// <summary>
        /// 数据集
        /// </summary>
        public DataTable dt;

        //团购分页列表
        public List<webs_YueyxShop.Model.vm_GBDetails> vmgblistpage;
        //团购分页列表
        public List<webs_YueyxShop.Model.vw_PInfo> zhoupaihang;
    }
}