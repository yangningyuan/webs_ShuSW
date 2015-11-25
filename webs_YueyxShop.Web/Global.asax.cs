using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webs_YueyxShop.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //前台
            //路由规则匹配是从上到下的，优先匹配的路由一定要写在最上面。因为路由匹配成功以后，他不会继续匹配下去。
            routes.MapRoute(
               "ShuSW", // 路由名称，这个只要保证在路由集合中唯一即可
               "ShuSW/{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
               new { controller = "sswHome", action = "Index", id = UrlParameter.Optional } // 
           );

            //路由规则匹配是从上到下的，优先匹配的路由一定要写在最上面。因为路由匹配成功以后，他不会继续匹配下去。
            routes.MapRoute(
               "Admin", // 路由名称，这个只要保证在路由集合中唯一即可
               "Admin/{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
               new { controller = "Login", action = "Login", id = UrlParameter.Optional } // 
           );

            

            //前台
            //路由规则匹配是从上到下的，优先匹配的路由一定要写在最上面。因为路由匹配成功以后，他不会继续匹配下去。
           // routes.MapRoute(
           //    "YueyXing", // 路由名称，这个只要保证在路由集合中唯一即可
           //    "YueyXing/{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
           //    new { controller = "Index", action = "Index", id = UrlParameter.Optional } // 
           //);

            //路由规则匹配是从上到下的，优先匹配的路由一定要写在最上面。因为路由匹配成功以后，他不会继续匹配下去。
           // routes.MapRoute(
           //    "Wap", // 路由名称，这个只要保证在路由集合中唯一即可
           //    "Wap/{controller}/{action}/{id}", //路由规则,匹配以Admin开头的url
           //    new { controller = "wapIndex", action = "Index", id = UrlParameter.Optional } // 
           //);

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                //new { controller = "Login", action = "Login", id = UrlParameter.Optional } // 参数默认值
                new { controller = "default", action = "default", id = UrlParameter.Optional } // 参数默认值
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Application["UserCount"] = 0;
            RegisterView();//注册视图访问规则
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["UserCount"] = (int)Application["UserCount"] + 1;
            Application.UnLock();
        }
        
        void Session_End(object sender, EventArgs e)          //站点在线人数减一
        {
            // 在会话结束时运行的代码。
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
            // 或 SQLServer，则不会引发该事件。
            Application.Lock();
            Application["UserCount"] = Int32.Parse(Application["UserCount"].ToString()) - 1;
            Application.UnLock();

        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyViewEngine());
        }
    }
}