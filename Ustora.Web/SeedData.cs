using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ustora.Data.Models;

namespace Ustora.Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder applicationBuilder)
        {
            addProducts(applicationBuilder);
            addSlides(applicationBuilder);
        }
        
        public static async void addSlides(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                UstoraContext context = serviceScope.ServiceProvider.GetService<UstoraContext>();
                bool hasElements = await context.Slides.AnyAsync();
                if (!hasElements)
                {
                    context.Slides.Add(new Slide()
                    {
                        Name = "iPhone 6s",
                        Description = "Dual SIM",
                        ImagePath = "/img/h4-slide.png",
                        Link = "/Catalog/1"
                    });

                    context.Slides.Add(new Slide()
                    {
                        Name = "by one, get one 50% off",
                        Description = "school supplies & backpacks.*",
                        ImagePath = "/img/h4-slide2.png",
                        Link = "/Catalog/2"
                    });

                    context.Slides.Add(new Slide()
                    {
                        Name = "Apple Store Ipod",
                        Description = "Select Item",
                        ImagePath = "/img/h4-slide3.png",
                        Link = "/Catalog/3"
                    });

                    context.Slides.Add(new Slide()
                    {
                        Name = "Apple Store Ipod",
                        Description = "& Phone",
                        ImagePath = "/img/h4-slide4.png",
                        Link = "/Catalog/4"
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async void addProducts(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {

                UstoraContext context = serviceScope.ServiceProvider.GetService<UstoraContext>();
                bool hasElements = await context.Products.AnyAsync();
                if (!hasElements)
                {
                    context.Products.Add(new Product()
                    {
                        Name = "Canon camera",
                        Description = "Описание2",
                        Price = 150,
                        ImagePath = "/img/product-2.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Canon", ImagePath = "/lmg/brand2.png" },
                        Section = new Section { Name = "Camera" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Apple new mac book 2015 March :P",
                        Description = "Описание3",
                        Price = 200,
                        ImagePath = "/img/product-3.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Samsung", ImagePath = "/lmg/brand3.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Nokia",
                        Description = "Описание",
                        Price = 100,
                        ImagePath = "/img/product-1.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Nokia", ImagePath = "/lmg/brand1.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Nokia",
                        Description = "Описание",
                        Price = 100,
                        ImagePath = "/img/product-1.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Nokia", ImagePath = "/lmg/brand1.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Canon camera",
                        Description = "Описание2",
                        Price = 150,
                        ImagePath = "/img/product-2.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Canon", ImagePath = "/lmg/brand2.png" },
                        Section = new Section { Name = "Camera" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Apple new mac book 2015 March :P",
                        Description = "Описание3",
                        Price = 200,
                        ImagePath = "/img/product-3.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Samsung", ImagePath = "/lmg/brand3.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Nokia",
                        Description = "Описание",
                        Price = 100,
                        ImagePath = "/img/product-1.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Nokia", ImagePath = "/lmg/brand1.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.Products.Add(new Product()
                    {
                        Name = "Nokia",
                        Description = "Описание",
                        Price = 100,
                        ImagePath = "/img/product-1.jpg",
                        DateCreate = new DateTime(),
                        DateUpdate = new DateTime(),
                        MainSliderShow = true,
                        TopSellerShow = true,
                        Brand = new Brand { Name = "Nokia", ImagePath = "/lmg/brand1.png" },
                        Section = new Section { Name = "Phones" }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
