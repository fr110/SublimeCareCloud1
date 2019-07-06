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
    public class InvestigationSearch : IIntelliboxResultsProvider
    {
        private AppDbContext db = new AppDbContext();
       // private AppDbContext thisdb;
        public InvestigationSearch()
        {
            //thisdb = db;
        }


        private List<Investigations> _results;
        private void ConstructResultSet()
        {
            Investigations objparty = new Investigations();
            // dsGeneral.dtPosPartyDataTable dt = iFacede.GetParty(Globalized.ObjDbName, objparty);
            _results = new List<Investigations>();
            _results = db.Investigations.Where(x => x.bIsActive == true).ToList();
            //foreach (DataRow row in dt.Rows)
            //{

            //    _results.Add(new dhParty
            //    {
            //        IPartyID = Convert.ToInt32(row["IPartyID"]),
            //        VPartyName = Convert.ToString(row["VPartyName"]),
            //        VPartyadress = Convert.ToString(row["VPartyadress"]),
            //        VpartyMobile = Convert.ToString(row["VpartyMobile"]),
            //        VPartyInfo = Convert.ToString(row["VPartyName"]) + " , " + Convert.ToString(row["VPartyadress"]) + " , " + Convert.ToString(row["VpartyMobile"]),
            //        //VItemName = Convert.ToString(row["VItemName"]),
            //        //FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
            //        //VpartyMobile = Convert.ToString(row["VpartyMobile"]),
            //        //VPartyName = Convert.ToString(row["ReadingInches"]),
            //    });
            //}

        }

        //public IEnumerable<object> DoSearch(string searchTerm, int maxResults, object extraInfo)
        //{
        //    ConstructResultSet();
        //    //return _results.Cast<object>();
        //    searchTerm = searchTerm.ToLower();
        //    return _results.Where(term => term.VInvName.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        //}

        IEnumerable IIntelliboxResultsProvider.DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            ConstructResultSet();
            //return _results.Cast<object>();
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.VInvName.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        }
    }
}
