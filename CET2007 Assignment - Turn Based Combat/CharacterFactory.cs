using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class CharacterFactory
    {
        public PlayerCombatant CreateCharacter(string type)
        {
            type = type.ToLower();
            if (type == "knight")
            {
                Knight knight = new Knight();
                Logger.GetInstance().Log("Created character: Knight");
                return knight;
            }
            else if (type == "archer")
            {
                Archer archer = new Archer();
                Logger.GetInstance().Log("Created character: Archer");
                return archer;
            }
            else if (type == "mage")
            {
                Mage mage = new Mage();
                Logger.GetInstance().Log("Created character: Mage");
                return mage;
            }
            else
            {
                //THROW AN EXCEPTION HERE FOR INVALID CHARACTER CLASS
                return null;
            }
        }
    }
}
