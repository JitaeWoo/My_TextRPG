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
                for(int i = 0; i < _monsterGroup.MonsterList.Count; i++)
                {
                    _monsterGroup.MonsterList[i].CurHp = _monsterGroup.MonsterList[i].MaxHp;
                }

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
