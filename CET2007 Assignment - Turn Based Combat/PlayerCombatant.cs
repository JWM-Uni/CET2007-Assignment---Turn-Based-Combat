using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public abstract class PlayerCombatant : Combatant
    {
        public int Defence { get; set; }
        public string SkillName { get; set; }

        public PlayerCombatant(int id, string name, string type, int health, int attack, int defence, string skill) : base(id, name, type, health, attack)
        {
            Defence = defence;
            SkillName = skill;
        }
        public bool Defend()
        {
            Console.WriteLine("\n" + Name + " decides to defend");
            Logger.GetInstance().Log("Player (" + Type + ") used defend.");
            return true;
        }

        public void CharacterInfo()
        {
            Console.WriteLine("\n=== Character Info ===");
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Health: " + Health);
            Console.WriteLine("Attack: " + Attack);
            Console.WriteLine("Defence: " + Defence);
            Console.WriteLine("Skill: " + SkillName);
            Logger.GetInstance().Log("Player decided to view their character information.");
        }

        public override void TakeDamage(int damage)
        {
            Console.WriteLine("\n" + Name + " took " + damage + " damage from the attack.");
            Logger.GetInstance().Log("Player (" + Type + ") took " + damage + " damage from the enemy attack.");
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            Console.WriteLine(Name + " now has " + Health + " health remaining.");
            Logger.GetInstance().Log("Player (" + Type + ") has " + Health + " health remaining.");
        }

        public abstract int Skill();
    }
}
