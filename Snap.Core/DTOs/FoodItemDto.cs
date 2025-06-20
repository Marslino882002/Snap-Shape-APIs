using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap.Core.DTOs
{
    public class FoodItemDto
    {

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("freshness")]
        public string Freshness { get; set; }

        [JsonPropertyName("weight_grams")]
        public double WeightGrams { get; set; }

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

    }
}
