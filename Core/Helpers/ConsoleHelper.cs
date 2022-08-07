using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteTextWithColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
