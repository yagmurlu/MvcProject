﻿using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName && x.AdminPassword==p.AdminPassword);
            if (adminuserinfo!=null)
            {
                //yönlendrime işlemleri
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                //Hata Mesajı döndür
                return RedirectToAction("Index");
            }
           
        }
    }
}