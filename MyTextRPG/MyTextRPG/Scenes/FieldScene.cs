using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    public abstract class FieldScene : BaseScene
    {
        protected String[] mapData;
        protected bool[,] isWall;

        public override void Render()
        {
            PrintMap();
        }

        public override void Result()
        {
        }

        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for(int y = 0; y < mapData.Length; y++)
            {
                for(int x = 0; x < mapData[0].Length; x++)
                {
                    Console.Write(mapData[y][x]);
                }
                Console.WriteLine();
            }
        }
    }
}
