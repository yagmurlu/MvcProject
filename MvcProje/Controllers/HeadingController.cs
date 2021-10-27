using BussinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProje.Controllers
{
    [Authorize]
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Heading

        public ActionResult Index(int p = 1)
        {
            var HeadingValues = hm.GetList().ToPagedList(p, 10);
            return View(HeadingValues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();


            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;

            var headingValue = hm.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
        public ActionResult StatusHeading(int id)
        {
            var headingValue = hm.GetById(id);
            if (headingValue.HeadingStatus == false)
            {

                headingValue.HeadingStatus = true;
                hm.HeadingDelete(headingValue);
                return RedirectToAction("Index");
            }
            else
            {
                headingValue.HeadingStatus = false;
                hm.HeadingDelete(headingValue);
                return RedirectToAction("Index");
            }
        }
        public ActionResult ActiveHeadingList(int p = 1)
        {
            var heading = hm.GetListHeadingTrue().ToPagedList(p, 10);
            return View(heading);
        }
        public ActionResult HeadingByWriter(int id)
        {
            var headingValue = hm.GetListByWriter(id);
            return View(headingValue);
        }
        public ActionResult HeadingByCategory(int id)
        {
            var headingValue = hm.GetLİstCategory(id);
            return View(headingValue);
        }
    }
}