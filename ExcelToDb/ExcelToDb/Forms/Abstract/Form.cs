using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb.Forms.Abstract
{
    abstract class Form : System.Windows.Forms.Form
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Form()
        {
            IntializeComponents();    
        }
        /// <summary>
        /// Initializes the local components of the class
        /// </summary>
        public void IntializeComponents()
        {

        }
        /// <summary>
        /// Writes to the console
        /// </summary>
        /// <param name="output">output to be written</param>
        public void writeToConsole(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}
