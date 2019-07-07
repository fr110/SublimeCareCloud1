using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataHolders;
using SublimeCareCloud.etc;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddInvoiceView.xaml
    /// </summary>
    public partial class AddInvoiceView : UserControl
    {


        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        static Int64 TabCounter = 0;


        public AddInvoiceView()
        {
            InitializeComponent();
            try
            {
                InitializeComponent();
                _tabItems = new List<TabItem>();
                _tabAdd = new TabItem();
                _tabAdd.Header = "+";
                _tabAdd.MouseLeftButtonUp += new MouseButtonEventHandler(tabAdd_MouseLeftButtonUp);
                _tabItems.Add(_tabAdd);
                this.AddTabItem();
                this.AddTabItem();
                this.AddTabItem();
                this.AddTabItem();
                this.AddTabItem();
                this.AddTabItem();
                tabDynamic.DataContext = _tabItems;
                tabDynamic.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private TabItem AddTabItem()
        {
            int count = _tabItems.Count;
            TabItem tab = new TabItem();
            //            tab.Header = "Add Invoice";//string.Format("Tab {0}", count);
            //tab.Name = "AddInvoice";//string.Format("tab{0}", count);
            tab.Header = string.Format("Lift {0}", TabCounter + 1);//string.Format("Tab {0}", count);
            tab.Name = string.Format("Lift{0}", TabCounter);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            dhInvoice NewItem = new dhInvoice();
            //   NewItem
            tab.Content = new EmptyInvoiceView();
            _tabItems.Insert(count - 1, tab);
            TabCounter++;
            return tab;
        }

        private void tabAdd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tabDynamic.DataContext = null;
            TabItem tab = this.AddTabItem();
            tabDynamic.DataContext = _tabItems;
            tabDynamic.SelectedItem = tab;
        }

        private void tab_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tab = sender as TabItem;
            TabProperty dlg = new TabProperty();
            dlg.txtTitle.Text = tab.Header.ToString();
            if (dlg.ShowDialog() == true)
            {
                // change header text
                tab.Header = dlg.txtTitle.Text.Trim();
            }
        }

        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;
            if (tab == null) return;

            if (tab.Equals(_tabAdd))
            {
                tabDynamic.DataContext = null;
                TabItem newTab = this.AddTabItem();
                tabDynamic.DataContext = _tabItems;
                tabDynamic.SelectedItem = newTab;
            }
            else
            {
                // your code here...
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();
            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;
            if (tab != null)
            {
                if (_tabItems.Count < 2)
                {
                    MessageBox.Show("At least one invoice should be in queue you can’t remove this invoice.");
                }
                else
                    if (MessageBox.Show(string.Format("Any Unsaved Data will be loss, Are you sure to close this invoice?"),
                    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;
                    tabDynamic.DataContext = null;
                    _tabItems.Remove(tab);
                    tabDynamic.DataContext = _tabItems;
                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
        }

        private void ItemBarCode_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dhItems ObjDhInputItem = new dhItems();
                    if (ItemBarCode.Text.Length > 1)
                    {
                        // ObjDhInputItem.VItemBarcode = ItemBarCode.Text;
                        // EmptyInvoice objabc = (EmptyInvoice)this._tabItems[0].Content as EmptyInvoice;
                        // objabc.AddItem(ObjDhInputItem);
                        // AddItem(ObjDhInputItem);
                        // ItemBarCode.Text = "";
                        // ItemBarCode.Focus();
                        // Keyboard.Focus(ItemBarCode);
                        LiftNumber.Text = "";
                        LiftNumber.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                //  Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }

        }
        private void LiftNumber_PreviewKeyUp(object sender, KeyEventArgs e)



        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    dhItems ObjDhInputItem = new dhItems();
                    if (ItemBarCode.Text.Length > 1)
                    {

                        ObjDhInputItem.VItemBarcode = ItemBarCode.Text;
                        Int32 tabid;
                        int.TryParse(LiftNumber.Text.ToString(), out tabid);
                        if (tabid > tabDynamic.Items.Count)
                        {
                            MessageBox.Show("No Lift is open with this number.");
                        }
                        tabid = tabid > 0 ? tabid - 1 : tabid;
                        EmptyInvoiceView objabc = (EmptyInvoiceView)this._tabItems[tabid].Content as EmptyInvoiceView;
                        //
                        //objabc.
                        objabc.AddItem(ObjDhInputItem);
                        //  AddItem(ObjDhInputItem);
                        tabDynamic.SelectedIndex = tabid;
                        ItemBarCode.Text = "";
                        ItemBarCode.Focus();
                        Keyboard.Focus(this.ItemBarCode);
                    }
                }

            }
            catch (Exception ex)
            {
                //  Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }

        }

    }
}
