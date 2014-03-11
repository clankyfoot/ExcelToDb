using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb.Xml.Interfaces
{
    interface IXmlConnectionString
    {
        /// <summary>
        /// Gets the connection tag from the Xml document as an element
        /// </summary>
        /// <returns></returns>
        System.Xml.XmlElement getAsElement();
        /// <summary>
        /// Writes the current connection Tag to a xml file
        /// </summary>
        /// <param name="filename">name of the file</param>
        /// <returns></returns>
        bool write(string filename);
        /// <summary>
        /// Writes output to the console
        /// </summary>
        /// <param name="output">output to the console</param>
        void writeToConsole(string output);
    }
}
