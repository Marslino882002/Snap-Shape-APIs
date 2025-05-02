using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap.Core.DTOs
{
    public class PredictionResultDto
    {
        [JsonPropertyName("predicted_weight")]
        public List<double> PredictedWeight { get; set; }
    }
}
