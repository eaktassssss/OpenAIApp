using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAIApp.Configurations;
using OpenAIApp.Services.Abstract;
using System.Reflection;

namespace OpenAIApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private readonly IOpenAiService _openAiService;
        public OpenAiController(IOpenAiService openAiService)
        {
            _openAiService = openAiService;
        }
        [HttpPost]
        [Route("complete_sentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var response = await _openAiService.CompleteSentence(text);
            return Ok(response);
        }
        [HttpPost]
        [Route("complete_sentence_advance")]
        public async Task<IActionResult> CompleteSentenceAdvance(string text)
        {
            var response = await _openAiService.CompleteSentenceAdvance(text);
            return Ok(response);
        }
        [HttpPost]
        [Route("programing_language_check")]
        public async Task<IActionResult> ProgramingLanguageCheck(string language)
        {
            var response = await _openAiService.CheckProgramingLanguage(language);
            return Ok(response);
        }
    }
}
