using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutItemService, AboutItemManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IBannerService, BannerManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<INewsletterService, NewsletterManager>();
            services.AddScoped<IPdfService, PdfManager>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<IAboutItemDal, AboutItemDal>();
            services.AddScoped<IAddressDal, AddressDal>();
            services.AddScoped<IAppUserDal, AppUserDal>();
            services.AddScoped<IBannerDal, BannerDal>();
            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<IDestinationDal, DestinationDal>();
            services.AddScoped<IFeatureDal, FeatureDal>();
            services.AddScoped<IMessageDal, MessageDal>();
            services.AddScoped<INewsletterDal, NewsletterDal>();
            services.AddScoped<IReservationDal, ReservationDal>();
            services.AddScoped<IRoomDal, RoomDal>();
            services.AddScoped<ISliderDal, SliderDal>();
            services.AddScoped<ITeamDal, TeamDal>();
            services.AddScoped<ITestimonialDal, TestimonialDal>();
        }
    }
}