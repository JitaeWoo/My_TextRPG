using MyTextRPG.GameObjects.Items.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class TownShopScene : BaseScene
    {
        public override void Render()
        {
            Console.WriteLine("다양한 물품을 파는 상점이다.");
            Game.Player.Inven.PrintGold();
            Console.WriteLine();
            Console.WriteLine("1. 나무 검을 산다. 100G");
            Console.WriteLine("2. 천 갑옷을 산다. 150G");
            Console.WriteLine("3. 돌 목걸이를 산다. 80G");
            Console.WriteLine("0. 돌아간다.");
        }

        public override void Result()
        {
            switch (InputKey)
            {
                case ConsoleKey.D1:
                    if(Game.Player.Inven.Gold < 100)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        Util.PressAnyKey();
                    }
                    else
                    {
                        Game.Player.Inven.PayGold(100);
                        Game.Player.Inven.Add(new Weapon("나무 검", "평범한 나무 검, 공격력을 3 높인다.", 3));
                    }
                    break;
                case ConsoleKey.D2:
                    if (Game.Player.Inven.Gold < 150)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        Util.PressAnyKey();
                    }
                    else
                    {
                        Game.Player.Inven.PayGold(150);
                        Game.Player.Inven.Add(new Armor("가죽 갑옷", "평범한 가죽 갑옷, 방어력을 2 높인다.", 2));
                    }
                    break;
                case ConsoleKey.D3:
                    if (Game.Player.Inven.Gold < 80)
                    {
                        Console.WriteLine("골드가 부족합니다.");
                        Util.PressAnyKey();
                    }
                    else
                    {
                        Game.Player.Inven.PayGold(80);
                        Game.Player.Inven.Add(new Accessory("돌 목결이", "착용자의 체력을 올려주는 목걸이, 체력을 5 높인다.", 5));
                    }
                    break;
                case ConsoleKey.D0:
                    Game.ChangeScene("Town");
                    break;
            }
        }
    }
}
