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
            //NEED TO SET DEFENCE VALUE TO 0 IF THERE IS NO DEFEND ACTION TAKEN
            int actualDamage = 0;
            actualDamage = attackValue - defenceValue;
            return actualDamage;
        }
    }
}
