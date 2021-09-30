using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{

    public class AuthorizationController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        AdminManager adm = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());
        // GET: Authorization
        //[Authorize(Roles="A")]
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }
        [HttpGet]
  
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRole = (from x in rm.GetAllList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.RoleId.ToString()
                                              }).ToList();
            ViewBag.vlc = adminRole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminLoginDto loginDto)
        {
            authService.AdminRegister(loginDto.AdminName,loginDto.AdminUsername, loginDto.AdminPassword,loginDto.AdminRoleId);
            return RedirectToAction("AddAdmin");
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
            p.AdminStatus = true;
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