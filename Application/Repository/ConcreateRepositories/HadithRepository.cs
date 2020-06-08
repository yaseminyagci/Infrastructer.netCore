using Data.Context;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository.ConcreateRepositories
{
    public class HadithRepository : Repository<Hadith>
    {
        private readonly EFHadithContext _context;
        public HadithRepository(EFHadithContext context) :base(context)
        {
            _context = context;
        }
    }
}
