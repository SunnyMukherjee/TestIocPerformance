using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIocPerformance
{
    internal static class Logger
    {
        /// <summary>
        /// Function writes the message to the screen.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="foregroundColor">Foreground color of text</param>
        /// <param name="backgroundColor">Background color of console</param>
        public static void WriteToScreen(string message, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            WriteToScreen(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Function writes the message to the screen.
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="foregroundColor">Foreground color of text</param>
        public static void WriteToScreen(string message, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;            
            WriteToScreen(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Function writes the message to the screen.
        /// </summary>
        /// <param name="message">Message</param>
        public static void WriteToScreen(string message)
        {            
            Console.WriteLine(message);
        }
    }
}
