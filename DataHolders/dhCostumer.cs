using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhCostumer : INotifyPropertyChanged
    {
        private long _CostumerID;

        public long CostumerID
        {
            get { return _CostumerID; }
            set { _CostumerID = value; OnPropertyChanged("CostumerID"); }
        }

        private string _CostumerName;

        public string CostumerName
        {
            get { return _CostumerName; }
            set { _CostumerName = value; OnPropertyChanged("CostumerName"); }
        }

        private string _CostumerBikeNumber;

        public string CostumerBikeNumber
        {
            get { return _CostumerBikeNumber; }
            set { _CostumerBikeNumber = value; OnPropertyChanged("CostumerBikeNumber"); }
        }

        private string _CostumerMobileNumber;

        public string CostumerMobileNumber
        {
            get { return _CostumerMobileNumber; }
            set { _CostumerMobileNumber = value; OnPropertyChanged("CostumerMobileNumber"); }
        }

        private System.Nullable<System.DateTime> _CostumerLastVisit;

        public System.Nullable<System.DateTime> CostumerLastVisit
        {
            get { return _CostumerLastVisit; }
            set { _CostumerLastVisit = value; OnPropertyChanged("CostumerLastVisit"); }
        }


        private string _CostumerInfo;

        public string CostumerInfo
        {
            get { return _CostumerInfo; }
            set { _CostumerInfo = value; OnPropertyChanged("CostumerLastVisit"); }
        }
        private string _MeterReading;

        public string MeterReading
        {
            get { return _MeterReading; }
            set { _MeterReading = value; OnPropertyChanged("CostumerLastVisit"); }
        }
        private string _ModelNumber;

        public string ModelNumber
        {
            get { return _ModelNumber; }
            set { _ModelNumber = value; OnPropertyChanged("CostumerLastVisit"); }
        }

        private System.Nullable<int> _iUpdate;
        public System.Nullable<int> IUpdate
        {
            get { return _iUpdate; }
            set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
        }

        private System.Nullable<Boolean> _bFallowUp;

        public System.Nullable<Boolean> BFallowUp
        {
            get { return _bFallowUp; }
            set { _bFallowUp = value; OnPropertyChanged("BFallowUp"); }
        }
        private System.Nullable<System.DateTime> _dLastInovice;

        public System.Nullable<System.DateTime> DLastInovice
        {
            get { return _dLastInovice; }
            set { 
                _dLastInovice = value; 
                OnPropertyChanged("DLastInovice");
                //if(value != null)
                //{
                //    DAlertDate = ((DateTime)value).AddDays(40);
                //}
             
            }
        }
        private System.Nullable<System.DateTime> _dAlertDate;

        public System.Nullable<System.DateTime> DAlertDate
        {
            get { return _dAlertDate; }
            set { _dAlertDate = value; OnPropertyChanged("DAlertDate"); }
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
