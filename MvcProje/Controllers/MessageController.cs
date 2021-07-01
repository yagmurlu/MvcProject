using BussinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        //Gelen mesajları listeleme
        MessageManager cm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox()
        {
            var messageList = cm.GetListInbox();
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            var messageList = cm.GetListSendBox();
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = cm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();
        }
    }
}