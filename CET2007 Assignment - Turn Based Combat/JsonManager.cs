using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class JsonManager
    {
        public JsonManager() { }
        const string JsonPath = "characterData.json";

        public List<PlayerCombatant> LoadCharacterData()
        {
            string JsonData = File.ReadAllText(JsonPath);
            List<PlayerCombatant> tempList = JsonSerializer.Deserialize<List<PlayerCombatant>>(JsonData);
            string load = "Loaded " + tempList.Count + " character's data from file.";
            Console.WriteLine(load);
            Logger.GetInstance().Log(load);
            return tempList;
        }

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
