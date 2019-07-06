using Caliburn.Micro;
using DataHolders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SublimeCareCloud.ViewModels
{
    class AddPartyViewModel : Screen, INotifyPropertyChanged
    {
        private dhParty _GlobalObjParty;

        public AddPartyViewModel()
        {
            
            this.GlobalObjParty = new dhParty();
            //  DisplayName = "New Party";
        }

        public AddPartyViewModel(dhParty objTodisplay)
        {
            this.GlobalObjParty = objTodisplay;
        }

        public dhParty GlobalObjParty 
            {
                get { return _GlobalObjParty; }
                set { _GlobalObjParty = value; //OnPropertyChanged("IUpdate");
                    }
            }

        //public event PropertyChangedEventHandler propertychanged;
        //protected virtual void onpropertychanged(string propertyname)
        //{
        //    PropertyChangedEventHandler handler = propertychanged;
        //    if (handler != null) handler(this, new PropertyChangedEventHandler(propertyname));
        //}
    }
}
