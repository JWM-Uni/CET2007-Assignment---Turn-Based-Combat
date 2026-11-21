using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// An interface to allow the .Sort() function to work
    /// </summary>
    public interface IComparable
    {
        /// <summary>
        /// Compares to PlayerCombatants' to determine which one comes first
        /// </summary>
        /// <param name="other"></param>
        /// <returns>An integer determining whether this object comes before or after the one it's being compared with</returns>
        int CompareTo(PlayerCombatant other);
    }
}
