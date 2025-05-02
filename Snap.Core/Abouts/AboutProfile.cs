using AutoMapper;
using Snap.Core.About.Commands.Create;
using Snap.Core.Constants;
using Snap.Core.DTOs;
using Snap.Core.Entities;
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
            // Map incoming DTO to CreateAboutCommand
            CreateMap<Entities.About, CreateAboutCommand>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => (Global.Gender)src.Gender))
                .ForMember(dest => dest.PreferrelFood, opt => opt.MapFrom(src => (Global.PreferrelFoodType)src.PreferrelFood))
                .ForMember(dest => dest.DailyMeals, opt => opt.MapFrom(src => (Global.MealFrequency)src.DailyMeals))
                .ForMember(dest => dest.ChronicDiseases, opt => opt.MapFrom(src => (Global.ChronicDisease)src.ChronicDiseases))
                .ForMember(dest => dest.Goal, opt => opt.MapFrom(src => (Global.FitnessGoal)src.Goal));

            // Map CreateAboutCommand to About entity
            CreateMap<CreateAboutCommand, Entities.About>();

            // Map About entity to AboutDto for returning to client
            CreateMap<Entities.About, AboutDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.PreferrelFood, opt => opt.MapFrom(src => src.PreferrelFood.ToString()))
                .ForMember(dest => dest.DailyMeals, opt => opt.MapFrom(src => src.DailyMeals.ToString()))
                .ForMember(dest => dest.ChronicDiseases, opt => opt.MapFrom(src => src.ChronicDiseases.ToString()))
                .ForMember(dest => dest.Goal, opt => opt.MapFrom(src => src.Goal.ToString()));

            // Map GetAboutQuery to AboutDto via About entity
            CreateMap<Entities.About, AboutDto>();
        }
    }


}
