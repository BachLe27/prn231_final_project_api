using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        
        [HttpGet("generate/answer")]
        public async Task<IActionResult> GetAnswer(string question)
        {
            string apiKey = "";
            var openai = new OpenAIAPI(apiKey);
            var chat = openai.Chat.CreateConversation();
            chat.RequestParameters.Temperature = 0;
            var result = await openai.Chat.CreateChatCompletionAsync(new OpenAI_API.Chat.ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 50,
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, question)
                }
            });
            var reply = result.Choices[0].Message;
            return Ok(reply);
        }
    }
}
