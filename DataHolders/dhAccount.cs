using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{

    [Table("posAccounts")]
    public class dhAccount : INotifyPropertyChanged
  {
        public dhAccount()
        {
            this.IUpdate = 0;
        }
      private long? _iAccountid;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long? IAccountid
      {
          get { return _iAccountid; }
          set { _iAccountid = value; OnPropertyChanged("IAccountid"); }
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

      private string _vAccountDesc;

      public string VAccountDesc
      {
          get { return _vAccountDesc; }
          set { _vAccountDesc = value; OnPropertyChanged("VAccountDesc"); }
      }

      private string _vAccountComments;

      public string VAccountComments
      {
          get { return _vAccountComments; }
          set { _vAccountComments = value; OnPropertyChanged("VAccountComments"); }
      }

      private System.Nullable<bool> _bEditable;

      public System.Nullable<bool> BEditable
      {
          get { return _bEditable; }
          set { _bEditable = value; OnPropertyChanged("BEditable"); }
      }

      private System.Nullable<int> _iFinaceType;

      public System.Nullable<int> IFinaceType
      {
          get { return _iFinaceType; }
          set { _iFinaceType = value; OnPropertyChanged("IFinaceType"); }
      }

      private System.Nullable<int> _iModuleID;

      public System.Nullable<int> IModuleID
      {
          get { return _iModuleID; }
          set { _iModuleID = value; OnPropertyChanged("IModuleID"); }
      }

      private System.Nullable<long> _iModuleFK_ID;

      public System.Nullable<long> IModuleFK_ID
      {
          get { return _iModuleFK_ID; }
          set { _iModuleFK_ID = value; OnPropertyChanged("IModuleFK_ID"); }
      }

      private System.Nullable<bool> _bNominal;

      public System.Nullable<bool> BNominal
      {
          get { return _bNominal; }
          set { _bNominal = value; OnPropertyChanged("BNominal"); }
      }

       

        private string _vFinaceType;
        [NotMapped]
        public string VFinaceType
      {
          get { return _vFinaceType; }
          set { _vFinaceType = value; OnPropertyChanged("VFinaceType"); }
      }
       
        private string _vFinaceTypeDes;
        [NotMapped]
        public string VFinaceTypeDes
      {
          get { return _vFinaceTypeDes; }
          set { _vFinaceTypeDes = value; OnPropertyChanged("VFinaceTypeDes"); }
      }

        // add for list change the binding
        private ObservableCollection<dhFinanceType> _FinanceTypeList;
        public ObservableCollection<dhFinanceType> FinanceTypeList
        {
            get { return _FinanceTypeList; }
            set { _FinanceTypeList = value; OnPropertyChanged("VFinaceTypeDes"); }
        }

      private System.Nullable<int> _iUpdate;
        [NotMapped]
        public System.Nullable<int> IUpdate
      {
          get { return _iUpdate; }
          set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
      }

      private string _holderName;
        [NotMapped]
        public string HolderName
      {
          get { return _holderName; }
          set { _holderName = value; OnPropertyChanged("HolderName"); }
      }
      private string _vAccountNature;
        [NotMapped]
        public string VAccountNature
      {
          get { return _vAccountNature; }
          set { _vAccountNature = value; OnPropertyChanged("VAccountNature"); }
      }
      private string _Accountbalance;
        [NotMapped]
        public string Accountbalance
      {
          get { return _Accountbalance; }
          set { _Accountbalance = value; OnPropertyChanged("Accountbalance"); }
      }
      private string _vAccType;
        [NotMapped]
        public string VAccType
      {
          get { return _vAccType; }
          set { _vAccType = value; OnPropertyChanged("VAccType"); }
      }
      private string _VTypeToFilter;
        [NotMapped]
        public string VTypeToFilter
      {
          get { return _VTypeToFilter; }
          set { _VTypeToFilter = value; OnPropertyChanged("VTypeToFilter"); }
      }

      private System.Nullable<double> _dr;
        [NotMapped]
        public System.Nullable<double> Dr
      {
          get { return _dr; }
          set { _dr = value; OnPropertyChanged("Dr"); }
      }
      private System.Nullable<double> _cr;
        [NotMapped]
        public System.Nullable<double> Cr
      {
          get { return _cr; }
          set { _cr = value; OnPropertyChanged("Cr"); }
      }
      private System.Nullable<double> _balance;
        [NotMapped]
        public System.Nullable<double> Balance
      {
          get { return _balance; }
          set { _balance = value; OnPropertyChanged("Balance"); }
      }


      private string _blancType;
        [NotMapped]
      public string BlancType
      {
          get { return _blancType; }
          set { _blancType = value; OnPropertyChanged("BlancType"); }
      }
      private System.Nullable<System.DateTime> _dTransactionFromDate;

        [NotMapped]
        public System.Nullable<System.DateTime> DTransactionFromDate
      {
          get { return _dTransactionFromDate; }
          set { _dTransactionFromDate = value; OnPropertyChanged("DTransactionFromDate"); }
      }


      private System.Nullable<System.DateTime> _dTransactionToDate;
        [NotMapped]
        public System.Nullable<System.DateTime> DTransactionToDate
      {
          get { return _dTransactionToDate; }
          set { _dTransactionToDate = value; OnPropertyChanged("DTransactionToDate"); }
      }
      System.Nullable<DateTime> _dEntryDateTime;
        [NotMapped]
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
