using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> _product;
        private Repository<Category> _category;
        public ProductController()
        {
            _product = new Repository<Product>();
            _category = new Repository<Category>();
        }
        // GET: Admin/Product
        public ActionResult Index(int ? page) 
        {
            int pageIndex = 1;
            int pageSize = 5;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var prodt = _product._tbl.Include(x => x.Categories).ToList();
            IPagedList<Product> pro = null;
            pro = prodt.ToPagedList(pageIndex, pageSize);
            return View(pro);
        }

        public ActionResult Details(int id)
        {
            return View(_product.Get(id));
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_category.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product pro)
        {
            ViewBag.CategoryId = new SelectList(_category.GetAll(), "Id", "Name");

            if (ModelState.IsValid)
            {
                _product.Add(pro);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_category.GetAll(), "Id", "Name", _product.Get(id).CategoryId);
            return View(_product.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Product p)
        {
            ViewBag.CategoryId = new SelectList(_category.GetAll(), "Id", "Name", _product.Get(p.CategoryId));
            if (ModelState.IsValid)
            {
                Repository<Product> _product2 = new Repository<Product>();
                _product2.Edit(p);
                return RedirectToAction("Index");
            }
            return View(); 
        }

        public ActionResult Delete(int id)
        {
            _product.Remove(id);
            return RedirectToAction("Index");
        }
    }
}