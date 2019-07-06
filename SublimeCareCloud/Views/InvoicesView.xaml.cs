using DataHolders;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for InvoicesView.xaml
    /// </summary>
    public partial class InvoicesView : UserControl
    {
        public InvoicesView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            dhInvoice objInvoice = new dhInvoice();


           // loadData(objInvoice);


        }

        private void Invoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode

                dhInvoice objTodisplay = new dhInvoice();
                objTodisplay.ISaleid = ((dhInvoice)dgr.Item).ISaleid;

                DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objTodisplay);
                objTodisplay = (dhInvoice)dgr.Item;
                if ((dsr.Tables.Count > 0) && (dsr.Tables[0].Rows.Count > 0))
                {
                    ObservableCollection<dhInvoice> objlist = ReflectionUtility.DataTableToObservableCollection<dhInvoice>(dsr.Tables[0]);
                    objTodisplay = (dhInvoice)objlist.SingleOrDefault();
                }

                if ((dsr.Tables.Count > 0) && (dsr.Tables[1].Rows.Count > 0))
                {
                    ObservableCollection<dhSaleItem> listItem = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(dsr.Tables[1]);
                    ItemsList itemlist = new ItemsList().AddRange(listItem);
                    objTodisplay.ItemsOfInvoice = itemlist;
                }

                //DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objTodisplay);
                //ObservableCollection<dhSaleItem> ListAccounts = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(dsr.Tables[1]);
                //ItemsList itemlist = new ItemsList().AddRange(ListAccounts);
                //objTodisplay = (dhInvoice)dgr.Item;
                if (objTodisplay.BIsDraft != true)
                {
                    objTodisplay.IsReadOnly = true;
                }
                else
                {
                    objTodisplay.IsReadOnly = false;
                }
                // AddTabItem(objTodisplay);


            }
        }
    }
}
