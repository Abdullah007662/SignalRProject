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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly SignalRContext _context;
        public EfMenuTableDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int MenuTableCount()
        {
            var value = _context.MenuTables.Count();
            return value;
        }
    }
}
