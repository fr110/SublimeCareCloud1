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
  public  class blAppPreference 
    {
        dalGeneral objDALGeneral;

        public blAppPreference()
        {
            objDALGeneral = new dalGeneral();
        }
        internal DataSet InsertUpdateAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateAppPreference(objDBNames, objPreference);
            return ds;
        }

        internal dsGeneral.dtAppPreferenceDataTable GetAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            dsGeneral.dtAppPreferenceDataTable dt = objDALGeneral.GetAppPreference(objDBNames, objPreference);
             return dt;
        }
    }
}