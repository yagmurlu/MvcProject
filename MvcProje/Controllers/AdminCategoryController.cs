using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcProje.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        //[Authorize(Roles = "A")]
        public ActionResult Index(int P = 1)
        {
            var categoryValues = cm.GetList().ToPagedList(P,10);
            return View(categoryValues);
        }
        //public ActionResult CategoryHeading(int id)
        //{
        //    //p = (string)Session["WriterMail"];
        //    //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
        //    //var values = hm.GetListByWriter(writeridinfo);
        //    //return View(values);
        //}
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValudator = new CategoryValidator();
            ValidationResult result = categoryValudator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index"); // Go to INDEX
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }

}