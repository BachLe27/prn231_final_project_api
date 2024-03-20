using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Moderation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        /*[HttpPost]
        public async Task<IActionResult> MarkStudentSubmission(string searchText)
        {
            var httpClient = httpClientFactory.CreateClient("ChtpGPT");

            ChatCompletionRequest completionRequest = new()
            {
                Model = "gpt-3.5-turbo",
                MaxTokens = 1000,
                Messages = [
                                new Message()
                                {
                                    Role = "user",
                                    Content = question,

                                }
                            ]
            };


            using var httpReq = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
            httpReq.Headers.Add("Authorization", $"Bearer {configuration["OpenAIKey"]}");

            string requestString = JsonSerializer.Serialize(completionRequest);
            httpReq.Content = new StringContent(requestString, Encoding.UTF8, "application/json");

            using HttpResponseMessage? httpResponse = await httpClient.SendAsync(httpReq);
            httpResponse.EnsureSuccessStatusCode();

            var completionResponse = httpResponse.IsSuccessStatusCode ? JsonSerializer.Deserialize<ChatCompletionResponse>(await httpResponse.Content.ReadAsStringAsync()) : null;

            return completionResponse.Choices?[0]?.Message?.Content;


        }*/
        /*[HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> MarkStudentSubmission(string searchText)
        {

            var openAIApiClient = new MarkController("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");
            var response = await openAIApiClient.SendPrompt(searchText, "davinci");
            return Ok(response);
        }

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public MarkController(string apiKey)

        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<string> SendPrompt(string prompt, string model)
        {
            var requestBody = new
            {
                prompt = prompt,
                model = model,
                max_tokens = 150,
                temperature = 0.5
            };

            var response = await _httpClient.PostAsJsonAsync("completions", requestBody);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }*/
    
    

}
}
