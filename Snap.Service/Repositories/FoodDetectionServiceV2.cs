using Microsoft.AspNetCore.Http;
using Snap.Core.DTOs;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class FoodDetectionServiceV2 : IFoodDetectionServiceV2
    {

        private readonly HttpClient _httpClient;

        public FoodDetectionServiceV2(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }





        public async Task<FoodDetectionResultV2Dto> DetectAsync(IFormFile imageFile)
        {

            using var stream = imageFile.OpenReadStream();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(imageFile.ContentType);

            var form = new MultipartFormDataContent();
            form.Add(fileContent, "file", imageFile.FileName);

            var response = await _httpClient.PostAsync("https://patricknassef1-food-det-freshness-weight.hf.space/detect/", form);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<FoodDetectionResultV2Dto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;







        }
    }
}
