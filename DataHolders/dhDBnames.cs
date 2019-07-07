// ----------------------------------------------------------------------
// The name of ALLAH Almighty, The Most Beneficient and The Most Merciful
// Author           <Asjad Ali>
// Create Date      <12-Aug-2011>
// Modify Date      <Date>
// ----------------------------------------------------------------------

namespace DataHolders
{
    public class dhDBnames
    {
        public dhDBnames()
        {
            DBUser = "sa";
            DBPassword = "sa";
            //DBPassword = "ammar";  // change here
            Control_DB = "ePractice";
        }

        public string ServerName;
        public string Default_DB_Name;
        public string Control_DB;
        public string XmlFilePath;
        public string DBUser;
        public string DBPassword;
        public string LogFolderPath;
        public string DateFormat;
        public bool EnableFileLogging;
        public string ExecutingPath;
    }
}