using System;

namespace CybersecurityChatbot
{
    public static class ConsoleFormatter
    {
        public static void WriteSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteQuestion(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void WriteBulletPoint(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  • ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public static void WriteBorder()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
        }

        public static void DisplayGoodbye()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("  Thank you for using the Cybersecurity Awareness Bot!");
            Console.WriteLine("  Remember: Stay vigilant, stay safe online! 🔒");
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();
        }
    }
}