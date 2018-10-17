using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFTest;
namespace mvc5test1.Controllers
{
    public class LinqController : Controller
    {
        // GET: Linq
        //查询所有
        public ActionResult Index()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = from a in entities.Books
                        select a;
            foreach (var item in query)
            {
                string name = item.BookName;
            }
            // query.ToList();
            return Content("xx");
        }
        //条件
        public ActionResult Where(int id)
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = from a in entities.Books
                        where a.BookId == id
                        select a; ;
            foreach (var item in query)
            {
                string name = item.BookName;
            }
            return Content("C#");
        }
        //排序
        public ActionResult Order()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = from a in entities.Books
                        orderby a.BookId descending
                        select a; 
            foreach (var item in query)
            {
                string name = item.BookName;
            }
            return Content("C#");
        }
        //查询指定列
        public ActionResult WhereColumn()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = from a in entities.Books
                        orderby a.BookId descending
                        select new { BookName=a.BookName,BookId=a.BookId};
            foreach (var item in query)
            {
                string name = item.BookName;
               
            }
            return Content("C#");
        }
        //分组
        public ActionResult group()
        {
            MVCTest1Entities entites = new MVCTest1Entities();
            var query = from a in entites.UserInfo
                        group a by new { a.Name} into b         //对Name分组
                        select b;
            foreach (var item in query)
            {
                string name = item.Key.Name;
            }
            return Content("x");
        }
        //统计
        public ActionResult tj()
        {
            MVCTest1Entities entites = new MVCTest1Entities();
            var query = from a in entites.UserInfo
                        group a by new { a.Name } into b         //对Name分组
                        select b;
            
            foreach (var item in query)
            {
               int count= item.Count();
               double avg= item.Average(f=>f.ID);//ID的平均值  没有年龄，用ID代替
               double sum = item.Sum(f => f.ID);//统计ID之和
               double max = item.Max(f => f.ID);//最大ID
                //double min
               string name = item.Key.Name;
            }
            return Content("x");
        }
        //模糊查询
        public ActionResult mh(string name)
        {
            MVCTest1Entities entites = new MVCTest1Entities();
            var query = from a in entites.UserInfo
                            // where a.Name.StartsWith(name)||a.Name.EndsWith(name)
                        where a.Name.Contains(name)
                        select a;

            foreach (var item in query)
            {
               
                string name0= item.Name;
            }
            return Content("x");
        }
        //top  Take 和Top的效果一样
        public ActionResult Top()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = (from a in entities.Books select a).Take(2);
            foreach (var item in query)
            {
                string name = item.BookName;
            }
            return Content("#");
        }
        //Skip
        public ActionResult Skip()
        {
            //skip 跳过指定行数的数据（排序之后再使用）
            MVCTest1Entities entities = new MVCTest1Entities();
            var query = (from a in entities.Books
                         orderby a.BookId descending
                         select a).Skip(2).Take(2);
            foreach (var item in query)
            {
                string name = item.BookName;
            }
            return Content("xxx");
        }
        //join 连接查询
        public ActionResult Join()
        {
            MVCTest1Entities entities = new MVCTest1Entities();
           var query=  from a in entities.Books
            join c in entities.Catalog on a.CID equals c.ID
            //--where xxx
            select new
            {
                Name = a.BookName,
                CName = c.Name
            };
            ///group by 
            ///select 
            foreach (var item in query)
            {
                string name = item.Name;
                string cname = item.CName;
            }
            return Content("xxx");
        }
        //子查询
        /*
         from a in obj.tabStudent
         var list=select new
         {
             name=a.name,
             gname={
                  from b in obj.Grade
                  where b.GradeID==a.GradeId
                  select b.GradeName
                }.FirstOrDefault
         };
         */

    }
}