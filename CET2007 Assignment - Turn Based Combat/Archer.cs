using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Creates an Archer for use in the game with their unique skill and stats, inheriting from the PlayerCombatant class 
    /// </summary>
    public class Archer : PlayerCombatant
    {
        /// <summary>
        /// Default constructor that creates the archer, with their assigned stats and skill
        /// </summary>
        public Archer() : base(2, "Robin Hood", "Archer", 160, 30, 10, "Sharp Arrow")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        /// <summary>
        /// Outputs the user choosing to use the skill, logs it, and applies the skill's damage bonus to the base attack damage
        /// </summary>
        /// <returns>The base damage + skill's damage bonus</returns>
        public override int Skill()
        {
            Console.WriteLine(Name + " used " + SkillName + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + SkillName);
            int DamageBonus = 15;
            return Attack + DamageBonus;
        }
    }
}
