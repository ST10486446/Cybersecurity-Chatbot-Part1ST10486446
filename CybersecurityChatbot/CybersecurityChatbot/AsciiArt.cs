using System;

namespace CybersecurityChatbot
{
    public static class AsciiArt
    {
        public static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string logo = @"
    ╔══════════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗             ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗            ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝            ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗            ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║            ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝            ║
    ║                                                          ║
    ║              C Y B E R S E C U R I T Y                   ║
    ║                 A W A R E N E S S                        ║
    ║                    B O T                                 ║
    ╚══════════════════════════════════════════════════════════╝
            ";

            Console.WriteLine(logo);
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }
    }
}