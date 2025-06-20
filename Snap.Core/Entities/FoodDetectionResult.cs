using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Entities
{
    public class FoodDetectionResult
    {

        public int Id { get; set; }
        public List<string> DetectedObjects { get; set; }
        public List<string> FreshnessStatus { get; set; }

    }
}
