using MyTextRPG.GameObjects.Items;
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
        public MonsterGroup(Monster monster = null)
            : this(new Vector2(1, 1), monster)
        {
        }

        public MonsterGroup(Vector2 position, Monster monster = null)
            : base(ConsoleColor.Red, 'M', position, true)
        {
            if(monster != null)
            {
                MonsterList.Add(monster);
            }
        }

        public override void Interact()
        {
            Game.ChangeScene(new BattleScene(MonsterList));
        }
    }
}
