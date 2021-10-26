using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [Authorize(Users = "Admin")]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.AboutAddBL(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult EditAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            return View(aboutValue);
        }
        [HttpPost]
        public ActionResult EditAbout(About p)
        {
            aboutManager.AboutUpdate(p);
            return RedirectToAction("Index");
        }
    }
}