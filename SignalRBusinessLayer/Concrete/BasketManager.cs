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
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void BAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void BDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> BGetBasketByMenuTableNumber(int id)
        {
            return _basketDal.GetBasketByMenuTableNumber(id);
        }

        public Basket BGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public List<Basket> BGetListAll()
        {
            return _basketDal.GetListAll();
        }

        public void BUpdate(Basket entity)
        {
            _basketDal.Update(entity);
        }
    }
}
