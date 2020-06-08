using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFHadithContext _context;
        public UnitOfWork(EFHadithContext context)
        {
            this._context = context;
        }
        public Task complateSaveAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
