using Snap.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Entities
{
    public class About
    { public int Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Tall { get; set; }
        public float CurrentWeight { get; set; }
        public float GoalWeight { get; set; }
        public PreferrelFoodType PreferrelFood { get; set; }
        public MealFrequency DailyMeals { get; set; }
        public ChronicDisease ChronicDiseases { get; set; }
        public FitnessGoal Goal { get; set; }

        // Foreign key to User
        public string UserId { get; set; }

        // Navigation property back to User
        public User User { get; set; }






    }
}
