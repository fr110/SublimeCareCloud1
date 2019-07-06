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
   public class ProcedureSearch : IIntelliboxResultsProvider
    {
        private AppDbContext db = new AppDbContext();
        // private AppDbContext thisdb;
        public ProcedureSearch()
        {
            //thisdb = db;
        }


        private List<dhProcedure> _results;
        private void ConstructResultSet()
        {
            dhProcedure objparty = new dhProcedure();
            // dsGeneral.dtPosPartyDataTable dt = iFacede.GetParty(Globalized.ObjDbName, objparty);
            _results = new List<dhProcedure>();
            _results = db.Procedures.Where(x => x.BIsActive == true).ToList();
           

        }

       

        IEnumerable IIntelliboxResultsProvider.DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            ConstructResultSet();
            //return _results.Cast<object>();
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.VProcedureName.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        }
    }
}
