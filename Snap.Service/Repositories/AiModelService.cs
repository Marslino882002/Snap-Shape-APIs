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
