using DataHolders;
using FeserWard.Controls;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.IconPacks;
using System.Windows.Media;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AccountsView.xaml
    /// </summary>
    public partial class AccountsView : UserControl
    {
        public AccountsView()
        {
            InitializeComponent();
        }

        //public ListAccounts()
        //{
        //    InitializeComponent();
        //}

        public IIntelliboxResultsProvider dbAccountList { get; private set; }
        private static dhAccount ObjFilterObject = new dhAccount();
        private List<TabItem> _TabItems;
        private TabItem _tabAdd;
        //public appAccount()
        //{
        //    InitializeComponent();
        //  //  dbAccountList = new blAccountsearch();

        //}
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Button clicked = (Button)sender;
            //int a = Convert.ToInt32(clicked.CommandParameter);
            //ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
            //Obj.con
        }
        private void Account_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode

                dhAccount objTodisplay = new dhAccount();

                objTodisplay.IAccountid = ((dhAccount)dgr.Item).IAccountid;
                dsGeneral.dtPosAccountsDataTable dtAccount = iFacede.GetAccount(Globalized.ObjDbName, objTodisplay);
                ObservableCollection<dhAccount> listAccount = ReflectionUtility.DataTableToObservableCollection<dhAccount>(dtAccount);
                if (listAccount.Count > 0)
                {
                    objTodisplay = listAccount.Cast<dhAccount>().Where(i => i.IAccountid.Equals(objTodisplay.IAccountid)).SingleOrDefault();
                    objTodisplay.IUpdate = 1;
                    //dsGeneral.dtPosFinaceTypeDataTable dtF = iFacede.GetFinaceType(Globalized.ObjDbName, objTodisplay);
                    //objTodisplay.FinanceTypeList = ReflectionUtility.DataTableToObservableCollection<dhFinanceType>(dtF);
                    AddTabItem(objTodisplay);
                }


            }
        }
        private void AddTabItem(dhAccount objTodisplay)
        {
            // create new tab AccountIn
            TabItem tab = new TabItem();
            string tabName = "";
            if (objTodisplay.AccountName != null)
            {
                tabName = "Account No - ' " + objTodisplay.VAccountNo + " '";

            }
            else
            {
                tabName = "Add New Account";
            }

            tab.Header = string.Format(tabName);
            tab.Name = string.Format("Account{0}", tabDynamic.Items.Count + 1);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            //    tab.MouseDoubleClick += new MouseButtonEventHandler(tab_MouseDoubleClick);
            AddAccountView wintoOpen = new AddAccountView(objTodisplay);
            tab.Content = wintoOpen;
            tab.IsSelected = true;

            //var AccountIn = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tab.Name)).SingleOrDefault();
            //if (AccountIn == null)  
            //{
            if (tabDynamic.Items.Count > 1)
            {

                tabDynamic.Items.Insert(tabDynamic.Items.Count - 1, tab); // inset the Eid tab 
            }
            else
            {
                tabDynamic.Items.Insert(tabDynamic.Items.Count, tab); // inset the Eid tab 
            }

            //}
            //else
            //{
            //    AccountIn.IsSelected = true;
            //}
            //  tabDynamic.DataContext = _TabItems;

        }
        private void tabAdd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;
            TabItem _tabAdd = tabDynamic.Items[0] as TabItem;
            if (tab == null) return;

            if ((tab.Header.Equals(" + ")) && (tabDynamic.Items.Count > 1))
            {
                TabItem Newtabs = new TabItem();
                string tabName = "";
                dhAccount Obj = new dhAccount();
                // AddTabItem(Obj);

                tabName = "Add New Account";
                Newtabs.Header = string.Format(tabName);
                Newtabs.Name = string.Format("AddAccountView");
                Newtabs.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
                // Newtabs.MouseDoubleClick += new MouseButtonEventHandler(tab_MouseDoubleClick);
                AddAccountView wintoOpen = new AddAccountView();
                Newtabs.Content = wintoOpen;
                Newtabs.IsSelected = true;

                var Account = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(Newtabs.Name)).SingleOrDefault();
                if (Account == null)
                {
                    tabDynamic.Items.Insert(tabDynamic.Items.Count - 1, Newtabs);

                }
                else
                {
                    Account.IsSelected = true;
                }
            }
            else
            {
                tab.IsSelected = true;
            }
        }

        private void tab_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tab = sender as TabItem;

            //TabProperty dlg = new TabProperty();
            //// get existing header text
            //dlg.txtTitle.Text = tab.Header.ToString();

            //if (dlg.ShowDialog() == true)
            //{
            //    // change header text
            //    tab.Header = dlg.txtTitle.Text.Trim();
            //}
        }

        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TabItem tab = tabDynamic.SelectedItem as TabItem;
            if (tab == null)
            {
                tab = tabDynamic.Items[0] as TabItem;
            }
            if (tab.Name == "AccountTab")
            {
                loadData(ObjFilterObject);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var Account = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            if (tabDynamic.Items.Count > 1)
            {
                tabDynamic.Items.Remove(Account);
                tabDynamic.SelectedIndex = 0;
            }
        }

        private void AccountControl_Initialized_1(object sender, EventArgs e)
        {
            try
            {
                //if (objAccount.IAccountid != Globalized.ObjCurrentUser.IAccountid)
                //{
                ///     VUserType.DataContext = iFacede.getAccountType(Globalized.ObjCurrentUser, "New");
                //}
                //else
                //{
                //    VUserType.DataContext = iFacede.getAccountType(Globalized.ObjCurrentUser, "Edit");
                //}
                //VUserType.DisplayMemberPath = "AccountType";
                //VUserType.SelectedValuePath = "AccountTypeKey";
                //    VUserType.SelectedValue = ObjEdit.VUserType;
                loadData(GlobalDhAccount);
                //if(Globalized.ObjCurrentUser.VUserType != "AccountIn")
                //{

                InitializeComponent();

                // initialize TabItem array
                _TabItems = new List<TabItem>();
                _tabAdd = new TabItem();

                // icon <materialDesign:PackIcon Kind="Close" Foreground="Black" Background="White"  Width="14" Height="14" Margin="2,2" />

                _tabAdd.Header = " + "; //Globalized.GetCloseButtonIcon();
                _tabAdd.MouseLeftButtonUp += new MouseButtonEventHandler(tabAdd_MouseLeftButtonUp);

                tabDynamic.Items.Add(_tabAdd);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static dhAccount GlobalDhAccount = new dhAccount();
        ObservableCollection<dhAccount> sequence = new ObservableCollection<dhAccount>();
        private void loadData(dhAccount objAccount, Boolean ShowResultCount = false)
        {

            dsGeneral.dtPosAccountsDataTable dtAccounts = iFacede.GetAccount(Globalized.ObjDbName, objAccount);

            EnumerableRowCollection<dsGeneral.dtPosAccountsRow> Filter = null;
            sequence.Clear();
            sequence = ReflectionUtility.DataTableToObservableCollection<dhAccount>(dtAccounts);
            //if (Globalized.ObjCurrentUser.VUserType == "Super")
            //{
            //    Filter = from r in dtAccounts.AsEnumerable()
            //             where (r.Field<int>("VUserType") == Module.IModuleID) && (r.Field<bool>("bIsActive") == true)
            //             select r;
            //}
            //if (Globalized.ObjCurrentUser.VUserType == "Owner")
            //{
            //    Filter = from r in dtAccounts.AsEnumerable()
            //             where (r.Field<string>("VUserType") == "Admin") || (r.Field<string>("VUserType") == "AccountIn") || (r.Field<string>("VUserType") == "Owner")
            //             select r;
            //}

            //if (Globalized.ObjCurrentUser.VUserType == "Admin")
            //{
            //    Filter = from r in dtAccounts.AsEnumerable()
            //             where ((r.Field<string>("VUserType") == "Admin") && (r.Field<int>("iAccountid") == Globalized.ObjCurrentUser.IAccountid) ) || (r.Field<string>("VUserType") == "AccountIn") 
            //             select r;
            //}
            //if (Globalized.ObjCurrentUser.VUserType == "AccountIn")
            //{
            //    Filter = from r in dtAccounts.AsEnumerable()
            //             where (r.Field<string>("VUserType") == "AccountIn") && (r.Field<int>("iAccountid") == Globalized.ObjCurrentUser.IAccountid)
            //             select r;
            //}

            if (Filter != null)
            {
                int CountRowInner = Filter.Count<dsGeneral.dtPosAccountsRow>();
                if (CountRowInner > 0)
                {
                    DataTable dtFilter = Filter.CopyToDataTable();
                    sequence = ReflectionUtility.DataTableToObservableCollection<dhAccount>(dtFilter);
                }
                else
                {
                    sequence = null;
                }
            }

            AccountList.ItemsSource = sequence;
            //pageControl.PageContract = null;
            //pageControl.PageContract = this;

            // pageControl_PreviewPageChange(null, null);
            // Globalized.ShowMsg(lblErrorMsg);
            //if (Globalized.lastMsg != null)
            //{
            //    //System.Windows.Forms.MessageBox.Show( );
            //    lblErrorMsg.Content = Globalized.lastMsg;
            //    lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
            //    Globalized.lastMsg = null;
            //}
            //else
            //{
            //    lblErrorMsg.Content = "";
            //    lblErrorMsg.Visibility = System.Windows.Visibility.Hidden;
            //}
            //    show msg for local search 
            if ((ShowResultCount) && (sequence != null))
            {
                String msg = String.Format("  {0}  Search Results Found", sequence.Count);
                //pageControl.ReLoad();
                Globalized.setException(msg, lblErrorMsg, CustomClasses.MsgType.Info);
                Globalized.ShowMsg(lblErrorMsg);
            }
            else
            {
                if (sequence == null)
                {
                    String msg = String.Format("  {0}  Search Results Found", 0);
                    Globalized.setException(msg, lblErrorMsg, CustomClasses.MsgType.Info);
                    Globalized.ShowMsg(lblErrorMsg);
                }

                if (ShowResultCount == false)
                {
                    lblErrorMsg.Visibility = Visibility.Hidden;
                }
            }
        }

        private void AccountControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //string abc = iFacede.GetProcessorID();

                //AccountSearchBox.DataContext = new dhAccount();
                //VUserType.SelectedValue = "";
                loadData(GlobalDhAccount);

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                dhAccount objSearchAccount = new dhAccount();
             //   objSearchAccount = (dhAccount)AccountSearchBox.DataContext;
                //    objSearchAccount.VUserType = string.IsNullOrEmpty(VUserType.SelectedValue.ToString()) ? null : VUserType.SelectedValue.ToString();
                loadData(objSearchAccount, true);
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void showall_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ObjFilterObject = new dhAccount();

                loadData(ObjFilterObject);

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }
        ////#region IPageControlContract Members
        ////private void pageControl_PreviewPageChange(object sender, PageChangedEventArgs args)
        ////{
        ////    List<Object> items = pageControl.ItemsSource.ToList();
        ////    int count = items.Count;
        ////}
        ////private void pageControl_PageChanged(object sender, PageChangedEventArgs args)
        ////{
        ////    List<Object> items = pageControl.ItemsSource.ToList();
        ////    int count = items.Count;
        ////}
        ////public uint GetTotalCount()
        ////{
        ////    return (uint)sequence.Count;
        ////}
        ////public ICollection<object> GetRecordsBy(uint StartingIndex, uint NumberOfRecords, object FilterTag)
        ////{
        ////    if (StartingIndex >= sequence.Count)
        ////    {
        ////        return new List<object>();
        ////    }

        ////    List<dhAccount> result = new List<dhAccount>();

        ////    for (int i = (int)StartingIndex; i < sequence.Count && i < StartingIndex + NumberOfRecords; i++)
        ////    {
        ////        result.Add(sequence[i]);
        ////    }

        ////    return result.ToList<object>();
        ////}
        ////#endregion
    }
}
