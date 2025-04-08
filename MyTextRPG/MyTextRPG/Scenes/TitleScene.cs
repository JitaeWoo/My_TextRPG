using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public class TitleScene : BaseScene
    {
        public override void Render()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("*      My Text RPG      *");
            Console.WriteLine("*************************");
            Console.WriteLine("");
            Console.WriteLine("아무키나 눌러서 시작");
        }

        public override void Result()
        {
            Game.ChangeScene("TestField");
        }
    }
}
