using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class InnScene : BaseScene
    {
        public InnScene()
        {
            Name = "Inn";
        }
        public override void Render()
        {
            Console.WriteLine("여행의 피로를 녹일 수 있는 여관이다.");
            Game.Player.Inven.PrintGold();
            Console.WriteLine();
            Console.WriteLine("1. 여관에서 잠을 잔다. 10G, 체력 완전 회복");
            Console.WriteLine("0. 돌아간다.");
        }

        public override void Result()
        {
            switch (InputKey)
            {
                case ConsoleKey.D1:
                    if(Game.Player.Inven.Gold < 10)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        Util.PressAnyKey();
                    }
                    else
                    {
                        Game.Player.Inven.PayGold(10);
                        Game.Player.Heal(Game.Player.MaxHp);
                    }
                    break;
                case ConsoleKey.D0:
                    Game.ChangeScene(Game.PrevSceneName);
                    break;
            }
        }
    }
}
