using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAIApp.Configurations;
using OpenAIApp.Services.Abstract;
using System.Reflection;

namespace OpenAIApp.Services.Concrete
{
    public class OpenAiService: IOpenAiService
    {
        private readonly OpenAiAppConfig _openAiAppConfig;
        public OpenAiService(IOptionsMonitor<OpenAiAppConfig> openAiAppConfig)
        {
            _openAiAppConfig = openAiAppConfig.CurrentValue;
        }

        public async Task<string> CheckProgramingLanguage(string language)
        {
            var apiConnection = new OpenAIAPI(_openAiAppConfig.Key);
            var chat = apiConnection.Chat.CreateConversation();
            chat.AppendSystemMessage("Tam nedir bilmiyorum");
            chat.AppendUserInput(language);
            var response = await chat.GetResponseFromChatbotAsync();
            return response;
        }

        public async Task<string> CompleteSentence(string text)
        {
            var apiConnection = new OpenAIAPI(_openAiAppConfig.Key);
            var result = await apiConnection.Completions.GetCompletion(text);
            return result;
        }

        public async Task<string> CompleteSentenceAdvance(string text)
        {
            var apiConnection = new OpenAIAPI(_openAiAppConfig.Key);
            var result = await apiConnection.Completions.CreateCompletionAsync(new CompletionRequest(text, model: Model.CurieText, temperature: 0.1));
            return result.Completions[0].Text;
        }
    }
}
