using BussinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ImageFileManager:IImageFileService
    {
        IImageDal _ımageDal;

        public ImageFileManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }

        public List<ImageFile> GetList()
        {
           return _ımageDal.List();
        }
    }
}
