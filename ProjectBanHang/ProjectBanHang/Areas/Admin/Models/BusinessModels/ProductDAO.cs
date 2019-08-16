using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBanHang.Areas.Admin.Models.BusinessModels
{
    public class ProductDAO
    {
        DataBanHangContext db = null;
        public ProductDAO()
        {
            db = new DataBanHangContext();
        }

        public List<Product> listProducts(int top)
        {
            return db.Products.OrderByDescending(x => x.Price).Take(top).ToList();
        }
    }
}