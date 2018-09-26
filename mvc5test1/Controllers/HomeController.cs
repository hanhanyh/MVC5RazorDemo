using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc5test1.Models;
namespace mvc5test1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int ? id)
        {
            List<User> users = new List<User>()
            {
                new User(){ id=0,name="xxx",age=20},
                 new User(){ id=10,name="xxasas",age=21}
            };
            ViewBag.jsdata = "张三";
            return View(users);   //强类型视图(控制器向视图返回一个指定类型对象)
        }
        public ActionResult Logi()
        {
            
            return View(new Models.User());
        }
        [HttpPost]
        public ActionResult Logi(Models.User u)
        {
            if (ModelState.IsValid == true)
            {
                string userName = "abcdef";
                if (u.name == userName)
                {
                    //手动添加
                    ModelState.AddModelError("DoubleUser", "该用户名已存在！");
                    return View(u);
                }
            }
            else
            {

            }
            return View(u);
        }
       
    }
}