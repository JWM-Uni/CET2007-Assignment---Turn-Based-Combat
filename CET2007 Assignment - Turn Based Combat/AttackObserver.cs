using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class AttackObserver : IDamageObserver
    {
        public int DamageCalculation(int attackValue, int defenceValue)
        {
            int actualDamage = 0;
            actualDamage = attackValue - defenceValue;
            return actualDamage;
        }
    }
}
