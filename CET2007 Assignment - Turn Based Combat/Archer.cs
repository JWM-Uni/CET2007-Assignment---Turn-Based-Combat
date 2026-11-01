using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Archer : Combatant
    {
        public Archer() : base(2, "Robin Hood", "Archer", 160, 30, 10, "Sharp Arrow", "Precision Stance")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            Console.WriteLine(Name + " used " + Skill1Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill1Name);
            int DamageBonus = 15;
            return Attack + DamageBonus;
        }

        public override int Skill2()
        {
            Console.WriteLine(Name + " used " + Skill2Name + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + Skill2Name);
            Defence += 5; //NEEDS CHANGING TO ONLY BE TEMPORARY
            Console.WriteLine("Defence up (+5) until next turn.");
            Logger.GetInstance().Log("Player (" + Type + ") gained +5 defence till their next turn");
            //Placeholder return value
            return 0;
        }
    }
}
