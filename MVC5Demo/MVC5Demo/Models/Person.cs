using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "請輸入姓名")]//, ErrorMessageResourceName ="", ErrorMessageResourceType ==""
        public string Name { get; set; }
        [Required(ErrorMessage = "請輸入年紀，至少18歲以上")]
        [Range(18, 90, ErrorMessage = "請輸入年紀，{1}~{2}之間")]//畢竟是驗證 不會主動加attribute
        [DisplayName("年紀")]
        public int Age { get; set; }
    }
}