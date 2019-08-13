using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        private Repository<Footer> _footer;
        public FooterController()
        {
            _footer = new Repository<Footer>();
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            return View(_footer.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_footer.Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Footer f)
        {

            if (ModelState.IsValid)
            {
                _footer.Add(f);
                SetAlert("Thêm menu thành công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _footer.Remove(id);
            SetAlert("Xóa menu thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_footer.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Footer f)
        {
            if (ModelState.IsValid)
            {
                _footer.Edit(f);
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