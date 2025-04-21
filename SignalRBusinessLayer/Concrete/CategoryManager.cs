using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int BActiveCategoryCount()
        {
            return _categoryDal.ActiveCategoryCount();
        }

        public void BAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public int BCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

        public void BDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category BGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> BGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public int BPasiveCategoryCount()
        {
            return _categoryDal.PasiveCategoryCount();
        }

        public void BUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }


    }
}
