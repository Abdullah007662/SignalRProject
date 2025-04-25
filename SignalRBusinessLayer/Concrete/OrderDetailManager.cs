using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetail;

        public OrderDetailManager(IOrderDetailDal orderDetail)
        {
            _orderDetail = orderDetail;
        }

        public void BAdd(OrderDetail entity)
        {
            _orderDetail.Add(entity);
        }

        public void BDelete(OrderDetail entity)
        {
            _orderDetail.Delete(entity);
        }

        public OrderDetail BGetById(int id)
        {
            return _orderDetail.GetById(id);
        }

        public List<OrderDetail> BGetListAll()
        {
            return _orderDetail.GetListAll();
        }

        public void BUpdate(OrderDetail entity)
        {
            _orderDetail.Update(entity);
        }
    }
}
