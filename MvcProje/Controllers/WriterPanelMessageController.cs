using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context c = new Context();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            
            var messageList = messageManager.GetListInbox(p);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = messageManager.GetListSendBox(p);
            return View(messageList);
        } 
        public ActionResult MessageListMenu()
        {
            return PartialView();
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
            ValidationResult results = messageValidator.Validate(p);
            string sendermail = (string)Session["WriterMail"];
            if (results.IsValid)
            {
               

                p.SenderMail = sendermail;
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