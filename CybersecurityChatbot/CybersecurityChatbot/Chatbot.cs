using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private string userName;
        private bool isRunning;
        private AudioPlayer audioPlayer;
        private CybersecurityResponses responses;

        public Chatbot()
        {
            audioPlayer = new AudioPlayer();
            responses = new CybersecurityResponses();
            isRunning = true;
        }

        public void Start()
        {
            try
            {
                // Play voice greeting
                ConsoleFormatter.WriteInfo("Starting Cybersecurity Bot...");
                audioPlayer.PlayGreeting();

                // Display ASCII art
                AsciiArt.DisplayLogo();

                // Display welcome
                DisplayWelcome();

                // Get user name
                GetUserName();

                // Main chat loop
                RunChat();
            }
            catch (Exception ex)
            {
                ConsoleFormatter.WriteError($"Error: {ex.Message}");
            }
            finally
            {
                ConsoleFormatter.DisplayGoodbye();
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }

        private void DisplayWelcome()
        {
            ConsoleFormatter.WriteSuccess("\n╔════════════════════════════════════════╗");
            ConsoleFormatter.WriteSuccess("║  CYBERSECURITY AWARENESS CHATBOT      ║");
            ConsoleFormatter.WriteSuccess("╚════════════════════════════════════════╝");
            ConsoleFormatter.WriteInfo("\nI can help you with:");
            ConsoleFormatter.WriteBulletPoint("Password safety");
            ConsoleFormatter.WriteBulletPoint("Phishing scams");
            ConsoleFormatter.WriteBulletPoint("Safe browsing");
            ConsoleFormatter.WriteBulletPoint("Cybersecurity tips");
        }

        private void GetUserName()
        {
            ConsoleFormatter.WriteQuestion("\nWhat's your name?");
            Console.Write("> ");

            string input = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(input))
            {
                ConsoleFormatter.WriteError("Please enter your name:");
                Console.Write("> ");
                input = Console.ReadLine();
            }

            userName = input.Trim();
            ConsoleFormatter.WriteSuccess($"\nNice to meet you, {userName}! 😊");
            Thread.Sleep(1000);
        }

        private void RunChat()
        {
            ConsoleFormatter.WriteInfo("\n" + new string('─', 50));
            ConsoleFormatter.WriteSuccess($"How can I help you stay safe online, {userName}?");
            ConsoleFormatter.WriteInfo("Type 'help' for options or 'exit' to quit");
            ConsoleFormatter.WriteInfo(new string('─', 50) + "\n");

            while (isRunning)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    ConsoleFormatter.WriteError("I didn't understand. Please say that again.");
                    continue;
                }

                string response = ProcessInput(userInput);
                TypeText(response);
                Console.WriteLine();
                ConsoleFormatter.WriteInfo(new string('─', 50));
            }
        }

        private string ProcessInput(string input)
        {
            string lowerInput = input.ToLower().Trim();

            // Exit
            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "goodbye")
            {
                isRunning = false;
                return $"Goodbye, {userName}! Stay safe online! 👋";
            }

            // Help
            if (lowerInput == "help")
            {
                return GetHelpMessage();
            }

            // Get response from database
            string response = responses.GetResponse(lowerInput);
            if (response != null)
                return response;

            // Default
            return "I didn't understand that. Try asking about passwords, phishing, or safe browsing!";
        }

        private string GetHelpMessage()
        {
            return $"Here's what I can help with, {userName}:\n\n" +
                   "📚 TOPICS:\n" +
                   "  • Password safety\n" +
                   "  • Phishing scams\n" +
                   "  • Safe browsing\n" +
                   "  • Cybersecurity tips\n\n" +
                   "💬 GENERAL:\n" +
                   "  • How are you?\n" +
                   "  • What's your purpose?\n" +
                   "  • What can I ask you about?\n\n" +
                   "🔧 COMMANDS:\n" +
                   "  • help - Show this menu\n" +
                   "  • exit - End chat\n\n" +
                   "What would you like to learn about?";
        }

        private void TypeText(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n🤖 Bot: ");
            Console.ResetColor();

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20); // Typing effect
            }
            Console.WriteLine();
        }
    }
}