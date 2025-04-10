using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public abstract class GameObject : IInteractable
    {
        private ConsoleColor _color;
        private char _symbol;
        protected char Symbol { set { _symbol = value } }
        private Vector2 _position;
        public Vector2 Position => _position;
        private bool _isOnce;
        public bool IsOnce => _isOnce;

        public GameObject(ConsoleColor color, char symbol, Vector2 position, bool isOnce = false)
        {
            _color = color;
            _symbol = symbol;
            _position = position;
            _isOnce = isOnce;
        }

        public void Print()
        {
            Console.SetCursorPosition(_position.x, _position.y);
            Console.ForegroundColor = _color;
            Console.Write(_symbol);
            Console.ResetColor();
        }

        public abstract void Interact();
    }
}
