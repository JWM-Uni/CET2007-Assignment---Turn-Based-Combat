using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Knight : Combatant
    {
        public Knight() : base(1, "Cedric Ironheart", "Knight", 200, 25, 15, "Piercing Slash", "Guardian Aura")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + Skill1Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill1Name);
            int DamageBonus = 10;
            return Attack + DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + Skill2Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill2Name);
            Defence += 10; //NEEDS CHANGING TO ONLY BE TEMPORARY
            Console.WriteLine("Defence up (+10) until next turn.");
            Logger.GetInstance().Log("Player (" + Type + ") gained +10 defence till their next turn.");
            //Placeholder return value
            return 0;
        }
    }
}
