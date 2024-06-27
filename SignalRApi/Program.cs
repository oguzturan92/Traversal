using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    // START ---------------------------------------------------------
    builder.Services.AddDbContext<Context>();
    builder.Services.AddScoped<VisitorServiceModel>();
    builder.Services.AddSignalR();

            // SignalRApi projesi, SignalRConsume klasöründe Consume edeceğiz. Bu metot, Api'yi Consume etmeye izin veriyor.
    builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder => 
        {
            builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials();
        }));
    // builder.Services.AddCors(options => options.AddDefaultPolicy( policy => policy
    //     .AllowCredentials()
    //     .AllowAnyHeader()
    //     .AllowAnyMethod()
    //     .SetIsOriginAllowed((host) => true)));

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior",true); // Tarih formatını, Npgsql formatında ayarlar
    // FINISH ---------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

    // START ---------------------------------------------------------
    // app.UseCors();
    app.UseCors("CorsPolicy");
    // FINISH ---------------------------------------------------------

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

    // START ---------------------------------------------------------
    app.MapHub<VisitorHubNpg>("/VisitorHubNpg");
    // FINISH ---------------------------------------------------------

app.Run();
