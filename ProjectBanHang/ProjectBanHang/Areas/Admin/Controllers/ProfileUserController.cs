using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class ProfileUserController : Controller
    {
        private Repository<ProfileUser> _user;
        public ProfileUserController()
        {
            _user = new Repository<ProfileUser>();
        }

        // GET: Admin/ProfileUser
        public ActionResult Index()
        {
            return View(_user.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileUser user)
        {
            if (ModelState.IsValid)
            {
                _user.Add(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _user.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_user.Get(id));
        }

        public ActionResult Edit(int id)
        {
            return View(_user.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileUser user)
        {
            if (ModelState.IsValid)
            {
                _user.Edit(user);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}