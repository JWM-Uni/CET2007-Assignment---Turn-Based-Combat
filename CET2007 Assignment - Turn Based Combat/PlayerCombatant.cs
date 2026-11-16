using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// An abstract class PlayerCombatant used to provide each player character type with the same attributes and methods that only the player needs.
    /// Inherits from Combatant.
    /// </summary>
    public abstract class PlayerCombatant : Combatant
    {
        /// <summary>
        /// Gets or sets the player's defence stat
        /// </summary>
        public int Defence { get; private set; }
        /// <summary>
        /// Gets or sets the player's skill name
        /// </summary>
        public string SkillName { get; private set; }

        /// <summary>
        /// Assigns the relevant attributes it has inherited to attributes PlayerCombatant shares, then passes the remaining attributes to the parent class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="health"></param>
        /// <param name="attack"></param>
        /// <param name="defence"></param>
        /// <param name="skill"></param>
        public PlayerCombatant(int id, string name, string type, int health, int attack, int defence, string skill) : base(id, name, type, health, attack)
        {
            Defence = defence;
            SkillName = skill;
        }

        /// <summary>
        /// Manages the player's defending status, outputs it, and logs it
        /// </summary>
        /// <returns>A true value to indicate the player is defending</returns>
        public bool Defend()
        {
            Console.WriteLine("\n" + Name + " decides to defend");
            Logger.GetInstance().Log("Player (" + Type + ") used defend.");
            return true;
        }

        /// <summary>
        /// Outputs all character information to the user
        /// </summary>
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
        }

        /// <summary>
        /// Takes a damage integer as a parameter and subtracts it from the current health.
        /// Outputs and logs the damage taken, as well as the player's remaining health
        /// </summary>
        /// <param name="damage"></param>
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

        /// <summary>
        /// Requires subclasses to implement the Skill method, but allows for flexibility so each character type can have a unique skill
        /// </summary>
        /// <returns></returns>
        public abstract int Skill();

        /// <summary>
        /// Outputs a selection of actions to the player, then asks them to enter their choice
        /// </summary>
        /// <returns>The player's chosen choice</returns>
        public string ActionSelection()
        {
            string choice = "";
            while (choice == "" || choice == "5")
            {
                Console.WriteLine("\n=== Choose an action ===" +
                "\n1) Attack" +
                "\n2) Defend" +
                "\n3) " + SkillName +
                "\n4) Show Character Information" +
                "\n5) Quit Game" +
                "\nEnter your choice: "
                );
                choice = Console.ReadLine();
                return choice;
            }
            return choice;
        }
    }
}
