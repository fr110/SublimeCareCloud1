using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using System.Collections.ObjectModel;

namespace SublimeCareCloud.ViewModels
{
    class AccountsViewModel : Screen, INotifyPropertyChanged
    {
        private ObservableCollection<dhAccount> _AccountList;

        public AccountsViewModel()
        {


        }

        public ObservableCollection<dhAccount> AccountList
        {
                get { return _AccountList; }
                set { _AccountList = value; OnPropertyChanged("AccountList"); }
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
