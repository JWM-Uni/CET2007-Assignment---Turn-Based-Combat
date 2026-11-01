using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Mage : Combatant
    {
        private string skill1 = "Fireball";
        private string skill2 = "Healing Pulse";
        public Mage() : base(3, "Lianne Warde", "Mage", 120, 15, 5)
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + skill1 + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + skill1);
            int DamageBonus = 40;
            return Attack + DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + skill2 + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + skill2);
            Health += 40;
            Console.WriteLine("Healed 40 health.");
            Logger.GetInstance().Log("Player healed 40 health");
            return 0;
        }
    }
}
