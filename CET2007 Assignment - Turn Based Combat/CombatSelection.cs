using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class CombatSelection
    {
        private PlayerCombatant Player {  get; set; }

        public CombatSelection(PlayerCombatant player)
        {
            Player = player;
        }

        public string ActionSelection()
        {
            string choice = "";
            while (choice == "" || choice == "5")
            {
                Console.WriteLine("\n=== Choose an action ===" +
                "\n1) Attack" +
                "\n2) Defend" +
                "\n3) " + Player.SkillName +
                "\n4) Show Character Information" +
                "\n5) Quit Game" +
                "\nEnter your choice: "
                );
                //NEEDS ERROR HANDLING HERE FOR IF THE USER ENTERS SOMETHING WRONG
                choice = Console.ReadLine();
                return choice;
            }
            return choice;
        }
    }
}
