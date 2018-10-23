using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
/*
 Forms权限验证
 先在Web.config 配置 system.web 下
  <authentication mode= "Forms">
  </authentication>
  导入 System.Web.Security
  FormsAuthentication.SetAuthCookie("用户名",是否永久保存)
  this.User.Identity.IsAuthenticated 判断是否存入cookie
  this.User.Identity.Name 获取刚刚存入的用户名
  FormsAuthentication.SignOut();清空cookie 
   */
namespace mvc5test1.Controllers
{
    public class FormAuthController : Controller
    {
        // GET: FormAuth
        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("qiuyuhan", true);//true or 2880
            return Content("登录成功！");
        }
        public ActionResult Auths()
        {
            if (this.User.Identity.IsAuthenticated)
             {
                return Content(this.User.Identity.Name);
           }
          else
          {
              return     Content("没有登录");
          }

        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();//清空
            return Content("注销成功");
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        /// [Authorize(Users="admin,root")] 只有用户名为Admin,root才有权限
        [Authorize]
        public ActionResult doauth()
        {
            return Content("验证成功");
        }
    }
}