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
        public PlayerCombatant CreateCharacter()
        {
            //Loads the data from the json file into list if one exists, or creates a new list and adds new character data to it
            List<PlayerCombatant> characterList = new List<PlayerCombatant>();
            const string JsonPath = "characterData.json";
            try
            {
                if (File.Exists(JsonPath))
                {
                    string JsonData = File.ReadAllText(JsonPath);
                    characterList = JsonSerializer.Deserialize<List<PlayerCombatant>>(JsonData);
                    string load = "Loaded " + characterList.Count + " character's data from file.";
                    Console.WriteLine(load);
                    Logger.GetInstance().Log(load);
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

            //Saves the list of character's data to a json by serialising it
            try
            {
                string JsonData = JsonSerializer.Serialize(characterList);
                File.WriteAllText(JsonPath, JsonData);
                string save = "Character data saved successfully.";
                Console.WriteLine(save);
                Logger.GetInstance().Log(save);
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
