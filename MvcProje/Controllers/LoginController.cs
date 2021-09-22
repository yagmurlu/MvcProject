using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using MvcProje.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        Context c = new Context();
        //WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLoginDto adminDto)
        {
            
            if (authService.AdminLogin(adminDto))
            {
                //yönlendrime işlemleri
                FormsAuthentication.SetAuthCookie(adminDto.AdminUsername, false);
                Session["AdminUsername"] = adminDto.AdminUsername;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                //Hata Mesajı döndür
                ViewData["ErrorMessage"] = "Kullanıcı Adı veya Parola Yanlış!";
                return View();
            }
           
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(WriterLoginDto writerDto)
        {
            var response = Request["g-recaptcha-response"];
            const string secret = "6LfbKk8bAAAAANkMjzLC_iAGX45a_J8RUWe1XYeQ";
            var client = new WebClient();
            var reply = client.DownloadString(
                string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.WriterLogin(writerDto)&&captchaResponse.Success)
            {
                //yönlendrime işlemleri
                FormsAuthentication.SetAuthCookie(writerDto.WriterMail, false);
                Session["WriterMail"] = writerDto.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                //Hata Mesajı döndür
                ViewData["ErrorMessage"] = "Kullanıcı Adı veya Parola Yanlış!";
                return RedirectToAction("WriterLogin");
            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            //Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }
        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AllHeading", "WriterPanel");
        }
    }
}