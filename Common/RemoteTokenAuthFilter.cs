using DA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DA.Services;

namespace DA.Common
{
    public class remoteTokenAuthFilter : ActionFilterAttribute
    {




        public tokenManagerService tokenManager = new tokenManagerService(ConfigurationManager.AppSettings["remote_auth_url"]);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string homeUrl = ConfigurationManager.AppSettings["web_demo_url"];


            bool redirect = MvcApplication.authToken == null ? true : false;

            if (redirect)
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            string token = filterContext.HttpContext.Request.Form.Get("token") ?? MvcApplication.authToken; 
            if ( !tokenManager.checkTokenVaild(token))
            {

                LogOut(filterContext);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

            //取得token

            //remote 驗證token
            // 成功 : 得到token的使用者資訊
            // 設定再session
            // 失敗 : 導至web首頁





        }
        private void LogOut(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Session.RemoveAll();
            filterContext.HttpContext.Response.Redirect(ConfigurationManager.AppSettings["web_demo_url"]+ "/logout.php");
            base.OnActionExecuting(filterContext);
        }
    }
}