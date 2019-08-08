using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        private Repository<MenuType> _typemenu;
        public MenuTypeController()
        {
            _typemenu = new Repository<MenuType>();
        }
        // GET: Admin/MenuType
        public ActionResult Index()
        {
            return View(_typemenu.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuType tyme)
        {
            if (ModelState.IsValid)
            {
                _typemenu.Add(tyme);
                SetAlert("Thêm Type Menu thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Thêm Type Menu thành công", "success");
                return View();
            }
        }

        public ActionResult Detail(int id)
        {
            return View(_typemenu.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _typemenu.Remove(_typemenu.Get(id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_typemenu.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuType tyme)
        {
            if (ModelState.IsValid)
            {
                _typemenu.Edit(tyme);
                SetAlert("Sủa Type Menu thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Sủa Type Menu không thành công", "error");
                return View();
            }
        }
    }
}