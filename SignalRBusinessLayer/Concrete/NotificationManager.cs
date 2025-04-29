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
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void BAdd(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void BDelete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> BGetAllNotificationsByFalse()
        {
            return _notificationDal.GetAllNotificationsByFalse();
        }

        public Notification BGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> BGetListAll()
        {
            return _notificationDal.GetListAll();
        }

        public int BNotificationCountByStatusFalse()
        {
            var value = _notificationDal.NotificationCountByStatusFalse();
            return value;
        }

        public void BUpdate(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
