using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Creates a Mage for use in the game with their unique skill and stats, inheriting from the PlayerCombatant class 
    /// </summary>
    public class Mage : PlayerCombatant
    {
        /// <summary>
        /// Default constructor that creates the mage, with their assigned stats and skill
        /// </summary>
        public Mage() : base(3, "Lianne Warde", "Mage", 120, 15, 5, "Healing Pulse")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        /// <summary>
        /// Outputs the user choosing to use the skill, logs it, and adds the health healed to the health attribute
        /// </summary>
        /// <returns>0 because no damage is done (health is added in the method)</returns>
        public override int Skill()
        {
            Console.WriteLine(Name + " used " + SkillName + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + SkillName);
            Health += 40;
            Console.WriteLine("Healed 40 health.");
            Logger.GetInstance().Log("Player healed 40 health");
            //Returns 0 because it doesn't do damage
            return 0;
        }
    }
}
