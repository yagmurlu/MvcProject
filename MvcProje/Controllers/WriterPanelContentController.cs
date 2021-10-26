using BussinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [Authorize]
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writeridinfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writeridinfo);
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        [HttpGet]
        public ActionResult EditContent(int id)
        {
            List<SelectListItem> headingValue = (from x in hm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.HeadingName,
                                                      Value = x.HeadingID.ToString()
                                                  }).ToList();

            ViewBag.vlc = headingValue;

            var contentValue = cm.GetById(id);
            return View(contentValue);
        }
        [HttpPost]
        public ActionResult EditContent(Content p)
        {
            cm.ContentUpdate(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult DeleteContent(int id)
        {
            var contentValue = cm.GetById(id);
            contentValue.ContentStatus = false;
            cm.ContentDelete(contentValue);
            return RedirectToAction("MyContent");
        }
    }
}