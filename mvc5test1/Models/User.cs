using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace mvc5test1.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        public int id { get; set; }
        [DisplayName("年龄")]
        [Range(0,120,ErrorMessage ="{0}必须在{1}和{2}之间")]
        public int age { get; set; }


        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string name { get; set; }


        [DisplayName("用户编码")]
        [Required(ErrorMessage ="{0}不能为空")]
        [StringLength(10,MinimumLength =6,ErrorMessage ="{0}的长度不能超过{1},也不能低于{2}")]
        public string userCode { get; set; }

        [DisplayName("注册日期")]
        [Range(typeof(DateTime),"2000-01-01","2018-09-19",ErrorMessage ="{0}必须在{1}和{2}之间")]
        public DateTime regTime { get; set; }

        [DisplayName("密码")]
        [RegularExpression(@"[a-zA-Z]{1}\d{5}",ErrorMessage ="格式不符合要求")]
        public string UserPwd { get; set; }

        [Compare("UserPwd", ErrorMessage ="两次密码不一致")]
        public string UserPwd2 { get; set; }

    }
}