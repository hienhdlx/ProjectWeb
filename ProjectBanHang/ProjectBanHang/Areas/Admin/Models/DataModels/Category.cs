using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Category
    {
        [Key]
        [Required]

        public int Id { get; set; }
        [Required]
        [DisplayName("Tên hãng")]
        public string Name { get; set; }

        //Thuộc tính liên kết 
        public ICollection<Product> Products { get; set; }

    }
}