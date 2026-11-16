using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Manages the damage calculations, implementing the IDamageObserver interface and methods
    /// </summary>
    public class AttackObserver : IDamageObserver
    {
        /// <summary>
        /// Takes an attack value and a defence value, and calculates the damage taken
        /// </summary>
        /// <param name="attackValue"></param>
        /// <param name="defenceValue"></param>
        /// <returns>Returns the damage taken after calculations</returns>
        public int DamageCalculation(int attackValue, int defenceValue)
        {
            int actualDamage = attackValue - defenceValue;
            
            if (actualDamage <= 0) //Ensures an attack does at least 1 damage, rather than 0 (prevents a character from being entirely invincible)
            {
                actualDamage = 1;
            }
            return actualDamage;
        }
    }
}
