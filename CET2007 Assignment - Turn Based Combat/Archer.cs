using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Archer : Combatant
    {
        private string skill1 = "Sharp Arrow";
        private string skill2 = "Precision Stance";
        public Archer() : base(2, "Robin Hood", "Archer", 160, 40, 15)
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + skill1 + ".");
            int DamageBonus = 20;
            return Attack * DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + skill2 + ".");
            Defence += 5; //NEEDS CHANGING TO ONLY BE TEMPORARY
            Console.WriteLine("Defence up (+5) until next turn.");
            //Placeholder return value
            return 0;
        }
    }
}
