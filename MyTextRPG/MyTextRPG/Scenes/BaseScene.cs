using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public abstract class BaseScene
    {
        protected ConsoleKey _input;
        public abstract void Render();

        public void Input()
        {
            _input = Console.ReadKey(true).Key;
        }

        public abstract void Result();
    }
}
