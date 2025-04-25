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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void BAdd(MenuTable entity)
        {
            _menuTableDal.Add(entity);
        }

        public void BDelete(MenuTable entity)
        {
            _menuTableDal.Delete(entity);
        }

        public MenuTable BGetById(int id)
        {
            return _menuTableDal.GetById(id);
        }

        public List<MenuTable> BGetListAll()
        {
            return _menuTableDal.GetListAll();
        }

        public void BUpdate(MenuTable entity)
        {
            _menuTableDal.Update(entity);
        }

        public int BMenuTableCount()
        {
            return _menuTableDal.MenuTableCount();
        }
    }
}
