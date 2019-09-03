using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        private Repository<Slide> _slide;
        public SlideController()
        {
            _slide = new Repository<Slide>();
        }
        // GET: Admin/Slide

        public ActionResult Index()
        {
            return View(_slide.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slide s)
        {
            if (ModelState.IsValid)
            {
                _slide.Add(s);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _slide.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_slide.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slide sz)
        {
            if (ModelState.IsValid)
            {
                _slide.Edit(sz);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}