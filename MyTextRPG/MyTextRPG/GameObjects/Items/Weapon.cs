using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Items
{
    public class Weapon : Equipment
    {
        private int _attack;
        public int Attack => _attack;

        public Weapon(string name, string description, int attack) 
            : base(new Vector2(1, 1), Types.Weapon)
        {
            Name = name;
            Description = description;
            _attack = attack;
        }
        public Weapon(Vector2 position, string name, string description, int attack) 
            : base(position, Types.Weapon)
        {
            Name = name;
            Description = description;
            _attack = attack;
        }

        public override void Use()
        {
            // 플레이어 무기 슬롯에 장착
        }
    }
}
