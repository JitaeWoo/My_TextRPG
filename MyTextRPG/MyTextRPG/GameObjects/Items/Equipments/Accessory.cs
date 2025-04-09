using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Items.Equipments
{
    class Accessory : Equipment
    {
        private int _hp;
        public int Hp => _hp;

        public Accessory(string name, string description, int hp)
            : this(new Vector2(1, 1), name, description, hp)
        {
        }

        public Accessory(Vector2 position, string name, string description, int hp) 
            : base(position, Types.Accessory)
        {
            Name = name;
            Description = description;
            _hp = hp;
        }
    }
}
