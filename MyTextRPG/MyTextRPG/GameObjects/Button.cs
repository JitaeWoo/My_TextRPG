using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    public class Button : GameObject
    {
        public event Action OnClicked;
        public Button(Vector2 position) 
            : base(ConsoleColor.Magenta, 'B', position, false)
        {
        }

        public override void Interact()
        {
            OnClicked?.Invoke();
        }
    }
}
