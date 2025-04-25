using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void BAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void BDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product BGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> BGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> BGetProductWithCategory()
        {
            return _productDal.GetProductWithCategory();
        }

        public decimal BProductAvgPriceByHamburger()
        {
            return _productDal.ProductAvgPriceByHamburger();
        }

        public int BProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public int BProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public string? BProductNamByMaxPrice()
        {
            return _productDal.ProductNamByMaxPrice();
        }

        public string? BProductNamByMinPrice()
        {
            return _productDal.ProductNamByMinPrice();
        }

        public decimal BProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public void BUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public int ProductCount()
        {
            return _productDal.ProductCount();
        }
    }
}
