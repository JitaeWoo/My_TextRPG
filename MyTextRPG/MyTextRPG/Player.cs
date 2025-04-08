using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTextRPG.Scenes;

namespace MyTextRPG
{
    public class Player
    {
        private Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        public void Print()
        {
            Console.SetCursorPosition(_position.x, _position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }

        public void Move(ConsoleKey input)
        {
            Vector2 targetPosition = _position;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    targetPosition.y--;
                    break;
                case ConsoleKey.DownArrow:
                    targetPosition.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    targetPosition.x--;
                    break;
                case ConsoleKey.RightArrow:
                    targetPosition.x++;
                    break;
            }

            if ((Game.CurScene as FieldScene).IsWall[targetPosition.y, targetPosition.x] == false)
            {
                _position = targetPosition;
            }
        }
    }
}
