using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class TownScene : BaseScene
    {
        public TownScene()
        {
            Name = "Town";
        }

        public override void Render()
        {
            Console.WriteLine("사람들이 많은 활기찬 마을이다.");
            Console.WriteLine();
            Console.WriteLine("1. 마을 밖으로 나가본다.");
            Console.WriteLine("2. 상점으로 들어간다.");
            Console.WriteLine("3. 소지품을 확인한다.");
        }

        public override void Result()
        {
            switch (InputKey)
            {
                case ConsoleKey.D1:
                    Game.ChangeScene("Forest1");
                    break;
                case ConsoleKey.D2:
                    Game.ChangeScene("TownShop");
                    break;
                case ConsoleKey.D3:
                    Game.Player.Inven.Open();
                    break;
            }
        }
    }
}
