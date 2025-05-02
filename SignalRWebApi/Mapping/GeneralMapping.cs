using AutoMapper;
using SignalRDtoLayer.ApiDTO.AboutDTO;
using SignalRDtoLayer.ApiDTO.BasketDTO;
using SignalRDtoLayer.ApiDTO.BookingDTO;
using SignalRDtoLayer.ApiDTO.CategoryDTO;
using SignalRDtoLayer.ApiDTO.ContactDTO;
using SignalRDtoLayer.ApiDTO.DiscountDTO;
using SignalRDtoLayer.ApiDTO.FeatureDTO;
using SignalRDtoLayer.ApiDTO.MenüTable;
using SignalRDtoLayer.ApiDTO.MessageDTO;
using SignalRDtoLayer.ApiDTO.ProductDTO;
using SignalRDtoLayer.ApiDTO.SocialMediaDTO;
using SignalRDtoLayer.ApiDTO.TestimonialDTO;
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


            CreateMap<Basket, CreateBasketDTO>().ReverseMap();
            CreateMap<Basket, ResultBasketDTO>().ReverseMap();
            CreateMap<Basket, GetByIdBasketDTO>().ReverseMap();
            CreateMap<Basket, UpdateBasketDTO>().ReverseMap();




            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();

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


            CreateMap<MenuTable, CreateMenüTableDTO>().ReverseMap();
            CreateMap<MenuTable, GetByIdMenüTableDTO>().ReverseMap();
            CreateMap<MenuTable, UpdateMenüTableDTO>().ReverseMap();
            CreateMap<MenuTable, ResultMenüTableDTO>().ReverseMap();

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
