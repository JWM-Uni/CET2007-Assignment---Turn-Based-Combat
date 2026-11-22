using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// An abstract class EnemyCombatant used to provide the enemy character type with the methods that only the enemy needs.
    /// Inherits from Combatant.
    /// </summary>
    public class EnemyCombatant : Combatant
    {
        /// <summary>
        /// Default constructor that passes all attributes up to the parent class
        /// </summary>
        public EnemyCombatant() : base(4, "Goblin", "Enemy", 150, 30)
        {
            //Passes parameters up to Combatant Constructor
        }

        /// <summary>
        /// Takes a damage integer as a parameter and subtracts it from the current health.
        /// Outputs and logs the damage taken, as well as the enemy's remaining health
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            Console.WriteLine("\n" + Name + " took " + damage + " damage from the attack.");
            Logger.GetInstance().Log(Type + " " + Name + " took " + damage + " damage from the player attack.");
            Health -= damage;
            if (Health < 0) //Ensures health can't enter negatives
            {
                Health = 0;
            }
            Console.WriteLine(Name + " has " + Health + " health remaining.");
            Logger.GetInstance().Log(Type + " " + Name + " has " + Health + " health remaining.");
        }
    }
}
