using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    public class Portal : GameObject
    {
        private string _nextScene;

        public Portal(string nextScene, Vector2 position) 
            : base(ConsoleColor.Blue, 'O', position, false)
        {
            _nextScene = nextScene;
        }

        public override void Interact()
        {
            Game.ChangeScene(_nextScene);
        }
    }
}
