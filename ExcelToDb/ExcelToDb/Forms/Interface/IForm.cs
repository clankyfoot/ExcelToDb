using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb.Forms.Interface
{
    interface IForm
    {
        /// <summary>
        /// Intializes the local components of the class
        /// </summary>
        void IntializeComponents();
        /// <summary>
        /// Writes a string to the console for output
        /// </summary>
        /// <param name="output"></param>
        void writeToConsole(string output);
    }
}
