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
    /// <summary>
    /// Manages the player's character creation/selection
    /// </summary>
    public class CharacterFactory
    {
        /// <summary>
        /// Creates a list to store the 3 character's data
        /// </summary>
        private List<PlayerCombatant> characterList = new List<PlayerCombatant>();
        /// <summary>
        /// Creates and assigns a set filepath to a string
        /// </summary>
        const string JsonPath = "characterData.json";
        /// <summary>
        /// Creates a new JsonManager object
        /// </summary>
        private JsonManager jsonSaveLoad = new JsonManager();

        /// <summary>
        /// Allows the user to choose between sorting the character selection menu by either ID or Name using bubble sort or built-in .Sort()
        /// </summary>
        public void SortList()
        {
            string choice = "";
            while (choice != "id" && choice != "name") //Loops until a valid choice is selected
            {
                Console.WriteLine("\nSort character list by ID or Name? (ID/Name): ");
                choice = Console.ReadLine().ToLower();
                if (choice == "id") //Handles sorting the list by ID (manual bubble sort implementation)
                {
                    for (int i = 0; i < characterList.Count - 1; i++)
                    {
                        for (int j = 0; j < characterList.Count - i - 1; j++)
                        {
                            if (characterList[j].ID > characterList[j + 1].ID)
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
                else if (choice == "name") //Handles sorting the list by name (automatic built-in sort)
                {
                    characterList.Sort();
                    Console.WriteLine("Sorted character list by Name.");
                    Logger.GetInstance().Log("Player chose to sort character list by Name.");
                }
                else //Outputs invalid choice method and loops
                {
                    Console.WriteLine("Invalid choice. Please input a valid choice.");
                }
            }
        }

        /// <summary>
        /// Loads the character data into the list from the json file or constructs a new list
        /// </summary>
        public void LoadData()
        {
            //Loads the data from the json file into list if one exists, or creates a new list and adds new character data to it
            try
            {
                if (File.Exists(JsonPath)) //Loads the data if the json file is found
                {
                    characterList = jsonSaveLoad.LoadCharacterData();
                }
                else //If the file was not found, creates a fresh list of character data
                {
                    Console.WriteLine("No data found, starting new list.");

                    characterList = new List<PlayerCombatant>();
                    Knight knight = new Knight();
                    Archer archer = new Archer();
                    Mage mage = new Mage();
                    characterList.Add(knight);
                    characterList.Add(archer);
                    characterList.Add(mage);
                }
            }
            catch (FileNotFoundException ex) //Handles the error for no file being located
            {
                Logger.GetInstance().Log("Error loading character data: " + ex.Message);
                Console.WriteLine("Error loading character data: " + ex.Message);
            }
            catch (Exception ex) //Handles general errors with loading the character data from json
            {
                Logger.GetInstance().Log("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves the character data currently in the list to the json file
        /// </summary>
        public void SaveData()
        {
            try //Saves the list of character's data to a json by serialising it
            {
                jsonSaveLoad.SaveCharacterData(characterList);
            }
            catch (Exception ex) //Handles general errors with saving the character data to a json
            {
                Logger.GetInstance().Log("Error saving character data: " + ex.Message);
                Console.WriteLine("Error saving character data: " + ex.Message);
            }
        }

        /// <summary>
        /// Searches for the requested character in the list and outputs there index
        /// </summary>
        public void SearchCharacter()
        {
            string searchChoice = "";
            while (searchChoice != "knight" && searchChoice != "archer" && searchChoice != "mage")
            {
                Console.WriteLine("\nEnter the character you are searching for (Knight/Archer/Mage): ");
                searchChoice = Console.ReadLine();
            }
            //Performs a linear search through the character list to select the player's chosen character
            int index = -1;
            for (int i = 0; i < characterList.Count; i++)
            {
                if (characterList[i].Type.ToLower() == searchChoice.ToLower())
                {
                    index = i;
                    break;
                }
            }
            Console.WriteLine("");
            if (index == -1) //Outputs a message if the character is not found in the list
            {
                Console.WriteLine("Character type not found in list.");
            }
            else //Outputs the character's position in the list
            {
                Console.WriteLine(searchChoice + " exists and was found at index " + index);
            }
        }

        /// <summary>
        /// Shows the character information for all characters in the list
        /// </summary>
        public void ViewCharacterList()
        {
            //Shows available characters.
            foreach (PlayerCombatant character in characterList)
            {
                character.CharacterInfo();
            }
        }

        /// <summary>
        /// Outputs the character information for each character in the list and then lets the player select a character.
        /// Searches the list for the character and then returns it
        /// </summary>
        /// <returns>A subclass of PLayerCombatant based on which character the user chose</returns>
        public PlayerCombatant CreateCharacter()
        {
            //Shows available characters.
            foreach (PlayerCombatant character in characterList)
            {
                character.CharacterInfo();
            }

            //Ensures it will loop until a valid character type is entered
            string characterChoice = "";
            while (characterChoice != "knight" && characterChoice != "archer" && characterChoice != "mage")
            {
                //Allows the user to make a choice on what character they want to play
                Console.WriteLine("\n=== Available Characters ===" +
                    "\n1) Knight" +
                    "\n2) Archer" +
                    "\n3) Mage" +
                    "\nEnter a character (Knight/Archer/Mage): "
                    );
                characterChoice = Console.ReadLine().ToLower();
                if (characterChoice != "knight" && characterChoice != "archer" && characterChoice != "mage")
                {
                    Console.WriteLine("\nPlease pick a valid character type.");
                }
            }
            
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
            if (index == -1) //Outputs a message if the character is not found in the list
            {
                Console.WriteLine("Character type not found in list.");
            }
            return chosenCharacter;
        }
    }
}
