using Application.Repository;
using Application.Repository.ConcreateRepositories;
using Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceExtensions
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            //services.AddScoped<IRepository<Hadith>>(x => new HadithRepository());
            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
