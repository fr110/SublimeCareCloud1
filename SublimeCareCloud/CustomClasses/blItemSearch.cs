using DataHolders;
using FeserWard.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iFacedeLayer;
using System.Data;
using Caliburn.Micro;
using System.Collections;

namespace SublimeCareCloud.CustomClasses
{
    public class blItemSearch :PropertyChangedBase, IIntelliboxResultsProvider
    {
        private object _selectedItem;
        public object SelectedItem { get { return _selectedItem; } set { if (value != _selectedItem) { _selectedItem = value; NotifyOfPropertyChange(() => SelectedItem); } } }

        private object _selectedValue;
        public object SelectedValue { get { return _selectedValue; } set { if (value != _selectedValue) { _selectedValue = value; NotifyOfPropertyChange(() => SelectedValue); } } }

        private IIntelliboxResultsProvider _queryProvider;
        public IIntelliboxResultsProvider QueryProvider { get { return _queryProvider; } private set { if (value != _queryProvider) { _queryProvider = value; this.NotifyOfPropertyChange(() => QueryProvider); } } }

        private List<dhItems> _results;

        private void ConstructResultSet()
        {
            dhItems objitem = new dhItems();
            dsGeneral.dtPosItemsDataTable dt = iFacede.GetItems(Globalized.ObjDbName, objitem);
            _results = new List<dhItems>();
            foreach (DataRow row in dt.Rows)
            {

                _results.Add(new dhItems
                {
                    IItemID = Convert.ToInt32(row["IItemID"]),
                    FUnitePrice = Convert.ToDouble(row["FUnitePrice"]),
                    VItemName = Convert.ToString(row["VItemName"]),
                //    FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
                    BIsSaleAble = string.IsNullOrEmpty(row["bIsSaleAble"].ToString()) ? Convert.ToBoolean("False") : Convert.ToBoolean(row["bIsSaleAble"].ToString()),
                    VItemBarcode = row["vItemBarcode"].ToString()
                    //VpartyMobile = Convert.ToString(row["VpartyMobile"]),
                    //VPartyName = Convert.ToString(row["ReadingInches"]),
                });
            }

        }

        //public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo, object tag)
        //{
        //    ConstructResultSet();
        //    int n;
        //    bool isNumeric = int.TryParse(searchTerm, out n);




        //    if (tag != null)
        //    {
        //        Boolean isSaleAble = tag == null ? Convert.ToBoolean("False") : Convert.ToBoolean(tag.ToString());
        //        //return _results.Cast<object>();
        //        if (isNumeric)
        //        {
        //            return _results.Where(term => term.VItemBarcode.Equals(n) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
        //        }
        //        else
        //        {
        //            searchTerm = searchTerm.ToLower();
        //            return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
        //        }
        //    }
        //    else
        //    {
        //        if (isNumeric)
        //        {
        //            return _results.Where(term => term.IItemID.Equals(n)).Take(maxResults).Cast<object>();
        //        }
        //        else
        //        {
        //            searchTerm = searchTerm.ToLower();
        //            return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();
        //        }
        //    }

        //}

        public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            ConstructResultSet();
            int n;
            bool isNumeric = int.TryParse(searchTerm, out n);




            //if (tag != null)
            //{
            //    Boolean isSaleAble = tag == null ? Convert.ToBoolean("False") : Convert.ToBoolean(tag.ToString());
            //    //return _results.Cast<object>();
            //    if (isNumeric)
            //    {
            //        return _results.Where(term => term.VItemBarcode.Equals(n) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
            //    }
            //    else
            //    {
            //        searchTerm = searchTerm.ToLower();
            //        return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
            //    }
            //}
            //else
            //{
            //    if (isNumeric)
            //    {
            //        return _results.Where(term => term.IItemID.Equals(n)).Take(maxResults).Cast<object>();
            //    }
            //    else
            //    {
            //        searchTerm = searchTerm.ToLower();
            //        return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();
            //    }
            //}
             return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();

        }

        //public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<object> DoSearch(string searchTerm, int maxResults, object tag)
        //{
        //    ConstructResultSet();
        //    int n;
        //    bool isNumeric = int.TryParse(searchTerm, out n);




        //    if (tag != null)
        //    {
        //        Boolean isSaleAble = tag == null ? Convert.ToBoolean("False") : Convert.ToBoolean(tag.ToString());
        //        //return _results.Cast<object>();
        //        if (isNumeric)
        //        {
        //            return _results.Where(term => term.VItemBarcode.Equals(n) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
        //        }
        //        else
        //        {
        //            searchTerm = searchTerm.ToLower();
        //            return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
        //        }
        //    }
        //    else
        //    {
        //        if (isNumeric)
        //        {
        //            return _results.Where(term => term.IItemID.Equals(n)).Take(maxResults).Cast<object>();
        //        }
        //        else
        //        {
        //            searchTerm = searchTerm.ToLower();
        //            return _results.Where(term => term.VItemName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();
        //        }
        //    }

        //}
    }
}
