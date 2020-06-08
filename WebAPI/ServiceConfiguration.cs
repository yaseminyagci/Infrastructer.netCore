using Application.Repository;
using Application.Repository.ConcreateRepositories;
using AutoMapper.Configuration;
using Data.Context;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
    }
}
