//using Microsoft.AspNetCore.Http;
//using Snap.Core.DTOs;
//using Snap.Core.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace Snap.Service.Repositories
//{
//    public class FoodDetectionService : IFoodDetectionService
//    {
//        private readonly HttpClient _httpClient;

//        public FoodDetectionService(HttpClient httpClient)
//        {
//            _httpClient = httpClient;
//        }
//        public async Task<FoodDetectionResultDto> DetectAsync(IFormFile imageFile)
//        {
//            // 1) Prepare the file content
//            await using var stream = imageFile.OpenReadStream();
//            var fileContent = new StreamContent(stream);
//            fileContent.Headers.ContentType = new MediaTypeHeaderValue(imageFile.ContentType);

//            // 2) Build multipart/form-data bodynd
//            var formData = new MultipartFormDataContent
//    {
//        { fileContent, "file", imageFile.FileName }
//    };

//            // 3) Send POST to the correct /detect/ endpoint
//            var response = await _httpClient.PostAsync(
//                "https://patricknassef1-food-detect-freshness-api.hf.space/detect/",
//                formData
//            );

//            // 4) Throw if not success
//            response.EnsureSuccessStatusCode();

//            // 5) Deserialize JSON into DTO
//            var json = await response.Content.ReadAsStringAsync();
//            return JsonSerializer.Deserialize<FoodDetectionResultDto>(json, new JsonSerializerOptions
//            {
//                PropertyNameCaseInsensitive = true
//            })!;
//        }


//    }
//}
