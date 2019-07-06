using Caliburn.Micro;
using DataHolders;
using System.Collections.ObjectModel;

namespace SublimeCareCloud.ViewModels
{
    class AddInvoiceViewModel: Screen 
    {
        private ObservableCollection<dhInvoice> _GlobalDhObjec;
        public AddInvoiceViewModel()
        {

        }

        public ObservableCollection<dhInvoice> GlobalDhObjec
        {
            get { return _GlobalDhObjec; }
            set { _GlobalDhObjec = value; }
        }



    }
}
