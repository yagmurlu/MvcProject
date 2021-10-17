using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Index(AdminLoginDto loginDto)
        //{
        //    authService.AdminRegister(loginDto.AdminName,loginDto.AdminUsername, loginDto.AdminPassword, loginDto.AdminRoleId);
        //    return RedirectToAction("Index", "Login");
        //}
        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLogin)
        {
            authService.WriterRegister
                (writerLogin.WriterName,
                writerLogin.WriterSurname,
                writerLogin.WriterImage,
                writerLogin.WriterAbout,
                writerLogin.WriterMail,
                writerLogin.WriterPassword,
                writerLogin.Title,
                writerLogin.WriterStatus=true
                );
            return RedirectToAction("MyContent", "WriterPanelContent");
        }
    }
}