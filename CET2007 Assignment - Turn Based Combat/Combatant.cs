using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// An abstract class of Combatant used to provide both the player and the enemy characters with the attributes and methods they both share.
    /// Parent class of PLayerCombatant and EnemyCombatant.
    /// </summary>
    public abstract class Combatant
    {
        /// <summary>
        /// Gets or sets the combatant's ID
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Gets or sets the combatant's name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets or sets the combatant's type
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// Gets or sets the combatant's health
        /// </summary>
        public int Health { get; private set; }
        /// <summary>
        /// Gets or sets the combatant's attack
        /// </summary>
        public int Attack {  get; private set; }
        
        /// <summary>
        /// A constructor that takes parameters inherited from subclasses and sets the attributes to the specified values
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="health"></param>
        /// <param name="attack"></param>
        public Combatant(int id, string name, string type, int health, int attack)
        {
            ID = id;
            Name = name;
            Type = type;
            Health = health;
            Attack = attack;
        }

        /// <summary>
        /// Manages the basic attack action of the combatant, outputting the action, and logging it
        /// </summary>
        /// <returns>The base damage (combatant's attack value)</returns>
        public int BasicAttack()
        {
            Console.WriteLine("\n" + Name + " uses basic attack.");
            Logger.GetInstance().Log("Player (" + Type + ") used basic attack.");
            return Attack;
        }

        /// <summary>
        /// Requires subclasses to implement the TakeDamage method, but allows for flexibility so different messages can be outputted for players and enemies
        /// </summary>
        /// <param name="damage"></param>
        public abstract void TakeDamage(int damage);
    }
}
