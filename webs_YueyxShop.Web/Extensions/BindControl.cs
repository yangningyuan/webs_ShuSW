using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webs_YueyxShop.BLL;
using System.Configuration;
using System.Xml;
using webs_YueyxShop.Model;


namespace webs_YueyxShop.Web
{

    /// <summary>
    ///BindControl 的摘要说明
    /// </summary>
    public class BindControl
    {
        //WeiXinContext WeiXinContext = new WeiXinContext();
        //public static UnitOfWork unit = new UnitOfWork();
        public BindControl()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 加载系统代码中的数据
        /// </summary>
        /// <param name="type">父【上级】编码</param>
        /// <param name="type">需要类型的层级</param>
        /// <param name="valuetype">value 值是否显示为名称（true 保存名称，false 保存编码)</param>
        /// <param name="bl">是否显示“请选择”项(true  显示请选择项，false 隐藏请选择项)</param>
        /// <param name="c_id">公司信息</param>
        /// <returns></returns>
        public SelectList BindSysCodeBase(string fcode, int cengji, bool valuetype, bool bl)
        {
            string sql = "sc_DeleteStateCode=0 and sc_CengJ=" + cengji + " and sc_BianM Like '" + fcode + "%' order by sc_BianM asc";
            var syscode = new BLL.SysCodeBase().GetModelList(sql);
            List<SelectListItem> items = new List<SelectListItem>();
            if (bl)
            {
                items.Add(new SelectListItem() { Text = "--请选择--", Value = "", Selected = true });
            }
            if (syscode != null)
            {
                foreach (var item in syscode)
                {
                    if (valuetype)
                    {
                        items.Add(new SelectListItem() { Text = item.sc_MingCh, Value = item.sc_MingCh, Selected = false });
                    }
                    else
                    {
                        items.Add(new SelectListItem() { Text = item.sc_MingCh, Value = item.sc_BianM, Selected = false });
                    }
                }
            }
            return new SelectList(items, "Value", "Text");
        }

        /// <summary>
        /// 加载系统代码中的数据
        /// </summary>
        /// <param name="type">父【上级】编码</param>
        /// <param name="type">需要类型的层级</param>
        /// <param name="valuetype">value 值是否显示为名称（true 保存名称，false 保存编码)</param>
        /// <param name="bl">是否显示“请选择”项(true  显示请选择项，false 隐藏请选择项)</param>
        /// <param name="c_id">公司信息</param>
        /// <returns></returns>
        public SelectList BindSysCodeBaseForCheckBoxList(string fcode, int cengji, bool valuetype)
        {
            BLL.SysCodeBase db = new BLL.SysCodeBase();
            var sysCode =
                db.GetModelList("sc_DeleteStateCode=0 and sc_CengJ=" + cengji + " and sc_BianM Like '" + fcode +
                                "%' order by sc_BianM asc");
            //var syscode = EnergyContext.Database.SqlQuery<SysCodeBase>("select * from dbo.SysCodeBase where  sc_DeleteStateCode=0 and sc_CengJ=" + cengji + " and sc_BianM Like '" + fcode + "%' order by sc_BianM asc");
            List<SelectListItem> items = new List<SelectListItem>();
            if (sysCode != null)
            {
                foreach (var item in sysCode)
                {
                    if (valuetype)
                    {
                        items.Add(new SelectListItem() {Text = item.sc_MingCh, Value = item.sc_MingCh, Selected = false});
                    }
                    else
                    {
                        items.Add(new SelectListItem() {Text = item.sc_MingCh, Value = item.sc_BianM, Selected = false});
                    }
                }
            }
            SelectList list = new SelectList(items, "Value", "Text");


            return list;
        }

        public string GetNameByCode(string vcode)
        {
            string sql = string.Format("select top 1 sc_MingCh from SysCodeBase where sc_BianM='{0}'", vcode);
            return new dataWork().SelectNo1(sql);
        }

        //public string GetBuildingFullName(int id)
        //{
        //    string name = "";
        //    GetBuildingName(id, ref name);

        //    return name;
        //}
        //private void GetBuildingName(int id, ref string name)
        //{
        //    webs_YueyxShop.Model.BuildingBase model = new webs_YueyxShop.BLL.BuildingBaseRepository().GetModel(id);
        //    if (model == null)
        //    {
        //        return;
        //    }
        //    if (name.Length == 0)
        //    {
        //        name = model.b_MingCh;
        //    }
        //    else
        //    {
        //        name = model.b_MingCh + ">>" + name;
        //    }
        //    if (model.b_ParentId != 0)
        //    {
        //        GetBuildingName(model.b_ParentId, ref name);
        //    }

        //}

        #region 得到部门列表
        /// <summary>
        /// 根据公司id得到公司的部门
        /// </summary>
        /// <param name="c_ID">公司ID</param>
        /// <param name="isShowSelect">是否显示请选择</param>
        /// <param name="valueType">value中存的是ID还是名称：true存id</param>
        /// <returns></returns>
        //public SelectList BindDepartmentList(Guid c_ID, bool isShowSelect, bool valueType)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    if (isShowSelect)
        //    {
        //        items.Add(new SelectListItem() { Text = "--请选择--", Value = "", Selected = true });
        //    }

        //    webs_YueyxShop.IBLL.IOrganizationBaseRepository departDB = new webs_YueyxShop.BLL.OrganizationBaseRepository();
        //    IEnumerable<OrganizationBase> allList = from d in departDB.GetOrganizationBases()
        //                                          where
        //                                          d.o_DeleteStateCode == 0
        //                                          select d;


        //    IEnumerable<OrganizationBase> list = from d in allList
        //                                       where d.o_CengJ == 1 &&
        //                                       d.o_ParentId == new Guid("00000000-0000-0000-0000-000000000000")
        //                                       select d;
        //    //根据首层进行递归
        //    foreach (OrganizationBase item in list)
        //    {
        //        string type = "..|-";
        //        if (valueType)//value中存名称还是id:
        //        {
        //            items.Add(new SelectListItem() { Text = type + item.o_MingCh, Value = item.o_ID.ToString() });
        //        }
        //        else
        //        {
        //            items.Add(new SelectListItem() { Text = type + item.o_MingCh, Value = item.o_MingCh });
        //        }
        //        InitDepartment(allList, item.o_ID, items);
        //    }

        //    departDB.Dispose();//释放资源
        //    return new SelectList(items, "value", "text");
        //}

        /// <summary>
        /// 添加人：程晓龙
        /// 功能：初始化部门
        /// </summary>
        /// <param name="selectItem"></param>
        /// <param name="sc_ID"></param>
        //private void InitDepartment(IEnumerable<OrganizationBase> allList, Guid sc_ID, List<SelectListItem> selectItem)
        //{
        //    IEnumerable<OrganizationBase> items = from d in allList
        //                                        where d.o_ParentId == sc_ID
        //                                        select d;
        //    if (items.Count() > 0)
        //    {
        //        foreach (OrganizationBase item in items)
        //        {
        //            string type = "";
        //            for (int i = 0; i < item.o_CengJ - 1; i++)
        //            {
        //                type += "..";
        //            }
        //            type += "|-";
        //            selectItem.Add(new SelectListItem() { Text = type + item.o_MingCh, Value = item.o_ID.ToString() });
        //            InitDepartment(allList, item.o_ID, selectItem);
        //        }
        //    }
        //}


        #endregion

    }
}
