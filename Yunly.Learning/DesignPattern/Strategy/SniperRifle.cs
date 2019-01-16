using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public class SniperRifle : Weapon
    {
        public SniperRifle(IAttackBehavior behavior)
        {
            AttackBehavior = behavior;
        }

        private IAttackBehavior AttackBehavior;


        public override void attack(Character enemy)
        {
            AttackBehavior.attack(enemy);
        }
    }
}
