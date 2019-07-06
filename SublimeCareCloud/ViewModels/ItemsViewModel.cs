using Caliburn.Micro;
using DataHolders;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    class ItemsViewModel : Screen
    {
        private ObservableCollection<dhItems> _Items ;

        public ItemsViewModel()
        {
            DisplayName = "Items";
            dhItems objLoad = new dhItems();
            this.loadData(objLoad);
        }

        public ObservableCollection<dhItems> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        private void loadData(dhItems objItem /* , Boolean ShowResultCount = false*/)
        {
            dsGeneral.dtPosItemsDataTable dtItems = iFacede.GetItems(Globalized.ObjDbName, objItem);
            Items = ReflectionUtility.DataTableToObservableCollection<dhItems>(dtItems);
        }
    }
}
