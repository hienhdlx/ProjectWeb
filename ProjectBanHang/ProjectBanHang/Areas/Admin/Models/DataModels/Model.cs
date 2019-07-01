using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.DataModels
{
    public class Model
    {
        public int Id { get; set; }

        //thuộc tính liên kết 
        public ICollection<Product> Products { get; set; }

        public ICollection<Color> Colors { get; set; }
        public ICollection<Size> Sizes { get; set; }

    }
}