using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public abstract class Combatant
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Health { get; private set; }
        public int Attack {  get; private set; }
        public int Defence { get; private set; }

        public Combatant(int id, string name, string type, int health, int attack, int defence)
        {
            ID = id;
            Name = name;
            Type = type;
            Health = health;
            Attack = attack;
            Defence = defence;
        }
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
            //Account for defence in the damage formulae

        }
        public abstract void CharacterInfo();
        public abstract int Skill1();
        public abstract int Skill2();
    }
}
