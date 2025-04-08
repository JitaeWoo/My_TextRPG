using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public class Inventory : List<Item>
    {
        public void UseAt(int index)
        {
            Item.Types type = this[index].Type;

            switch (type)
            {
                case Item.Types.Consumable:
                    this[index].Use();
                    this.RemoveAt(index);
                    break;
            }
        }

        public void PrintTop()
        {
            Console.WriteLine("====소유한 아이템====");
            if (this.Count == 0)
            {
                Console.WriteLine("없음");
            }
            else
            {
                for (int i = 0; i < Math.Min(this.Count, 5); i++)
                {
                    Console.WriteLine($"{i + 1}. {this[i].Name}");
                }
            }
            Console.WriteLine("=====================");
        }

        public void PrintAll()
        {
            Console.WriteLine("====소유한 아이템====");
            if(this.Count == 0)
            {
                Console.WriteLine("없음");
            }
            else
            {
                for(int i = 0; i < this.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {this[i].Name}");
                }
            }
            Console.WriteLine("=====================");
        }
    }
}
