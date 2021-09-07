using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {
            Context c = new Context();
            var headerCount = c.Headings.Count().ToString();
            ViewBag.headerCount = headerCount;

            var writerCount = c.Writers.Count().ToString();
            ViewBag.writerCount = writerCount;
            var contentCount = c.Contents.Count().ToString();
            ViewBag.contentCount = contentCount;
            var messageCount = c.Messages.Count().ToString();
            ViewBag.messageCount = messageCount;
            return View();
        }
    }
}