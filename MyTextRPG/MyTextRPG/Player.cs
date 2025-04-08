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

        private Inventory _inventory = new Inventory();
        public Inventory Inven => _inventory;

        private int _curHp;
        public int CurHp => _curHp;
        private int _maxHp;
        public int MaxHp => _maxHp;

        public void Print()
        {
            Console.SetCursorPosition(_position.x, _position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }

        public void Heal(int amount)
        {
            if(amount > 0)
            {
                _curHp = Math.Min(_curHp + amount, _maxHp);
            }
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
