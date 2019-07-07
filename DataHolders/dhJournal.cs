using System.ComponentModel;

namespace DataHolders
{
    public class dhJournal : INotifyPropertyChanged
    {
        private int _iJournalId;

        public int IJournalId
        {
            get { return _iJournalId; }
            set { _iJournalId = value; OnPropertyChanged("IJournalId"); }
        }

        private System.Nullable<double> _fAmount;

        public System.Nullable<double> FAmount
        {
            get { return _fAmount; }
            set { _fAmount = value; OnPropertyChanged("FAmount"); }
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

        private string _vTranTitle;

        public string VTranTitle
        {
            get { return _vTranTitle; }
            set { _vTranTitle = value; OnPropertyChanged("VTranTitle"); }
        }

        private System.Nullable<System.DateTime> _dSystemEntryDateTime;

        public System.Nullable<System.DateTime> DSystemEntryDateTime
        {
            get { return _dSystemEntryDateTime; }
            set { _dSystemEntryDateTime = value; OnPropertyChanged("DSystemEntryDateTime"); }
        }

        private System.Nullable<System.DateTime> _dTransactionDate;

        public System.Nullable<System.DateTime> DTransactionDate
        {
            get { return _dTransactionDate; }
            set { _dTransactionDate = value; OnPropertyChanged("DTransactionDate"); }
        }

        private System.Nullable<int> _iUserId;

        public System.Nullable<int> IUserId
        {
            get { return _iUserId; }
            set { _iUserId = value; OnPropertyChanged("IUserId"); }
        }

        private System.Nullable<int> _iUpdate;

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        private JournalDetailList _drList;

        public JournalDetailList DrList
        {
            get { return _drList; }
            set { _drList = value; OnPropertyChanged("DrList"); }
        }

        private JournalDetailList _cRList;

        public JournalDetailList CRList
        {
            get { return _cRList; }
            set { _cRList = value; OnPropertyChanged("CRList"); }
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