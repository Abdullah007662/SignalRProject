using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using SignalRBusinessLayer.Abstract;

namespace SignalRWebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IOrderService _orderService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMoneyCaseService moneyCaseService, IOrderService orderService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _moneyCaseService = moneyCaseService;
            _orderService = orderService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        public async Task SendStatistic()
        {
            var categoryCount = _categoryService.BCategoryCount();
            var productCount = _productService.ProductCount();
            var activeCategoryCount = _categoryService.BActiveCategoryCount();
            var passiveCategoryCount = _categoryService.BPasiveCategoryCount();
            var hamburgerCategory = _productService.BProductCountByCategoryNameHamburger();
            var drinkCategory = _productService.BProductCountByCategoryNameDrink();
            var productPriceavg = _productService.BProductPriceAvg();
            var productnameByMaxprice = _productService.BProductNamByMaxPrice();
            var productnameByMinprice = _productService.BProductNamByMinPrice();
            var productavgPricebyHamburger = _productService.BProductAvgPriceByHamburger();
            var totalOrdercount = _orderService.BTotalOrderCount();
            var activeOrdercount = _orderService.BActiveOrderCount();
            var lastOrderprice = _orderService.BLastOrderPrice();
            var totalMoneycaseAmount = _moneyCaseService.BTotalMoneyCaseAmount();
            var menuTableCount = _menuTableService.BMenuTableCount();

            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
            await Clients.All.SendAsync("ReceiveProductCount", productCount);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", hamburgerCategory);
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", drinkCategory);
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceavg.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productnameByMaxprice);
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productnameByMinprice);
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", productavgPricebyHamburger.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrdercount);
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrdercount);
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderprice.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneycaseAmount.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTableCount);


        }

        public async Task SendProgress()
        {
            var totalCaseAmount = _moneyCaseService.BTotalMoneyCaseAmount();
            var activeOrdercount = _orderService.BActiveOrderCount();
            var menuTablecount = _menuTableService.BMenuTableCount();


            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalCaseAmount.ToString("0.00") + "₺");
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrdercount);
            await Clients.All.SendAsync("ReceiveMenuTableCount", menuTablecount);

        }
    }
}
