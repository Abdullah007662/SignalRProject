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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void BAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void BDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public Testimonial BGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> BGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public void BUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
