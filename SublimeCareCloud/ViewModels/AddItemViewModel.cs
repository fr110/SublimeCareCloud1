using Caliburn.Micro;
using DataHolders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    class AddItemViewModel : Screen, INotifyPropertyChanged
    {
        private dhItems  _GlobalObjItem;
        public AddItemViewModel()
         {
            

         }
        public dhItems GlobalObj
        {
            get { return _GlobalObjItem; }
            set { _GlobalObjItem = value; }
        }


        public AddItemViewModel(dhItems objItem)
        {
            this.GlobalObj = objItem;
        }
    }
}
