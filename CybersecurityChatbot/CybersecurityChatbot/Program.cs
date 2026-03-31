using System;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot";
            Console.SetWindowSize(100, 40);

            Chatbot chatbot = new Chatbot();
            chatbot.Start();
        }
    }
}