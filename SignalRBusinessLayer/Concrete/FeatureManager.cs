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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void BAdd(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public void BDelete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public Feature BGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public List<Feature> BGetListAll()
        {
            return _featureDal.GetListAll(); ;
        }

        public void BUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
