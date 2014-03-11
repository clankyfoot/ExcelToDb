using System;
using System.Text;

namespace ExcelToDb.Xml
{
    /// <summary>
    /// Represnts an element in the XmlConfigurationFile
    /// Additions reesource info on Connections strings
    /// <see cref="http://msdn.microsoft.com/en-us/library/jj653752(v=vs.110).aspx"/>
    /// </summary>
    class XmlConnectionString : Xml.Interfaces.IXmlConnectionString
    {
        /// <summary>
        /// name of the Connection String
        /// </summary>
        public string name{ get; set; }
        /// <summary>
        /// Server to connection to, local or Domain based
        /// <example>10.134.23.123</example>
        /// <example>/Domain/myDatabase</example>
        /// </summary>
        public string Server{ get; set; }
        /// <summary>
        /// Name of the database (Only included if the "server" tag is include)
        /// <example>MyDatabase</example>
        /// <example>/MyDatabase/database</example>
        /// </summary>
        public string Database{ get; set; }
        /// <summary>
        /// Initial Cataglog (Optional)
        /// </summary>
        public string InitialCatalog{ get; set; }
        /// <summary>
        /// Name of the Database to Attach (Optional)
        /// </summary>
        public string AttachDbFileName{ get; set; }
        /// <summary>
        /// Initial Local Data source
        /// <example>(LocalDb)\.SQLEXPRESS</example>
        /// <example>(LocalDb)\v11.0</example>
        /// </summary>
        public string DataSource{ get; set; }
        /// <summary>
        /// Does the Connection String have Integrated Security
        /// <example>True, False</example>
        /// </summary>
        public IntegratedSecurity IntegratedSecurity{ get; set; }
        /// <summary>
        /// Does the Database allow for User Instances?
        /// <example>True, False</example>
        /// </summary>
        public UserInstance UserInstance{ get; set; }
        /// <summary>
        /// If the Database requires a username
        /// <example>User</example>
        /// </summary>
        public string uid{ get; set; }
        /// <summary>
        /// If the database needs a passworrd (Requred if the "username" tag is used"){ get; set; }
        /// <example>Password</example>
        /// </summary>
        public string password{ get; set; }
        /// <summary>
        /// True, Authentication is done by the domain, and authorization is handled by SQL Server
        /// False, Authentication is done through a Username, and Password
        /// </summary>
        public TrustedConnection TrustedConnection{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NetworkLibrary{ get; set; }
        /// <summary>
        /// If the connection fails, which server should it send the command to?
        /// </summary>
        public string FailOverPartner{ get; set; }
        /// <summary>
        /// Is the process being done Asynchronous. 
        /// This is most likely False
        /// </summary>
        public AsynchronousProcessing AsynchronousProcessing{ get; set; }
        /// <summary>
        /// The provider of the connection
        /// <example>System.Data.SqlClient</example>
        /// <example>System.Data.Entity</example>
        /// </summary>
        public string provider{ get; set; }
        /// <summary>
        /// Generates itself as a XmlElement
        /// <element Prefix="someValue" Value="someValue"></element>
        /// </summary>
        /// <returns></returns>
        public System.Xml.XmlElement getAsElement()
        {
            System.Xml.XmlElement node = new System.Xml.XmlElement();
            
            if (!String.IsNullOrEmpty(Server)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "Server", Value = Server }); }
            if (!String.IsNullOrEmpty(Database)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "database", Value = Database }); }
            if (!String.IsNullOrEmpty(InitialCatalog)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "InitialCatalog", Value = InitialCatalog }); }
            if (!String.IsNullOrEmpty(AttachDbFileName)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "AttachDbFileName", Value = AttachDbFileName }); }
            if (!String.IsNullOrEmpty(DataSource)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "DataSource", Value = DataSource }); }
            if (!String.IsNullOrEmpty(uid)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "uid", Value = uid }); }
            if (!String.IsNullOrEmpty(password)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "password", Value = password }); }
            if (!String.IsNullOrEmpty(provider)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "provider", Value = provider }); }
            if (!String.IsNullOrEmpty(FailOverPartner)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "FailOverPartner", Value = FailOverPartner }); }
            if (!String.IsNullOrEmpty(NetworkLibrary)) { node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "NetworkLibrary", Value = NetworkLibrary }); }
            
            // append the Enum values
            node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "IntegratedSecurity", Value = IntegratedSecurity.ToString() });
            node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = " UserInstance", Value = UserInstance.ToString() });
            node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "TrustedConnection", Value = TrustedConnection.ToString() });
            node.Attributes.Append(new System.Xml.XmlAttribute() { Prefix = "AsynchronousProcessing", Value = AsynchronousProcessing.ToString() });

            return node;
        }
        /// <summary>
        /// Writes the object to the XmlDoc
        /// <param name="filename">Name of the file to write the Xml to</param>
        /// </summary>
        /// <returns></returns>
        public bool write(string filename)
        {
            bool written = false;
            try
            { 

                System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(filename);
                writer.WriteStartElement("Configuration");
                writer.WriteStartElement("Databases");
                writer.WriteStartElement("connection");

                foreach(System.Reflection.PropertyInfo info in this.GetType().GetProperties())
                {
                    if(info.GetValue(this) != null)
                    {
                        writer.WriteAttributeString(info.Name, info.GetValue(this).ToString());
                    }
                }

                writer.WriteEndElement(); // writes </connection> closing tag
                writer.WriteEndElement(); // writes </Databases> closing tag
                writer.WriteEndElement(); // writes </Configuration> closing tag
                writer.Close();
                written = true;
            }
            catch(ArgumentException arEx)
            {
                writeToConsole(arEx.Message);
                written = false;
            }

            return written;
        }
        /// <summary>
        /// Writes a message to the console
        /// </summary>
        /// <param name="output">output to be printed to the Console</param>
        public void writeToConsole(string output)
        {
            System.Console.WriteLine(output);
        }
    }
    /// <summary>
    /// Is the Connection Trusted?
    /// </summary>
    public enum TrustedConnection
    {
        True, False
    }
    /// <summary>
    /// Are User Instances allowed?
    /// </summary>
    public enum UserInstance
    {
        True, False
    }
    /// <summary>
    /// Is the process Asynchronous?
    /// </summary>
    public enum AsynchronousProcessing
    {
        True, False
    }
    /// <summary>
    /// Type of connection security
    /// </summary>
    public enum IntegratedSecurity
    {
        True, SSPI
    }
}
