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
using PagedList;

namespace MvcProje.Controllers
{
    [Authorize(Users = "Admin")]
    public class MessageController : Controller
    {
        // GET: Message
        //Gelen mesajları listeleme
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(int? page)
        {
            string p = (string)Session["AdminUserName"];
            var messageList = messageManager.GetListInbox(p).ToPagedList(page ?? 1,8);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["AdminUserName"];
            var messageList = messageManager.GetListSendBox(p);
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
        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message p,string menuName)
        {
            string session = (string)Session["AdminUserName"];
            ValidationResult results =messageValidator.Validate(p);
            if (menuName=="send")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
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
            }
            else if (menuName=="draft")
            {
                if (results.IsValid)
                {
                    p.SenderMail = session;
                    p.IsDraft = true;
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAddBL(p);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (menuName=="cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var result = messageManager.GetById(id);
            if (result.Trash==true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            messageManager.MessageDelete(result);
            return RedirectToAction("Inbox");
        }
        public ActionResult DraftMessages()
        {
            string session = (string)Session["AdminUserName"];
            var result = messageManager.IsDraft(session);
            return View(result);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }
        public ActionResult IsRead(int id)
        {
            var mesageValue = messageManager.GetById(id);
            if (mesageValue.IsRead)
            {
                mesageValue.IsRead = false;
            }
            else
            {
                mesageValue.IsRead = true;
            }
            messageManager.MessageUpdate(mesageValue);
            return RedirectToAction("Inbox");
        }
        public ActionResult IsImportant(int id)
        {
            var mesageValue = messageManager.GetById(id);
            if (mesageValue.IsImportant)
            {
                mesageValue.IsImportant = false;
            }
            else
            {
                mesageValue.IsImportant = true;
            }
            messageManager.MessageUpdate(mesageValue);
            return RedirectToAction("Inbox");
        }
    }
}