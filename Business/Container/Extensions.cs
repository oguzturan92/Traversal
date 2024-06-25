using Business.Abstract;
using Business.Abstract.AbstractUOfWork;
using Business.Concrete;
using Business.Concrete.ConcreteUOfWork;
using Business.Validation;
using Data.Abstract;
using Data.Abstract.AbstractUOfWork;
using Data.EntityFramework;
using Data.EntityFramework.EntityFrameworkUOfWork;
using Data.UnitOfWork;
using Dto.DTOs.AnnouncementDTOs;
using Dto.DTOs.MessageDTOs;
using Dto.DTOs.NewsletterDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
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
            services.AddScoped<IAddressDal, AddressDal>();
            services.AddScoped<IAnnouncementDal, AnnouncementDal>();
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

            //UnitOfWork  Registerları --------------------------------------------
            services.AddScoped<IAccountUOfWorkService, AccountUOfWorkManager>();
            services.AddScoped<IAccountUOfWorkDal, AccountUOfWorkDal>();

            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();
        }

        // Validator ile Dto'lar eşleştirilmesi
        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementCreateDTO>, AnnouncementCreateValidator>();
            services.AddTransient<IValidator<AnnouncementUpdateDTO>, AnnouncementUpdateValidator>();

            services.AddTransient<IValidator<MessageCreateDTO>, MessageValidator>();
            services.AddTransient<IValidator<NewsletterCreateDTO>, NewsletterValidator>();
        }
    }
}