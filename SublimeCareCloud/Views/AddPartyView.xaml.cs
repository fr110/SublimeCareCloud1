using BL;
using DataHolders;
using FluentValidation.Results;
using iFacedeLayer;
using SublimeCareCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddPartyView.xaml
    /// </summary>
    public partial class AddPartyView : UserControl
    {
        public AddPartyView()
        {
            InitializeComponent();
        }


        // dhParty GlobalObjParty = new dhParty();
        public AddPartyView(dhParty Obj)
        {
            InitializeComponent();
            dhSaleMan objSaleMan = new dhSaleMan();
            Globalized.ShowMsg(lblErrorMsg);
        }
    
        static DataTable GetTable()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("ICityID", typeof(int));
            table.Columns.Add("VCityName", typeof(string));


            //
            // Here we add DataRows.
            //
            table.Rows.Add(01, "Karāchi");
            table.Rows.Add(01, "Lahore");
            table.Rows.Add(01, "Faisalabad");
            table.Rows.Add(01, "Rāwalpindi");
            table.Rows.Add(01, "Multan");
            table.Rows.Add(01, "Haidarabad");
            table.Rows.Add(01, "Gujranwala");
            table.Rows.Add(01, "Peshawar");
            table.Rows.Add(01, "Quetta");
            table.Rows.Add(01, "Muzaffarābād");
            table.Rows.Add(01, "Bahawalpur");
            table.DefaultView.Sort = "VCityName ASC";
            return table;
        }

       
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            vCityList.DataContext = GetTable();
            vCityList.DisplayMemberPath = "VCityName";
            vCityList.SelectedValuePath = "VCityName";
            Globalized.ShowMsg(lblErrorMsg);
        }
        public bool ContainsAny(string str, IEnumerable<string> values)
        {
            if (!string.IsNullOrEmpty(str) || values.Any())
            {
                foreach (string value in values)
                {
                    // Ignore case comparison from @TimSchmelter
                    if (str.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1) return true;
                }
            }

            return false;
        }
        private void SaveTheParty(object sender, RoutedEventArgs e)
        {
            try
            {
                dhParty objParty = new dhParty();
                objParty = (dhParty)grid1.DataContext;
                objParty.VCity = vCityList.SelectedValue != null ? this.vCityList.SelectedValue.ToString() : null;
                dsGeneral.dtPosPartyDataTable dtParty = iFacede.GetParty(Globalized.ObjDbName, new dhParty());
                ObservableCollection<dhParty> listItem = BL.ReflectionUtility.DataTableToObservableCollection<dhParty>(dtParty);
                string bFound = null;

                foreach (dhParty item in listItem)
                {
                    string[] words = item.VPartyName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string[] filter = objParty.VPartyName.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if ((objParty.IPartyID != null) && (item.IPartyID == objParty.IPartyID))
                    {
                        continue;
                    }
                    bFound = words.Where(x => filter.Contains(x.ToLower())).FirstOrDefault();
                    if (bFound != null)
                    {
                        break;
                    }
                }

                if (bFound != null)
                {
                    if (!blUtil.OverrideInformation(objParty.VPartyName, bFound))
                    {
                        this.vPartyNameTextBox.SelectAll();
                        this.vPartyNameTextBox.Focus();
                        return;
                    }
                }
                objParty.VPartyadress = objParty.VMarket + " , " + objParty.VArea + " , " + objParty.VDistrict + " , " + objParty.VCity;


                lblErrorMsg.Visibility = Visibility.Hidden;
                DataSet dsr = iFacede.InsertUpdateParty(Globalized.ObjDbName, objParty);

                if(dsr.Tables.Count > 0)
                { 
                     DataTable dtb = dsr.Tables[0];
                     if( dtb.Rows.Count > 0)
                     {
                        objParty = BL.ReflectionUtility.DataTableToObservableCollection<dhParty>(dtb).FirstOrDefault();
                       
                    }
                }

                    if (((dhParty)grid1.DataContext).IUpdate == 1)
                {
                    Globalized.SetMsg("P02", CustomClasses.MsgType.Info);
                }
                else
                {
                    Globalized.SetMsg("P01", CustomClasses.MsgType.Info);
                    objParty.IUpdate = 1;
                    AddPartyViewModel ObjSetToEdit = new AddPartyViewModel(objParty);
                    Globalized.LoadThisObject(ObjSetToEdit, "Edit Party '" + objParty.VPartyName + "'", Globalized.AppModuleList.Where(xx => xx.VDisplayName == "Party").FirstOrDefault().VShortDescription);

                    
                }
                Globalized.ShowMsg(lblErrorMsg);
            }

            catch (Exception ex)
            {
                Globalized.GlobalMsg = null;
                Globalized.SetMsg(ex.Message, CustomClasses.MsgType.Error);
                Globalized.ShowMsg(lblErrorMsg);
            }

        }

        private void vpartyMobileTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean Have = Globalized.NumaricKey.Contains(e.Key);
            if (!Globalized.NumaricKey.Contains(e.Key))
            {
                e.Handled = false;
            }
            ////char c = (char)e.Key;
            ////if (Char.IsLetterOrDigit(c)) {
            //if (!char.IsControl(c)  && !char.IsDigit(c) && c != '.')
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if (c == '.'  && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        private void vpartyMobileTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Boolean Have = Globalized.NumaricKey.Contains(e.Key);
            if (!Globalized.NumaricKey.Contains(e.Key))
            {
                e.Handled = true;
            }
        }

        private void vpartyMobileTextBox_PreviewKeyUp_1(object sender, KeyEventArgs e)
        {
            //if (Globalized.NumaricKey.Contains(e.Key))
            //{
            //    e.Handled = false;

            //}
            //else
            //{
            //    e.Handled = true;
            //}
            //if (e.Key)
        }

        private void vpartyMobileTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (Globalized.NumaricKey.Contains(e.Key))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void vLandlineNumberTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (Globalized.NumaricKey.Contains(e.Key))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel objvm = (MainViewModel)Globalized.Objw.DataContext;
            objvm.SelectToEdit(new PartyViewModel());
        }
    }
}
