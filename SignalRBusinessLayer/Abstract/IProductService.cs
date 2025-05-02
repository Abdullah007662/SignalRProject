using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> BGetProductWithCategory();
        int ProductCount();
        int BProductCountByCategoryNameHamburger();
        int BProductCountByCategoryNameDrink();
        decimal BProductPriceAvg();
        string? BProductNamByMaxPrice();
        string? BProductNamByMinPrice();
        public decimal BProductPriceBySteakBurger();
        public decimal BTotalPriceByDrinkCategory();
        public decimal BTotalPriceBySaladCategory();

        decimal BProductAvgPriceByHamburger();

    }
}
