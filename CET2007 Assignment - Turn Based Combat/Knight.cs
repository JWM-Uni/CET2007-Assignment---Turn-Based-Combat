using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Knight : Combatant
    {
        private string skill1 = "Piercing Slash";
        private string skill2 = "Guardian Aura";
        public Knight() : base(1, "Cedric Ironheart", "Knight", 200, 35, 20)
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + skill1 + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + skill1);
            int DamageBonus = 10;
            return Attack + DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + skill2 + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + skill2);
            Defence += 10; //NEEDS CHANGING TO ONLY BE TEMPORARY
            Console.WriteLine("Defence up (+10) until next turn.");
            //Placeholder return value
            return 0;
        }
    }
}
