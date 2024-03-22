using api.DTOs;
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
        
        [HttpPost("generate/answer")]
        public async Task<IActionResult> GetAnswer(GPTRequestDTO question)
        {
            string apiKey = "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";
            var openai = new OpenAIAPI(apiKey);
            var chat = openai.Chat.CreateConversation();
            chat.RequestParameters.Temperature = 0;
            var result = await openai.Chat.CreateChatCompletionAsync(new OpenAI_API.Chat.ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 200,
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, question.ToString())
                }
            });
            var reply = result.Choices[0].Message;
            return Ok(reply);
        }
    }
}
