using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class CombatSelection
    {
        private Combatant Player {  get; set; }

        public CombatSelection(Combatant player)
        {
            Player = player;
        }

        public string ActionSelection()
        {
            string choice = "";
            while (choice == "" || choice == "5")
            {
                Console.WriteLine("=== Choose an action ===" +
                "1) Attack" +
                "2) Defend" +
                "3) " + Player.SkillName +
                "4) Show Character Information" +
                "5) Quit Game" +
                "Enter your choice: "
                );
                choice = Console.ReadLine();
                if (choice == "4")
                {
                    Player.CharacterInfo();
                }
            }
            return choice;
        }
    }
}
