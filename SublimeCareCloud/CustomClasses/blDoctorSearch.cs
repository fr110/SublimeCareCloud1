using BL;
using DAL;
using DataHolders;
using FeserWard.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.CustomClasses
{
    public class blDoctorSearch : IIntelliboxResultsProvider
    {
        private List<dhDoctorView> _results;
        private blDoctor objBlDocotor;
        public blDoctorSearch(blDoctor objBlDocotor)
        {
            this.objBlDocotor = objBlDocotor;
        }
        public  blDoctorSearch()
        {
            this.objBlDocotor = new blDoctor();
        }
        private void ConstructResultSet(Boolean extraInfo = false)
        {
            this._results = objBlDocotor.DoctorList.Where(x => x.BActive == true).ToList();
        }
        public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            if ((extraInfo != null) && (extraInfo.ToString() == "true"))
            {
                ConstructResultSet(true);
            }
            else
            {
                ConstructResultSet();
            }
            //return _results.Cast<object>();
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.VfName.ToString().ToLower().Contains(searchTerm) ).Take(maxResults).Cast<object>();

        }
    }
}
