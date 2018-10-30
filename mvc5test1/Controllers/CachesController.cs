using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFTest;
namespace mvc5test1.Controllers
{
    public class CachesController : Controller
    {
        // GET: Caches
        public ActionResult Index()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            if (HttpContext.Cache["name"] == null)
            {
                var ul = (from a in entities.UserInfo
                          select a).ToList();
                UserInfo ul0 = ul[0];
                HttpContext.Cache.Insert("name", ul0, null, DateTime.Now.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
                ViewData["n"] = ul0;

            }
            else
            {
                ViewData["n"] = (UserInfo)HttpContext.Cache["name"];
            }
            return View();
        }
    }
}