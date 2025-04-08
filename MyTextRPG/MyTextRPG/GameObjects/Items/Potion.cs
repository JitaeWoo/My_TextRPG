using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Items
{
    public class Potion : Item
    {
        public Potion(Vector2 position) : base(position)
        {
            Name = "포션";
            Description = "플레이어의 체력을 소량 회복한다.";
        }

        public override void Use()
        {
            Game.Player.Heal(10);
        }
    }
}
