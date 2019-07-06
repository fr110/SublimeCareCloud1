/* 
    Writen by M Atif ALi 12-01-2012
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace DataHolders
{
    public class dhSalary : INotifyPropertyChanged
    {

        private int _iSalId;
        private System.Nullable<int> _iEmpId;
        private System.Nullable<bool> _bIsPaid;
        private System.Nullable<System.DateTime> _dSrtDate;
        private System.Nullable<System.DateTime> _dEndDate;
        private System.Nullable<int> _iDays;
        private System.Nullable<int> _iHours;
        private System.Nullable<int> _iTranId;
        private System.Nullable<System.DateTime> _dPaidDate;
        private System.Nullable<System.DateTime> _dGenratedDate;
        private System.Nullable<double> _iAmount;
        private System.Nullable<double> _iDeduction;
        private string _vSortColumn;
        private string _vSortOrder;
        private int iUpdate;
        private System.Nullable<double> iAmountPaid;
        private System.Nullable<double> iAbsentdays;
        private System.Nullable<double> fOverTime;
        private System.Nullable<double> iOverTimeAmount;
        private int iProjid;

    
        public dhSalary()
        {
        }


        public int iSalId
        {
            get
            {
                return this._iSalId;
            }
            set
            {
                this._iSalId = value; OnPropertyChanged("iSalId"); 
            }
        }
        public System.Nullable<int> iEmpId
        {
            get
            {
                return this._iEmpId;
            }
            set
            {
                this._iEmpId = value; OnPropertyChanged("iEmpId"); 
            }
        }
        public System.Nullable<bool> bIsPaid
        {
            get
            {
                return this._bIsPaid;
            }
            set
            {
                this._bIsPaid = value; OnPropertyChanged("bIsPaid"); 
            }
        }
        public System.Nullable<System.DateTime> dSrtDate
        {
            get
            {
                return this._dSrtDate;
            }
            set
            {
                this._dSrtDate = value; OnPropertyChanged("dSrtDate"); 
            }
        }
        public System.Nullable<System.DateTime> dEndDate
        {
            get
            {
                return this._dEndDate;
            }
            set
            {
                this._dEndDate = value; OnPropertyChanged("dEndDate"); 
            }
        }
        public System.Nullable<int> iDays
        {
            get
            {
                return this._iDays;
            }
            set
            {
                this._iDays = value; OnPropertyChanged("iDays"); 
            }
        }
        public System.Nullable<int> iHours
        {
            get
            {
                return this._iHours;
            }
            set
            {
                this._iHours = value; OnPropertyChanged("iHours"); 
            }
        }
        public System.Nullable<int> iTranId
        {
            get
            {
                return this._iTranId;
            }
            set
            {
                this._iTranId = value; OnPropertyChanged("iTranId"); 
            }
        }
        public System.Nullable<System.DateTime> dPaidDate
        {
            get
            {
                return this._dPaidDate;
            }
            set
            {
                this._dPaidDate = value; OnPropertyChanged("dPaidDate"); 
            }
        }
        public System.Nullable<System.DateTime> dGenratedDate
        {
            get
            {
                return this._dGenratedDate;
            }
            set
            {
                this._dGenratedDate = value; OnPropertyChanged("dGenratedDate"); 
            }
        }
        public System.Nullable<double> iAmount
        {
            get
            {
                return this._iAmount;
            }
            set
            {
                this._iAmount = value == null ? 0 : Math.Round(value.Value, 2); OnPropertyChanged("iAmount"); 
            }
        }
        public System.Nullable<double> iDeduction
        {
            get
            {
                return this._iDeduction;
            }
            set
            {
                this._iDeduction = value == null ? 0 : Math.Round(value.Value, 2) ; OnPropertyChanged("iDeduction"); 
            }
        }
        public string VSortColumn
        {
            get { return _vSortColumn; }
            set { _vSortColumn = value; OnPropertyChanged("VSortColumn"); }
        }


        public string VSortOrder
        {
            get { return _vSortOrder; }
            set { _vSortOrder = value; OnPropertyChanged("VSortOrder"); }
        }

       public int IUpdate
        {
            get { return iUpdate; }
            set { iUpdate = value; OnPropertyChanged("IUpdate"); }
        }
       private System.Nullable<int> _iBasicSalary;

       public System.Nullable<int> IBasicSalary
       {
           get { return _iBasicSalary; }
           set { _iBasicSalary = value; OnPropertyChanged("IBasicSalary"); }
       }

       private System.Nullable<int> _iTraveling;

       public System.Nullable<int> ITraveling
       {
           get { return _iTraveling; }
           set { _iTraveling = value; OnPropertyChanged("ITraveling"); }
       }

       private System.Nullable<int> _iHousing;

       public System.Nullable<int> IHousing
       {
           get { return _iHousing; }
           set { _iHousing = value; OnPropertyChanged("IHousing"); }
       }

       private System.Nullable<int> _iMiscellaneous;

       public System.Nullable<int> IMiscellaneous
       {
           get { return _iMiscellaneous; }
           set { _iMiscellaneous = value; OnPropertyChanged("IMiscellaneous"); }
       }

       private System.Nullable<int> _iHourlyRate;

       public System.Nullable<int> IHourlyRate
       {
           get { return _iHourlyRate; }
           set { _iHourlyRate = value; OnPropertyChanged("IHourlyRate"); }
       }

       private string _vEmployeeType;

       public string VEmployeeType
       {
           get { return _vEmployeeType; }
           set { _vEmployeeType = value; OnPropertyChanged("VEmployeeType"); }
       }

       private string _vTimeSheetID;

       public string VTimeSheetID
       {
           get { return _vTimeSheetID; }
           set { _vTimeSheetID = value; OnPropertyChanged("VTimeSheetID"); }
       }

       public System.Nullable<double> IAmountPaid
       {
           get { return iAmountPaid; }
           set { iAmountPaid = value; OnPropertyChanged("IAmountPaid"); }
       }

       public System.Nullable<double> IAbsentdays
       {
           get { return iAbsentdays; }
           set { iAbsentdays = value == null ? 0 : Math.Round(value.Value, 2) ;  OnPropertyChanged("IAbsentdays"); }
       }
       public System.Nullable<double> FOverTime
       {
           get { return fOverTime; }
           set { fOverTime = value == null ? 0 : Math.Round(value.Value, 2) ; OnPropertyChanged("FOverTime"); }
       }


       public System.Nullable<double> IOverTimeAmount
       {
           get { return iOverTimeAmount; }
           set { iOverTimeAmount = value == null ? 0 : Math.Round(value.Value, 2) ;  OnPropertyChanged("IOverTimeAmount"); }
       }
       public int IProjid
       {
           get { return iProjid; }
           set { iProjid = value; OnPropertyChanged("IProjid"); }
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
