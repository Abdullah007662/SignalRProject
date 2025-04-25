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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;
        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int ActiveOrderCount()
        {
            var values = _context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
            return values;
        }

        public decimal LastOrderPrice()
        {
            var values = _context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(z => z.TotalPrice).FirstOrDefault();
            return values;
        }

        public decimal TodayTotalPrice()
        {
            throw new NotImplementedException();
        }

        public int TotalOrderCount()
        {
            var values = _context.Orders.Count();
            return values;
        }
    }
}
