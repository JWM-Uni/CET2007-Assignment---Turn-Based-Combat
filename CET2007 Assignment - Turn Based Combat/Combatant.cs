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
        public Combatant(int id, string name, string type, int health, int attack)
        {
            ID = id;
            Name = name;
            Type = type;
            Health = health;
            Attack = attack;
        }
        public int BasicAttack()
        {
            Console.WriteLine(Name + " uses basic attack.");
            Logger.GetInstance().Log("Player (" + Type + ") used basic attack.");
            return Attack;
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine(Name + " took " + damage + " damage from the attack.");
            Logger.GetInstance().Log("Player (" + Type + ") took " + damage + " damage from the enemy attack.");
            Health -= damage;
            Console.WriteLine(Name + " now has " + Health + " health remaining.");
            Logger.GetInstance().Log("Player (" + Type + ") has " + Health + " health remaining.");
        }
    }
}
