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
        public int Health { get; set; }
        public int Attack {  get; set; }
        public int Defence { get; set; }
        public string Skill1Name { get; set; }
        public string Skill2Name { get; set; }

        public Combatant(int id, string name, string type, int health, int attack, int defence, string skill1, string skill2)
        {
            ID = id;
            Name = name;
            Type = type;
            Health = health;
            Attack = attack;
            Defence = defence;
            Skill1Name = skill1;
            Skill2Name = skill2;
        }
        public int BasicAttack()
        {
            Console.WriteLine(Name + " uses basic attack.");
            return Attack;
        }

        public int Defend()
        {
            Console.WriteLine(Name + " decides to defend");
            return Defence;
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine(Name + " took " + damage + " damage from the attack.");
            Health -= damage;
            Console.WriteLine(Name + " now has " + Health + " health remaining.");
            //Account for defence in the damage formulae

        }
        public void CharacterInfo()
        {
            Console.WriteLine("=== Character Info ===");
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Attack: " + Attack);
            Console.WriteLine("Defence: " + Defence);
            Console.WriteLine("Skill 1: " + Skill1Name);
            Console.WriteLine("Skill 2: " + Skill2Name);
        }
        public abstract int Skill1();
        public abstract int Skill2();
    }
}
