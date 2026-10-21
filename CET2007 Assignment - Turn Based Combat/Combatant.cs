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

        public virtual int BasicAttack()
        {
            //Placeholder text for basic attack action
            Console.WriteLine("Attacking...");
            return 0;
        }

        public virtual int Defend()
        {
            //Placeholder text for defend action
            Console.WriteLine("Defending...");
            return 0;
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine(Name + " took " + damage + " damage from the attack.");
            Health -= damage;
            Console.WriteLine(Name + " now has " + Health + " health remaining.");

        }
        public abstract void CharacterInfo();
        public abstract int Skill1();
        public abstract int Skill2();
    }
}
