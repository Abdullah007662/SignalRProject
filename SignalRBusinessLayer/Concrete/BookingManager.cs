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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void BAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void BBookingStatusApproved(int id)
        {
            _bookingDal.BookingStatusApproved(id);
        }

        public void BBookingStatusCancelled(int id)
        {
            _bookingDal.BookingStatusCancelled(id);
        }

        public void BDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking BGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> BGetListAll()
        {
            return _bookingDal.GetListAll();
        }

        public void BUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
