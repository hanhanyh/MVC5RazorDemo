using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFTest;

namespace mvc5test1.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {

            EFTest.MVCTest1Entities entites = new EFTest.MVCTest1Entities();
            var lbooks=entites.Books.Where(x => true).ToList();
            return View();
        }
        //添加分类
        public ActionResult Add(EFTest.Catalog catalog)
        {
            if (catalog == null || catalog.Name == null|| catalog.Name=="")
            {
                return Content("没有输入");
            }
            EFTest.MVCTest1Entities entities = new EFTest.MVCTest1Entities();
            entities.Catalog.Add(catalog);
            int re=  entities.SaveChanges();
            if (re > 0)
            {
                return Content("添加记录成功！");
            }
            else
            {
                return Content("添加记录失败");
            }
   
        }
        //通过ID查询用户信息
        public ActionResult SelectUser(int id)
        {
            //如果是多条数据 entities.UserInfo.Where(x=>x.ID==id&&x.Name=="xxx").ToList();
            EFTest.MVCTest1Entities entities = new EFTest.MVCTest1Entities();
            List<UserInfo> luserinfo= entities.UserInfo.Where(x => x.ID == id).ToList();
            if (luserinfo == null || luserinfo.Count == 0)
            {
                return Content("null");
            }
            else
            {
                return Content(luserinfo[0].Name);
            }
        }
        //查询一条数据
        public ActionResult First()
        {
            EFTest.MVCTest1Entities entities = new EFTest.MVCTest1Entities();
            UserInfo u=   entities.UserInfo.FirstOrDefault();//第一条  里面可以传lambda
                                            //Single()   也是一条数据(强制要求结果只有一条，否则报错)
            return Content(u.Name);
        }
        /*
         
         修改数据
         
         
         */
        public ActionResult Update(int id, string name)
        {
            EFTest.MVCTest1Entities entities = new EFTest.MVCTest1Entities();
            UserInfo uinfo= entities.UserInfo.FirstOrDefault(x => x.ID == id);
            uinfo.Name = name;
            entities.SaveChanges();
            //foreach
            var list = entities.UserInfo.Where(x => true).ToList();
            list.ForEach(x => x.Name = "修改");
            entities.SaveChanges();
            return Content("  ");
        }
        //删除
        public ActionResult del()
        {
            EFTest.MVCTest1Entities entities = new EFTest.MVCTest1Entities();
            var clist= entities.Catalog.Where(x => true).ToList();
            foreach (var item in clist)
            {
                entities.Catalog.Remove(item);
            }
            entities.SaveChanges();
            return Content("执行成功");
        }
    }
}