using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder();

// Connect directly to Groq (Uses standard OpenAI protocol, free & fast)
builder.AddOpenAIChatCompletion(
    modelId: "llama-3.3-70b-versatile",               // Extremely fast & high quality
    apiKey: "YOUR_GROQ_API_KEY_HERE",              // Replace with your gsk_ key
    endpoint: new Uri("https://api.groq.com/openai/v1")
);

Kernel kernel = builder.Build();

var chatService = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();

Console.WriteLine("Connected to Groq! Type your message below:\n");

while (true)
{
    Console.Write("User >> ");
    var userMessage = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userMessage)) break;

    history.AddUserMessage(userMessage);

    var response = chatService.GetStreamingChatMessageContentsAsync(history, kernel: kernel);

    Console.Write("AI >> ");

    string fullResponse = "";
    await foreach (var chat in response)
    {
        Console.Write(chat.Content);
        fullResponse += chat.Content;
    }

    history.AddAssistantMessage(fullResponse);
    Console.WriteLine("\n");
}