using BussinessLayer.Concrete;
using EntityLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProje.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        //Gelen mesajları listeleme
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            var messageList = messageManager.GetListSendBox();
            return View(messageList);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var sendValues = messageManager.GetById(id);
            return View(sendValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results =messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAddBL(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}