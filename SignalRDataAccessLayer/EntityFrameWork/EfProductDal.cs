using Microsoft.EntityFrameworkCore;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;

        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductWithCategory()
        {
            var values = _context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            var values = _context.Products.Include(x => x.Category).Count();
            return values;
        }

        public int ProductCountByCategoryNameDrink()
        {
            var values = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.CategoryID).FirstOrDefault())).Count();
            return values;
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var values = _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Count();
            return values;
        }
    }
}
