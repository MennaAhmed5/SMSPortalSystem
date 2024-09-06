using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMSPortal.BL.Managers;
using SMSPortal.DAL.Data.Context;
using SMSPortal.DAL.Data.Models;
using SMSPortal.DAL.Repository;
using SMSPortal.DAL.UnitOfWork;
using SMSPortal.BL.Helpers;
using System.Security.Claims;
using SMSPortal.BL.Services;

namespace SMSPortal.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("SMSPortalDB");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Users/AccessDenied";
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
                options.AddPolicy("SenderPolicy", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Sender");
                });
                options.AddPolicy("ViewerPolicy", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Viewer");
                });
            });



            builder.Services.AddScoped<IMessageTempleteRepository, MessageTempleteRepository>();
            builder.Services.AddScoped<IReportRepository, ReportRepository>();
            builder.Services.AddScoped<IMessageTempleteManager, MessageTempleteManager>();
            builder.Services.AddScoped<IReportManager, ReportManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ISMSService, SMSService>();

            builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
