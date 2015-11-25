using System;
using System.Reflection;
using System.Configuration;
using Common;
using webs_YueyxShop.IDAL;

namespace webs_YueyxShop.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
    /// DataCache类在导出代码的文件夹里
    /// <appSettings> 
    /// <add key="DAL" value="webs_YueyxShop.DAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess //<t>
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];

        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace); //从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace); //反射创建
                    DataCache.SetCache(ClassNamespace, objType); // 写入缓存
                }
                catch
                {
                }
            }
            return objType;
        }

        /// <summary>
        /// 创建数据层接口
        /// </summary>
        //public static t Create(string ClassName)
        //{
        //string ClassNamespace = AssemblyPath +"."+ ClassName;
        //object objType = CreateObject(AssemblyPath, ClassNamespace);
        //return (t)objType;
        //}

        /// <summary>
        /// 创建BrandBase数据层接口。品牌管理
        /// </summary>
        public static webs_YueyxShop.IDAL.IBrandBase CreateBrandBase()
        {

            string ClassNamespace = AssemblyPath + ".BrandBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IBrandBase)objType;
        }


        /// <summary>
        /// 创建BrandProductAttrBase数据层接口。品牌商品属性明细
        /// </summary>
        public static webs_YueyxShop.IDAL.IBrandProductAttrBase CreateBrandProductAttrBase()
        {

            string ClassNamespace = AssemblyPath + ".BrandProductAttrBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IBrandProductAttrBase)objType;
        }


        /// <summary>
        /// 创建DepartmentBase数据层接口。部门信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IDepartmentBase CreateDepartmentBase()
        {

            string ClassNamespace = AssemblyPath + ".DepartmentBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IDepartmentBase)objType;
        }


        /// <summary>
        /// 创建EmployeeBase数据层接口。员工信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IEmployeeBase CreateEmployeeBase()
        {

            string ClassNamespace = AssemblyPath + ".EmployeeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IEmployeeBase)objType;
        }


        /// <summary>
        /// 创建EmpRolesDetails数据层接口。用户角色明细
        /// </summary>
        public static webs_YueyxShop.IDAL.IEmpRolesDetails CreateEmpRolesDetails()
        {

            string ClassNamespace = AssemblyPath + ".EmpRolesDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IEmpRolesDetails)objType;
        }


        /// <summary>
        /// 创建FunctionBase数据层接口。功能信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IFunctionBase CreateFunctionBase()
        {

            string ClassNamespace = AssemblyPath + ".FunctionBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IFunctionBase)objType;
        }


        /// <summary>
        /// 创建MenuBase数据层接口。菜单信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IMenuBase CreateMenuBase()
        {

            string ClassNamespace = AssemblyPath + ".MenuBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IMenuBase)objType;
        }


        /// <summary>
        /// 创建ProductAttributesBase数据层接口。商品属性
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductAttributesBase CreateProductAttributesBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductAttributesBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductAttributesBase)objType;
        }


        /// <summary>
        /// 创建ProductBase数据层接口。商品信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductBase CreateProductBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductBase)objType;
        }



        /// <summary>
        /// 创建ProductTypeBase数据层接口。商品分类信息
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductTypeBase CreateProductTypeBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductTypeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductTypeBase)objType;
        }


        /// <summary>
        /// 创建ProductTypeBrandBase数据层接口。商品品牌分类明细
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductTypeBrandBase CreateProductTypeBrandBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductTypeBrandBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductTypeBrandBase)objType;
        }


        /// <summary>
        /// 创建RolesFunctionDetails数据层接口。角色功能明细表
        /// </summary>
        public static webs_YueyxShop.IDAL.IRolesFunctionDetails CreateRolesFunctionDetails()
        {

            string ClassNamespace = AssemblyPath + ".RolesFunctionDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRolesFunctionDetails)objType;
        }


        /// <summary>
        /// 创建RolesInfo数据层接口。角色信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IRolesInfo CreateRolesInfo()
        {

            string ClassNamespace = AssemblyPath + ".RolesInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRolesInfo)objType;
        }


        /// <summary>
        /// 创建RolesMenuDetails数据层接口。角色菜单明细表
        /// </summary>
        public static webs_YueyxShop.IDAL.IRolesMenuDetails CreateRolesMenuDetails()
        {

            string ClassNamespace = AssemblyPath + ".RolesMenuDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRolesMenuDetails)objType;
        }


        /// <summary>
        /// 创建SysCodeBase数据层接口。系统代码词典
        /// </summary>
        public static webs_YueyxShop.IDAL.ISysCodeBase CreateSysCodeBase()
        {

            string ClassNamespace = AssemblyPath + ".SysCodeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.ISysCodeBase)objType;
        }


        /// <summary>
        /// 创建SysLogBase数据层接口。系统日志
        /// </summary>
        public static webs_YueyxShop.IDAL.ISysLogBase CreateSysLogBase()
        {

            string ClassNamespace = AssemblyPath + ".SysLogBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.ISysLogBase)objType;
        }


        /// <summary>
        /// 创建vw_EmployeeBase数据层接口。系统日志
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivw_EmployeeBase Createvw_EmployeeBase()
        {

            string ClassNamespace = AssemblyPath + ".vw_EmployeeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivw_EmployeeBase)objType;
        }


        /// <summary>
        /// 创建vw_EmpRoleFun数据层接口。系统日志
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivw_EmpRoleFun Createvw_EmpRoleFun()
        {

            string ClassNamespace = AssemblyPath + ".vw_EmpRoleFun";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivw_EmpRoleFun)objType;
        }
        /// <summary>
        /// 创建ProductAttributeDetails数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductAttributeDetails CreateProductAttributeDetails()
        {

            string ClassNamespace = AssemblyPath + ".ProductAttributeDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductAttributeDetails)objType;
        }


        /// <summary>
        /// 创建ProductImgBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductImgBase CreateProductImgBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductImgBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductImgBase)objType;
        }


        /// <summary>
        /// 创建ProductInfoBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductInfoBase CreateProductInfoBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductInfoBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductInfoBase)objType;
        }


        /// <summary>
        /// 创建ProductSEOBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductSEOBase CreateProductSEOBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductSEOBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductSEOBase)objType;
        }


        /// <summary>
        /// 创建ProductStandardBase数据层接口。商品规格明细
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductStandardBase CreateProductStandardBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductStandardBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductStandardBase)objType;
        }


        /// <summary>
        /// 创建SKUBase数据层接口。商品规格明细
        /// </summary>
        public static webs_YueyxShop.IDAL.ISKUBase CreateSKUBase()
        {

            string ClassNamespace = AssemblyPath + ".SKUBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.ISKUBase)objType;
        }

        /// <summary>
        /// 创建ConsigneeInfoBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IConsigneeInfoBase CreateConsigneeInfoBase()
        {

            string ClassNamespace = AssemblyPath + ".ConsigneeInfoBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IConsigneeInfoBase)objType;
        }


        /// <summary>
        /// 创建OrderBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IOrderBase CreateOrderBase()
        {

            string ClassNamespace = AssemblyPath + ".OrderBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IOrderBase)objType;
        }
        /// <summary>
        /// 创建OrderSKUDetail数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IOrderSKUDetail CreateOrderSKUDetail()
        {

            string ClassNamespace = AssemblyPath + ".OrderSKUDetail";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IOrderSKUDetail)objType;
        }

        /// <summary>
        /// 创建PaymentBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IPaymentBase CreatePaymentBase()
        {

            string ClassNamespace = AssemblyPath + ".PaymentBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IPaymentBase)objType;
        }

        /// <summary>
        /// 创建ShipTypeBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IShipTypeBase CreateShipTypeBase()
        {

            string ClassNamespace = AssemblyPath + ".ShipTypeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IShipTypeBase)objType;
        }

        /// <summary>
        /// 创建RejectionBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IRejectionSKUDetail CreateRejectionSKUDetail()
        {

            string ClassNamespace = AssemblyPath + ".RejectionSKUDetail";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRejectionSKUDetail)objType;
        }

        /// <summary>
        /// 创建RejectionBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IRejectionBase CreateRejectionBase()
        {

            string ClassNamespace = AssemblyPath + ".RejectionBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRejectionBase)objType;
        }
        /// <summary>
        /// 创建RegionBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IRegionBase CreateRegionBase()
        {

            string ClassNamespace = AssemblyPath + ".RegionBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRegionBase)objType;
        }

        /// <summary>
        /// 创建CarriageBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.ICarriageBase CreateCarriageBase()
        {

            string ClassNamespace = AssemblyPath + ".CarriageBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.ICarriageBase)objType;
        }


        /// <summary>
        /// 创建CarriageTempleteBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.ICarriageTempleteBase CreateCarriageTempleteBase()
        {

            string ClassNamespace = AssemblyPath + ".CarriageTempleteBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.ICarriageTempleteBase)objType;
        }

        /// <summary>
        /// 创建ProductConsultBase数据层接口。商品咨询信息表
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductConsultBase CreateProductConsultBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductConsultBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductConsultBase)objType;
        }


        /// <summary>
        /// 创建ProductAppraiseBase数据层接口。商品评价信息
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductAppraiseBase CreateProductAppraiseBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductAppraiseBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductAppraiseBase)objType;
        }


        /// <summary>
        /// 创建ProductReplyBase数据层接口。商品资讯回复明细
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductReplyBase CreateProductReplyBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductReplyBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductReplyBase)objType;
        }
        /// <summary>
        /// 创建ProductRecommendDetail数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductRecommendDetail CreateProductRecommendDetail()
        {

            string ClassNamespace = AssemblyPath + ".ProductRecommendDetail";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductRecommendDetail)objType;
        }


        /// <summary>
        /// 创建ProductRecommendTypeBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IProductRecommendTypeBase CreateProductRecommendTypeBase()
        {

            string ClassNamespace = AssemblyPath + ".ProductRecommendTypeBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IProductRecommendTypeBase)objType;
        }

        public static IVipRank CreateVipRank()
        {
            string ClassNamespace = AssemblyPath + ".VipRank";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IVipRank)objType;
        }

        public static IMemberBase CreateMemberBase()
        {
            string ClassNamespace = AssemblyPath + ".MemberBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IMemberBase)objType;
        }

        public static INewsBase CreateNewsBase()
        {
            string ClassNamespace = AssemblyPath + ".NewsBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.INewsBase)objType;
        }

        /// <summary>
        /// 创建GroupPurchaseBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IGroupPurchaseBase CreateGroupPurchaseBase()
        {

            string ClassNamespace = AssemblyPath + ".GroupPurchaseBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IGroupPurchaseBase)objType;
        }


        /// <summary>
        /// 创建RushPurchaseBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IRushPurchaseBase CreateRushPurchaseBase()
        {

            string ClassNamespace = AssemblyPath + ".RushPurchaseBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IRushPurchaseBase)objType;
        }
        /// <summary>
        /// 创建vm_GPDetails数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivm_GPDetails Createvm_GPDetails()
        {

            string ClassNamespace = AssemblyPath + ".vm_GPDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivm_GPDetails)objType;
        }
        /// <summary>
        /// 创建vm_RPDetails数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivm_RPDetails Createvm_RPDetails()
        {

            string ClassNamespace = AssemblyPath + ".vm_RPDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivm_RPDetails)objType;
        }

        /// <summary>
        /// 广告
        /// </summary>
        /// <returns></returns>
        public static IAdert CreateAdert()
        {
            string ClassNamespace = AssemblyPath + ".Adert";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IAdert)objType;
        }
        /// <summary>
        /// 广告位
        /// </summary>
        /// <returns></returns>
        public static IAdertPositionBase CreateAdertPositionBase()
        {
            string ClassNamespace = AssemblyPath + ".AdertPositionBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IAdertPositionBase)objType;
        }
        /// <summary>
        /// 创建vm_PCdetails数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivm_PCdetails Createvm_PCdetails()
        {

            string ClassNamespace = AssemblyPath + ".vm_PCdetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivm_PCdetails)objType;
        }

        /// <summary>
        /// 创建vm_GBDetails数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivm_GBDetails Createvm_GBDetails()
        {

            string ClassNamespace = AssemblyPath + ".vm_GBDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivm_GBDetails)objType;
        }

        /// <summary>
        /// 创建ShoppingCartBase数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.IShoppingCartBase CreateShoppingCartBase()
        {

            string ClassNamespace = AssemblyPath + ".ShoppingCartBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IShoppingCartBase)objType;
        }

        /// <summary>
        /// 创建vw_PInfo数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivw_PInfo Createvw_PInfo()
        {

            string ClassNamespace = AssemblyPath + ".vw_PInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivw_PInfo)objType;
        }

        /// <summary>
        /// 创建VipCollectionBase数据层接口。收藏夹
        /// </summary>
        public static webs_YueyxShop.IDAL.IVipCollectionBase CreateVipCollectionBase()
        {

            string ClassNamespace = AssemblyPath + ".VipCollectionBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IVipCollectionBase)objType;
        }
        /// <summary>
        /// 创建vw_Orderpinfo数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivw_Orderpinfo Createvw_Orderpinfo()
        {

            string ClassNamespace = AssemblyPath + ".vw_Orderpinfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivw_Orderpinfo)objType;
        }


        /// <summary>
        /// 创建vm_GroupInfo数据层接口。
        /// </summary>
        public static webs_YueyxShop.IDAL.Ivm_GroupInfo Createvm_GroupInfo()
        {

            string ClassNamespace = AssemblyPath + ".vm_GroupInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.Ivm_GroupInfo)objType;
        }


        /// <summary>
        /// 创建OrderStatusBase数据层接口。订单状态表
        /// </summary>
        public static webs_YueyxShop.IDAL.IOrderStatusBase CreateOrderStatusBase()
        {
            string ClassNamespace = AssemblyPath + ".OrderStatusBase";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (webs_YueyxShop.IDAL.IOrderStatusBase)objType;
        }

    }
}