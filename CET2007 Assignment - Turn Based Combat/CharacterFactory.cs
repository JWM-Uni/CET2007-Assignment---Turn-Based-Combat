using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json; //Added to allow for serialisation and deserialisation
using System.Text.Json.Serialization; //To allow for polymorphic serialisation and deserialisation of the abstract class
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class CharacterFactory
    {
        List<PlayerCombatant> characterList = new List<PlayerCombatant>();

        public void SortList()
        {
            string choice = "";
            while (choice != "id" && choice != "name")
            {
                Console.WriteLine("\nSort character list by ID or Name? (ID/Name): ");
                choice = Console.ReadLine().ToLower();
                if (choice == "id")
                {
                    for (int i = 0; i < characterList.Count - 1; i++)
                    {
                        for (int j = 0; j < characterList.Count - i - 1; j++)
                        {
                            if (characterList[i].ID > characterList[j + 1].ID)
                            {
                                PlayerCombatant temp = characterList[j];
                                characterList[j] = characterList[j + 1];
                                characterList[j + 1] = temp;
                            }
                        }
                    }
                    Console.WriteLine("Sorted character list by ID.");
                    Logger.GetInstance().Log("Player chose to sort character list by ID.");
                }
                else if (choice == "name")
                {
                    characterList.Sort();
                    Console.WriteLine("Sorted character list by Name.");
                    Logger.GetInstance().Log("Player chose to sort character list by Name.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please input a valid choice.");
                }
            }
        }

        public PlayerCombatant CreateCharacter()
        {
            //Loads the data from the json file into list if one exists, or creates a new list and adds new character data to it
            const string JsonPath = "characterData.json";
            JsonManager jsonSaveLoad = new JsonManager();
            try
            {
                if (File.Exists(JsonPath))
                {
                    characterList = jsonSaveLoad.LoadCharacterData();
                }
                else
                {
                    Console.WriteLine("No data found, starting new list.");

                    //Creates a list and objects of the available characters, then adds the characters to the list if the file was not loaded
                    characterList = new List<PlayerCombatant>();
                    Knight knight = new Knight();
                    Archer archer = new Archer();
                    Mage mage = new Mage();
                    characterList.Add(knight);
                    characterList.Add(archer);
                    characterList.Add(mage);
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.GetInstance().Log("Error loading character data: " + ex.Message);
                Console.WriteLine("Error loading character data: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }

            //Calls the previously established sort list function to sort by ID or Name
            SortList();

            //Saves the list of character's data to a json by serialising it
            try
            {
                jsonSaveLoad.SaveCharacterData(characterList);
            }
            catch (Exception ex)
            {
                Logger.GetInstance().Log("Error saving character data: " + ex.Message);
                Console.WriteLine("Error saving character data: " + ex.Message);
            }


            //Shows available characters.
            foreach (PlayerCombatant character in characterList)
            {
                character.CharacterInfo();
            }

            //Allows the user to make a choice on what character they want to play
            Console.WriteLine("\n=== Available Characters ===" +
                "\n1) Knight" +
                "\n2) Archer" +
                "\n3) Mage" +
                "\nEnter a character: "
                );
            string characterChoice = Console.ReadLine().ToLower(); //ADD EXTRA VALIDATION HERE TO ENSURE ONLY CHARACTERS ARE ENTERED
            PlayerCombatant chosenCharacter = null;

            //Performs a linear search through the character list to select the player's chosen character
            int index = -1;
            for (int i = 0; i < characterList.Count; i++)
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
            return chosenCharacter; //FIX ISSUE OF CHARACTER NOT BEING RETURNED IF UNFOUND
        }
    }
}
