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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void BAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void BDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About BGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> BGetListAll()
        {
            return _aboutDal.GetListAll();
        }

        public void BUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
