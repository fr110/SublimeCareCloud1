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
    /// Interaction logic for lstTransaction.xaml
    /// </summary>
    public partial class lstTransaction : UserControl
    {
        public static dhTransactionList objFilter = new dhTransactionList();
        private dhJournalDetail obj;
        public lstTransaction()
        {
            InitializeComponent();
            this.DataContext = objFilter;

        }

        public lstTransaction(dhTransactionList obj)
        {
            InitializeComponent();
            objFilter = obj;
            this.DataContext = objFilter;
        }
        private void Stock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                //DataGridRow dgr = sender as DataGridRow;
                //// get the obect and then Invoice ID opne the Id in readonly mode

                //dhInvoice objTodisplay = new dhInvoice();
                //objTodisplay.ISaleid = ((dhInvoice)dgr.Item).ISaleid;
                //DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objTodisplay);
                //ObservableCollection<dhSaleItem> ListAccounts = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(dsr.Tables[1]);
                //ItemsList itemlist = new ItemsList().AddRange(ListAccounts);
                //objTodisplay = (dhInvoice)dgr.Item;
                //objTodisplay.ItemsOfInvoice = itemlist;
                //objTodisplay.IsReadOnly = true;
                //AddTabItem(objTodisplay);


            }
        }
        private void loadData(dhTransactionList objFilter, Boolean ShowResultCount = false)
        {
            DataTable dt = iFacede.GetTransactionsList(Globalized.ObjDbName, objFilter);
            ObservableCollection<dhTransactionList> sequence = ReflectionUtility.DataTableToObservableCollection<dhTransactionList>(dt);
            Stock.ItemsSource = sequence;
            // Globalized.ShowMsg(lblErrorMsg);
            // show msg for local search 
            if (ShowResultCount)
            {
                string msg = String.Format("  {0} Search Results Found", Stock.Items.Count);
                Globalized.setException(msg, lblErrorMsg, DataHolders.MsgType.Info);
            }
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            //if(objFilter.VItemName!=null){
            //    Itemd.Text = "Stock Detail For Item ' " + objFilter.VItemName + " '";
            //}
            loadData(objFilter, false);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            loadData(objFilter, true);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Current.Windows[1].Close();
        }
    }
}