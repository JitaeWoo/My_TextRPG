using MyTextRPG.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    class MonsterSpawner : GameObject
    {
        private MonsterGroup _monsterGroup;
        private bool isSpawned = true;

        public MonsterSpawner(Vector2 position, Monster monster) 
            : this(position, new MonsterGroup(monster))
        {
        }

        public MonsterSpawner(Vector2 position, MonsterGroup monsterGroup)
            : base(ConsoleColor.Red, 'M', position, false)
        {
            _monsterGroup = monsterGroup;

            Game.OnSleeped += Spawn;
        }

        public override void Interact()
        {
            if (isSpawned)
            {
                Game.ChangeScene(new BattleScene(_monsterGroup.MonsterList));
                Symbol = ' ';
                isSpawned = false;
            }
        }

        public void Spawn()
        {
            isSpawned = true;
            Symbol = 'M';
        }
    }
}
