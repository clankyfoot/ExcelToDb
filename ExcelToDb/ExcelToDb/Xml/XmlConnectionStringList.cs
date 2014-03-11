using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDb.Xml
{
    /// <summary>
    /// Holds a collection of the Connection Strings
    /// </summary>
    class XmlConnectionStringList
    {
        /// <summary>
        /// collection of connection objects
        /// </summary>
        private ExcelToDb.Xml.XmlConnectionString[] connections { get; set; }
        /// <summary>
        /// Xml document to read from. 
        /// Configuration File
        /// </summary>
        private System.Xml.XmlDocument doc { get; set; }
        /// <summary>
        /// Number of available connection;
        /// </summary>
        private int length;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public XmlConnectionStringList()
        {
            InitializeComponents();
        }
        /// <summary>
        /// Initializes local components in the class
        /// </summary>
        private void InitializeComponents()
        {
            doc = new System.Xml.XmlDocument();
            doc.Load("Databases.xml");
            length = 0;
            //
            // loads up all the documents into an array
            //
            foreach(System.Xml.XmlNode data in doc.SelectNodes("/Configuration/Databases/"))
            {
                connections[length] = new XmlConnectionString();
                foreach(System.Xml.XmlNode node in data)
                {
                    connections[length].GetType().GetProperty(node.Name).SetValue(connections[length], node.InnerText);
                }
                length++; // this will most likely cause An IndexOutOfBounds Exception somewhere
            }
        }
        /// <summary>
        /// Gets the connections
        /// <returns>A collection of string object with the connection names</returns>
        /// </summary>
        public string[] getConnectionNames()
        {

        }

        public string loadAttributes(string connectionName)
        {

        }
    }
}
