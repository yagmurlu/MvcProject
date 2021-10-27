using BussinessLayer.Concrete;
using BussinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        
        }
        public PartialViewResult ContactPartial()
        {
            string p = (string)Session["AdminUserName"];
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetListSendBox(p).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetListInbox(p).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = messageManager.GetListDraft(p).Count();
            ViewBag.draftMail = draftMail;
            var trashMail = messageManager.GetLisTrash().Count();
            ViewBag.trashMail = trashMail;

            var readMessage = messageManager.GetReadList(p).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetUnReadList(p).Count();
            ViewBag.unreadMessage = unreadMessage;

            var importantMail = messageManager.GetListImportant(p).Count();
            ViewBag.importantMail = importantMail;
            var spamMail = messageManager.GetListSpam(p).Count();
            ViewBag.spamMail = spamMail;

            return PartialView();
        }
        public PartialViewResult PartialMessageList()
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialMessageFooterButton()
        {
            return PartialView();
        }
        public ActionResult IsRead(int id)
        {
            var contactValue = cm.GetById(id);
            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }
            cm.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }
        public ActionResult IsImportant(int id)
        {
            var contactValue = cm.GetById(id);
            if (contactValue.IsImportant)
            {
                contactValue.IsImportant = false;
            }
            else
            {
                contactValue.IsImportant = true;
            }
            cm.ContactUpdate(contactValue);
            return RedirectToAction("Index");
        }
    }
}