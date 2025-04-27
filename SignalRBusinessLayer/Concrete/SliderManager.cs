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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void BAdd(Slider entity)
        {
            _sliderDal.Add(entity);
        }

        public void BDelete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public Slider BGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public List<Slider> BGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public void BUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
