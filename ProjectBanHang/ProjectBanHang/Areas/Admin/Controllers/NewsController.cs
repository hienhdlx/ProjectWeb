using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBanHang.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private Repository<News> _news;
        public NewsController()
        {
            _news = new Repository<News>();
        }
        // GET: Admin/News
        public ActionResult Index()
        {
            return View(_news.GetAll());
        }
    }
}