using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace mvc5test1.Filters
{
    /// <summary>
    /// 自动以日志过滤器,继承FilterAttribute是为了 使用特性，实现IExcepitionFilter是为了使用过滤器
    /// </summary>
    public class LogFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string path = filterContext.HttpContext.Server.MapPath("~/Logs/log.txt");
            StreamWriter sw = new StreamWriter(path,true,System.Text.Encoding.UTF8);
            sw.WriteLine(DateTime.Now.ToString() + filterContext.Exception.Message);
            sw.Flush();
            sw.Close();

        }
    }
}