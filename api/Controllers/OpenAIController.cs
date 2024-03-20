using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly string apiKey = "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";
        private readonly HttpClient httpClient;

        public OpenAIController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        [HttpPost("chat/completions")]
        public async Task<IActionResult> GetChatCompletions([FromBody] ChatRequestModel request)
        {
            try
            {
                var requestBody = new
                {
                    model = "text-davinci-002",
                    prompt = request.Prompt,
                    max_tokens = request.MaxTokens,
                    temperature = request.Temperature,
                    stop = request.Stop
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.openai.com/v1/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return Ok(responseData);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "OpenAI API request failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
    public class ChatRequestModel
    {
        public string Prompt { get; set; }
        public int MaxTokens { get; set; }
        public double Temperature { get; set; }
        public string[] Stop { get; set; }
    }
}
