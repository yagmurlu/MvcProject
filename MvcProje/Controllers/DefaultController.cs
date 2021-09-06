using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}