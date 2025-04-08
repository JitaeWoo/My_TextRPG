using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class TestFieldScene : FieldScene
    {
        public TestFieldScene()
        {
            mapData = new string[]
            {
                "########",
                "#      #",
                "#      #",
                "#      #",
                "#      #",
                "########"
            };

            isWall = new bool[mapData.Length, mapData[0].Length];
            for(int y = 0; y < isWall.GetLength(0); y++)
            {
                for(int x = 0; x < isWall.GetLength(1); x++)
                {
                    isWall[y, x] = mapData[y][x] == '#';
                }
            }
        }
    }
}
