using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities
{
   public class Product
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="请输入产品名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请输入类别")]
        public string Category { get; set; }
        [Required(ErrorMessage = "请输入产品介绍")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="请输入正确的价格")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
