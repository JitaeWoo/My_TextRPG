using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG.GameObjects.Items
{
    public class Equipment : Item
    {
        public Equipment(Types type)
            : this(new Vector2(1, 1), type)
        {
        }

        public Equipment(Vector2 position, Types type) 
            : base(position, type)
        {
        }

        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
