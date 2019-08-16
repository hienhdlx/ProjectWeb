using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDao = new ProductDAO();
            ViewBag.listproducts = productDao.listProducts(5);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            using (var db = new DataBanHangContext())
            {
                var listMenu = db.Menus.Where(x => x.MenuTypeId == 1).ToList();
                return PartialView(listMenu);
            }
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            using (var db = new DataBanHangContext())
            {
                var listtopMenu = db.Menus.Where(x => x.MenuTypeId == 2).ToList();
                return PartialView(listtopMenu);
            }
        }
    }
}