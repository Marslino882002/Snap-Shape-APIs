using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap.Core.DTOs
{
    public class FoodDetectionResultDto
    {


        [JsonPropertyName("detected_objects")]
        public List<string>? DetectedObjects { get; set; }

        [JsonPropertyName("freshness_status")]
        public List<string>? FreshnessStatus { get; set; }



    }
}
