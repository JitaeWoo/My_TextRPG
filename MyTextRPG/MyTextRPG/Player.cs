using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTextRPG.GameObjects;
using MyTextRPG.GameObjects.Items;
using MyTextRPG.GameObjects.Items.Equipments;
using MyTextRPG.Scenes;

namespace MyTextRPG
{
    public class Player
    {
        private Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        private Inventory _inventory = new Inventory();
        public Inventory Inven => _inventory;

        private Weapon _weapon;
        private Armor _armor;
        private Accessory _accessory;

        private int _curHp;
        public int CurHp => _curHp;
        private int _maxHp;
        private int _totalMaxHp
        {
            get
            {
                int totalMaxHp = _maxHp;
                if(_accessory != null)
                {
                    totalMaxHp += _accessory.Hp;
                }
                return totalMaxHp;
            }
        }
        public int MaxHp => _totalMaxHp;

        private int _attack;
        private int _totalAttack
        {
            get
            {
                int totalAttack = _attack;
                if(_weapon != null)
                {
                    totalAttack += _weapon.Attack;
                }
                return totalAttack;
            }
        }
        public int Attack => _totalAttack;

        private int _defense;
        private int _totalDefense
        {
            get
            {
                int totalDefense = _defense;
                if(_armor != null)
                {
                    totalDefense += _armor.Defense;
                }
                return totalDefense;
            }
        }

        public Player()
        {
            _maxHp = 100;
            _curHp = _maxHp;
            _attack = 10;
            _defense = 3;
        }

        public void Print()
        {
            Console.SetCursorPosition(_position.x, _position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();
        }

        public void PrintStats()
        {
            Console.WriteLine($"플레이어 : 체력 {_curHp} / {_totalMaxHp} 공격력 {_totalAttack} 방어력 {_totalDefense}");
        }

        public void PrintEquipment()
        {
            Console.WriteLine($"무기 : {_weapon?.Name}  방어구 : {_armor?.Name}  장신구 : {_accessory?.Name}");
        }

        public void Equip(Equipment equipment)
        {
            switch (equipment.Type)
            {
                case Item.Types.Weapon:
                    if(_weapon != null)
                    {
                        _inventory.Add(_weapon);
                    }
                    _weapon = (equipment as Weapon);
                    break;
                case Item.Types.Armor:
                    if (_armor != null)
                    {
                        _inventory.Add(_armor);
                    }
                    _armor = (equipment as Armor);
                    break;
                case Item.Types.Accessory:
                    if(_accessory != null)
                    {
                        _inventory.Add(_accessory);
                    }
                    _accessory = (equipment as Accessory);
                    _curHp = Math.Min(_totalMaxHp, _curHp);
                    break;
            }
        }

        public void Heal(int amount)
        {
            if(amount > 0)
            {
                _curHp = Math.Min(_curHp + amount, _totalMaxHp);
            }
        }

        public int TakeDamage(int amount)
        {
            amount -= _defense;
            if(_armor != null)
            {
                amount -= _armor.Defense;
            }

            if(amount > 0)
            {
                _curHp = Math.Max(_curHp - amount, 0);
                return amount;
            }

            return 0;
        }

        public void Action(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    Move(input);
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                    Inven.UseAt((int)input - 49);
                    break;
                case ConsoleKey.I:
                    Inven.Open();
                    break;
            }
        }

        private void Move(ConsoleKey input)
        {
            Vector2 targetPosition = _position;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                    targetPosition.y--;
                    break;
                case ConsoleKey.DownArrow:
                    targetPosition.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    targetPosition.x--;
                    break;
                case ConsoleKey.RightArrow:
                    targetPosition.x++;
                    break;
            }

            if ((Game.CurScene as FieldScene).IsWall[targetPosition.y, targetPosition.x] == false)
            {
                _position = targetPosition;
            }
        }
    }
}
