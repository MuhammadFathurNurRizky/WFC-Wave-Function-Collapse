using System.Collections;
using System.Collections.Generic;

namespace Monsters
{
    public class Monster
    {
        // Properties
        public int monsterHealth {get; set;}
        public int monsterDamage {get; set;}
        public int totalPower;

        // Method
        public Monster(int health, int damage)
        {
            if (health < 0 && damage < 0)
            {
                throw new System.ArgumentOutOfRangeException("Health must above from zero");
            }

            monsterHealth = health;
            monsterDamage = damage;
        }

        public int TotalMonsterPower()
        {
            totalPower = monsterHealth + monsterDamage;
            return totalPower;
        }
    }
}
