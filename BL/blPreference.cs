using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class blPreference
    {
        dalGeneral objDALGeneral;

        public blPreference()
        {
            objDALGeneral = new dalGeneral();
        }
        internal dsGeneral.dtPosPreferenceDataTable GetPreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            dsGeneral.dtPosPreferenceDataTable dt = objDALGeneral.GetPreference(objDBNames, objPreference);
            return dt;
        }

        internal System.Data.DataSet InsertUpdatePreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdatePreference(objDBNames, objPreference);
            return ds;
        }

        internal dsGeneral.dtAppPreferenceDataTable GetAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            dsGeneral.dtAppPreferenceDataTable dt = objDALGeneral.GetAppPreference(objDBNames, objPreference);
             return dt;
        }
    }
}
