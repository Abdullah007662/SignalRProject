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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void BAdd(SocialMedia entity)
        {
            _socialMediaDal.Add(entity);
        }

        public void BDelete(SocialMedia entity)
        {
            _socialMediaDal.Delete(entity);
        }

        public SocialMedia BGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> BGetListAll()
        {
            return _socialMediaDal.GetListAll();
        }

        public void BUpdate(SocialMedia entity)
        {
            _socialMediaDal.Update(entity);
        }
    }
}
