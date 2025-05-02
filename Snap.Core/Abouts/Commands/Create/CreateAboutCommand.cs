using MediatR;
using Snap.Core.Common;
using Snap.Core.Constants;
using Snap.Core.DTOs;
using Snap.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.About.Commands.Create
{
    public class CreateAboutCommand : IRequest<int>
    {
        public int Age { get; set; }
        public int Tall { get; set; }
        public float CurrentWeight { get; set; }
        public float GoalWeight { get; set; }

        public Global.Gender Gender { get; set; }
        public Global.PreferrelFoodType PreferrelFood { get; set; }
        public Global.MealFrequency DailyMeals { get; set; }
        public Global.ChronicDisease ChronicDiseases { get; set; }
        public Global.FitnessGoal Goal { get; set; }




    }
}
