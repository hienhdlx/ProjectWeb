using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            var productlist = new ProductDAO();
            ViewBag.likeproduct = productlist.listRelateProduct(id, 3);
            return View(product);
        }

       
    }
}