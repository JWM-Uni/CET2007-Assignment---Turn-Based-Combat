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
        /// Gets or sets the ActualDamage taken
        /// </summary>
        public int ActualDamage { get; private set; }
        /// <summary>
        /// Takes an attack value and a defence value, and calculates the damage taken
        /// </summary>
        /// <param name="attackValue"></param>
        /// <param name="defenceValue"></param>
        public void OnDamageCalculation(int attackValue, int defenceValue)
        {
            ActualDamage = attackValue - defenceValue;
            if (ActualDamage < 0)
            {
                ActualDamage = 0;
            }
        }
    }
}
