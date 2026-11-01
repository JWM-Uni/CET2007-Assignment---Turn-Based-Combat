using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    public class Logger
    {
        private static Logger instance;

        private Logger()
        {

        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string message)
        {
            //Temporary message to log stuff - CHANGE TO JSON when learned
            Console.WriteLine("[LOG - " + DateTime.Now.ToString("HH:mm::ss") + "] " + message);
        }
    }
}
