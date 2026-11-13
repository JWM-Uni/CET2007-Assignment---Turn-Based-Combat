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
            Console.WriteLine("Choose a character: ");
            string choice = Console.ReadLine();
            CharacterFactory characters = new CharacterFactory();
            PlayerCombatant player = characters.CreateCharacter(choice);
            EnemyCombatant enemy = new EnemyCombatant();
            GameManager gameManager = new GameManager(player, enemy);
            gameManager.RunGame();
        }
    }
}
