using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Monsters
{
    class Goblin : Monster
    {
        public Goblin() :
            this(new Vector2(1, 1))
        {
        }

        public Goblin(Vector2 position) 
            : base(position, 10, 1, 30)
        {
            Name = "고블린";
        }
    }
}
