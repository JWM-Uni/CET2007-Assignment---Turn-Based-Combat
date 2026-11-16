using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Creates an interface used to implement damage calculation methods
    /// </summary>
    public interface IDamageObserver
    {
        /// <summary>
        /// Takes an attack value and a defence value, and calculates the damage taken
        /// </summary>
        /// <param name="attackValue"></param>
        /// <param name="defenceValue"></param>
        /// <returns>Returns the damage taken after calculations</returns>
        int DamageCalculation(int attackValue, int defenceValue);
    }
}
