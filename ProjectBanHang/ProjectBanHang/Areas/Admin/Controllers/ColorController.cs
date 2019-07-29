using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class ColorController : Controller
    {
        private Repository<Color> _color; 
        public ColorController()
        {
            _color = new Repository<Color>();
        }
        // GET: Admin/Color
        public ActionResult Index(int page, int pageSize)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Color c)
        {
            if (ModelState.IsValid)
            {
                _color.Add(c);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(_color.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _color.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_color.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Color c)
        {
            if (ModelState.IsValid)
            {
                _color.Edit(c);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}