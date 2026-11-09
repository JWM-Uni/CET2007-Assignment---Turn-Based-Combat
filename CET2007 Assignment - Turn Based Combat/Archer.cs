using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Archer : PlayerCombatant
    {
        public Archer() : base(2, "Robin Hood", "Archer", 160, 30, 10, "Sharp Arrow")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill()
        {
            Console.WriteLine(Name + " used " + SkillName + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + SkillName);
            int DamageBonus = 15;
            return Attack + DamageBonus;
        }
    }
}
