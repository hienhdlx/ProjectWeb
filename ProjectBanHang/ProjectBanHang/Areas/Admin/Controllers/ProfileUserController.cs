using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using ProjectBanHang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileUserController : BaseController
    {
        private Repository<ProfileUser> _user;
        public ProfileUserController()
        {
            _user = new Repository<ProfileUser>();
        }

        // GET: Admin/ProfileUser
        public ActionResult Index(string searchString, int? page)
        {
            //with no text search

            //int pageIndex = 1;
            //int pageSize = 4;
            //pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //var user = _user.GetAll();
            //IPagedList<ProfileUser> users = null;
            //users = user.ToPagedList(pageIndex, pageSize);
            //return View(users);


            //have text search and pagelist

            IPagedList<ProfileUser> users;
            int pageIndex = 1;
            int pageSize = 4;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            using (var db = new DataBanHangContext())
            {
                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    users = db.ProfileUsers.Where(w => w.UserName.Contains(searchString) || w.Name.Contains(searchString)).OrderByDescending(o => o.CreateDate).ToPagedList(pageIndex, pageSize);
                    ViewBag.SearchString = searchString;

                }
                else
                    users = db.ProfileUsers.OrderByDescending(o => o.CreateDate).ToPagedList(pageIndex, pageSize);
            }

            return View(users);
        }

        public ActionResult Create()
        {

            var _gender = new List<Gender>()
            {
                new Gender(){Id = 1, Text = "Nam"},
                new Gender(){Id = 2, Text = "Nữ"},
                new Gender(){Id = 3, Text = "Giới tính khác"}
            };

            var _role = new List<Role>()
            {
                new Role(){Id = 1, Text = "Quản lý" },
                new Role(){Id = 2, Text = "Nhân viên" },
                new Role(){Id = 3, Text = "Khách hàng" }
            };

            ViewBag._Role = _role;
            ViewBag._Gender = _gender;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileUser user)
        {
            var _gender = new List<Gender>()
            {
                new Gender(){Id = 1, Text = "Nam"},
                new Gender(){Id = 2, Text = "Nữ"},
                new Gender(){Id = 3, Text = "Giới tính khác"}
            };

            var _role = new List<Role>()
            {
                new Role(){Id = 1, Text = "Quản lý" },
                new Role(){Id = 2, Text = "Nhân viên" },
                new Role(){Id = 3, Text = "Khách hàng" }
            };

            ViewBag._Role = _role;
            ViewBag._Gender = _gender;
            if (ModelState.IsValid)
            {
                var encryptedMD5 = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMD5;
                _user.Add(user);
                SetAlert("Thêm hồ sơ User thành công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {

            _user.Remove(id);
            SetAlert("Xóa hồ sơ User thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_user.Get(id));
        }

        public ActionResult Edit(int id)
        {
            var _gender = new List<Gender>()
            {
                new Gender(){Id = 1, Text = "Nam"},
                new Gender(){Id = 2, Text = "Nữ"},
                new Gender(){Id = 3, Text = "Giới tính khác"}
            };

            var _role = new List<Role>()
            {
                new Role(){Id = 1, Text = "Quản lý" },
                new Role(){Id = 2, Text = "Nhân viên" },
                new Role(){Id = 3, Text = "Khách hàng" }
            };

            ViewBag._Role = _role;
            ViewBag._Gender = _gender;
            return View(_user.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileUser user)
        {
            var _gender = new List<Gender>()
            {
                new Gender(){Id = 1, Text = "Nam"},
                new Gender(){Id = 2, Text = "Nữ"},
                new Gender(){Id = 3, Text = "Giới tính khác"}
            };

            var _role = new List<Role>()
            {
                new Role(){Id = 1, Text = "Quản lý" },
                new Role(){Id = 2, Text = "Nhân viên" },
                new Role(){Id = 3, Text = "Khách hàng" }
            };

            ViewBag._Role = _role;
            ViewBag._Gender = _gender;

            if (ModelState.IsValid)
            {
                _user.Edit(user);
                return RedirectToAction("Index");
            }
            return View();
        }
    }

    class Gender
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    class Role
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}