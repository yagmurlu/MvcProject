using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context context = new Context();
        public ActionResult Index()
        {
            var categoryTotal = context.Categories.Count().ToString();
            ViewBag.totalCategories = categoryTotal;

            var categorySoftware = context.Headings.Count(x => x.CategoryID == 18);
            ViewBag.softwareCategoryTitleNumber = categorySoftware;

            var writerName = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.nameWriter = writerName;

            var Titles = context.Categories.Where(x => x.CategoryID == context.Headings.GroupBy(c => c.CategoryID).OrderByDescending(c => c.Count()).Select(c => c.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            
            ViewBag.categoryTitles = Titles;


            var categoryStatusDifference = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.DifferenceCategories = categoryStatusDifference;

            return View();
        }
    }
}