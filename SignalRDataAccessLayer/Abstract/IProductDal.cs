using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductWithCategory();
        public int ProductCount();
        public int ProductCountByCategoryNameHamburger();
        public int ProductCountByCategoryNameDrink();
        public decimal ProductPriceAvg();

        public string? ProductNamByMaxPrice();
        public string? ProductNamByMinPrice();

        public decimal ProductAvgPriceByHamburger();
    }
}
