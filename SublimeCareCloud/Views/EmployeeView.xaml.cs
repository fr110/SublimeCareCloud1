using BL;
using DataHolders;
using FeserWard.Controls;
using iFacedeLayer;
using SublimeCareCloud.CustomClasses;
using SublimeCareCloud.etc;
using SublimeCareCloud.ViewModels;
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
using ReflectionUtility = DataHolders.ReflectionUtility;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public IIntelliboxResultsProvider dbEmployeeSearch { get; private set; }
        private static dhEmployee ObjFilterObject = new dhEmployee();
        public EmployeeView()
        {
            InitializeComponent();
            dbEmployeeSearch = new blEmploySearch();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Button clicked = (Button)sender;
            //int a = Convert.ToInt32(clicked.CommandParameter);
            //ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
            //Obj.con
        }
        private void Stock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode

                dhEmployee objTodisplay = new dhEmployee();

                objTodisplay.IEmpid = ((dhEmployee)dgr.Item).IEmpid;
                dsGeneral.dtEmployeeDataTable dtEmployee = iFacede.GetEmployee(Globalized.ObjDbName, objTodisplay);
                ObservableCollection<dhEmployee> listItem = ReflectionUtility.DataTableToObservableCollection<dhEmployee>(dtEmployee);
                if (listItem.Count > 0)
                {
                    objTodisplay = listItem.Cast<dhEmployee>().Where(i => i.IEmpid.Equals(objTodisplay.IEmpid)).SingleOrDefault();
                    objTodisplay.IUpdate = 1;
                    AddTabItem(objTodisplay);
                }


            }
        }
        private void AddTabItem(dhEmployee objTodisplay)
        {
            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = string.Format(objTodisplay.VEmpfName);
            tab.Name = string.Format("Employee{0}", objTodisplay.IEmpid);
            tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;
            //  tab.MouseDoubleClick += new MouseButtonEventHandler(tab_MouseDoubleClick);
            AddEmployeeView wintoOpen = new AddEmployeeView (objTodisplay);
            tab.Content = wintoOpen;
            tab.IsSelected = true;

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tab.Name)).SingleOrDefault();
            if (item == null)
            {
                tabDynamic.Items.Add(tab);//    tabDynamic.Items.Remove(item);

            }
            else
            {
                item.IsSelected = true;
            }
            //  tabDynamic.DataContext = _tabItems;

        }
        private void tabAdd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //// clear tab control binding
            //tabDynamic.DataContext = null;

            //TabItem tab = this.AddTabItem();

            //// bind tab control
            //tabDynamic.DataContext = _tabItems;

            //// select newly added tab item
            //tabDynamic.SelectedItem = tab;
        }

        private void tab_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TabItem tab = sender as TabItem;

            TabProperty dlg = new TabProperty();

            // get existing header text
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
            if (tab == null)
            {
                tab = tabDynamic.Items[0] as TabItem;
            }
            if (tab.Name == "EmployeeTab")
            {
                loadData(ObjFilterObject);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            if (tabDynamic.Items.Count > 1)
            {
                tabDynamic.Items.Remove(item);
            }

            //TabItem tab = item as TabItem;

            //if (tab != null)
            //{
            //    if (_tabItems.Count < 3)
            //    {
            //        MessageBox.Show("Cannot remove last tab.");
            //    }
            //    else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
            //        "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {
            //        // get selected tab
            //        TabItem selectedTab = tabDynamic.SelectedItem as TabItem;

            //        // clear tab control binding
            //        tabDynamic.DataContext = null;

            //        _tabItems.Remove(tab);

            //        // bind tab control
            //        tabDynamic.DataContext = _tabItems;

            //        // select previously selected tab. if that is removed then select first tab
            //        if (selectedTab == null || selectedTab.Equals(tab))
            //        {
            //            selectedTab = _tabItems[0];
            //        }
            //        tabDynamic.SelectedItem = selectedTab;
            //    }
            //}
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            loadData(ObjFilterObject);
        }
        ObservableCollection<dhEmployee> sequence = new ObservableCollection<dhEmployee>();
        private void loadData(dhEmployee objEmployee, Boolean ShowResultCount = false)
        {

            dsGeneral.dtEmployeeDataTable dtEmployee = iFacede.GetEmployee(Globalized.ObjDbName, objEmployee);
            sequence = ReflectionUtility.DataTableToObservableCollection<dhEmployee>(dtEmployee);
              EmployeeList.ItemsSource = sequence;
           // pageControl.PageContract = null;
            //pageControl.PageContract = this;
            Globalized.ShowMsg(lblErrorMsg);
            // show msg for local search 
            if ((ShowResultCount) && (sequence != null))
            {
                String msg = String.Format("  {0}  Search Results Found", sequence.Count);
                //pageControl.ReLoad();
                Globalized.setException(msg, lblErrorMsg, CustomClasses.MsgType.Info);
            }

        }

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    var child = cstmUtilities.FindChildByType<TextBox>(Employeelist);
        //    if (child.Text != "")
        //    {
        //        if (Employeelist.SelectedValue != null)
        //        {
        //            ObjFilterObject.IEmpid = Convert.ToInt32(Employeelist.SelectedValue.ToString());
        //        }

        //    }
        //    else
        //    {
        //        // make the selected value null
        //        Employeelist.SelectedValue = null;
        //        //   ObjFilterObject.IEmpid = null;
        //    }

        //    //child.Focus();
        //    loadData(ObjFilterObject, true);
        //}

        //private void showall_Click(object sender, RoutedEventArgs e)
        //{
        //    var child = cstmUtilities.FindChildByType<TextBox>(Employeelist);
        //    Employeelist.SelectedValue = null;
        //    child.Text = "";
        //    ObjFilterObject = new dhEmployee();
        //    loadData(ObjFilterObject);
        //}

        private void Employeelist_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }
        //#region IPageControlContract Members
        //private void pageControl_PreviewPageChange(object sender, PageChangedEventArgs args)
        //{
        //    List<Object> items = pageControl.ItemsSource.ToList();
        //    int count = items.Count;
        //}
        //private void pageControl_PageChanged(object sender, PageChangedEventArgs args)
        //{
        //    List<Object> items = pageControl.ItemsSource.ToList();
        //    int count = items.Count;
        //}
        //public uint GetTotalCount()
        //{
        //    return (uint)sequence.Count;
        //}
        //public ICollection<object> GetRecordsBy(uint StartingIndex, uint NumberOfRecords, object FilterTag)
        //{
        //    if (StartingIndex >= sequence.Count)
        //    {
        //        return new List<object>();
        //    }

        //    List<dhEmployee> result = new List<dhEmployee>();

        //    for (int i = (int)StartingIndex; i < sequence.Count && i < StartingIndex + NumberOfRecords; i++)
        //    {
        //        result.Add(sequence[i]);
        //    }

        //    return result.ToList<object>();
        //}
        //#endregion

    }
}
