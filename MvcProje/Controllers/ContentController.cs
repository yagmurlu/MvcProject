using BussinessLayer.Concrete;
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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());   
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GettAllContent()
        {

            var values = cm.GetList();
            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
            return View(contentValues);
        }
        
    }
}