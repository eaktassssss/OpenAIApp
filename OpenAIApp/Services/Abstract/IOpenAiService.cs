namespace OpenAIApp.Services.Abstract
{
    public interface IOpenAiService
    {
        Task<string> CheckProgramingLanguage(string language);
        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvance(string text);

    }
}
