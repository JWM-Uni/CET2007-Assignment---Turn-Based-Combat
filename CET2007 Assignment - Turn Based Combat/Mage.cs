using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Mage : PlayerCombatant
    {
        public Mage() : base(3, "Lianne Warde", "Mage", 120, 15, 5, "Healing Pulse")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill()
        {
            Console.WriteLine(Name + " used " + SkillName + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + SkillName);
            Health += 40;
            Console.WriteLine("Healed 40 health.");
            Logger.GetInstance().Log("Player healed 40 health");
            return 0;
        }
    }
}
