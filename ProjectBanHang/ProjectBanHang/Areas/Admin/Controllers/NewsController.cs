using ProjectBanHang.Areas.Admin.Models.BusinessModels;
using ProjectBanHang.Areas.Admin.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
        public ActionResult Index(int ? page)
        {

            int pageIndex = 1;
            int pageSize = 4;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //var news = _news.GetAll();
            //IPagedList<News> ne = null;
            //ne = news.ToPagedList(pageIndex, pageSize);
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(_news.Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreateDate = DateTime.UtcNow;
                _news.Add(news);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            _news.Remove(_news.Get(id));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_news.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreateDate = DateTime.UtcNow;
                _news.Edit(news);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}