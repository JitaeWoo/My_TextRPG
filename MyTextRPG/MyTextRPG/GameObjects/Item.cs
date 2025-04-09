using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    public abstract class Item : GameObject
    {
        public enum Types
        {
            Consumable, Armor, Weapon, Accessory
        }

        private Types _type;
        public Types Type => _type;
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        public Item(Vector2 position, Types type) 
            : base(ConsoleColor.Yellow, 'I', position, true)
        {
            _type = type;
        }

        public override void Interact()
        {
            Game.Player.Inven.Add(this);
        }

        public abstract void Use();
    }
}
