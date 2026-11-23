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
            //Creates a game manager
            GameManager gameManager = new GameManager();

            //Opens the menu and lets the player choose options or start the game
            string startOrExit = gameManager.GameMenu();

            //If start game (1) was the output of GameMenu, runs the game, otherwise the program ends
            if (startOrExit == "1")
            {
                gameManager.RunGame();
            }
            else { }
        }
    }
}
