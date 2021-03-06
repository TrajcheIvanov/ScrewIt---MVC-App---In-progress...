using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScrewIt.Models;
using ScrewIt.Repositories;
using ScrewIt.Repositories.Interfaces;
using ScrewIt.Services;
using ScrewIt.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewIt
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ScrewItDbContext>(
                x => x.UseSqlServer(Configuration.GetConnectionString("ScrewIt"))
                );


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyMethod()
                           .AllowAnyOrigin()
                           .AllowAnyHeader();
                });
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ScrewItDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(x =>
            {
                x.ExpireTimeSpan = TimeSpan.FromDays(30);
                x.LoginPath = "/Account/SignIn";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            //register services
            services.AddTransient<IDimensionsService, DimensionsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IPanelsService, PanelsService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<IReceiptsService, ReceiptsService>();
            services.AddTransient<IReceiptItemsRepository, ReceiptItemsRepository>();

            //register repositories
            services.AddTransient<IDimensionsRepository, DimensionsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPanelsRepository, PanelsRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IReceiptsRepository, ReceiptsRepository>();
            services.AddTransient<IReceiptItemsService, ReceiptItemsService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Overview}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
