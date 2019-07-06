using Caliburn.Micro;
using DataHolders;
using FeserWard.Controls;
using iFacedeLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.CustomClasses
{
    public class blAccountSearch : PropertyChangedBase, IIntelliboxResultsProvider
    {

        private object _selectedAccount;
        public object SelectedAccount { get { return _selectedAccount; } set { if (value != _selectedAccount) { _selectedAccount = value; NotifyOfPropertyChange(() => SelectedAccount); } } }

        private object _selectedValue;
        public object SelectedValue { get { return _selectedValue; } set { if (value != _selectedValue) { _selectedValue = value; NotifyOfPropertyChange(() => SelectedValue); } } }

        private IIntelliboxResultsProvider _queryProvider;
        public IIntelliboxResultsProvider QueryProvider { get { return _queryProvider; } private set { if (value != _queryProvider) { _queryProvider = value; this.NotifyOfPropertyChange(() => QueryProvider); } } }
        private List<dhAccount> _results;
        //private void ConstructResultSet()
        //{
        //    dhAccount objAccount = new dhAccount();
        //    dsGeneral.dtPosAccountsDataTable dt = iFacede.GetAccount(Globalized.ObjDbName, objAccount);
        //    ObservableCollection<dhAccount> listAccount = ReflectionUtility.DataTableToObservableCollection<dhAccount>(dt);
        //    _results = new List<dhAccount>();
        //    _results = listAccount.ToList();
        //  //  _results = new List<dhAccount>();
        //    //foreach (DataRow row in dt.Rows)
        //    //{

        //    //    _results.Add(new dhAccount
        //    //    {
        //    //        //IAccountID = Convert.ToInt32(row["IAccountID"]),
        //    //        //FUnitePrice = Convert.ToDouble(row["FUnitePrice"]),
        //    //        //VAccountName = Convert.ToString(row["VAccountName"]),
        //    //        //FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
        //    //        //BIsSaleAble = string.IsNullOrEmpty(row["bIsSaleAble"].ToString()) ? Convert.ToBoolean("False") : Convert.ToBoolean(row["bIsSaleAble"].ToString())
        //    //        //VpartyMobile = Convert.ToString(row["VpartyMobile"]),
        //    //        //VPartyName = Convert.ToString(row["ReadingInches"]),
        //    //    });
        //    //}

        //}


        private void ConstructResultSet(Boolean? IncClosedAccount = true)
        {
            try
            {

                //_results = new List<dhAccount>();
                //_results = listAccount.ToList();
                _results = new List<dhAccount>();
                _results = Globalized.listAccount.ToList<dhAccount>();
                //foreach (dhAccount row in Globalized.listAccount)
                //{
                //   // if ((IncClosedAccount == false) && (row.BCloseAccount == true)) { continue; }
                //    _results.Add(new dhAccount
                //    {
                //        IAccountid = row.IAccountid,
                //        AccountName = row.AccountName,
                //     //   VPartyInfo = row.AccountName + "\n" + row.VPartyInfo,
                //        //IAccountid = Convert.ToInt32(row["iAccountid"]),
                //        //FUnitePrice = Convert.ToDouble(row["FUnitePrice"]),
                //        //VAccountName = Convert.ToString(row["VAccountName"]),
                //        //FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
                //        //BIsSaleAble = string.IsNullOrEmpty(row["bIsSaleAble"].ToString()) ? Convert.ToBoolean("False") : Convert.ToBoolean(row["bIsSaleAble"].ToString())
                //        //VpartyMobile = Convert.ToString(row["VpartyMobile"]),
                //        //VPartyName = Convert.ToString(row["ReadingInches"]),
                //    });
                //}

            }
            catch (Exception ex)
            {

            }

        }
       // public IEnumerable<object> DoSearch(string searchTerm, int maxResults, object tag)
       //{
       //     ConstructResultSet();
       //     int n;
       //     bool isNumeric = int.TryParse(searchTerm, out n);




       //     //if (tag != null)
       //     //{
       //     //    Boolean isSaleAble = tag == null ? Convert.ToBoolean("False") : Convert.ToBoolean(tag.ToString());
       //     //    //return _results.Cast<object>();
       //     //    if (isNumeric)
       //     //    {
       //     //        return _results.Where(term => term.IAccountid.Equals(n) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
       //     //    }
       //     //    else
       //     //    {
       //     //        searchTerm = searchTerm.ToLower();
       //     //        return _results.Where(term => term.VAccountName.ToString().ToLower().StartsWith(searchTerm) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
       //     //    }
       //     //}
       //     //else
       //     //{
       //     //    if (isNumeric)
       //     //    {
       //     //        return _results.Where(term => term.IAccountID.Equals(n)).Take(maxResults).Cast<object>();
       //     //    }
       //     //    else
       //     //    {
       //     searchTerm = searchTerm.ToLower();
       //     return _results.Where(term => term.AccountName != null && term.AccountName != "" && term.AccountName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();
       //     //        }
       //     //    }

       //     //}
       // }

        IEnumerable IIntelliboxResultsProvider.DoSearch(string searchTerm, int maxResults, object extraInfo)
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
            //        return _results.Where(term => term.IAccountid.Equals(n) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
            //    }
            //    else
            //    {
            //        searchTerm = searchTerm.ToLower();
            //        return _results.Where(term => term.VAccountName.ToString().ToLower().StartsWith(searchTerm) && term.BIsSaleAble == isSaleAble).Take(maxResults).Cast<object>();
            //    }
            //}
            //else
            //{
            //    if (isNumeric)
            //    {
            //        return _results.Where(term => term.IAccountID.Equals(n)).Take(maxResults).Cast<object>();
            //    }
            //    else
            //    {
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.AccountName != null && term.AccountName != "" && term.AccountName.ToString().ToLower().StartsWith(searchTerm.ToLower())).Take(maxResults).Cast<object>();
            //        }
            //    }

            //}
        }
    }
}
