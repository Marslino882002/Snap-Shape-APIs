using AutoMapper;
using MediatR;
using Snap.Core.About.Commands.Create;
using Snap.Core.Common;
using Snap.Core.Entities.Enums;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Abouts.Commands.Create
{
    public class CreateAboutCommandHandler(IAboutRepository aboutRepo , IMapper mapper) : ResponseHandler, IRequestHandler<CreateAboutCommand, Response<string>>
    {
    
public async Task<Response<string>> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = new Entities.About
            {
                Age = request.About.Age,
                Tall = request.About.Tall,
                CurrentWeight = request.About.CurrentWeight,
                GoalWeight = request.About.GoalWeight,
                Gender = Enum.Parse<Gender>(request.About.Gender, true),
                PreferrelFood = Enum.Parse<PreferrelFoodType>(request.About.PreferrelFood, true),
                DailyMeals = Enum.Parse<MealFrequency>(request.About.DailyMeals, true),
                ChronicDiseases = Enum.Parse<ChronicDisease>(request.About.ChronicDiseases, true),
                Goal = Enum.Parse<FitnessGoal>(request.About.Goal, true),
                UserId = request.About.UserId
            };
            await aboutRepo.CreateAsync(about);
            return Success<string>("About details saved successfully.");

        }
    }
}
