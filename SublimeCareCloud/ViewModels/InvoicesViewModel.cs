using Caliburn.Micro;
using DataHolders;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    class InvoicesViewModel : Screen, INotifyPropertyChanged
    {
        private ObservableCollection<dhInvoice> _Invoices;

        //= new ObservableCollection<dhParty>();
        public InvoicesViewModel()
        {
            DisplayName = "Invoices";
            dhInvoice objLoad = new dhInvoice();
            this.loadData(objLoad);
        }

        public ObservableCollection<dhInvoice> Invoices
        {
            get { return _Invoices; }
            set { _Invoices = value; }
        }

        private void loadData(dhInvoice objInovice/* , Boolean ShowResultCount = false*/)
        {

            DataSet dtInovice = iFacede.GetSaleInovice(Globalized.ObjDbName, objInovice);
            Invoices = ReflectionUtility.DataTableToObservableCollection<dhInvoice>(dtInovice.Tables[0]);
        }

    }
}
