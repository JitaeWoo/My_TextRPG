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
        public Inventory()
        {
        }

        public void UseAt(int index)
        {
            this[index].Use();
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
