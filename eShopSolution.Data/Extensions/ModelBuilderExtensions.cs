﻿using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HoemKeyword", Value = "This is keyword page of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                    new Category() { 
                        Id =1, 
                        IsShowOnHome = true, 
                        ParentId = null, 
                        SortOrder = 1, 
                        Status  = Status.Active,
                    },
                    new Category()
                    {
                        Id = 2,
                        IsShowOnHome = true,
                        ParentId = null,
                        SortOrder = 2,
                        Status = Status.Active,
                    }
                );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                    new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "" },
                    new CategoryTranslation() { Id = 2,CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "" },
                    new CategoryTranslation() {Id = 3,CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "" },
                    new CategoryTranslation() {Id = 4,CategoryId =2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id= 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                        new ProductTranslation()
                        {
                            Id =1,
                            ProductId = 1,
                            Name = "Áo sơ mi nam trắng Việt Tiến",
                            LanguageId = "vi-VN",
                            SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                            SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                            SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                            Details = "Áo sơ mi nam trắng Việt Tiến",
                            Description = "Áo sơ mi nam trắng Việt Tiến"
                        },
                        new ProductTranslation()
                        {
                            Id = 2,
                            ProductId = 1,
                            Name = "Viet Tien Men T-Shirt",
                            LanguageId = "en-US",
                            SeoAlias = "viet-tien-men-t-shirt",
                            SeoDescription = "Viet Tien Men T-Shirt",
                            SeoTitle = "Viet Tien Men T-Shirt",
                            Details = "Viet Tien Men T-Shirt",
                            Description = "Viet Tien Men T-Shirt"
                        }
                );
            modelBuilder.Entity<ProductInCategory>().HasData
                (
                new ProductInCategory() { ProductId = 1, CategoryId = 1}
                );


            var roleID = new Guid("09120475-3020-4682-a2eb-23f3915051d6");
            var adminID = new Guid("FCF90235-67A7-4A8C-B7E0-81CC988CCF74");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role",
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "tienncph18949@fpt.edu.vn",
                NormalizedEmail = "tienncph18949@fpt.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234@"),
                SecurityStamp = string.Empty,
                FirstName = "Tien",
                LastName ="Nguyen",
                Dob = new DateTime(2023,02,18)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleID,
                UserId = adminID
            });


        }
    }
}
