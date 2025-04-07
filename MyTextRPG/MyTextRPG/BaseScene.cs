using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public abstract class BaseScene
    {
        protected ConsoleKey input;
        public abstract void Render();

        public void Input()
        {
            input = Console.ReadKey().Key;
        }

        public abstract void Result();
    }
}
