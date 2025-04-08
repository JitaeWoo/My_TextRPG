using MyTextRPG.GameObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public class Inventory : List<Item>
    {
        private enum State
        {
            Menu, Selected, UseConfirm, DropConfirm
        }
        private Stack<State> _stack = new Stack<State>();
        private int _selectedIndex;

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

        public void Open()
        {
            _stack.Push(State.Menu);

            while(_stack.Count > 0)
            {
                Console.Clear();
                switch (_stack.Peek())
                {
                    case State.Menu:
                        Menu();
                        break;
                    case State.Selected:
                        Selected();
                        break;
                    case State.UseConfirm:
                        UseConfirm();
                        break;
                    case State.DropConfirm:
                        DropConfirm();
                        break;
                }
            }
        }

        private void Menu()
        {
            PrintTop();
            Console.WriteLine();

            Console.WriteLine("원하는 아이템의 번호 입력");
            Console.WriteLine("뒤로가기 : 0");

            ConsoleKey input = Console.ReadKey(true).Key;
            if(input == ConsoleKey.D0)
            {
                _stack.Pop();
                return;
            }

            int select = (int)input - (int)ConsoleKey.D1;
            if(select < 0 || select >= Math.Min(5, this.Count))
            {
                return;
            }

            _selectedIndex = select;
            _stack.Push(State.Selected);

        }

        private void Selected()
        {
            Console.WriteLine($"{this[_selectedIndex].Name}을/를 선택하셨습니다.");
            Console.WriteLine("원하시는 메뉴를 선택하십시오.");
            Console.WriteLine();
            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 버리기");
            Console.WriteLine("0. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D0:
                    _stack.Pop();
                    break;
                case ConsoleKey.D1:
                    _stack.Push(State.UseConfirm);
                    break;
                case ConsoleKey.D2:
                    _stack.Push(State.DropConfirm);
                    break;
            }
        }

        private void UseConfirm()
        {
            Console.WriteLine($"{this[_selectedIndex].Name}을/를 사용하시겠습니까? (y/n)");

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.Y:
                    UseAt(_selectedIndex);
                    _stack.Pop();
                    _stack.Pop();
                    break;
                case ConsoleKey.N:
                    _stack.Pop();
                    break;
            }
        }

        private void DropConfirm()
        {
            Console.WriteLine($"정말 {this[_selectedIndex].Name}을/를 버리시겠습니까? (y/n)");

            ConsoleKey input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.Y:
                    this.RemoveAt(_selectedIndex);
                    _stack.Pop();
                    _stack.Pop();
                    break;
                case ConsoleKey.N:
                    _stack.Pop();
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
