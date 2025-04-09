using MyTextRPG.GameObjects.Items;
using MyTextRPG.GameObjects.Monsters;
using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.Scenes
{
    class Forest1Scene : FieldScene
    {
        public Forest1Scene()
        {
            Name = "Forest1";

            MapData = new string[]
            {
                "########",
                "#      #",
                "#####  #",
                "#      #",
                "#  #####",
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

            objects.Add(new Portal("Town", new Vector2(1, 1)));
            objects.Add(new Portal("Forest2", new Vector2(6, 5)));
            objects.Add(new Potion(new Vector2(1, 3)));
            objects.Add(new Goblin(new Vector2(3, 3)));
        }

        public override void Enter()
        {
            if(Game.PrevSceneName == "Town")
            {
                Game.Player.Position = new Vector2(1, 1);
            }
        }
    }
}
