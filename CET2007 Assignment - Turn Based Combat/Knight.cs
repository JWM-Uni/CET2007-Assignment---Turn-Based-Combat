using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Knight : Combatant
    {
        public Knight() : base(1, "Cedric Ironheart", "Knight", 200, 35, 20)
        {
            //Parameters are preset as the characters are the same each time the game is ran
            //All parameters are passed up to the base class to keep them encapsulated
        }

        public override int Skill1()
        {
            //Placeholder return value
            return 0;
        }

        public override int Skill2()
        {
            //Placeholder return value
            return 0;
        }
    }
}
