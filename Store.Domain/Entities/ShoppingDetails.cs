using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities
{
    public class ShoppingDetails
    {
        [Required(ErrorMessage = "请输入姓名")]
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请输入地址")]
        [Display(Name="地址")]
        public string Line { get; set; }
        [Required(ErrorMessage = "请输入城市")]
        [Display(Name ="城市")]
        public string City { get; set; }
        [Required(ErrorMessage = "请输入区（镇）")]
        [Display(Name= "区（镇）")]
        public string State { get; set; }
        [Required(ErrorMessage = "请输入邮编")]
        [Display(Name="邮编")]
        public string Zip { get; set; }
        public bool GiftWrap { get; set; }
    }
}
