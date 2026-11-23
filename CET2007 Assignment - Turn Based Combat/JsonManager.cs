using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Manages serialising and deserialising character data to the json file
    /// Kept separate to encapsulate file access
    /// </summary>
    public class JsonManager
    {
        /// <summary>
        /// Sets a constant value defining where the character data json is located
        /// </summary>
        private const string JsonPath = "characterData.json";

        /// <summary>
        /// Loads the character data into a list from a json file and returns it
        /// </summary>
        /// <returns>A list containing all the character data</returns>
        public List<PlayerCombatant> LoadCharacterData()
        {
            string JsonData = File.ReadAllText(JsonPath);
            List<PlayerCombatant> tempList = JsonSerializer.Deserialize<List<PlayerCombatant>>(JsonData);
            string load = "Loaded " + tempList.Count + " character's data from file.";
            Console.WriteLine(load);
            Logger.GetInstance().Log(load);
            return tempList;
        }

        /// <summary>
        /// Takes a list of character data as an input and saves the data to a json file
        /// </summary>
        /// <param name="characterData"></param>
        public void SaveCharacterData(List<PlayerCombatant> characterData)
        {

            string JsonData = JsonSerializer.Serialize(characterData);
            File.WriteAllText(JsonPath, JsonData);
            string save = "Character data saved successfully.";
            Console.WriteLine(save);
            Logger.GetInstance().Log(save);
        }
    }
}
