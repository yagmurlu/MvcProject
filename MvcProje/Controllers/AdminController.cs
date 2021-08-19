using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adm.GetList();
            return View(adminValues);
        }
    }
}