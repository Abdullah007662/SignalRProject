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
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        private readonly SignalRContext _context;

        public EfMoneyCaseDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public decimal TotalMoneyCaseAmount()
        {
            var values = _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
            return values;
        }
    }
}
