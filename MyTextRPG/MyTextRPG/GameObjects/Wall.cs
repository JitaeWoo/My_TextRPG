using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    class Wall : GameObject
    {
        private Directions _directoin;
        public Wall(Vector2 position, Directions direction) 
            : base(ConsoleColor.Gray, 'W', position, false)
        {
            _directoin = direction;
        }

        public override void Interact()
        {
            switch (_directoin)
            {
                case Directions.Up:
                    Game.Player.Position = new Vector2(Game.Player.Position.x, Game.Player.Position.y - 1);
                    break;
                case Directions.Down:
                    Game.Player.Position = new Vector2(Game.Player.Position.x, Game.Player.Position.y + 1);
                    break;
                case Directions.Left:
                    Game.Player.Position = new Vector2(Game.Player.Position.x - 1, Game.Player.Position.y);
                    break;
                case Directions.Right:
                    Game.Player.Position = new Vector2(Game.Player.Position.x + 1, Game.Player.Position.y);
                    break;
            }
        }
    }
}
