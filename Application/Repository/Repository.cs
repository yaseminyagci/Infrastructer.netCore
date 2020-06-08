using Application.ServiceExtensions;
using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Application.Repository
{
    public class Repository<Type> : IRepository<Type> where Type : class
    {
        //protected EFHadithContext _context;
        private readonly EFHadithContext _context;
        public Repository(EFHadithContext context)
        {
            //IServiceCollection services = new ServiceCollection();
            // services.AddDbContextService();
            //ServiceProvider provider = services.BuildServiceProvider();

            //_context = provider.GetService<EFHadithContext>();

            _context = context;        
        }
        [NonAction]
        public DbSet<Type> Table()
        {
            return Table<Type>();
        }
        [NonAction]
        public DbSet<A> Table<A>() where A : class
        {
            return _context.Set<A>();
        }
        [NonAction]
        public Type Add(Type model)
        {
            Add<Type>(model);
            return model;
        }
        [NonAction]
        public bool Add<A>(A model) where A : class
        {
            Table<A>().Add(model);
            Save();
            return true;
        }
        [NonAction]
        public List<Type> Get()
        {
            return Get<Type>();
        }
        [NonAction]
        public List<A> Get<A>() where A : class
        {
            return Table<A>().ToList();
        }
        [NonAction]
        public Type GetById(int id)
        {
            return GetById<Type>(id);
        }
        [NonAction]
        public A GetById<A>(int id) where A : class
        {
            return GetSingle<A>(t => typeof(A).GetProperty("Id").GetValue(t).ToString() == id.ToString());
        }
        [NonAction]
        public bool Remove(Type model)
        {
            return Remove<Type>(model);
        }
        [NonAction]
        public bool Remove<A>(A model) where A : class
        {
            Table<A>().Remove(model);
            return true;
        }
        [NonAction]
        public bool Remove(int id)
        {
            return Remove<Type>(id);
        }
        [NonAction]
        public bool Remove<A>(int id) where A : class
        {
            A silinecekData = GetSingle<A>(x => (int)typeof(A).GetProperty("Id").GetValue(x) == id);
            Remove<A>(silinecekData);
            Save();
            return true;
        }
        [NonAction]
        public int Save()
        {
            return _context.SaveChanges();
        }
        [NonAction]
        public bool Update(Type model, int id)
        {
            return Update<Type>(model, id);
        }
        [NonAction]
        public bool Update<A>(A model, int id) where A : class
        {
            A guncellenecekNesne = GetById<A>(id);
            var tumPropertyler = typeof(A).GetProperties();
            foreach (var property in tumPropertyler)
                if (property.Name != "Id")
                    property.SetValue(guncellenecekNesne, property.GetValue(model));
            Save();
            return true;
        }
        [NonAction]
        public List<Type> GetWhere(Expression<Func<Type, bool>> metot)
        {
            return GetWhere<Type>(metot);
        }
        [NonAction]
        public List<A> GetWhere<A>(Expression<Func<A, bool>> metot) where A : class
        {
            return Table<A>().Where(metot).ToList();
        }
        [NonAction]
        public Type GetSingle(Func<Type, bool> metot)
        {
            return GetSingle<Type>(metot);
        }
        [NonAction]
        public A GetSingle<A>(Func<A, bool> metot) where A : class
        {
            return Table<A>().FirstOrDefault(metot);
        }
    }
}
