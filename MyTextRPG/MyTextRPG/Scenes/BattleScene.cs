using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public class BattleScene : BaseScene
    {
        private Monster _monster;
        private Queue<string> _battleSequence = new Queue<string>();
        private string _curTurn;
        public BattleScene(Monster monster)
        {
            Name = "BattleScene";

            _monster = monster;

            _battleSequence.Enqueue(_monster.Name);

            _curTurn = "Player";
        }

        public override void Render()
        {
            if(_curTurn == "Player")
            {
                Console.WriteLine($"========플레이어 턴========");
                Console.WriteLine();
                Console.WriteLine($"{_monster.Name} : [{_monster.CurHp} / {_monster.MaxHp}]");
                Console.WriteLine();
                Console.WriteLine("다음 행동을 선택하십시오");
                Console.WriteLine("1. 공격한다.");
            }
            else
            {
                Console.WriteLine($"=========몬스터 턴=========");
                Console.WriteLine();
                Console.WriteLine($"{_monster.Name} : [{_monster.CurHp} / {_monster.MaxHp}]");
                Console.WriteLine();
                Console.WriteLine($"{_monster.Name}의 공격!");
                int damage = _monster.AttackPlayer();
                Console.WriteLine($"{damage}의 데미지를 입었다!");
                Console.WriteLine();
                Console.WriteLine("아무키나 눌러서 계속...");
            }
        }

        public override void Result()
        {
            if(_curTurn == "Player")
            {
                switch (InputKey)
                {
                    case ConsoleKey.D1:
                        int damage = _monster.TakeDamage(Game.Player.Attack);
                        Console.WriteLine("플레이어의 공격!");
                        Console.WriteLine($"{_monster.Name}에게 {damage}의 데미지를 입혔다!");
                        break;
                }

                if (_monster.CurHp <= 0)
                {
                    Console.WriteLine("승리했습니다!!");
                    Game.ChangeScene(Game.PrevSceneName);
                }

                Util.PressAnyKey();
            }
            else 
            {
                if (Game.Player.CurHp <= 0)
                {
                    Console.WriteLine("패배하였습니다...");
                    Game.GameOver();
                    Util.PressAnyKey();
                }
            } 


            _battleSequence.Enqueue(_curTurn);
            _curTurn = _battleSequence.Dequeue();
        }
    }
}
