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

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> listRelateProduct(int productId, int top)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.Id != productId).Take(top).ToList();
        }
    }
}