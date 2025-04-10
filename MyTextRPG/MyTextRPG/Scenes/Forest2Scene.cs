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
    class Forest2Scene : FieldScene
    {
        public Forest2Scene()
        {
            Name = "Forest2";

            MapData = new string[]
            {
                "########",
                "#    # #",
                "#    # #",
                "#    # #",
                "###    #",
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

            objects.Add(new Portal("Forest1", new Vector2(1, 1)));
            MonsterGroup monsterGroup = new MonsterGroup(new Vector2(6, 3));
            monsterGroup.MonsterList.Add(new Goblin());
            monsterGroup.MonsterList.Add(new Goblin());
            monsterGroup.MonsterList.Add(new Goblin());
            objects.Add(monsterGroup);
            Wall wall = new Wall(new Vector2(2, 5), Directions.Right);
            Button button = new Button(new Vector2(6, 1));
            button.OnClicked += () =>
            {
                objects.Remove(wall);
            };
            objects.Add(wall);
            objects.Add(button);
        }

        public override void Enter()
        {
            if (Game.PrevSceneName == "Forest1")
            {
                Game.Player.Position = new Vector2(1, 1);
            }
        }
    }
}
