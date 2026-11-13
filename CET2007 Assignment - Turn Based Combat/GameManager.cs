using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class GameManager
    {
        public PlayerCombatant Player { get; set; }
        public EnemyCombatant Enemy { get; set; }
        
        public GameManager()
        {
            Player = null;
            Enemy = null;
        }
        public GameManager(PlayerCombatant player, EnemyCombatant enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        public void RunGame()
        {
            //Resets the log to record this instance of the game
            Logger.GetInstance().ResetLog();
            Logger.GetInstance().Log("Game started.");

            //Creates all the variables and objects the game needs to run
            CombatSelection playerTurn = new CombatSelection(Player);
            int turnCount = 1;
            bool gameRunning = true;

            //While loop to keep running until either one side has no health remaining, or the game is exited.
            while ((Player.Health > 0 || Enemy.Health > 0) && gameRunning)
            {
                //Manages the player's action per turn
                string playerAction = "";
                AttackObserver attack = new AttackObserver();
                bool defending = false;

                //Loops while an action
                while (playerAction == "") //NEEDS FIXING TO INCLUDE ERRORS FROM NO VALID INPUTS BEING SELECTED
                {
                    playerAction = playerTurn.ActionSelection();
                }

                //Controls which action the player has selected for their turn and carries out the correct action
                switch (playerAction)
                {
                    case "1":
                        int damage = attack.DamageCalculation(Player.BasicAttack(), 0);
                        Enemy.TakeDamage(damage);
                        break;

                    case "2":
                        defending = Player.Defend();
                        break;

                    case "3":
                        damage = attack.DamageCalculation(Player.Skill(), 0);
                        Enemy.TakeDamage(damage);
                        break;

                    case "4":
                        Player.CharacterInfo();
                        break;

                    case "5":
                        gameRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid choice (1-5)");
                        break;
                }

                if (Enemy.Health <= 0)
                {
                    break;
                }

                //Prevents the enemy from taking their action for the turn and advancing turn count until the player picks an option other than show their summary or quitting the game
                if (playerAction != "4" && playerAction != "5")
                {
                    //Manages the enemy's action per turn
                    if (defending)
                    {
                        int damage = attack.DamageCalculation(Enemy.BasicAttack(), Player.Defence);
                        Player.TakeDamage(damage);
                        defending = false;
                    }
                    else
                    {
                        int damage = attack.DamageCalculation(Enemy.BasicAttack(), 0);
                        Player.TakeDamage(damage);
                    }

                    //Increments the turn count by 1 at the end of both character's actions for the round
                    turnCount++;
                }
            }

            //Outcomes of the Game

            if (Player.Health <= 0) //Lose condition
            {
                Console.WriteLine("\nYour health has been reduced to 0. You lose.");
                Logger.GetInstance().Log("Player health reduced to 0. Player lost the game.");
            }
            else if (Enemy.Health <= 0) //Win condition
            {
                Console.WriteLine("\nYou reduced the enemy's health to 0. You win!");
                Logger.GetInstance().Log("Enemy health reduced to 0. Player won the game.");
            }
            else //Quitting game
            {
                Console.WriteLine("\nQuitting game.");
                Logger.GetInstance().Log("Player chose to quit the game. No winner.");
            }
            Console.WriteLine("\nThank you for playing!");
            Logger.GetInstance().Log("Game ended.");
        }
    }
}
