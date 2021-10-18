using AutoMapper;
using CustomerApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApi.BusinessLogic.Profiles
{
    public class CompanyProfile: Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, Dtos.CompanyDto>().ReverseMap();
        }
    }
}
