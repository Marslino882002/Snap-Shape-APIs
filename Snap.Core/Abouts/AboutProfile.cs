using AutoMapper;
using Snap.Core.About.Commands.Create;
using Snap.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Snap.Core.Abouts
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<Entities.About, AboutDto>().ReverseMap();
            CreateMap<Entities.About, CreateAboutCommand>().ReverseMap();

        }
    }

    
}
