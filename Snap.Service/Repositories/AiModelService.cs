using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Snap.Core.DTOs;
using Snap.Core.Repositories;
using Snap.Service.Maps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class AiModelService : IAiModelService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public AiModelService(
            IHttpClientFactory httpClientFactory,
            IConfiguration config)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task<PredictionResultDto> GetPredictedWeight()
        {
            var result = new PredictionResultDto
            {
                PredictedWeight = new List<double>
        {
            107.61966705322266,
            107.42593383789062,
            107.20130920410156,
            106.94723510742188,
            106.82571411132812,
            106.70574951171875,
            106.56610870361328
        }
            };

            return await Task.FromResult(result);
        }

        public async Task<PredictionResultDto> SendCsvAndGetResponseAsync(
            IEnumerable<WeightCalorieRecordDto> records)
        {
            // 1) Build CSV in-memory with correct headers
            await using var mem = new MemoryStream();
            using (var writer = new StreamWriter(mem, Encoding.UTF8, leaveOpen: true))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            }))
            {
                // Register custom map to match "Calories intake" header
                csv.Context.RegisterClassMap<WeightCalorieRecordMap>();
                await csv.WriteRecordsAsync(records); // Handles both header + records
            }
            mem.Seek(0, SeekOrigin.Begin);


            // 2) POST multipart/form-data
            var client = _httpClientFactory.CreateClient();
            var baseUrl = _config["AiModel:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
                throw new InvalidOperationException("AI model base URL is not configured.");

            client.BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/");

            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(mem);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
            content.Add(fileContent, "file", "data.csv");

            // 3) Call the Python API (no trailing slash)
            var response = await client.PostAsync("predict/", content); // Note the slash at the end
            response.EnsureSuccessStatusCode();

            // 4) Deserialize into our DTO
            var result = await response.Content.ReadFromJsonAsync<PredictionResultDto>();
            if (result == null)
                throw new InvalidOperationException("Failed to parse prediction response.");

            return result;
        }
    }
}
