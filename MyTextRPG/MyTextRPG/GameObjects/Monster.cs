using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects
{
    public abstract class Monster : GameObject
    {
        public string Name { get; protected set; }

        protected int Attack;
        protected int Defense;
        public int CurHp { get; protected set; }
        public int MaxHp { get; protected set; }

        public Monster(Vector2 position, int attack, int defense, int hp) 
            : base(ConsoleColor.Red, 'M', position, true)
        {
            Attack = attack;
            Defense = defense;
            MaxHp = hp;
            CurHp = MaxHp;
        }

        public override void Interact()
        {
            // 몬스터와 전투 돌입
        }

        public virtual int AttackPlayer()
        {
            return Game.Player.TakeDamage(Attack);
        }

        public int TakeDamage(int damage)
        {
            int totalDamage = damage - Defense;

            if(totalDamage > 0)
            {
                CurHp = Math.Max(totalDamage, 0);
                return totalDamage;
            }

            return 0;
        }
    }
}
