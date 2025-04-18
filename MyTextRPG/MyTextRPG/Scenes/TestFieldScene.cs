﻿using MyTextRPG.GameObjects;
using MyTextRPG.GameObjects.Items;
using MyTextRPG.GameObjects.Monsters;
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
            Name = "TestField";

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
            for(int y = 0; y < IsWall.GetLength(0); y++)
            {
                for(int x = 0; x < IsWall.GetLength(1); x++)
                {
                    IsWall[y, x] = MapData[y][x] == '#';
                }
            }

            objects.Add(new Portal("TestField2", new Vector2(3, 3)));
            objects.Add(new Potion(new Vector2(3, 2)));
            objects.Add(new Goblin(new Vector2(2, 2)));
        }

        public override void Enter()
        {
            if(Game.PrevSceneName == "Title")
            {
                Game.Player.Position = new Vector2(1, 1);
            }
        }
    }
}
