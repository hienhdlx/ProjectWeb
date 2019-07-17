using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using ProjectBanHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private Repository<LoginModel> _login;
        public LoginController()
        {
            _login = new Repository<LoginModel>();
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var result = _login.Login(login.UserName, Encryptor.MD5Hash(login.Password));
                if (result == 1)
                {
                    var user = _login.GetByName(login.UserName);
                    var userSession = new UserLogin(); 
                    userSession.UserId = user.Id;
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstants.USER_SESSION, userSession);  
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }
            return RedirectToAction("Index");
        }
    }
}