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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void BAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void BDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order BGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> BGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void BUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public int BTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public int BActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public decimal BLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal BTotalMoneyCaseAmount()
        {
            return _orderDal.TodayTotalPrice();
        }
    }
}
