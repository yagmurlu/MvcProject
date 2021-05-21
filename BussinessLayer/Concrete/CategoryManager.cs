using BussinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)//construcor method
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        // GenericRepository<Category> repo = new GenericRepository<Category>();

        //Listeleme işlemi
        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}
        //Category tablosuna şartlı ekleme yapma
        //public void CategoryAddBL(Category p)
        //{
        //    //if (p.CategoryName==""||p.CategoryName.Length<=3||p.CategoryDescription==""|| p.CategoryName.Length >= 51)
        //    //{
        //    //    //hata mesajı
        //    //}
        //    //else
        //    //{
        //        repo.Insert(p);
        //    //}
        //}
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
