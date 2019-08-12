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
            //ViewBag.TypeId = new SelectList(_typemenu.GetAll(), "MenuTypeId", "Name");
            return View(_menu.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_menu.Get(id));
        }

        public ActionResult Create()
        {
            ViewBag.MenuTypeId = new SelectList(_typemenu.GetAll(), "MenuTypeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Menu me)
        {
            //ViewBag.MenuTypeId = new SelectList(_typemenu.GetAll(), "MenuTypeId", "Name");

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
            _menu.Remove(id);
            SetAlert("Xóa menu thành công", "success");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TypeId = new SelectList(_typemenu.GetAll(), "MenuTypeId", "Name", _menu.Get(id).MenuTypeId);
            return View(_menu.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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