using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Mage : Combatant
    {
        public Mage() : base(3, "Lianne Warde", "Mage", 120, 15, 5, "Fireball", "Healing Pulse")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + Skill1Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill1Name);
            int DamageBonus = 40;
            return Attack + DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + Skill2Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill2Name);
            Health += 40;
            Console.WriteLine("Healed 40 health.");
            Logger.GetInstance().Log("Player healed 40 health");
            return 0;
        }
    }
}
