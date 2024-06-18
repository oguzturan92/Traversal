using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // Identity kullanımı için - Start ------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();
    builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

    // Injection için Configure İşlemleri ----------------------------------------------------------------------------------
    builder.Services.AddScoped<IAboutService, AboutManager>();
    builder.Services.AddScoped<IAboutItemService, AboutItemManager>();
    builder.Services.AddScoped<IAddressService, AddressManager>();
    builder.Services.AddScoped<IBannerService, BannerManager>();
    builder.Services.AddScoped<ICommentService, CommentManager>();
    builder.Services.AddScoped<IDestinationService, DestinationManager>();
    builder.Services.AddScoped<IFeatureService, FeatureManager>();
    builder.Services.AddScoped<IMessageService, MessageManager>();
    builder.Services.AddScoped<INewsletterService, NewsletterManager>();
    builder.Services.AddScoped<IReservationService, ReservationManager>();
    builder.Services.AddScoped<IRoomService, RoomManager>();
    builder.Services.AddScoped<ISliderService, SliderManager>();
    builder.Services.AddScoped<ITeamService, TeamManager>();
    builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

    builder.Services.AddScoped<IAboutDal, AboutDal>();
    builder.Services.AddScoped<IAboutItemDal, AboutItemDal>();
    builder.Services.AddScoped<IAddressDal, AddressDal>();
    builder.Services.AddScoped<IBannerDal, BannerDal>();
    builder.Services.AddScoped<ICommentDal, CommentDal>();
    builder.Services.AddScoped<IDestinationDal, DestinationDal>();
    builder.Services.AddScoped<IFeatureDal, FeatureDal>();
    builder.Services.AddScoped<IMessageDal, MessageDal>();
    builder.Services.AddScoped<INewsletterDal, NewsletterDal>();
    builder.Services.AddScoped<IReservationDal, ReservationDal>();
    builder.Services.AddScoped<IRoomDal, RoomDal>();
    builder.Services.AddScoped<ISliderDal, SliderDal>();
    builder.Services.AddScoped<ITeamDal, TeamDal>();
    builder.Services.AddScoped<ITestimonialDal, TestimonialDal>();

    // Proje Seviyesinde Authorize -----------------------------------------------------------------------------------------
    // builder.Services.AddMvc(config => 
    // {
    //     var policy = new AuthorizationPolicyBuilder()
    //     .RequireAuthenticatedUser()
    //     .Build();
    //     config.Filters.Add(new AuthorizeFilter(policy));
    // });

    // IDENTITY AYARLARI - 1
    builder.Services.Configure<IdentityOptions>(options => {

        // Şifre Ayarları
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        // options.Password.RequiredLength = false; // Minimum karakter sayısı.
        options.Password.RequireNonAlphanumeric = false;

        // Kilitleme Ayarları
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.AllowedForNewUsers = true;

        // Mail Ayarları
        // options.User.AllowedUserNameCharacters = "";
        options.User.RequireUniqueEmail = true;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
    });

    // IDENTITY AYARLARI - 2
    builder.Services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/User/UserLogin";
        options.LogoutPath = "/User/Logout";
        options.AccessDeniedPath = "/User/UserLogin";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.Cookie = new CookieBuilder
        {
            HttpOnly = true,
            Name = ".traversal.Security.Cookie",
            SameSite = SameSiteMode.Strict
        };
    });
    // Identity kullanımı için - Finish ------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

    app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
