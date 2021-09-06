using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}