using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> _product;
        public ProductController()
        {
            _product = new Repository<Product>();
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(_product.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_product.Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                _product.Add(pro);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_product.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                _product.Edit(p);
                return RedirectToAction("Edit");
            }
            return View(); 
        }
    }
}