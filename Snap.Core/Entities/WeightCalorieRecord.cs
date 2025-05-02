using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Entities
{
    public class WeightCalorieRecord
    {public int Id { get; set; }               // if you want to persist it in your DB
        public double Weight { get; set; }        // in kilograms
        public double CaloriesIntake { get; set; } // in kcal

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

 }
}
