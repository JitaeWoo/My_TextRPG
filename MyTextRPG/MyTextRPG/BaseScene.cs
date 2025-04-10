using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public abstract class BaseScene
    {
        protected ConsoleKey InputKey;
        public string Name { get; protected set; }
        public abstract void Render();

        public virtual void Input()
        {
            InputKey = Console.ReadKey(true).Key;
        }

        public abstract void Result();

        public virtual void Enter() { }

        public virtual void End() { }
    }
}
