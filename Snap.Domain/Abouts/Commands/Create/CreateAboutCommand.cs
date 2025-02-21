using MediatR;
using Snap.Core.Common;
using Snap.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Domain.Abouts.Commands.Create
{
    public class CreateAboutCommand : IRequest<Response<string>>
    {

        public string UserId { get; set; }
        public ChronicDisease ChronicDisease { get; set; }
        public FitnessGoal FitnessGoal { get; set; }
        public MealFrequency MealFrequency { get; set; }
        public PreferrelFoodType PreferrelFoodType { get; set; }


        public int Age { get; set; }




    }
}
