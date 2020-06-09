using Core.CustomException;
using Data.Authentication;
using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;


namespace Data.Context
{
    public class EFHadithContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EFHadithContext(DbContextOptions<EFHadithContext> options)
          : base(options)
        {
        }
        public DbSet<Hadith> Hadiths { get; set; }

        //public override int SaveChanges()
        //{
        //    var result = 0;
        //    try
        //    {
        //        result = base.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        // özelleştir
        //        throw new DatabaseException("DataBaseExcetion", ex);
        //    }
        //    return result;
        //}



      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}