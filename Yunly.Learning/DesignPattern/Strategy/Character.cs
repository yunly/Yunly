using System;
using System.Collections.Generic;
using System.Text;

namespace Yunly.Learning.DesignPattern.Strategy
{
    public abstract class Character
    {
        public string Nam7e { get; private set; }
        public int Life { get; private set; }

        public Weapon Weapon { get; private set; }

        public Character(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void attack(Character enemy)
        {
            Weapon.attack(enemy);
        }

    }
}
