using AutoMapper;
using Snap.APIs.DTOs;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Domain.Abouts
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
        }
    }
}
