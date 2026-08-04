using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var builder = Kernel.CreateBuilder();

// Connect to local Ollama server running llama3.2
builder.AddOpenAIChatCompletion(
    modelId: "llama3.2",                           // Model name pulled in Ollama
    apiKey: "ollama",                              // Dummy key required by OpenAI client initialization
    endpoint: new Uri("http://localhost:11434/v1") // Local Ollama server address
);

Kernel kernel = builder.Build();

var chatService = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();

Console.WriteLine("Connected to Local Ollama (llama3.2)! Type your message below:\n");

while (true)
{
    Console.ResetColor();
    Console.Write("User >> ");
    var userMessage = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userMessage)) break;

    history.AddUserMessage(userMessage);

    Console.Write("AI >> ");

    try
    {
        var response = chatService.GetStreamingChatMessageContentsAsync(history, kernel: kernel);
        string fullResponse = "";

        Console.ForegroundColor = ConsoleColor.Green;

        await foreach (var chat in response)
        {
            Console.Write(chat.Content);
            fullResponse += chat.Content;
        }

        history.AddAssistantMessage(fullResponse);
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[Error]: Could not reach local Ollama instance. Is Ollama running? Details: {ex.Message}");
    }
    finally
    {
        Console.ResetColor() ;
    }

    Console.WriteLine("\n");
}