using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class SizeController : Controller
    {
        private Repository<Size> _size;
        public SizeController()
        {
            _size = new Repository<Size>();
        }
        // GET: Admin/Size
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
        public ActionResult Create(Size s)
        {
            if (ModelState.IsValid)
            {
                _size.Add(s);
                return RedirectToAction("Index");
            }
            return View();
        }

        //public ActionResult Details(int id)
        //{
        //    return View(_size.Get(id));
        //}

        public ActionResult Delete(int id)
        {
            _size.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_size.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Size sz)
        {
            if (ModelState.IsValid)
            {
                _size.Edit(sz);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}