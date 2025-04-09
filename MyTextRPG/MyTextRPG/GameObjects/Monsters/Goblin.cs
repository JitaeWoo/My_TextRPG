using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Monsters
{
    class Goblin : Monster
    {
        public Goblin(Vector2 position) 
            : base(position, 10, 1, 30)
        {
        }
    }
}
