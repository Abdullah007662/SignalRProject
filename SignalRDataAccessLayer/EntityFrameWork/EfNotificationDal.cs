using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDataAccessLayer.Repositories;
using SignalREntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SignalRDataAccessLayer.EntityFrameWork
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Notification> GetAllNotificationsByFalse()
        {
            var values = _context.Notifications.Where(x => x.Status == false).ToList();
            return values;
        }

        public int NotificationCountByStatusFalse()
        {
            var values = _context.Notifications.Where(x => x.Status == false).Count();
            return values;
        }
    }
}
