using ProjectBanHang.Areas.Admin.Code;
using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using ProjectBanHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private Repository<LoginModel> _login;
        public LoginController()
        {
            _login = new Repository<LoginModel>();
        }

        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {

            if (Membership.ValidateUser(login.UserName, login.Password) && ModelState.IsValid)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng");
            }
            return View(login);
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}