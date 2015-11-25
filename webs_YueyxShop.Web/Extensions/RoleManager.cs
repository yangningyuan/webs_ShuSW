using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webs_YueyxShop.Model;
using webs_YueyxShop.BLL;


namespace webs_YueyxShop.Web
{
    public class RoleManager
    {
        //IRolesFunctionDetailsRepository fun_db = new RolesFunctionDetailsRepository();

        public RoleManager()
        { }

        /// <summary>
        /// 根据用户id，功能编码判断该用户在该模块是否有该功能
        /// </summary>
        /// <param name="e_id">用户id</param>
        /// <param name="functionCode">功能编码</param>
        /// <returns></returns>
        public bool IsHasFunRole(Guid e_id, string functionCode)
        {
            return true;
            //string strSql = string.Format(" select count(*) from vw_EmpRoleFun where e_id ='{0}' and f_BianM='{1}'", e_id, functionCode);

            //using (EnergyContext EnergyContext = new EnergyContext())
            //{
            //    int count = EnergyContext.Database.SqlQuery<int>(strSql).First();
            //    if (count > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }

        /// <summary>
        /// 根据用户id，功能编码判断该用户在该模块是否有该功能
        /// </summary>
        /// <param name="e_id">用户id</param>
        /// <param name="functionCode">功能编码</param>
        /// <returns></returns>
        public bool IsHasFunRole(int e_id, string functionCode)
        {
            return true;
            //string strSql = string.Format(" select count(*) from vw_EmpRoleFun where e_id ='{0}' and f_BianM='{1}'", e_id, functionCode);

            //using (EnergyContext EnergyContext = new EnergyContext())
            //{
            //    int count = EnergyContext.Database.SqlQuery<int>(strSql).First();
            //    if (count > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }

//        public bool IsHasMenuRole(Guid e_id, string menuCode)
//        {
//            string strSql = string.Format(@"select COUNT(*) from RolesMenuDetails as rmb 
//                                            join MenuBase as mb on mb.m_ID=rmb.m_ID
//                                            where mb.m_DeleteStateCode=0 and mb.m_BianM='{0}'
//                                            and rmb.r_ID in (select r_ID from EmpRolesDetails where e_ID='{1}')", menuCode, e_id);

//            using (EnergyContext EnergyContext = new EnergyContext())
//            {
//                int count = EnergyContext.Database.SqlQuery<int>(strSql).First();
//                if (count > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
    }
}