using CsvHelper.Configuration;
using Snap.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Maps
{
    public class WeightCalorieRecordMap : ClassMap<WeightCalorieRecordDto>
    {
        public WeightCalorieRecordMap()
        {
            Map(m => m.Weight).Name("Weight");
            Map(m => m.CaloriesIntake).Name("Calories intake"); // note the space
        }
    }
}
