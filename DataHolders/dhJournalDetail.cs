using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhJournalDetail: INotifyPropertyChanged
    {
        private int _iJournalDetailId;

        public int IJournalDetailId
        {
            get { return _iJournalDetailId; }
            set { _iJournalDetailId = value; OnPropertyChanged("IJournalDetailId"); }
        }

        private System.Nullable<int> _iJournalId;

        public System.Nullable<int> IJournalId
        {
            get { return _iJournalId; }
            set { _iJournalId = value; OnPropertyChanged("IJournalId"); }
        }

        private string _vTransactionType;

        public string VTransactionType
        {
            get { return _vTransactionType; }
            set { _vTransactionType = value; OnPropertyChanged("VTransactionType"); }
        }

        private System.Nullable<int> _iAccountID;

        public System.Nullable<int> IAccountID
        {
            get { return _iAccountID; }
            set { _iAccountID = value; OnPropertyChanged("IAccountID"); }
        }
       
        private System.Nullable<double> _fAmount;

        public System.Nullable<double> FAmount
        {
            get { return _fAmount; }
            set { _fAmount = value; OnPropertyChanged("FAmount"); }
        }

        private System.Nullable<System.DateTime> _dEntryDateTime;

        public System.Nullable<System.DateTime> DEntryDateTime
        {
            get { return _dEntryDateTime; }
            set { _dEntryDateTime = value; OnPropertyChanged("DEntryDateTime"); }
        }

        private string _vReceivedBy;

        public string VReceivedBy
        {
            get { return _vReceivedBy; }
            set { _vReceivedBy = value; OnPropertyChanged("VReceivedBy"); }
        }

        private string _vVoucherNo;

        public string VVoucherNo
        {
            get { return _vVoucherNo; }
            set { _vVoucherNo = value; OnPropertyChanged("VVoucherNo"); }
        }

        private string _vdescription;

        public string Vdescription
        {
            get { return _vdescription; }
            set { _vdescription = value; OnPropertyChanged("Vdescription"); }
        }

        private System.Nullable<int> _iChequeNumber;

        public System.Nullable<int> IChequeNumber
        {
            get { return _iChequeNumber; }
            set { _iChequeNumber = value; OnPropertyChanged("IChequeNumber"); }
        }

        private string _vBankAccountNumber;

        public string VBankAccountNumber
        {
            get { return _vBankAccountNumber; }
            set { _vBankAccountNumber = value; OnPropertyChanged("VBankAccountNumber"); }
        }

        private string _vPaymentMode;

        public string VPaymentMode
        {
            get { return _vPaymentMode; }
            set { _vPaymentMode = value; OnPropertyChanged("VPaymentMode"); }
        }

        private string _vModuleFK_Table;

        public string VModuleFK_Table
        {
            get { return _vModuleFK_Table; }
            set { _vModuleFK_Table = value; OnPropertyChanged("VModuleFK_Table"); }
        }

        private string _vModuleFK_Name;

        public string VModuleFK_Name
        {
            get { return _vModuleFK_Name; }
            set { _vModuleFK_Name = value; OnPropertyChanged("VModuleFK_Name"); }
        }

        private System.Nullable<int> _iModuleFK_ID;

        public System.Nullable<int> IModuleFK_ID
        {
            get { return _iModuleFK_ID; }
            set { _iModuleFK_ID = value; OnPropertyChanged("IModuleFK_ID"); }
        }

        private string _AccountName;

        public string AccountName
        {
            get { return _AccountName; }
            set { _AccountName = value; OnPropertyChanged("AccountName"); }
        }

        private string _vAccountNo;

        public string VAccountNo
        {
            get { return _vAccountNo; }
            set { _vAccountNo = value; OnPropertyChanged("VAccountNo"); }
        }

        private System.Nullable<int> _iUpdate;

        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
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
