using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Items
{
    public class Armor : Equipment
    {
        private int _defense;
        public int Defense => _defense;

        public Armor(string name, string description, int defense)
            : this(new Vector2(1, 1), name, description, defense)
        {
        }

        public Armor(Vector2 position, string name, string description, int defense) 
            : base(position, Types.Armor)
        {
            Name = name;
            Description = description;
            _defense = defense;
        }
    }
}
