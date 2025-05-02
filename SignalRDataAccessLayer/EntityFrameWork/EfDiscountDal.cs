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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        private readonly SignalRContext _context;
        public EfDiscountDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeStatusToFalse(int id)
        {
            var value = _context.Discounts.Find(id);
            value!.Status = false;
            _context.SaveChanges();
        }

        public void ChangeStatusToTrue(int id)
        {
            var value = _context.Discounts.Find(id);
            value!.Status = true;
            _context.SaveChanges();
        }
    }
}
