﻿using Microsoft.EntityFrameworkCore;
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

        public string? ProductNamByMaxPrice()
        {
            var value = _context.Products.Where(x => x.Price == (_context.Products.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return value;
        }

        public string? ProductNamByMinPrice()
        {
            var value = _context.Products.Where(x => x.Price == (_context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
            return value;
        }

        public decimal ProductPriceAvg()
        {
            var value = _context.Products.Average(x => x.Price);
            return value;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            return _context.Products.Where(x => x.CategoryID == (_context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            return _context.Products.Where(x => x.ProductName == "Steak Burger").Select(y => y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            int id = _context.Categories.Where(x => x.CategoryName == "İçecek").Select(y => y.CategoryID).FirstOrDefault();
            return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            int id = _context.Categories.Where(x => x.CategoryName == "Salata").Select(y => y.CategoryID).FirstOrDefault();
            return _context.Products.Where(x => x.CategoryID == id).Sum(y => y.Price);
        }
    }
}
