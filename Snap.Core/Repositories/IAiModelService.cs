using Snap.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Repositories
{
    public interface IAiModelService
    {
        public Task<PredictionResultDto> SendCsvAndGetResponseAsync(IEnumerable<WeightCalorieRecordDto> records);




        public Task<PredictionResultDto> GetPredictedWeight();


    }
}
