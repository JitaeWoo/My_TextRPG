using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public class BattleScene : BaseScene
    {
        private enum PlayerMenu
        {
            Menu, Attack
        }

        private struct BattleInfo
        {
            public string Name;
            public int Index;

            public BattleInfo(string name, int index)
            {
                Name = name;
                Index = index;
            }
        }

        private Stack<PlayerMenu> _menuStack = new Stack<PlayerMenu>();
        private List<Monster> _monsters;
        private Queue<BattleInfo> _battleSequence = new Queue<BattleInfo>();
        private BattleInfo _curTurn;
        private int _killCount;

        public BattleScene(Monster monster) 
            : this(new List<Monster>() { monster })
        {
        }

        public BattleScene(List<Monster> monsters)
        {
            Name = "BattleScene";
            _monsters = monsters;

            for(int i = 0; i < _monsters.Count; i++)
            {
                _battleSequence.Enqueue(new BattleInfo(_monsters[i].Name, i));
            }

            _curTurn = new BattleInfo("Player", -1);
            _killCount = 0;
        }

        public override void Render()
        {
            if (_curTurn.Name == "Player")
            {
                Console.WriteLine($"========플레이어 턴========");

                PrintBaseInfo();
                
            }
            else
            {
                if (_monsters[_curTurn.Index].CurHp <= 0)
                {
                    return;
                }

                Console.WriteLine($"=========몬스터 턴=========");

                PrintBaseInfo();

                Console.WriteLine($"{_curTurn.Name}의 공격!");
                int damage = _monsters[_curTurn.Index].AttackPlayer();
                Console.WriteLine($"{damage}의 데미지를 입었다!");
                Console.WriteLine();
                Util.PressAnyKey();
            }

        }

        public override void Input()
        {
            // 플레이어 입력을 따로 관리하기 때문에 Input은 비워뒀습니다.
        }

        public override void Result()
        {
            if(_curTurn.Name == "Player")
            {
                PlayerTurn();
            }
            else 
            {
                if (Game.Player.CurHp <= 0)
                {
                    Console.WriteLine("패배하였습니다...");
                    Game.GameOver();
                    Util.PressAnyKey();
                }

                if (_monsters[_curTurn.Index].CurHp > 0)
                {
                    _battleSequence.Enqueue(_curTurn);
                }
                _curTurn = _battleSequence.Dequeue();
            } 
        }

        private void PrintBaseInfo()
        {
            Console.WriteLine();
            Game.Player.PrintStats();
            Console.WriteLine();
            foreach (Monster monster in _monsters)
            {
                if (monster.CurHp > 0)
                {
                    Console.WriteLine($"{monster.Name} : [{monster.CurHp} / {monster.MaxHp}]");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{monster.Name} : 사망");
                    Console.WriteLine();
                }
            }
        }

        private void PlayerTurn()
        {
            _menuStack.Push(PlayerMenu.Menu);

            while(_menuStack.Count > 0)
            {
                Console.Clear();
                Render();

                switch (_menuStack.Peek())
                {
                    case PlayerMenu.Menu:
                        Menu();
                        break;
                    case PlayerMenu.Attack:
                        Attack();
                        break;
                }
            }

            if (_killCount == _monsters.Count)
            {
                Console.WriteLine("승리했습니다!!");
                Game.ChangeScene(Game.PrevSceneName);
            }

            Util.PressAnyKey();

            _battleSequence.Enqueue(_curTurn);
            _curTurn = _battleSequence.Dequeue();
        }

        private void Menu()
        {
            Console.WriteLine("다음 행동을 선택하십시오");
            Console.WriteLine("1. 공격한다.");

            InputKey = Console.ReadKey(true).Key;

            switch (InputKey)
            {
                case ConsoleKey.D1:
                    _menuStack.Push(PlayerMenu.Attack);
                    break;
            }
        }

        private void Attack()
        {
            Console.WriteLine("누구를 공격하시겠습니까?");
            Console.WriteLine();
            for (int i = 0; i < _monsters.Count; i++) 
            {
                if (_monsters[i].CurHp > 0)
                {
                    Console.WriteLine($"{i + 1}. {_monsters[i].Name}");
                }
            }
            Console.WriteLine("0. 뒤로가기");

            InputKey = Console.ReadKey(true).Key;

            if(InputKey < ConsoleKey.D0 || (int)InputKey > _monsters.Count + 48)
            {
                return;
            }

            switch (InputKey)
            {
                case ConsoleKey.D0:
                    _menuStack.Pop();
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                    int index = (int)InputKey - (int)ConsoleKey.D1;

                    int damage = _monsters[index].TakeDamage(Game.Player.Attack);

                    Console.WriteLine($"{_monsters[index].Name}에게 {damage}의 데미지를 입혔다!");

                    if (_monsters[index].CurHp <= 0)
                    {
                        _killCount++;
                    }

                    _menuStack.Pop();
                    _menuStack.Pop();
                    break;
            }
        }
    }
}
