using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ustora.Data;
using Ustora.Service.Interfaces;
using Ustora.Service;
using Serilog;

namespace Ustora.Web
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .Enrich.FromLogContext()
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(Configuration);
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSession();
            services.AddMemoryCache();
            services.AddDbContext<UstoraContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("UstoraConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            SeedData.Initialize(app);

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("cart", "ajax/cart/add/{productId}/{quantity}",
                    defaults: new { controller = "Cart", action = "AddToCart" });
                routes.MapRoute("cart", "ajax/cart/remove/{productId}",
                    defaults: new { controller = "Cart", action = "Remove" });
                routes.MapRoute("catalog_pagination", "catalog/page{productPage}",
                    defaults: new { controller = "Catalog", action = "Index" });
                routes.MapRoute("catalog_detail", "catalog/{id}",
                    defaults: new { controller = "Catalog", action = "Detail" });
                routes.MapRoute("catalog", "catalog",
                    defaults: new { controller = "Catalog", action = "Index" });
                routes.MapRoute("cart", "cart",
                    defaults: new { controller = "Cart", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
