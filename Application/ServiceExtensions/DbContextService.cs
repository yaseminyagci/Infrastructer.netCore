using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceExtensions
{
    static class DbContextService
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();

            services.AddDbContext<EFHadithContext>(x => x.UseSqlServer("Server=DESKTOP-2MILLH9\\SQLEXPRESS; Initial Catalog=Hadith;Integrated Security=True;MultipleActiveResultSets=True;"));
            return services;
        }
    }
}
