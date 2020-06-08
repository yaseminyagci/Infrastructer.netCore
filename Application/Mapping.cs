using AutoMapper;
using Domain.Entity;
using Domain.VmModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Hadith, HadithVM>();
            CreateMap<HadithVM, Hadith>();
        }
    }
}
