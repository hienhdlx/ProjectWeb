using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Thuộc tính liên kết 
        public ICollection<Product> Products { get; set; }

    }
}