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
        public bool[,] IsWall { get; protected set; }

        protected List<GameObject> objects = new List<GameObject>();

        public override void Render()
        {
            PrintMap();
            Console.WriteLine();
            Game.Player.PrintStats();
            Console.WriteLine();
            Game.Player.PrintEquipment();
            Console.WriteLine();
            Game.Player.Inven.PrintTop();

            foreach (GameObject obj in objects)
            {
                obj.Print();
            }

            Game.Player.Print();
        }

        public override void Result()
        {
            Game.Player.Action(InputKey);

            foreach(GameObject obj in objects)
            {
                if(Game.Player.Position == obj.Position)
                {
                    obj.Interact();
                    if (obj.IsOnce)
                    {
                        objects.Remove(obj);
                    }
                    break;
                }
            }
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
