using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Context
{
    public class DesignDBContext : IDesignTimeDbContextFactory<EFHadithContext>
    {
        public EFHadithContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<EFHadithContext> builder = new DbContextOptionsBuilder<EFHadithContext>();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"))
                .AddJsonFile("appsettings.json")
                .Build();
            builder.UseSqlServer(config.GetConnectionString("EFHadithContext"));
            return new EFHadithContext(builder.Options);
        }
    }
}
