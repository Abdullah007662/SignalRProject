using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMoneyCaseService moneyCaseService, IOrderService orderService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _moneyCaseService = moneyCaseService;
            _orderService = orderService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;

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


            var value5 = _productService.BProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

            var value6 = _productService.BProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6);

            var value7 = _productService.BProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

            var value8 = _orderService.BTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _productService.BProductPriceBySteakBurger();
            await Clients.All.SendAsync("ReceiveProductPriceBySteakBurger", value9);

            var value10 = _productService.BTotalPriceByDrinkCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value10);

            var value11 = _productService.BTotalPriceBySaladCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11);

        }


        public async Task GetBookingList()
        {
            var bookings = _bookingService.BGetListAll(); // Liste al
            await Clients.All.SendAsync("ReceiveBookingList", bookings);
        }



        public async Task SendNotification()
        {
            var notificationCountByStatusFalse = _notificationService.BNotificationCountByStatusFalse();
            var notificationListByfalse = _notificationService.BGetAllNotificationsByFalse();


            await Clients.All.SendAsync("ReceiveGetAllNotificationsByFalse", notificationListByfalse);
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", notificationCountByStatusFalse);
        }
        public async Task GetMenuTableStatus()
        {
            var value = _menuTableService.BGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            Console.WriteLine($"Yeni bağlantı: {Context.ConnectionId}, Toplam: {clientCount}");
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
