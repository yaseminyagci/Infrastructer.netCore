using Application.Repository;
using Application.Repository.ConcreateRepositories;
using AutoMapper.Configuration;
using Data.Authentication;
using Data.Context;
using Data.CustomValidations;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWebUI
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<EFHadithContext>(x => x.UseSqlServer("Server=DESKTOP-2MILLH9\\SQLEXPRESS; Initial Catalog=Hadith;Integrated Security=True;MultipleActiveResultSets=True;"));
            return services;
        }
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //services.AddScoped<IRepository<Hadith>>(x => new HadithRepository());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<IRepository<Hadith>,HadithRepository>();
            services.AddScoped<IRepository<Hadith>,Repository<Hadith>>();
            
            return services;
        }
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(_ =>
                {
                    _.Password.RequiredLength = 5; //En az kaç karakterli olması gerektiğini belirtiyoruz.
                _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluğunu kaldırıyoruz.
                _.Password.RequireLowercase = false; //Küçük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireUppercase = false; //Büyük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireDigit = false; //0-9 arası sayısal karakter zorunluluğunu kaldırıyoruz.

                _.User.RequireUniqueEmail = true; //Email adreslerini tekilleştiriyoruz.
                _.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.
            }).AddPasswordValidator<CustomPasswordValidation>()
                  .AddUserValidator<CustomUserValidation>()
                  .AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<EFHadithContext>()
                  .AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection AddCookieService(this IServiceCollection services)
        {
            //services.ConfigureApplicationCookie(_ =>
            //{
            //    _.LoginPath = new PathString("/User/Login");
            //    _.LogoutPath = new PathString("/User/Logout");
            //    _.Cookie = new CookieBuilder
            //    {
            //        Name = "AspNetCoreIdentityExampleCookie", //Oluşturulacak Cookie'yi isimlendiriyoruz.
            //        HttpOnly = false, //Kötü niyetli insanların client-side tarafından Cookie'ye erişmesini engelliyoruz.
            //        Expiration = TimeSpan.FromMinutes(2), //Oluşturulacak Cookie'nin vadesini belirliyoruz.
            //        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
            //        SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden erişilebilir yapıyoruz.
            //    };
            //    _.SlidingExpiration = true; //Expiration süresinin yarısı kadar süre zarfında istekte bulunulursa eğer geri kalan yarısını tekrar sıfırlayarak ilk ayarlanan süreyi tazeleyecektir.
            //    _.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tanımlanan Expiration değerinin varsayılan değerlerle ezilme ihtimaline karşın tekrardan Cookie vadesi burada da belirtiliyor.
            //    _.AccessDeniedPath = new PathString("/authority/page");
            //});

            return services;
        }

    }
}
