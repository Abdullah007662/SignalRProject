using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SignalRBusinessLayer.Abstract;
using SignalRBusinessLayer.Concrete;
using SignalRDataAccessLayer.Abstract;
using SignalRDataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRBusinessLayer.Conteiner
{
    public static class Extension
    {
        public static void ConteinerDependencies(this IServiceCollection Services)
        {
            Services.AddScoped<IAboutDal, EfAboutDal>();
            Services.AddScoped<IAboutService, AboutManager>();


            Services.AddScoped<IBookingDal, EfBookingDal>();
            Services.AddScoped<IBookingService, BookingManager>();

            Services.AddScoped<ICategoryDal, EfCategoryDal>();
            Services.AddScoped<ICategoryService, CategoryManager>();


            Services.AddScoped<IContactDal, EfContactDal>();
            Services.AddScoped<IContactService, ContactManager>();


            Services.AddScoped<IDiscountDal, EfDiscountDal>();
            Services.AddScoped<IDiscountService, DiscountManager>();


            Services.AddScoped<IFeatureDal, EfFeatureDal>();
            Services.AddScoped<IFeatureService, FeatureManager>();


            Services.AddScoped<IProductDal, EfProductDal>();
            Services.AddScoped<IProductService, ProductManager>();


            Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            Services.AddScoped<ISocialMediaService, SocialMediaManager>();


            Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            Services.AddScoped<ITestimonialService, TestimonialManager>();


        }
    }
}
