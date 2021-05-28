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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)//constuctor
        {
            _aboutDal = aboutDal;
        }

        public void CategoryAddBL(About about)
        {
            throw new NotImplementedException();
        }

        public void CategoryDelete(About about)
        {
            throw new NotImplementedException();
        }

        public void CategoryUpdate(About about)
        {
            throw new NotImplementedException();
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
