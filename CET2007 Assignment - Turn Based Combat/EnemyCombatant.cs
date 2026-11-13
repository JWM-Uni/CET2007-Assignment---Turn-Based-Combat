using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class EnemyCombatant : Combatant
    {
        public EnemyCombatant() : base(4, "Goblin", "Enemy", 150, 30)
        {
            //Passes parameters up to Combatant Constructor
        }

        public override void TakeDamage(int damage)
        {
            Console.WriteLine("\n" + Name + " took " + damage + " damage from the attack.");
            Logger.GetInstance().Log(Type + " " + Name + " took " + damage + " damage from the player attack.");
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            Console.WriteLine(Name + " has " + Health + " health remaining.");
            Logger.GetInstance().Log(Type + " " + Name + " has " + Health + " health remaining.");
        }
    }
}
