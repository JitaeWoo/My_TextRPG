using MyTextRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    class MonsterGroup : GameObject
    {
        public List<Monster> MonsterList = new List<Monster>();
        public MonsterGroup(Vector2 position) 
            : base(ConsoleColor.Red, 'M', position, true)
        {
        }

        public override void Interact()
        {
            Game.ChangeScene(new BattleScene(MonsterList));
        }
    }
}
