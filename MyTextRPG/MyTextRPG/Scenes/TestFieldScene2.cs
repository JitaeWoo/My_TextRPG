using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class TestFieldScene2 : FieldScene
    {
        public TestFieldScene2()
        {
            MapData = new string[]
            {
                "########",
                "#      #",
                "#      #",
                "#      #",
                "#      #",
                "########"
            };

            IsWall = new bool[MapData.Length, MapData[0].Length];
            for (int y = 0; y < IsWall.GetLength(0); y++)
            {
                for (int x = 0; x < IsWall.GetLength(1); x++)
                {
                    IsWall[y, x] = MapData[y][x] == '#';
                }
            }

            objects = new List<GameObject>();
        }

        public override void Enter()
        {
            Game.Player.Position = new Vector2(1, 1);
        }
    }
}
