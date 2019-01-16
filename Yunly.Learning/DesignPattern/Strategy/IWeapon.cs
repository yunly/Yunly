using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public abstract class Weapon
    {
        IAttackBehavior AttackBehavior { get;  }


        public abstract void attack(Character enemy);
    }
}
