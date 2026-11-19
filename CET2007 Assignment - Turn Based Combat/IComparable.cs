using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public interface IComparable
    {
        int CompareTo(PlayerCombatant other);
    }
}
