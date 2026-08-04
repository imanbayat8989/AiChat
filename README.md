Markdown
# 🤖 AiChat - Semantic Kernel C# Console Application

A lightweight, real-time streaming AI chat console application built with **C#**, **.NET**, and **Microsoft Semantic Kernel**. Supports both offline local models via **Ollama** and cloud acceleration via **Groq**.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)
![Microsoft Semantic Kernel](https://img.shields.io/badge/Semantic_Kernel-Latest-0078D4?style=flat)
![Ollama](https://img.shields.io/badge/Ollama-Local_LLM-000000?style=flat)
![Groq](https://img.shields.io/badge/Groq-Cloud_API-F05032?style=flat)

---

## ✨ Features

- ⚡ **Real-Time Streaming Responses:** Displays AI responses token-by-token as they generate.
- 🎨 **Colorized Console UI:** Styled console output distinguishing User inputs, AI responses (Green), and System errors (Red).
- 🔒 **Privacy-First (Offline Support):** Connects to local **Ollama** models (`llama3.2`) with zero external network dependencies or region restrictions.
- 🚀 **Groq Cloud Integration:** Easily switch to cloud-hosted models (`llama-3.3-70b-versatile`) for maximum speed.
- 💬 **Conversation Context:** Maintains multi-turn chat memory using `ChatHistory`.

---

## 🛠️ Prerequisites

- **[.NET 8.0 SDK](https://dotnet.microsoft.com/download)** (or higher)
- **[Visual Studio 2022 / 2026](https://visualstudio.microsoft.com/)** or **VS Code**
- *(For Local AI)* **[Ollama](https://ollama.com/)** installed on your machine
- *(For Cloud AI)* **[Groq API Key](https://console.groq.com/)**

---

## 🚀 Quick Start (Local Ollama)

### 1. Pull the Local Model
Ensure Ollama is running in the background, then pull the lightweight `llama3.2` model via your terminal:

```bash
ollama run llama3.2
(Once downloaded, type /bye to exit the interactive prompt).

2. Clone the Repository
Bash
git clone [https://github.com/imanbayat8989/AiChat.git](https://github.com/imanbayat8989/AiChat.git)
cd AiChat
3. Build & Run
Open the solution in Visual Studio and press F5, or run via terminal:

Bash
dotnet run
⚙️ Configuration Options
Running with Local Ollama (Default)
In Program.cs, use the local OpenAI-compatible endpoint:

C#
builder.AddOpenAIChatCompletion(
    modelId: "llama3.2",
    apiKey: "ollama",
    endpoint: new Uri("http://localhost:11434/v1")
);
Running with Groq Cloud API
To switch to high-speed cloud inference:

C#
builder.AddOpenAIChatCompletion(
    modelId: "llama-3.3-70b-versatile",
    apiKey: Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? "YOUR_GROQ_KEY",
    endpoint: new Uri("[https://api.groq.com/openai/v1](https://api.groq.com/openai/v1)")
);
