using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Business.Interfaces;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using DataAccess.Concrete.EntityFrameworkCore.Repositories;
using DataAccess.Interfaces;
using DTO.DTOs.AciliyetDtos;
using DTO.DTOs.AppUserDtos;
using DTO.DTOs.GorevDtos;
using DTO.DTOs.RaporDtos;
using Entities.Concrete;

namespace WebUI.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
             .AddEntityFrameworkStores<JobTrackingContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "IsTakipCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/GirişYap";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AciliyetAddDto>, AciliyetAddValidator>();
            services.AddTransient<IValidator<AciliyetUpdateDto>, AciliyetUpdateValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserSignInDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<GorevAddDto>, GorevAddValidator>();
            services.AddTransient<IValidator<GorevUpdateDto>, GorevUpdateValidator>();
            services.AddTransient<IValidator<RaporAddDto>, RaporAddValidator>();
            services.AddTransient<IValidator<RaporUpdateDto>, RaporUpdateValidator>();
        }
    }
}
