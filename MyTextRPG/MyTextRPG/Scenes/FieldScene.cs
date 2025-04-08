using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public abstract class FieldScene : BaseScene
    {
        protected String[] MapData;
        protected bool[,] IsWall;

        public override void Render()
        {
            PrintMap();

            Game.Player.Print();
        }

        public override void Result()
        {
            Game.Player.Move(InputKey);
        }

        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for(int y = 0; y < MapData.Length; y++)
            {
                for(int x = 0; x < MapData[0].Length; x++)
                {
                    Console.Write(MapData[y][x]);
                }
                Console.WriteLine();
            }
        }
    }
}
