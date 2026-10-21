using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public abstract class Combatant
    {
        private int ID {  get; set; }
        private string Name { get; set; }
        private string Type { get; set; }
        private int Health { get; set; }
        private int Attack {  get; set; }
        private int Defence { get; set; }

        public int BasicAttack()
        {
            //Placeholder text for basic attack action
            Console.WriteLine("Attacking...");
            return 0;
        }

        public int Defend()
        {
            //Placeholder text for defend action
            Console.WriteLine("Defending...");
            return 0;
        }
        public abstract void CharacterInfo();
        public abstract int Skill1();
        public abstract int Skill2();
    }
}
