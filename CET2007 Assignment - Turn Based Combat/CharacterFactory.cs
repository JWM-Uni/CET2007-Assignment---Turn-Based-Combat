using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class CharacterFactory
    {
        public PlayerCombatant CreateCharacter()
        {
            //Creates a list and objects of the available characters, then adds the characters to the list
            List<PlayerCombatant> characterList = new List<PlayerCombatant>();
            Knight knight = new Knight();
            Archer archer = new Archer();
            Mage mage = new Mage();
            characterList.Add(knight);
            characterList.Add(archer);
            characterList.Add(mage);

            //Allows the user to make a choice on what character they want to play
            Console.WriteLine("=== Available Characters ===" +
                "\n1) Knight" +
                "\n2) Archer" +
                "\n3) Mage" +
                "\nEnter a character: "
                );
            string characterChoice = Console.ReadLine().ToLower(); //ADD EXTRA VALIDATION HERE TO ENSURE ONLY CHARACTERS ARE ENTERED
            PlayerCombatant chosenCharacter = null;

            //Performs a linear search through the character list to select the player's chosen character
            int index = -1;
            for (int i = 0; i < characterList.Count; i++) //EDIT FROM HERE
            {
                if (characterList[i].Type.ToLower() == characterChoice)
                {
                    Console.WriteLine("Creating character: " + characterList[i].Type);
                    chosenCharacter = characterList[i];
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Character type not found in list.");
            }
            return chosenCharacter;
        }
    }
}
