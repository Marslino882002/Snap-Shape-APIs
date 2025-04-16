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
    public class CreateAboutCommandHandler(IAboutRepository aboutRepo , IMapper mapper) : ResponseHandler, IRequestHandler<CreateAboutCommand, int>
    {
    
public async Task<int> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = new Entities.About
            {
                Age = request.Age,
                Tall = request.Tall,
                CurrentWeight = request.CurrentWeight,
                GoalWeight = request.GoalWeight,
                //Gender = Enum.Parse<Gender>(request.Gender, true),
                //PreferrelFood = Enum.Parse<PreferrelFoodType>(request.PreferrelFood, true),
                //DailyMeals = Enum.Parse<MealFrequency>(request.DailyMeals, true),
                //ChronicDiseases = Enum.Parse<ChronicDisease>(request.ChronicDiseases, true),
                //Goal = Enum.Parse<FitnessGoal>(request.Goal, true),
                //UserId = request.UserId
            };
        var newAboutid = await aboutRepo.AddAsync(about);
            return newAboutid;

        }
    }
}
