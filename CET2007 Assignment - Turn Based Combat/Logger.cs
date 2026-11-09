using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CET2007_Assignment___Turn_Based_Combat
{
    /// <summary>
    /// Manages all logging operations for the program
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Creates a single logger instance
        /// </summary>
        private static Logger instance;
        /// <summary>
        /// Creates a single log path for the text file
        /// </summary>
        private static readonly string logPath = "log.txt";

        /// <summary>
        /// Default constructor for a logger
        /// </summary>
        private Logger() { }

        /// <summary>
        /// Allows other areas in the program to access the private logger instance
        /// </summary>
        /// <returns>The single logger instance</returns>
        public static Logger GetInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        /// <summary>
        /// Logs the time and a specified message to the console and the log text file
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            string entry = "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + "\n";
            File.AppendAllText(logPath, entry);
        }

        /// <summary>
        /// Resets the log by overwriting all the text with a blank string
        /// </summary>
        public void ResetLog()
        {
            File.WriteAllText(logPath, string.Empty);
        }
    }
}
