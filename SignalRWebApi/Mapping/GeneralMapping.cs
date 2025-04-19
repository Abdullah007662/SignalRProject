using AutoMapper;
using SignalRDtoLayer.AboutDTO;
using SignalRDtoLayer.BookingDTO;
using SignalRDtoLayer.CategoryDTO;
using SignalRDtoLayer.ContactDTO;
using SignalRDtoLayer.DiscountDTO;
using SignalRDtoLayer.FeatureDTO;
using SignalRDtoLayer.ProductDTO;
using SignalRDtoLayer.SocialMediaDTO;
using SignalRDtoLayer.TestimonialDTO;
using SignalREntityLayer.Entities;

namespace SignalRWebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            #region About Mapping
            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, GetByIdAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            #endregion


            #region Booking Mapping

            CreateMap<Booking, ResultBookingDTO>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();
            CreateMap<Booking, GetByIdBookingDTO>().ReverseMap();
            #endregion


            #region Category Mapping

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDTO>().ReverseMap();

            #endregion


            #region Contact Mapping

            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, GetByIdContactDTO>().ReverseMap();


            #endregion



            #region Discount Mapping

            CreateMap<Discount, ResultDiscountDTO>().ReverseMap();
            CreateMap<Discount, CreateDiscountDTO>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDTO>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountDTO>().ReverseMap();


            #endregion


            #region Feature Mapping

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();

            #endregion


            #region Product Mapping

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();

            // Burasını Yazdık Çünkü Nested Yapıda Geliyor veriler
            CreateMap<Product, ResultProductWithCategory>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.CategoryName));

            #endregion




            #region  SocialMedia Mapping


            CreateMap<SocialMedia, ResultSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDTO>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaDTO>().ReverseMap();


            #endregion


            #region Testimonial Mapping

            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDTO>().ReverseMap();

            #endregion



        }
    }
}
