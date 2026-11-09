using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Knight : PlayerCombatant
    {
        public Knight() : base(1, "Cedric Ironheart", "Knight", 200, 25, 15, "Piercing Slash")
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill()
        {
            Console.WriteLine(Name + " used " + SkillName + ".");
            Logger.GetInstance().Log("Player (" + Type + ") used " + SkillName);
            int DamageBonus = 10;
            return Attack + DamageBonus;
        }
    }
}
