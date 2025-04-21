using Microsoft.AspNetCore.SignalR;
using SignalRDataAccessLayer.Concrete;

namespace SignalRWebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly SignalRContext _context;

        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var value = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiverCategoryCount", value);
        }
    }
}
