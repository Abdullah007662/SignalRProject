using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void BAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void BDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount BGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> BGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public void BUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}
