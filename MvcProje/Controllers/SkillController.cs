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

namespace MvcProje.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm = new SkillManager(new EfSkillDal());
        SkillValidator skillValidator = new SkillValidator();
        public ActionResult Index()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
        public ActionResult GetAllSkill()
        {
            var skillValues = sm.GetList();
            return View(skillValues);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            ValidationResult result = skillValidator.Validate(p);
            if (result.IsValid)
            {
                sm.SkillAdd(p);
                return RedirectToAction("Index");//GetAllSkill e döndür.

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
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skillValue = sm.GetById(id);
            return View(skillValue);
        }
        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            sm.SkillUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skillValue = sm.GetById(id);
            sm.SkillDelete(skillValue);
            return RedirectToAction("Index");
        }
    }
}