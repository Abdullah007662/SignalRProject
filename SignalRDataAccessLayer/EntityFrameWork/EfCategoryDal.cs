using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;
        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            return _context.Categories.Count(x => x.Status == true);
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int PasiveCategoryCount()
        {
            return _context.Categories.Count(x => x.Status == false);
        }
    }
}
