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
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetListSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            //var draftMail = messageManager.GetListSendBox().Where(m => m.IsDraft == true).Count();
            //ViewBag.draftMail = draftMail;

            //var readMessage = messageManager.GetMessagesInbox().Where(m => m.IsRead == true).Count();
            //ViewBag.readMessage = readMessage;

            //var unreadMessage = messageManager.GetAllRead().Count();
            //ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}