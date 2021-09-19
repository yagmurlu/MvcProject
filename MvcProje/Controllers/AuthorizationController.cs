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
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());
        // GET: Authorization
        [Authorize(Roles="A")]
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminValues = (from x in rm.GetAllList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.RoleId.ToString()
                                                  }).ToList();
            ViewBag.vlc = adminValues;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAddBL(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueAdmin = (from x in rm.GetAllList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.RoleName,
                                                      Value = x.RoleId.ToString()
                                                  }).ToList();

            ViewBag.vla = valueAdmin;
            var admniValues = adm.GetById(id);
            return View(admniValues);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var adminValues = adm.GetById(id);
            adminValues.AdminStatus = false;
            adm.AdminDelete(adminValues);
            return RedirectToAction("Index");
        }
        public ActionResult AdminStatus(int id)
        {
            var adminValues = adm.GetById(id);
            if (adminValues.AdminStatus == false)
            {

                adminValues.AdminStatus = true;
                adm.AdminDelete(adminValues);
                return RedirectToAction("Index");
            }
            else
            {
                adminValues.AdminStatus = false;
                adm.AdminDelete(adminValues);
                return RedirectToAction("Index");
            }
        }

    }
}