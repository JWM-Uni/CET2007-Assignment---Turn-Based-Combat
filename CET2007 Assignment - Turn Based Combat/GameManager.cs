using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Manages all operations needed to run the game, controlling the turn based process, player and enemy actions, and the game's outcomes
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Gets or sets the player object
        /// </summary>
        public PlayerCombatant Player { get; private set; }
        /// <summary>
        /// Gets or sets the enemy object
        /// </summary>
        public EnemyCombatant Enemy { get; private set; }
        /// <summary>
        /// Creates a variable to store an AttackObserver
        /// </summary>
        private AttackObserver DamageObserver;
        /// <summary>
        /// Default constructor that sets the player and enemy objects to null
        /// </summary>
        public GameManager()
        {
            Player = null;
            Enemy = null;
        }
        /// <summary>
        /// Parameterised constructor that sets the player and enemy to specified objects
        /// </summary>
        /// <param name="player"></param>
        /// <param name="enemy"></param>
        public GameManager(PlayerCombatant player, EnemyCombatant enemy)
        {
            Player = player;
            Enemy = enemy;
        }

        /// <summary>
        /// Subscribes to the GameManager to the AttackObserver
        /// </summary>
        /// <param name="damageObserver"></param>
        public void SubscribeToObserver(AttackObserver damageObserver)
        {
            DamageObserver = damageObserver;
        }

        /// <summary>
        /// Notifies the observer that a damage calculation is needed and receives the result
        /// </summary>
        /// <param name="attackValue"></param>
        /// <param name="defenceValue"></param>
        /// <returns>The calculated damage of the attack</returns>
        public int NotifyDamageCalculation(int attackValue, int defenceValue)
        {
            DamageObserver.OnDamageCalculation(attackValue, defenceValue);
            return DamageObserver.ActualDamage;
        }

        /// <summary>
        /// Runs the main game process, managing the player's actions each turn as well as the enemy's action.
        /// It also manages the result of the game and any operations as a result of the players actions.
        /// </summary>
        public void RunGame()
        {
            //Resets the log to record this instance of the game
            Logger.GetInstance().ResetLog();
            Logger.GetInstance().Log("Game started.");

            //Creates all the variables and objects the game needs to run
            int turnCount = 1;
            bool gameRunning = true;
            //Subscribes to the AttackObserver for damage calculations
            AttackObserver attack = new AttackObserver();
            SubscribeToObserver(attack);

            //While loop to keep running until either one side has no health remaining, or the game is exited.
            while ((Player.Health > 0 || Enemy.Health > 0) && gameRunning)
            {
                //Manages the player's action per turn
                string playerAction = "";
                bool defending = false;

                Logger.GetInstance().Log("Turn " + turnCount);

                //Loops while an action is unselected + outputs current state of each character's health
                while (playerAction == "")
                {
                    Console.WriteLine("\nTurn " + turnCount + " | " + Player.Name + "'s Health: " + Player.Health + " | " + Enemy.Name + "'s Health: " + Enemy.Health);
                    playerAction = Player.ActionSelection();
                }

                //Controls which action the player has selected for their turn and carries out the correct action
                switch (playerAction)
                {
                    case "1": //Manages the player's attack action
                        int damage = NotifyDamageCalculation(Player.BasicAttack(), 0);
                        Enemy.TakeDamage(damage);
                        break;

                    case "2": //Manages the player's defending action/status
                        defending = Player.Defend();
                        break;

                    case "3": //Manages the player's skill action
                        damage = NotifyDamageCalculation(Player.Skill(), 0);
                        Enemy.TakeDamage(damage);
                        break;

                    case "4": //Manages the output of the selected character's information
                        Player.CharacterInfo();
                        Logger.GetInstance().Log("Player decided to view their character information.");
                        break;

                    case "5": //Breaks the loop to exit the game
                        gameRunning = false;
                        break;

                    default: //Default case for if an invalid choice was entered
                        Console.WriteLine("Invalid choice. Please enter a valid choice (1-5)");
                        break;
                }

                //Checks to see if enemy has died to end the game process before they take their turn
                if (Enemy.Health <= 0)
                {
                    break;
                }

                //Prevents the enemy from taking their action for the turn and advancing turn count until the player picks either attack, defend, or to use their skill
                if (playerAction == "1" || playerAction == "2" || playerAction == "3")
                {
                    //Manages the enemy's action per turn
                    if (defending)
                    {
                        //Includes player's defence in damage calculation if player is defending this turn
                        int damage = NotifyDamageCalculation(Enemy.BasicAttack(), Player.Defence);
                        Player.TakeDamage(damage);
                        defending = false;
                    }
                    else
                    {
                        //Accounts only for enemy damage since player is not defending
                        int damage = NotifyDamageCalculation(Enemy.BasicAttack(), 0);
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
