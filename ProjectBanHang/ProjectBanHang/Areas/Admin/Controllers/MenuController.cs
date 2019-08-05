using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        private Repository<Menu> _menu;
        private Repository<MenuType> _typemenu;
        public MenuController()
        {
            _menu = new Repository<Menu>();
            _typemenu = new Repository<MenuType>();
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View(_menu.GetAll());
        }

        public ActionResult Detail(int id)
        {
            return View(_menu.Get(id));
        }

        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(_typemenu.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu me)
        {
            if (ModelState.IsValid)
            {
                _menu.Add(me);
                SetAlert("Thêm menu thành công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _menu.Remove(_menu.Get(id));
            SetAlert("Xóa menu thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_menu.Get(id));
        }

        public ActionResult Edit(Menu me)
        {
            if (ModelState.IsValid)
            {
                _menu.Edit(me);
                SetAlert("Sửa thông tin thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Sửa không thành công", "error");
                return View();
            }
        }
    }
}