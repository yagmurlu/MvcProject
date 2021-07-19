using BussinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ım = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ım.GetList();

            return View(files);
        }
    }
}
