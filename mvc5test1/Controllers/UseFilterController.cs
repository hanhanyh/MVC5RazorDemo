using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc5test1.Filters;
namespace mvc5test1.Controllers
{
    public class UseFilterController : Controller
    {
        // GET: UseFilter
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 异常日志过滤器测试
        /// </summary>
        /// <returns></returns>
        [LogFilter]
        public ActionResult Exception()
        {
            string s = null;
            int i = s.Length;
            return Content("异常过滤器测试！");
        }
    }
}