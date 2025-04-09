using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    class Extension
    {
    }

    public static class Util
    {
        public static void PressAnyKey() => PressAnyKey("아무키나 눌러서 계속...");

        public static void PressAnyKey(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.ReadKey(true);
        }
    }
}
