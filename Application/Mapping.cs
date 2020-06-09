using AutoMapper;
using Data.Authentication;
using Domain.Entity;
using Domain.VmModel;
using Domain.VmModel.Identity;
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
            CreateMap<AppUser, UserDetailViewModel>();
            CreateMap<UserDetailViewModel,AppUser>();
        }
    }
}
