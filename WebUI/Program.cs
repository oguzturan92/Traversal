using Business.Container;
using Data.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // LOGLAMA START : Aldığımız hataları görebilmek için tutacağız. ------------------------------------------------------
    // Burası açık olduğunda, proje run yapıldığında, started'de kalıyor ama prıje açılıyor.
    // builder.Services.AddLogging(x =>
    // {
    //     x.ClearProviders();

    //     // 1- Aoutput üzerinde gösterme ---------------------------
    //         // Örnek çalışma Home/Index içinde yapıldı
    //     x.SetMinimumLevel(LogLevel.Debug); // Debug'dan itibaren başlasın
    //     x.AddDebug(); // Loglanacak yer (OutputTa)

    //     // 2- Klasör oluşturup içinde text dosyasında tutacağız
    //         // Nugget Ekle : dotnet add package Serilog.Extensions.Logging.File --version 3.0.0
    //         // WebUI içinde otomatik olarak oluşturur
    //     var path = Directory.GetCurrentDirectory();
    //     x.AddFile($"{path}\\logs\\log.txt");
    // });
    // LOGLAMA FINISH ------------------------------------------------------

    // Identity kullanımı için - Start ------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();
    builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

    // Injection için Configure İşlemleri (Business/Container/Extensions içinde) ------------------------------------------------------
    builder.Services.ContainerDependencies();

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
    app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

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
