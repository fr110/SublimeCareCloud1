using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHolders
{
    public class dhVMS_Com
    {
        private string _vehicleID;
        private string _vehicleID_arabic;
        private string _CountryName;
        private string _CountryName_arabic;
        private string _Driver_Name;
        private string _Driver_Gender;
        private string _Driver_Age;
        private string _Threat_level;
        private string _Comments;
        private string _EXT_SCAN_ID;

        public dhVMS_Com()
        {

        }

        public string vehicleID
        {
            set { _vehicleID = value; }
            get { return _vehicleID; }
        }

        public string vehicleID_arabic
        {
            set { _vehicleID_arabic = value; }
            get { return _vehicleID_arabic; }
        }

        public string CountryName
        {
            set { _CountryName = value; }
            get { return _CountryName; }
        }

        public string CountryName_arabic
        {
            set { _CountryName_arabic = value; }
            get { return _CountryName_arabic; }
        }

        public string Driver_Name
        {
            set { _Driver_Name = value; }
            get { return _Driver_Name; }
        }
        
        public string Driver_Gender
        {
            set { _Driver_Gender = value; }
            get { return _Driver_Gender; }
        }

        public string Driver_Age
        {
            set { _Driver_Age = value; }
            get { return _Driver_Age; }
        }

        public string Threat_level
        {
            set { _Threat_level = value; }
            get { return _Threat_level; }
        }

        public string Comments
        {
            set { _Comments = value; }
            get { return _Comments; }
        }

        public string EXT_SCAN_ID
        {
            set { _EXT_SCAN_ID = value; }
            get { return _EXT_SCAN_ID; }
        }
      
    }
}
