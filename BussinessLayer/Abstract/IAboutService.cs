using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void CategoryAddBL(About about);
        About GetById(int id);
        void CategoryDelete(About about);
        void CategoryUpdate(About about);
    }
}
