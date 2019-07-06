using BL;
using DataHolders;
using FeserWard.Controls;
using FluentValidation.Results;
using iFacedeLayer;
using SublimeCareCloud.CustomClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using ReflectionUtility = BL.ReflectionUtility;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for EmptyInvoiceView.xaml
    /// </summary>
    public partial class EmptyInvoiceView : UserControl
    {
        //public EmptyInvoiceView()
        //{
        //    InitializeComponent();
        //}
        //public AddInvoiceView()
        //{
        //    InitializeComponent();
        //}

        private dhInvoice GlobalobjInvoice = new dhInvoice();
        public IIntelliboxResultsProvider dbCostumerSearch { get; private set; }
        public IIntelliboxResultsProvider dbEmployeeSearch { get; private set; }
        public IIntelliboxResultsProvider dbItemList { get; private set; }
        // load paerty for defalt 
        dhPreference CheckSetting = Globalized.ObjPrefernce;
        DataSet ds;
        dhSaleItem objEmpToEdit = null;

        public EmptyInvoiceView()
        {
            InitializeComponent();
            dbItemList = new blItemSearch();
            dbCostumerSearch = new blCostumerSearch();
            dbEmployeeSearch = new blEmploySearch();
            //MultipleColumnVM = new StandardSearchVM(dbItemList);
            this.GlobalobjInvoice = new dhInvoice(Globalized.ObjCurrentUser);
            this.GlobalobjInvoice.VDeliveryExpense = "0";
            //this.GlobalobjInvoice = 
            this.DataContext = this.GlobalobjInvoice;
            this.grdItems.DataContext = this.GlobalobjInvoice.ItemsOfInvoice;
            this.CostumerBox.DataContext = new dhCostumer();

        }

        public EmptyInvoiceView(dhInvoice obj)
        {
            InitializeComponent();
            dbItemList = new blItemSearch();
            dbEmployeeSearch = new blEmploySearch();
            dbCostumerSearch = new blCostumerSearch();
            this.DataContext = obj;
            this.grdItems.ItemsSource = obj.ItemsOfInvoice; if (obj.BIsDraft != true)
            {
                DisableControl(MainGroup, obj.IsReadOnly);
            }
            this.CostumerBox.DataContext = new dhCostumer();
            this.GlobalobjInvoice = obj;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadData();
                //  ddateDatePicker.Focus();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void ShowHide()
        {
            // Costumer
            if (Globalized.ObjPrefernce.BDefaultCustomer == true)
            {
                SetCostumer(1);
            }

            // Show Costumer
            //if ((Globalized.ObjPrefernce.BShowCostumerDetail == null) || (Globalized.ObjPrefernce.BShowCostumerDetail != true))
            //{
            //    CostumerBox.Visibility = System.Windows.Visibility.Hidden;
            //    SetCostumer(1);
            //}
            //else
            //{ CostumerBox.Visibility = System.Windows.Visibility.Visible; }
            // Show Hide Delivery Detail
            if ((Globalized.ObjPrefernce.BShowDeliveryDetail == null) || (Globalized.ObjPrefernce.BShowDeliveryDetail != true))
            {
                //extrabox.Visibility = System.Windows.Visibility.Hidden;
                //this.GlobalobjInvoice.VDeliveryExpense = "0";
                //this.GlobalobjInvoice.VDriverName = "Defult";
                //this.GlobalobjInvoice.VReciverName = "Defult";
                //this.GlobalobjInvoice.VVehicleNo = "Defult";
            }
            else
            {
                //    extrabox.Visibility = System.Windows.Visibility.Visible; 
            }
            // Setting for Stock Colum
            if (Globalized.ObjPrefernce.BShowStockStatus == false)
            {
                this.grdItems.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                //this.grdItems.Columns[6].Visibility = System.Windows.Visibility.Hidden;
            }

            //this.grdItems.Columns[4].Visibility = System.Windows.Visibility.Hidden;
            //this.grdItems.Columns[6].Visibility = System.Windows.Visibility.Hidden;
        }
        private void LoadData()
        {
            CheckSetting = Globalized.ObjPrefernce;

            //   abc.ShowMsg(this);
            dhCostumer objdhCostumer = new dhCostumer();
            //  iFacede.GetCostumer(Globalized.ObjDbName, objdhCostumer, partlist);
            dhSaleMan objSaleMan = new dhSaleMan();
            // iFacede.GetSaleMan(Globalized.ObjDbName, objSaleMan, cmbSaleMan);

            if ((Globalized.LastPageLeaved == true) && (this.GlobalobjInvoice.IsReadOnly != true))
            {
                this.GlobalobjInvoice = new dhInvoice();
                Reset(this.GlobalobjInvoice);
                Item_Grid.DataContext = new dhSaleItem();
                this.GlobalobjInvoice = new dhInvoice();
                CheckSetting = Globalized.ObjPrefernce;
                if (Globalized.ObjPrefernce.BDefaultCustomer == true)
                {
                    SetCostumer(1);
                }
            }

            if ((this.GlobalobjInvoice == null) && (this.GlobalobjInvoice.IsReadOnly != true))
            {
                iFacede.SetInitialItemRow(grdItems);
                Reset(this.GlobalobjInvoice);
                Item_Grid.DataContext = new dhSaleItem();
                this.GlobalobjInvoice = new dhInvoice();
                CheckSetting = Globalized.ObjPrefernce;

                if (Globalized.ObjPrefernce.BDefaultCustomer == true)
                {
                    SetCostumer(1);
                }
            }

            if (this.GlobalobjInvoice != null)
            {
                this.DataContext = this.GlobalobjInvoice;
                this.ddateDatePicker.SelectedDate = this.GlobalobjInvoice.Ddate;
                Item_Grid.DataContext = new dhSaleItem();
                if ((GlobalobjInvoice.ISaleid != 0) && (GlobalobjInvoice.ISaleid != null))
                {
                    btnPrint.IsEnabled = true;
                }
                else
                {
                    btnPrint.IsEnabled = false;
                }
                if ((GlobalobjInvoice.ICostumerId != null) && (this.GlobalobjInvoice.ICostumerId > 0))
                {
                    long partid = this.GlobalobjInvoice.ICostumerId;
                    SetCostumer(partid);
                }
                else
                {
                    if (Globalized.ObjPrefernce.BDefaultCustomer == true)
                    {
                        SetCostumer(1);
                    }
                }
                this.grdItems.ItemsSource = (ItemsList)this.GlobalobjInvoice.ItemsOfInvoice;
                // enable or disable the controls 


                //if ((GlobalobjInvoice.ISaleid == null)&& (GlobalobjInvoice.BReturnInvoice == null))
                //{
                //    btnCnclInvoice.Visibility = System.Windows.Visibility.Hidden;
                //    this.btnCancel.Visibility = System.Windows.Visibility.Visible;
                //}

                //if ((GlobalobjInvoice.BCanelDone == true) && (GlobalobjInvoice.BReturnInvoice != true))
                //{
                //    btnCnclInvoice.Visibility = System.Windows.Visibility.Hidden;
                //    Globalized.SetMsg("This Invoice is canceled.", MsgType.Info);
                //    Globalized.ShowMsg(lblErrorMsg);
                //}

                //if ((GlobalobjInvoice.BCanelDone != true) && (GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    btnCnclInvoice.Visibility = System.Windows.Visibility.Hidden;
                //    Globalized.SetMsg("This is Return Invoice. ", MsgType.Info);
                //    Globalized.ShowMsg(lblErrorMsg);
                //}


                if (GlobalobjInvoice.BIsDraft == true)
                {
                    // this the draft emp  

                    DisableControl(MainGroup, false);
                    Globalized.ShowMsg(lblErrorMsg);
                }
                else
                {

                    if (GlobalobjInvoice.BReturnInvoice == true)
                    {
                        btnCnclInvoice.Visibility = System.Windows.Visibility.Hidden;
                        btnDraft.Visibility = System.Windows.Visibility.Hidden;
                        btnCancel.Visibility = System.Windows.Visibility.Hidden;
                        btnSave.Visibility = System.Windows.Visibility.Hidden;
                        btnPrint.Visibility = System.Windows.Visibility.Hidden;
                        Globalized.SetMsg("This is Return Invoice. ", MsgType.Info);
                        Globalized.ShowMsg(lblErrorMsg);
                    }

                    if ((GlobalobjInvoice.BCanelDone != true) && (GlobalobjInvoice.BReturnInvoice != true) && (GlobalobjInvoice.ISaleid != null))
                    {
                        //  btnCnclInvoice.Visibility = System.Windows.Visibility.Visible;
                        btnDraft.Visibility = System.Windows.Visibility.Hidden;
                        btnCancel.Visibility = System.Windows.Visibility.Hidden;
                        btnSave.Visibility = System.Windows.Visibility.Hidden;
                        btnPrint.Visibility = System.Windows.Visibility.Hidden;
                        //Globalized.SetMsg("This is Return Invoice. ", MsgType.Info);
                        //Globalized.ShowMsg(lblErrorMsg);
                    }
                }

            }
            ShowHide();


        }
        public void Reset(dhInvoice obj)
        {
            InitializeComponent();
            dbItemList = new blItemSearch();
            dbCostumerSearch = new blCostumerSearch();
            this.DataContext = obj;
            this.grdItems.ItemsSource = obj.ItemsOfInvoice;
            lblErrorMsg.Content = "";

            //   var child = FindChildByType<TextBox>(ItemList);
            //  child.Text = "";
            // child.Focus();
            ItemBarCode.Focus();
            this.GlobalobjInvoice = obj;
            if (Globalized.ObjPrefernce.BDefaultCustomer == true)
            {
                SetCostumer(1);
            }
            CostumerBox.DataContext = new dhCostumer();
        }

        public void DisableControl(Control control, System.Nullable<Boolean> _IsReadOnly)
        {
            if (_IsReadOnly == true)
            {
                PropertyInfo enProp = control.GetType().GetProperty("IsEnabled");
                if (enProp != null)
                {
                    enProp.SetValue(control, false, null);
                }
                // this.btnSave.Content = "Print Invoice";
                btnCancel.Visibility = Visibility.Hidden;
                this.grdItems.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                this.grdItems.Columns[6].Visibility = System.Windows.Visibility.Hidden;
                //this.btnSave.Visibility = Visibility.Visible;
                this.btnPrintIt.Visibility = System.Windows.Visibility.Visible;
                // this.Electrition2.Visibility = System.Windows.Visibility.Hidden;
                //this.Electrition.Visibility = System.Windows.Visibility.Hidden;

                //txtVSecElectricianName.Visibility = System.Windows.Visibility.Visible;
                //txtVFirstElectricianName.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {
                PropertyInfo enProp = control.GetType().GetProperty("IsEnabled");
                if (enProp != null)
                {
                    enProp.SetValue(control, true, null);
                }
                //this.btnSave.Content = "Save & Print";
                //  this.btnSave.Visibility = System.Windows.Visibility.Hidden;
                btnCancel.Visibility = Visibility.Visible;
                this.grdItems.Columns[4].Visibility = System.Windows.Visibility.Visible;
                this.grdItems.Columns[6].Visibility = System.Windows.Visibility.Visible;
                GlobalobjInvoice.IsReadOnly = false;
                //return;
            }
        }

        private void iQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Item_Grid.DataContext = ObjDhItem;
                if (iQuantity.Text != "")
                {
                    //       fAmount.Text = (Convert.ToDouble(fUnitPrice.Text) * Convert.ToInt32(iQuantity.Text)).ToString();

                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void iQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.Key == Key.Enter)
                {
                    AddItemToGrid();
                    //
                }
                if (e.Key == Key.Down)
                {
                    grdItems.SelectedIndex = 0;
                    grdItems.Focus();
                }
            }
            catch (Exception ex)
            {

                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void ItemList_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void grdItems_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Down)
                {
                    grdItems.SelectedIndex++;
                    grdItems.Focus();
                }
                if (e.Key == Key.Up)
                {
                    grdItems.SelectedIndex--;
                    grdItems.Focus();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void ftotalamountTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    //vDeliveryExpenseTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void vDeliveryExpenseTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                addExpence();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void vDeliveryExpenseTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    addExpence();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void iDiscountPersentTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                CalculateBill();

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void iDiscountPersentTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    UpdateSource(sender);
                    CalculateBill();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fAmmountRecivedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    UpdateSource(sender);
                    calculateBalance();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fAmmountRecivedTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                calculateBalance();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly == true) || (this.GlobalobjInvoice.BReturnInvoice == true))
                {
                    printinvoice(this.GlobalobjInvoice.BReturnInvoice);
                }
                if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice != true))
                {
                    insertnewinvoice();
                }

                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    InsertReturnInvoice();
                //}


            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }

        private void Costumerlist_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    if (Costumerlist.SelectedValue != null)
                    {
                        SetCostumer(Convert.ToInt32(Costumerlist.SelectedValue));
                    }
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddItemToGrid();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }

        private void grdItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                objEmpToEdit = grdItems.SelectedItem as dhSaleItem;
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void grdItems_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dhSaleItem cell = (dhSaleItem)grdItems.CurrentItem;
                cell.FGrossAmount = (cell.IQuantity * cell.FUnitePrice);
                cell.FGrossPurchasePrice = (cell.IQuantity * cell.FUnitPurchasePrice);
                grdItems.CurrentItem = cell;
                UpdateSource(sender);
                CalculateBill();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // if()
                iFacede.RemoveItem(grdItems, objEmpToEdit, Globalized.ObjDbName, GlobalobjInvoice.BIsDraft);
                GlobalobjInvoice.ItemsOfInvoice = (ItemsList)this.grdItems.ItemsSource;

                CalculateBill();
            }
            catch (Exception ex)
            {

                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        public Boolean LeavingWindows()
        {
            string messageBoxText = "Are you sure to cancel this draft invoice? You can’t undo this operation.";
            string caption = "Delete this Invoice";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                // check is it a draft 
                if (GlobalobjInvoice.BIsDraft == true)
                {
                    if (LeavingWindows())
                    {
                        //  MessageBox.Show("Test");
                        dhInvoice objInvoice = new dhInvoice();
                        objInvoice = (dhInvoice)this.DataContext;
                        if (GlobalobjInvoice.BIsDraft == true)
                        {
                            DataSet ds = iFacede.RemoveSaleInovice(Globalized.ObjDbName, objInvoice);
                            this.IsEnabled = false;
                            Globalized.SetMsg("Invoice is deleted ", CustomClasses.MsgType.Info);
                            Globalized.ShowMsg(lblErrorMsg);
                        }

                    }
                }
                else
                {
                    this.GlobalobjInvoice = new dhInvoice();
                    Reset(this.GlobalobjInvoice);
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }

        private void TextBlock_TargetUpdated_1(object sender, DataTransferEventArgs e)
        {
            //try{
            //        if (ItemList.SelectedValue != null)
            //        {
            //            AddItem();
            //        }
            //}
            //catch (Exception ex)
            //{
            //    Globalized.setException(ex, lblErrorMsg,  CustomClasses.MsgType.Error);
            //}
        }

        private void TextBlock_TargetUpdated_2(object sender, DataTransferEventArgs e)
        {
            try
            {
                if (Costumerlist.SelectedValue != null)
                {
                    SetCostumer(Convert.ToInt32(Costumerlist.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fAmmountRecivedTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    UpdateSource(sender);
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void vDeliveryExpenseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((ftotalamountTextBox.Text == "") || (ftotalamountTextBox.Text == "0"))
                {
                    throw new ApplicationException("Without items you could not generate an invoice !!");
                }
            }
            catch (Exception ex)
            {
                e.Handled = true;
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fAmmountRecivedTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    UpdateSource(sender);
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }


        private void UpdateSource(object sender)
        {
            var obj = sender as UIElement;
            BindingExpression textBinding = BindingOperations.GetBindingExpression(
            obj, TextBox.TextProperty);

            if (textBinding != null)
                textBinding.UpdateSource();
        }

        private void addExpence()
        {
            if ((ftotalamountTextBox.Text == "") || (ftotalamountTextBox.Text == "0"))
            {
                // var child = FindChildByType<TextBox>(ItemList);
                //   CalculateBill();
                throw new ApplicationException("Without items you could not generate an invoice !!");

            }
            //if (this.vDeliveryExpenseTextBox.Text == "")
            //{
            //    this.vDeliveryExpenseTextBox.Text = "0";
            //}

            // add to total ammount and set it to next control
            //    ammountwithDeliveryexpense.Text = (Convert.ToDouble(ftotalamountTextBox.Text) + Convert.ToDouble(vDeliveryExpenseTextBox.Text)).ToString();
            iDiscountPersentTextBox.SelectAll();
            iDiscountPersentTextBox.Focus();
            CalculateBill();
        }

        private void CalculateBill()
        {
            if (grdItems.Items.Count <= 0)
            {
                // reset the 
                GlobalobjInvoice.Ftotalamount = 0;// ; ftotalamountTextBox.Text = "0";
                fPayAbleAmountTextBox.Text = "0";
                ammountwithDeliveryexpense.Text = "0";
                calculateBalance();
                throw new ApplicationException("Please Add Items to continue!!.");
            }
            // calculate the bill

            ItemsList ItemsSoFor = (ItemsList)grdItems.ItemsSource;
            // Count Total Bill 
            double total = 0;
            double totalUnitGross = 0;
            total = 0;
            if ((ItemsSoFor != null) && (ItemsSoFor.Count > 0))
            {
                foreach (dhSaleItem item in ItemsSoFor)
                {
                    if (item != null)
                    {
                        total = total + Convert.ToDouble(item.FGrossAmount);
                        totalUnitGross = totalUnitGross + Convert.ToDouble(item.FGrossPurchasePrice);
                        // updatedList.Add(gridRowObject);
                    }
                }
            }
            // get All the parems 
            //GlobalobjInvoice.Ftotalamount = total;
            double? FServices = GlobalobjInvoice.FServices == null ? 0 : GlobalobjInvoice.FServices;
            UpdateSource(txtFServices);
            this.txtFServices.Text = FServices.ToString();
            GlobalobjInvoice.Ftotalamount = total + FServices;

            GlobalobjInvoice.FGrossPurchasePrice = totalUnitGross;

            double? FPayAbleAmount = GlobalobjInvoice.FPayAbleAmount == null ? 0 : GlobalobjInvoice.FPayAbleAmount;
            double? FBalance = GlobalobjInvoice.FBalance == null ? 0 : GlobalobjInvoice.FBalance;
            double? Ftotalamount = GlobalobjInvoice.Ftotalamount == null ? 0 : GlobalobjInvoice.Ftotalamount;
            double? FAmmountRecived = GlobalobjInvoice.FAmmountRecived == null ? 0 : GlobalobjInvoice.FAmmountRecived;
            double? IDiscountPersent = GlobalobjInvoice.IDiscountPersent == null ? 0 : GlobalobjInvoice.IDiscountPersent;


            this.fPayAbleAmountTextBox.Text = (((Ftotalamount) - IDiscountPersent)).ToString();
            UpdateSource(fPayAbleAmountTextBox);
            this.fAmmountRecivedTextBox.Text = (((Ftotalamount) - IDiscountPersent) - FBalance).ToString();
            UpdateSource(fAmmountRecivedTextBox);
            this.fBlance.Text = (FPayAbleAmount - FAmmountRecived).ToString();
            UpdateSource(fBlance);

            //// Reset the Fields if neded and validation 

            //if ((fAmmountRecivedTextBox.Text == "") || (fAmmountRecivedTextBox.Text == "0"))
            //{
            //    //   throw new ApplicationException("Received Amount is missing.");
            //}

            if ((fAmmountRecivedTextBox.Text != "") && (fPayAbleAmountTextBox.Text != "") && ((Globalized.ObjPrefernce.VSaleType != "CR") && (Globalized.ObjPrefernce.VSaleType != "Both")))
            {
                if (Convert.ToDouble(fPayAbleAmountTextBox.Text) < Convert.ToDouble(fAmmountRecivedTextBox.Text))
                {
                    throw new ApplicationException("Received Amount can’t be greater than payable amount.");
                }
            }



            //// GlobalobjInvoice.Ftotalamount = total;
            // ftotalamountTextBox.Text = total.ToString(); // Total 
            // fPayAbleAmountTextBox.Text = total.ToString();

            if ((this.iDiscountPersentTextBox.Text != "") && (this.iDiscountPersentTextBox.Text != "0"))
            {
                if (Convert.ToDouble(this.iDiscountPersentTextBox.Text) > Convert.ToDouble(this.fPayAbleAmountTextBox.Text))
                {
                    throw new ApplicationException("Discount could not be greater than Total Ammount");
                }

            }
            // Discount
            //if ((this.iDiscountPersentTextBox.Text != "") && (this.iDiscountPersentTextBox.Text != "0"))
            //{

            //    double current = Convert.ToDouble(this.ftotalamountTextBox.Text);
            //    double dicount = Convert.ToDouble(this.iDiscountPersentTextBox.Text);
            //    fPayAbleAmountTextBox.Text = (current - dicount).ToString();// (maximum - Math.Round(((current / 100) * maximum), 2)).ToString();
            //}
            //else
            //{
            //    this.iDiscountPersentTextBox.Text = "0";
            //    fPayAbleAmountTextBox.Text = Convert.ToDouble(this.ftotalamountTextBox.Text).ToString();
            //}
            //if (txtFServices.Text != "")
            //{
            //    fPayAbleAmountTextBox.Text =( Convert.ToDouble(this.ftotalamountTextBox.Text) + Convert.ToDouble(txtFServices.Text)).ToString();
            //}
            //calculateBalance();           
        }
        private void calculateBalance()
        {

            double? FServices = GlobalobjInvoice.FServices == null ? 0 : GlobalobjInvoice.FServices;
            double? FPayAbleAmount = GlobalobjInvoice.FPayAbleAmount == null ? 0 : GlobalobjInvoice.FPayAbleAmount;
            double? FBalance = GlobalobjInvoice.FBalance == null ? 0 : GlobalobjInvoice.FBalance;
            double? Ftotalamount = GlobalobjInvoice.Ftotalamount == null ? 0 : GlobalobjInvoice.Ftotalamount;
            double? FAmmountRecived = GlobalobjInvoice.FAmmountRecived == null ? 0 : GlobalobjInvoice.FAmmountRecived;
            double? IDiscountPersent = GlobalobjInvoice.IDiscountPersent == null ? 0 : GlobalobjInvoice.IDiscountPersent;
            // this.txtFServices.Text = FServices.ToString();
            // this.fPayAbleAmountTextBox.Text = ((Ftotalamount + FServices)).ToString();
            this.fBlance.Text = (FPayAbleAmount - FAmmountRecived).ToString();
            UpdateSource(fBlance);
            //this.fAmmountRecivedTextBox.Text = ((Ftotalamount + FServices) - IDiscountPersent).ToString();


            //if (fAmmountRecivedTextBox.Text == "")
            //{
            //    fAmmountRecivedTextBox.Text = "0";

            //}
            // recived = (payable) - (idiscount)
            //fAmmountRecivedTextBox.Text = (Convert.ToDouble(fPayAbleAmountTextBox.Text) - Convert.ToDouble(iDiscountPersentTextBox.Text)).ToString();
            //if ((fAmmountRecivedTextBox.Text != "") && (fPayAbleAmountTextBox.Text != ""))
            //{
            //    fBlance.Text = (Convert.ToDouble(fPayAbleAmountTextBox.Text) - Convert.ToDouble(fAmmountRecivedTextBox.Text)).ToString();
            //}
            //   if (fBlance.Text == "")
            //  {
            //     fAmmountRecivedTextBox.Text = (Convert.ToDouble(fPayAbleAmountTextBox.Text) - Convert.ToDouble(fBlance.Text)).ToString();
            // }



        }
        private void SetCostumer(long ICostumerID)
        {
            this.CostumerBox.DataContext = new dhCostumer();
            dhCostumer objdhCostumer = new dhCostumer();
            objdhCostumer.CostumerID = ICostumerID;// Convert.ToInt32(Costumerlist.SelectedValue);
            dsGeneral.dtPOSCostumerDataTable dt = iFacede.GetCostumer(Globalized.ObjDbName, objdhCostumer);
            ObservableCollection<dhCostumer> list = BL.ReflectionUtility.DataTableToObservableCollection<dhCostumer>(dt);
            if (list.Count > 0)
            {
                Costumerlist.SelectedItem = new dhCostumer();
                Costumerlist.SelectedValue = null;
                CostumerBox.DataContext = list[0];
                if (list[0].BFallowUp == true)
                {
                    bFallow.IsChecked = true;
                }
                txtCostumerID.Text = ((dhCostumer)list[0]).CostumerID.ToString();
            }
            //     vCostumerNameTextBox.Text = dt.Rows[0]["CostumerName"].ToString();
            //     vCostumermobileTextBox.Text = dt.Rows[0]["CostumerMobileNumber"].ToString();
            //     txtCostumerID.Text = dt.Rows[0]["CostumerId"].ToString();
            //    txtCostumerMobileNumber.Text = dt.Rows[0]["CostumerBikeNumber"].ToString();
            //    txtMeterReading.Text = dt.Rows[0]["MeterReading"].ToString();
            //   txtModelNumber.Text = dt.Rows[0]["ModelNumber"].ToString();


            //vCostumerAddress.Text = dt.Rows[0]["vCostumeradress"].ToString();
            //cmbSaleMan.SelectedValue = dt.Rows[0]["iSaleManID"].ToString();

        }

        public void AddItem(dhItems ObjDhInputItem = null)
        {
            dhItems ObjDhItem;

            //       if(ObjDhInputItem != null){
            ObjDhItem = iFacede.GetdhItem(Globalized.ObjDbName, new dhItems { VItemBarcode = ObjDhInputItem.VItemBarcode });
            //}else
            //{
            //    ObjDhItem = iFacede.GetdhItem(Globalized.ObjDbName, new dhItems { VItemBarcode = ItemList.SelectedValue.ToString() });
            //}
            if (ObjDhItem != null)
            {
                ObjDhItem.IQuantity = 0;

                iItemID.Text = ObjDhItem.IItemID.ToString();
                vItemName.Text = ObjDhItem.VItemName.ToString();
                fUnitPrice.Text = ObjDhItem.FUnitePrice.ToString();
                iQuantity.Text = "1";
                StockStatus.Text = ObjDhItem.StockStatus.ToString();
                ICurrantStock.Text = ObjDhItem.ICurrantStock.ToString();
                BIsEditAbleInInvoice.Text = ObjDhItem.BIsEditAbleInInvoice.ToString();

                FUnitPurchasePrice.Text = ObjDhItem.FUnitPurchasePrice.ToString();
                FGrossPurchasePrice.Text = (ObjDhItem.FUnitPurchasePrice * 1).ToString();
                AddItemToGrid();
                CalculateBill();
            }
            else
            {
                MessageBox.Show(("Item Having barcode ' " + ItemBarCode.Text.ToString() + " ' is not define , please contact your administrator.").ToString(), "Barcode is incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void insertnewinvoice()
        {
            //  txtVSecElectricianName.Text = Electrition2.SelectedValue == null ? "" : Electrition2.SelectedValue.ToString();
            // txtVFirstElectricianName.Text = Electrition.SelectedValue == null ? "" : Electrition.SelectedValue.ToString();

            if (Globalized.ObjPrefernce.BStockOverRide != true)
            {
                // check for stock 
                dhSaleItem ItemTorearch = new dhSaleItem();
                // ItemTorearch.IsAvailable = false;

                dhSaleItem item;
                item = grdItems.Items.Cast<dhSaleItem>().Where(i => i.StockStatus.Equals("Not Available")).FirstOrDefault();
                if (item != null) { throw new ApplicationException("There is an item \"" + item.VItemName + "\" which is out of stock \"Not Available \" please remove item to generate invoice. "); }

                item = grdItems.Items.Cast<dhSaleItem>().Where(i => i.IQuantity > i.ICurrantStock).FirstOrDefault();
                if (item != null) { throw new ApplicationException("There is an item \"" + item.VItemName + "\", Quantity is out of stock please reduce Quantity to generate invoice. "); }
            }

            CalculateBill();
            dhInvoice objInvoice = new dhInvoice();
            objInvoice = (dhInvoice)this.DataContext;
            objInvoice.ItemsOfInvoice = (DataHolders.ItemsList)grdItems.ItemsSource;
            if ((objInvoice.ISaleid != 0) && (objInvoice.ISaleid != null))
            {
                objInvoice.IUpdate = 1;
            }
            else
            {
                objInvoice.IUpdate = 0;
            }
            // set user ID 
            objInvoice.IUserid = Globalized.ObjCurrentUser.IUserid;
            dhInvoiceValidator validator = new dhInvoiceValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(objInvoice);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            //if (bIsdraft == true)
            //{
            //    objInvoice.BIsDraft = true;
            //    objInvoice.BFinalized = false;
            //}
            //else
            //{
            //    objInvoice.BIsDraft = false;
            //    objInvoice.BFinalized = true;                    
            //}




            if (validationSucceeded)
            {
                InsertUpdateCostumer();
                if (((Globalized.ObjPrefernce.VSaleType != "CR") || (Globalized.ObjPrefernce.VSaleType != "Both")) && (Globalized.ObjPrefernce.VSaleType == "Cash"))
                {

                    if ((objInvoice.FBalance != 0) || (objInvoice.FBalance < 0))
                    {
                        throw new ApplicationException("Credit is not Allowed Balance must be zero !");
                    }
                }
                int CustomerID;
                Int32.TryParse(txtCostumerID.Text.ToString(), out CustomerID);
                if (CustomerID > 0)
                {
                    objInvoice.ICostumerId = CustomerID;
                }
                else
                {
                    throw new ApplicationException("No Customer Selectd please select the customer or enter the custormer information.");
                }
                // its final Invoice so set the param
                objInvoice.BFinalized = true;
                objInvoice.BIsDraft = false;
                objInvoice.BCanelDone = false;
                objInvoice.BReturnInvoice = false;
                ds = iFacede.InsertUpdateSaleInovice(Globalized.ObjDbName, objInvoice, true);
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    System.Media.SystemSounds.Beep.Play();
                    lblErrorMsg.Visibility = Visibility.Hidden;
                    objInvoice = new dhInvoice();
                    objInvoice.ISaleid = Convert.ToInt32(ds.Tables[0].Rows[0]["iSaleid"].ToString());
                    DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objInvoice);
                    PrintUtilities.printDoc("Invoice.xaml", dsr, "Invoice", true);
                    string msg = "Invoice # " + objInvoice.ISaleid.ToString() + " is Generated Successfully to Costumer.'";
                    MessageBox.Show(msg, "Invoice Generated Successfully");
                    GlobalobjInvoice = new dhInvoice();
                    this.DataContext = GlobalobjInvoice;
                    grdItems.ItemsSource = null;
                    CostumerBox.DataContext = new dhCostumer();
                    // ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
                    // Obj.ContentSource = new Uri("/Pages/Invoice/ListInvoices.xaml", UriKind.Relative);

                }
            }
            else
            {
                //lblErrorMsg.Content = ;
                throw new ApplicationException(failures.First().ErrorMessage);
            }

        }

        private void printinvoice(bool? p)
        {

            DataSet ds;
            //  lblErrorMsg.Content = "";
            dhInvoice objInvoice = new dhInvoice();
            objInvoice.ISaleid = this.GlobalobjInvoice.ISaleid;

            ds = iFacede.GetSaleInovice(Globalized.ObjDbName, objInvoice);
            dhPreference GlobalObjPreference = new dhPreference();
            dsGeneral.dtPosPreferenceDataTable dt = iFacede.GetPreference(Globalized.ObjDbName, GlobalObjPreference);
            ds.Tables.Add(dt.Copy());
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                //DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objInvoice);
                //if (this.GlobalobjInvoice.BCanelDone == true)
                //{
                //    PrintUtilities.printDoc("CancelInvoice.xaml", ds, "Invoice", true);
                //    return;
                //}

                if (p == true)
                {
                    PrintUtilities.printDoc("ReturnInvoice.xaml", ds, "Invoice", true);
                }
                else
                {
                    PrintUtilities.printDoc("Invoice.xaml", ds, "Invoice", true);
                }

            }
            else
            {
                throw new System.InvalidOperationException("There is a problem with database, can’t print the Invoice!!");
            }


        }

        private T FindChildByType<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                    return child as T;
                DependencyObject grandchild = FindChildByType<T>(child);
                if (grandchild != null)
                    return grandchild as T;
            }
            return default(T);
        }

        private void AddItemToGrid()
        {
            dhSaleItem newItem = (dhSaleItem)Item_Grid.DataContext;
            var item = grdItems.Items.Cast<dhSaleItem>().Where(i => i.IItemID.Equals(newItem.IItemID)).SingleOrDefault();
            if (item == null)
            {
                iFacede.InsertNewItemRow(grdItems, newItem, ftotalamountTextBox);
                Item_Grid.DataContext = new dhSaleItem();
                //  //if (vDeliveryExpenseTextBox.Text == "") { vDeliveryExpenseTextBox.Text = "0"; }
                ////  ItemList.Focus();
                // // ItemList.SelectedValue = null;
                // // ItemList.SelectedItem = new dhItems();
                //  // ItemList.Content = "";
                //  var child = FindChildByType<TextBox>(ItemList);
                //  child.Text = "";
                //  //child.Focus();
                lblErrorMsg.Content = "";
                GlobalobjInvoice.ItemsOfInvoice = (DataHolders.ItemsList)grdItems.ItemsSource;

            }
            else
            {
                //var child = FindChildByType<TextBox>(ItemList);
                //child.Text = "";
                //child.Focus();
                ItemBarCode.Focus();
                ItemBarCode.SelectAll();
                //     throw new ApplicationException("Item is Already Added to emp.");
                Globalized.setException("Item is Already Added to invoice.", lblErrorMsg, CustomClasses.MsgType.Error);

            }
        }


        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox SentFrom = (TextBox)e.Source;
                int? i = objEmpToEdit.ICurrantStock;

                if (Globalized.ObjPrefernce.BStockOverRide != true)
                {
                    if ((i != null) && (SentFrom.Text != "") && (Convert.ToInt32(SentFrom.Text) > i))
                    {
                        MessageBox.Show("Quantity required that you enter is grater then quantity available in stock.", "Out Of Stock");
                        SentFrom.Text = objEmpToEdit.IQuantity.ToString();
                    }
                }
                if (SentFrom.Text == "")
                {
                    MessageBox.Show("Quantity Could Not be Empty", "Entere the Quantity");
                    SentFrom.Text = objEmpToEdit.IQuantity.ToString();
                    // e.Handled = false;
                    //   return;
                    SentFrom.Focus();
                }
                dhSaleItem objCeck = grdItems.SelectedItem as dhSaleItem;
                UpdateSource(sender);
                CalculateBill();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void InsertReturnInvoice()
        {

            CalculateBill();
            dhInvoice objInvoice = new dhInvoice();
            objInvoice = (dhInvoice)this.DataContext;
            objInvoice.ItemsOfInvoice = (DataHolders.ItemsList)grdItems.ItemsSource;
            DateTime diff1;
            if (Globalized.ObjPrefernce.BDurationReturnOnly == true)
            {
                //              today     = System.DateTime.Today
                //yesterday = today.AddDays( -1 )
                //tomorrow  = today.AddDays(  1 )
                if ((Globalized.ObjPrefernce.IAllowedBackDays != null) && (Globalized.ObjPrefernce.IAllowedBackDays > 0))
                {
                    diff1 = DateTime.Now.AddDays(-(Convert.ToDouble(Globalized.ObjPrefernce.IAllowedBackDays.ToString())));
                    if (objInvoice.Ddate < diff1)
                    {
                        throw new ApplicationException("The invoice date is too old could not be cancel/return. " + Globalized.ObjPrefernce.IAllowedBackDays + " days old invoices are allowed to cancel/return.");
                    }
                }

            }

            objInvoice.IUpdate = 0;
            // set user ID 
            objInvoice.IUserid = Globalized.ObjCurrentUser.IUserid;

            //  Customer customer = new Customer();
            dhInvoiceValidator validator = new dhInvoiceValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(objInvoice);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if (validationSucceeded)
            {
                // set boolean param 
                objInvoice.BIsDraft = false;
                objInvoice.BReturnInvoice = true;
                objInvoice.BFinalized = true;
                objInvoice.BCanelDone = true;
                //    objInvoice.ICostumerId = Convert.ToInt32(txtCostumerID.Text.ToString());
                int CustomerID;
                Int32.TryParse(txtCostumerID.Text.ToString(), out CustomerID);
                if (CustomerID > 0)
                {
                    objInvoice.ICostumerId = CustomerID;
                }
                else
                {
                    throw new ApplicationException("No Customer Selectd please select the customer or enter the custormer information.");
                }
                //this.DataContext = objInvoice;
                objInvoice.BReturnInvoice = true;
                GlobalobjInvoice.Ddate = DateTime.Now;
                GlobalobjInvoice.IUpdate = 0;
                ds = iFacede.InsertUpdateSaleInovice(Globalized.ObjDbName, objInvoice, true); // insert new record for return
                // update this emp as its is cancel 
                GlobalobjInvoice.IUpdate = 1;
                GlobalobjInvoice.BCanelDone = true;

                DataSet dsr;

                iFacede.InsertUpdateSaleInovice(Globalized.ObjDbName, GlobalobjInvoice, false); // update old
                if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                {
                    System.Media.SystemSounds.Beep.Play();
                    lblErrorMsg.Visibility = Visibility.Hidden;

                    objInvoice = new dhInvoice();
                    objInvoice.ISaleid = Convert.ToInt32(ds.Tables[0].Rows[0]["iSaleid"].ToString());
                    dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objInvoice);
                    PrintUtilities.printDoc("CancelInvoice.xaml", dsr, "Invoice", true);
                    Globalized.SetMsg("Return Invoice # " + objInvoice.ISaleid.ToString() + " is Generated Successfully for Costumer . Check Invoice List.", MsgType.Info);
                    Globalized.ShowMsg(lblErrorMsg);
                    this.GlobalobjInvoice.BReturnInvoice = false; // as this emp which is loaded is not returnd actualy 
                    //  LoadData();
                    //MessageBox.Show("Check Invoice List.");
                    this.btnCnclInvoice.Visibility = System.Windows.Visibility.Hidden;

                    //Obj.ContentSource = new Uri("/Pages/Invoice/ListInvoices.xaml", UriKind.Relative);
                    //
                }
            }
            else
            {
                throw new ApplicationException(failures.First().ErrorMessage);
            }


        }

        private void btnCnclInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string messageBoxText = "Are sure to cancel this invoice and generate a  return invoice?";
                string caption = "Are you sure?";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                if (result == MessageBoxResult.Yes)
                {
                    InsertReturnInvoice();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void btnDraft_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly == true) || (this.GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    printinvoice(this.GlobalobjInvoice.BReturnInvoice);
                //}
                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice != true))
                //{
                SaveDraft(true);
                //}

                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    InsertReturnInvoice();
                //}


            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void btnDraft_Click_print(object sender, RoutedEventArgs e)
        {
            try
            {
                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly == true) || (this.GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    printinvoice(this.GlobalobjInvoice.BReturnInvoice);
                //}
                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice != true))
                //{
                //SaveDraft(true);
                //}
                PrintIt();
                //if ((this.GlobalobjInvoice != null) && (this.GlobalobjInvoice.IsReadOnly != true) && (this.GlobalobjInvoice.BReturnInvoice == true))
                //{
                //    InsertReturnInvoice();
                //}


            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }


        private void SaveDraft(bool? bIsdraft)
        {

            CalculateBill();
            dhInvoice objInvoice = new dhInvoice();
            objInvoice = (dhInvoice)this.DataContext;
            objInvoice.ItemsOfInvoice = (DataHolders.ItemsList)grdItems.ItemsSource;
            if (!string.IsNullOrEmpty(objInvoice.ISaleid.ToString()))
            {
                objInvoice.IUpdate = 1;
            }
            else
            {
                objInvoice.IUpdate = 0;
            }

            // set user ID 
            objInvoice.IUserid = Globalized.ObjCurrentUser.IUserid;
            dhInvoiceValidator validator = new dhInvoiceValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(objInvoice);

            //bool validationSucceeded = results.IsValid;
            //IList<ValidationFailure> failures = results.Errors;

            if (bIsdraft == true)
            {
                objInvoice.BIsDraft = true;
                objInvoice.BFinalized = false;
            }
            else
            {
                objInvoice.BIsDraft = false;
                objInvoice.BFinalized = true;
            }

            InsertUpdateCostumer();

            //     objInvoice.ICostumerId = Convert.ToInt32(txtCostumerID.Text.ToString());

            int CustomerID;
            Int32.TryParse(txtCostumerID.Text.ToString(), out CustomerID);
            if (CustomerID > 0)
            {
                objInvoice.ICostumerId = CustomerID;
            }
            else
            {
                throw new ApplicationException("No Customer Selectd please select the customer or enter the custormer information.");
            }

            ds = iFacede.InsertUpdateSaleInovice(Globalized.ObjDbName, objInvoice, true);
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                System.Media.SystemSounds.Beep.Play();
                lblErrorMsg.Visibility = Visibility.Hidden;
                objInvoice = new dhInvoice();
                objInvoice.ISaleid = Convert.ToInt32(ds.Tables[0].Rows[0]["iSaleid"].ToString());
                ISaleid.Text = ds.Tables[0].Rows[0]["iSaleid"].ToString();

                DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, objInvoice);
                //  ObservableCollection<dhInvoice> Obj = ReflectionUtility.DataTableToObservableCollection<dhInvoice>(dsr.Tables[0]);
                ObservableCollection<dhSaleItem> list = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(dsr.Tables[1]);
                //if (Obj.Count > 0)
                //{
                //    this.GlobalobjInvoice = (dhInvoice)Obj[0];
                //}
                this.GlobalobjInvoice.ItemsOfInvoice = new ItemsList().AddRange(list); //(ItemsList)list;
                Globalized.SetMsg("Invoice is saved as Draft you can Edit Draft Invoice any time.", MsgType.Info);

                //   lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
                //
                LoadData();
                // PrintUtilities.printDoc("Invoice.xaml", dsr, "Invoice", true);
                //Globalized.SetMsg("Invoice # " + objInvoice.ISaleid.ToString() + " is Generated Successfully to Costumer '" + objInvoice.VCostumerName + "'", MsgType.Info);

                //ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
                //Obj.ContentSource = new Uri("/Pages/Invoice/ListInvoices.xaml", UriKind.Relative);
            }


        }
        private void PrintIt()
        {
            DataSet dsr = iFacede.GetSaleInovice(Globalized.ObjDbName, GlobalobjInvoice);
            ObservableCollection<dhSaleItem> list = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(dsr.Tables[1]);
            this.GlobalobjInvoice.ItemsOfInvoice = new ItemsList().AddRange(list); //(ItemsList)list;

            //  LoadData();
            PrintUtilities.printDoc("Invoice.xaml", dsr, "Invoice", true);
        }
        private void ItemList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            // AddItem();

        }

        private void ItemBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.Key == Key.Enter)
            //    {
            //        if (ItemList.SelectedValue != null)
            //        {
            //            //int int ;
            //            AddItem();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            //}
        }

        private void ItemBarCode_LostFocus(object sender, RoutedEventArgs e)
        {
            //try
            //{

            //    dhItems ObjDhInputItem = new dhItems();
            //    if (ItemBarCode.Text.Length > 1)
            //    {
            //        ObjDhInputItem.VItemBarcode = ItemBarCode.Text;
            //        AddItem(ObjDhInputItem);
            //        ItemBarCode.Text = "";
            //        //ItemBarCode.Focus();
            //        Keyboard.Focus(ItemBarCode);   
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            //}
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
                        ObjDhInputItem.VItemBarcode = ItemBarCode.Text;
                        AddItem(ObjDhInputItem);
                        ItemBarCode.Text = "";
                        ItemBarCode.Focus();
                        Keyboard.Focus(ItemBarCode);
                    }
                }

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }

        private void ItemList_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.Key == Key.Enter)
            //    {
            //        if (ItemList.SelectedValue != null)
            //        {
            //            //int int ;
            //            AddItem();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            //}
        }


        private void InsertUpdateCostumer()
        {
            dhCostumer IUCostumerObject = (dhCostumer)CostumerBox.DataContext;
            int CID;
            int.TryParse(IUCostumerObject.CostumerID.ToString(), out CID);
            if (CID > 0)
            { // let we update 
                IUCostumerObject.IUpdate = 1;
            }
            else
            { // let insert 
                IUCostumerObject.IUpdate = 0;
            }

            if (bFallow.IsChecked == true)
            {
                IUCostumerObject.DLastInovice = GlobalobjInvoice.Ddate;
                IUCostumerObject.DAlertDate = ((DateTime)(IUCostumerObject.DLastInovice)).AddDays(45);
            }
            dhCostumerValidator validator = new dhCostumerValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(IUCostumerObject);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if (validationSucceeded)
            {
                DataSet ds = iFacede.InsertUpdateCostumer(Globalized.ObjDbName, IUCostumerObject);
                if (!((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0) && ((ds.Tables[0].Rows[0]["CostumerID"].ToString() != "") || (ds.Tables[0].Rows[0]["CostumerID"].ToString() != "0"))))
                {
                    throw new ApplicationException("There Is a problem in saving costumer info contact admin");
                }
                else
                {
                    SetCostumer(Convert.ToInt64(ds.Tables[0].Rows[0]["CostumerID"].ToString()));
                }
            }
            else
            {
                throw new ApplicationException(failures.First().ErrorMessage);
            }


        }
        int lastlift;
        private void txtMeterReading_Copy_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //int LiftNUmber;
                //int.TryParse(txtMeterReading_Copy.Text, out LiftNUmber);

                //if(LiftNUmber > 0)
                //{
                //   // if( LiftNumbers.selct(
                //    if (Globalized.LiftNumbers.Any(x => x == LiftNUmber))
                //    {
                //        MessageBox.Show(("Lift Number that you are trying is not avaliable.").ToString(), "Lift is in Used", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //    else
                //    {
                //        Globalized.LiftNumbers.Add(LiftNUmber);
                //        lastlift = LiftNUmber;
                //    }

                //}

                //if (e.Key == Key.Enter)
                //{

                //}
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }


        }

        private void txtFServices_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    CalculateBill();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fPayAbleAmountTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    CalculateBill();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void fBlance_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    UpdateSource(sender);
                    CalculateBill();
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void txtFServices_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                CalculateBill();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        private void TextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox SentFrom = (TextBox)e.Source;
                int? i = objEmpToEdit.ICurrantStock;

                if (Globalized.ObjPrefernce.BStockOverRide != true)
                {
                    if ((i != null) && (SentFrom.Text != "") && (Convert.ToInt32(SentFrom.Text) > i))
                    {
                        MessageBox.Show("Quantity required that you enter is grater then quantity available in stock.", "Out Of Stock");
                        SentFrom.Text = objEmpToEdit.IQuantity.ToString();
                    }
                }
                if (SentFrom.Text == "")
                {
                    MessageBox.Show("Quantity Could Not be Empty", "Entere the Quantity");
                    SentFrom.Text = objEmpToEdit.IQuantity.ToString();
                    // e.Handled = false;
                    //   return;
                    SentFrom.Focus();
                }
                dhSaleItem objCeck = grdItems.SelectedItem as dhSaleItem;
                UpdateSource(sender);
                CalculateBill();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }
    }
}
