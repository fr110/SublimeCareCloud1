using DataHolders;
using SublimeCareCloud.CustomClasses;
using SublimeCareCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for PartyView.xaml
    /// </summary>
    public partial class PartyView : UserControl
    {
       

        private static dhParty ObjFilterObject = new dhParty();
        public PartyView()
        {
            InitializeComponent();
        }

      
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
           // loadData(ObjFilterObject);
           // this.SubMenuToolBar.ItemsSource = Globalized.SubMenu;
        }
      
        private void loadData(dhParty objParty, Boolean ShowResultCount = false)
        {

            //dsGeneral.dtPosPartyDataTable dtparty = iFacede.GetParty(Globalized.ObjDbName, objParty);
            //sequence = ReflectionUtility.DataTableToObservableCollection<dhParty>(dtparty);
            // partyList.ItemsSource = sequence;
            ////pageControl.PageContract = null;
            ////pageControl.PageContract = this;
            //Globalized.ShowMsg(lblErrorMsg);
            //// show msg for local search 
            //if ((ShowResultCount) && (sequence != null))
            //{
            //    String msg = String.Format("  {0}  Search Results Found", sequence.Count);
            ////    pageControl.ReLoad();
            //    Globalized.setException(msg, lblErrorMsg, DataHolders.MsgType.Info);
            //}

        }
        private void Stock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode
                dhParty objTodisplay = new dhParty();

                objTodisplay = ((dhParty)dgr.Item);
                if (objTodisplay != null)
                {
                    objTodisplay.IUpdate = 1;
                    AddPartyViewModel ObjSetToEdit = new AddPartyViewModel(objTodisplay);
                    //objvm.SelectToEdit(new AddPartyViewModel(objTodisplay));
                    Globalized.LoadThisObject(ObjSetToEdit, "Edit Party '" + objTodisplay.VPartyName + "'", Globalized.AppModuleList.Where(xx => xx.VModuleName == "Party").FirstOrDefault().VShortDescription);
                }
            }
        }
        

        private void showall_Click(object sender, RoutedEventArgs e)
        {
          //  var child = cstmUtilities.FindChildByType<TextBox>(Partylist);
          ////  Partylist.SelectedValue = null;
          //  child.Text = "";
          //  ObjFilterObject = new dhParty();
          //  loadData(ObjFilterObject);
        }

        private void Partylist_PreviewKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Printit_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<dhParty> tempData = partyList.Items.Cast<dhParty>().ToList();
            DataTable SelectedParties = new DataTable();
            SelectedParties = Globalized.ToDataTable(tempData, "Parties");
            DataSet ds = new DataSet();

            // dsGeneral.dtPosItemsDataTable dt = iFacede.GetItems(Globalized.ObjDbName, objPrint);
            ds.Tables.Add(SelectedParties);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                string ReportDisc = BL.MsgTextCollection.MsgsList.Where(x => x.Key == "DP01").FirstOrDefault().Value;
                PrintUtilities.printDoc("Parties.xaml", ds, "Parties Report", true, ReportDisc);
            }
            else
            {
                string msg = "There is not enough data to generate the report.";
                Globalized.setException(msg, lblErrorMsg, MsgType.Error);
            }

            // MessageBox.Show(tmptb.Rows.Count.ToString());
        }
    }
}
