using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhTransactionList : INotifyPropertyChanged
    {
        private  System.Nullable<int> _iJournalId;
        public System.Nullable<int> IJournalId
        {
            get { return _iJournalId; }
            set { _iJournalId = value; OnPropertyChanged("IJournalId"); }
        }
        private System.Nullable<long> _iAccountID;

        public System.Nullable<long> IAccountID
        {
            get { return _iAccountID; }
            set { _iAccountID = value; OnPropertyChanged("IAccountID"); }
        }
        private System.Nullable<Boolean> _bShowBlance;

        public System.Nullable<Boolean> BShowBlance
        {
            get { return _bShowBlance; }
            set { _bShowBlance = value; OnPropertyChanged("BShowBlance"); }
        }
       
        private System.Nullable<System.DateTime> _dTransactionFromDate;

        public System.Nullable<System.DateTime> DTransactionFromDate
        {
            get { return _dTransactionFromDate; }
            set { _dTransactionFromDate = value; OnPropertyChanged("DTransactionFromDate"); }
        }
        private System.Nullable<System.DateTime> _dTransactionToDate;

        public System.Nullable<System.DateTime> DTransactionToDate
        {
            get { return _dTransactionToDate; }
            set { _dTransactionToDate = value; OnPropertyChanged("DTransactionToDate"); }
        }
        System.Nullable<DateTime> _dEntryDateTime;

        public System.Nullable<DateTime> DEntryDateTime
        {
            get { return _dEntryDateTime; }
            set { _dEntryDateTime = value; OnPropertyChanged("DEntryDateTime"); }
        }
        System.Nullable<DateTime> _dTransactionDate;

        public System.Nullable<DateTime> DTransactionDate
        {
            get { return _dTransactionDate; }
            set { _dTransactionDate = value; OnPropertyChanged("DTransactionDate"); }
        }
        string vTranTitle;

        public string VTranTitle
        {
            get { return vTranTitle; }
            set { vTranTitle = value; OnPropertyChanged("VTranTitle"); }
        }
        string vPaymentMode;

        public string VPaymentMode
        {
            get { return vPaymentMode; }
            set { vPaymentMode = value; OnPropertyChanged("VPaymentMode"); }
        }
        System.Nullable<double> _dr;

        public System.Nullable<double> Dr
        {
            get { return _dr; }
            set { _dr = value; OnPropertyChanged("Dr"); }
        }
        System.Nullable<double> _cr;

        public System.Nullable<double> Cr
        {
            get { return _cr; }
            set { _cr = value; OnPropertyChanged("Cr"); }
        }
        string _accountName;

        public string AccountName
        {
            get { return _accountName; }
            set { _accountName = value; OnPropertyChanged("AccountName"); }
        }
        string _vModuleName;

        public string VModuleName
        {
            get { return _vModuleName; }
            set { _vModuleName = value; OnPropertyChanged("VModuleName"); }
        }
        private string _winTitle;

        public string WinTitle
        {
            get { return _winTitle; }
            set { _winTitle = value; OnPropertyChanged("WinTitle"); }
        }
        private string _winHeading;

        public string WinHeading
        {
            get { return _winHeading; }
            set { _winHeading = value; OnPropertyChanged("WinHeading"); }
        }
        private string _winDetial;

        public string WinDetial
        {
            get { return _winDetial; }
            set { _winDetial = value; OnPropertyChanged("WinDetial"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
