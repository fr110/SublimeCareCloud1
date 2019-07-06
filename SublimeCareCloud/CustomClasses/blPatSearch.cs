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
   public class blPatSearch : IIntelliboxResultsProvider
    {
        private List<dhPatient> _results;
        private AppDbContext Ldb;
        public blPatSearch()
        {
            this.Ldb = new AppDbContext();
        }
        private void ConstructResultSet(Boolean extraInfo = false)
        {
            this._results = Ldb.Patients.AsNoTracking().Where(x => x.bActive == true).ToList();
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
            return _results.Where(term => term.vFullName.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        }
    }
}
