using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private Repository<Category> _category; 
        public CategoryController()
        {
            _category = new Repository<Category>();
        }
        // GET: Admin/Category
        public ActionResult Index(int page, int pageSize)
        {
            return View(_category.GetAllListPage(page, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DataBanHangContext())
                {
                    if (!db.Categories.Any(w => w.Name.Equals(c.Name)))
                    {
                        _category.Add(c);
                    }
                }
                return RedirectToAction("Index");
            }
            return View();           
        }

        public ActionResult Details(int? id)
        {
            return View(_category.Get(id));
        }

        public ActionResult Edit(int id)
        {
            return View(_category.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category ca)
        {
            if (ModelState.IsValid)
            {
                _category.Edit(ca);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _category.Remove(id);
            return RedirectToAction("Index");
        }
    }
}