using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CET2007_Assignment___Turn_Based_Combat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creates a character factory to create and select the player's choice of character
            CharacterFactory characters = new CharacterFactory();
            PlayerCombatant player = characters.CreateCharacter();

            //Creates the enemy for the game
            EnemyCombatant enemy = new EnemyCombatant();

            //Creates a game manager and passes the created player and enemy characters as parameters, then runs the game
            GameManager gameManager = new GameManager(player, enemy);
            gameManager.RunGame();
        }
    }
}
