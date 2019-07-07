using DataHolders;
using FluentValidation.Results;
using iFacedeLayer;
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

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : UserControl
    {
        dhEmployee GlobalObjEmployee = new dhEmployee();
        AddEmployeeViewModel MyViewModel ;
        public AddEmployeeView()
        {
            InitializeComponent();
            MyViewModel = new AddEmployeeViewModel();
        }
        public AddEmployeeView(dhEmployee objTodisplay)
        {
            InitializeComponent();
            MyViewModel = new AddEmployeeViewModel(objTodisplay);
         //   InitializeComponent();
            this.GlobalObjEmployee = new dhEmployee();
            this.GlobalObjEmployee = objTodisplay;

            this.EmpInfo.DataContext = this.GlobalObjEmployee;
            this.AccountInfo.DataContext = MyViewModel.EmployeeAccount;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dhEmployee objEmployee = new dhEmployee();
                objEmployee = (dhEmployee)EmpInfo.DataContext;



                objEmployee.VMartialStatus = VMartialStatus.SelectedValue.ToString();
                int IIEmpid;
                if (cmbIEmpTypeId.SelectedValue != null)
                {
                    int.TryParse(cmbIEmpTypeId.SelectedValue.ToString(), out IIEmpid);
                    objEmployee.IEmpTypeId = IIEmpid;
                }
                else
                {
                    objEmployee.IEmpTypeId = 1;
                    objEmployee.IEmpTypeId = 1;
                }
                // check for existing Name 
                dhEmployeeValidator validator = new dhEmployeeValidator();
                FluentValidation.Results.ValidationResult results = validator.Validate(objEmployee);

                bool validationSucceeded = results.IsValid;
                IList<ValidationFailure> failures = results.Errors;

                if (validationSucceeded)
                {
                    dsGeneral.dtEmployeeDataTable dtEmployee = iFacede.GetEmployee(Globalized.ObjDbName, new dhEmployee());
                    ObservableCollection<dhEmployee> listItem = ReflectionUtility.DataTableToObservableCollection<dhEmployee>(dtEmployee);
                    string bFound = null;

                    //if ((this.vEmployeeNameTextBox.Text!= "") && (item.VEmployeeName != "")) { }
                    //foreach (dhEmployee item in ListAccounts)
                    //{
                    //    string[] words = item.VEmployeeName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //    string[] filter = objEmployee.VEmployeeName.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    //    if ((objEmployee.IEmployeeID != null) && (item.IEmployeeID == objEmployee.IEmployeeID))
                    //    {
                    //        continue;
                    //    }
                    //    bFound = words.Where(x => filter.Contains(x.ToLower())).FirstOrDefault();
                    //    if (bFound != null)
                    //    {
                    //        break;
                    //    }
                    //}
                    //if (bFound != null)
                    //{
                    //    if (!blUtil.OverrideInformation(objEmployee.VEmployeeName, bFound))
                    //    {
                    //        this.vEmployeeNameTextBox.SelectAll();
                    //        this.vEmployeeNameTextBox.Focus();
                    //        return;
                    //    }
                    //}

                    //if (iSaleManIDComboBox.SelectedValue != null)
                    //{
                    //  objEmployee.ISaleManID = Convert.ToInt32(iSaleManIDComboBox.SelectedValue.ToString());
                    //}

                    //   objEmployee.VCity = VMartialStatus.SelectedValue.ToString();
                    //  objEmployee.VEmployeeadress = objEmployee.VMarket + " , " + objEmployee.VArea + " , " + objEmployee.VDistrict + " , " + objEmployee.VCity;


                    //lblErrorMsg.Visibility = Visibility.Hidden;
                    DataSet dsr = iFacede.InsertUpdateEmployee(Globalized.ObjDbName, objEmployee);
                    if (dsr.Tables[0].Rows.Count > 0)
                    {
                        objEmployee.IEmpid = Convert.ToInt32(dsr.Tables[0].Rows[0][0].ToString());
                    }
                    if (objEmployee.IUpdate == 1)
                    {
                       

                        //lblErrorMsg.Visibility = Visibility.Visible;
                        //lblErrorMsg.Foreground = Brushes.Green;
                        //lblErrorMsg.Content = "Employee ' " + objEmployee.VEmployeeName + " ' Information is Updated Successfully";
                        Globalized.SetMsg("Employee ' " + objEmployee.VEmpfName + " ' Information is Updated Successfully", DataHolders.MsgType.Info);
                       // Globalized.ShowMsg(lblErrorMsg);
                        GlobalObjEmployee = objEmployee;
                        // We need to get data from database to bind it back
                        LoadData();
                        // LoadData();

                    }
                    else
                    {
                        Globalized.SetMsg("Employee ' " + objEmployee.VEmpfName + " ' Information is Saved Successfully", DataHolders.MsgType.Info);
                        objEmployee.IUpdate = 1;
                        GlobalObjEmployee = objEmployee;
                        // We need to get data from database to bind it back
                        LoadData();
                        //    ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
                        //    GlobalObjEmployee = null;
                        //    Obj.ContentSource = new Uri("/Pages/emp/listEmp.xaml", UriKind.Relative);
                    }


                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    lblErrorMsg.Visibility = Visibility.Visible;
                    lblErrorMsg.Foreground = Brushes.Red;
                    lblErrorMsg.Content = failures.First().ErrorMessage;
                }
                //Globalized.ShowMsg(lblErrorMsg);
           
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }
        static DataTable GetEmType()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("iEmpTypeId", typeof(int));
            table.Columns.Add("vEmpType", typeof(string));

            //
            // Here we add DataRows.
            //

            table.Rows.Add(01, "Accountant");
            table.Rows.Add(02, "Foreman");
            table.Rows.Add(03, "Senoir Technition");
            table.Rows.Add(04, "Technition");
            table.Rows.Add(05, "Electition");
            table.Rows.Add(06, "Helper");
            table.Rows.Add(07, "Driver");
            table.Rows.Add(07, "Chief Executive");
            table.Rows.Add(07, "Managing Director");
            table.Rows.Add(07, "Assistant Manager");
            table.DefaultView.Sort = "iEmpTypeId ASC";
            return table;
        }
        static DataTable GetTable()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("IMartialStatusID", typeof(int));
            table.Columns.Add("MartialStatus", typeof(string));


            //
            // Here we add DataRows.
            //
            table.Rows.Add(01, "Married");
            table.Rows.Add(02, "Signal");

            table.DefaultView.Sort = "IMartialStatusID ASC";
            return table;
        }

        private void LoadData()
        {
            VMartialStatus.DataContext = GetTable();
            cmbIEmpTypeId.DataContext = GetEmType();
            VMartialStatus.DisplayMemberPath = "MartialStatus";
            VMartialStatus.SelectedValuePath = "MartialStatus";
            cmbIEmpTypeId.DisplayMemberPath = "vEmpType";
            cmbIEmpTypeId.SelectedValuePath = "iEmpTypeId";

            if ((GlobalObjEmployee != null) && (GlobalObjEmployee.IEmpid > 0))
            {
                EmpInfo.DataContext = GlobalObjEmployee;
                VMartialStatus.SelectedValue = GlobalObjEmployee.VMartialStatus;
                cmbIEmpTypeId.SelectedValue = GlobalObjEmployee.IEmpTypeId;
                if (GlobalObjEmployee.Active != true)
                {
                    SalleryBox.IsEnabled = false;
                }
                else
                {
                    SalleryBox.IsEnabled = true;
                }
                //else
                //{
                //    SalleryBox.DataContext = new dhSalary();
                //}
                BindSalary();
                
            }
            else
            {
                GlobalObjEmployee = new dhEmployee();
                EmpInfo.DataContext = GlobalObjEmployee;
                SalleryBox.IsEnabled = false;
            }
            MyViewModel.ObjAddEdit = GlobalObjEmployee;
            MyViewModel.EmployeeAccount = Globalized.GetAccountByMdule(MyViewModel.db, MyViewModel.ObjAddEdit.IEmpid, MyViewModel.MyModuel.IModuleID);
            this.AccountInfo.DataContext = MyViewModel.EmployeeAccount;

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

                    //if(str.ToLowerInvariant().Contains(value.ToLowerInvariant()))
                    // return true;
                }
            }

            return false;
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {

                LoadData();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void vEmployeeMobileTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void vEmployeeMobileTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Boolean Have = Globalized.NumaricKey.Contains(e.Key);
            //if (!Globalized.NumaricKey.Contains(e.Key))
            //{
            //    e.Handled = true;
            //}
        }

        private void vEmployeeMobileTextBox_PreviewKeyUp_1(object sender, KeyEventArgs e)
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

        private void vEmployeeMobileTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {

            //if (Globalized.NumaricKey.Contains(e.Key))
            //{
            //    e.Handled = false;

            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void vLandlineNumberTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {

                // Button SenderBtn = sender as Button;
                if (gnrtSalary.Content.ToString() == "Calculate")
                {
                    if (SalleryBox.DataContext != null)
                    {
                        GenrateSallary((dhSalary)(SalleryBox.DataContext));
                    }
                    else
                    {
                        GenrateSallary();
                    }

                    return;
                }
                if (gnrtSalary.Content.ToString() == "Save")
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Once Salary is generated you will be unable to Edit, please double check the calculation. Click Yes to generate, No to change.", "Salary Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        SaveSalary();
                        return;
                    }
                }
                if (gnrtSalary.Content.ToString() == "Pay Salary")
                {
                    if (SalleryBox.DataContext != null)
                    {
                        PaySalary();

                        this.SalleryBox.DataContext = new dhSalary();
                        this.gnrtSalary.Content = "Calculate";
                        return;
                    }



                }

                if (gnrtSalary.Content.ToString() == "Calculate")
                {
                    if (SalleryBox.DataContext != null)
                    {
                        GenrateSallary((dhSalary)(SalleryBox.DataContext));
                        // BindSalary();
                    }
                    else
                    {
                        GenrateSallary();
                        //    BindSalary();
                    }

                    return;
                }


            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }
        private void CalculateDays()
        {
            dhSalary OBjSalaryUpdate = new dhSalary();
            OBjSalaryUpdate = (dhSalary)this.SalleryBox.DataContext;
            if (OBjSalaryUpdate != null)
            {
                DateTime StartDate;
                if (OBjSalaryUpdate.dSrtDate != null)
                {
                    StartDate = (DateTime)OBjSalaryUpdate.dSrtDate;
                }
                else
                {
                    return;
                }
                DateTime EndDate;
                if (OBjSalaryUpdate.dSrtDate != null)
                {
                    EndDate = (DateTime)OBjSalaryUpdate.dEndDate;
                }
                else
                {
                    return;
                }
                OBjSalaryUpdate.iDays = (Int32)(EndDate - StartDate).TotalDays;
                CalculateSallary();
            }
        }
        private void GenrateSallary(dhSalary objPassed = null)
        {
            dhSalary objSalry = new dhSalary();
            objSalry.iEmpId = GlobalObjEmployee.IEmpid;
            dsGeneral.dtSalaryDataTable SalaryDataTable;
            SalaryDataTable = iFacede.GetSalary(Globalized.ObjDbName, objSalry);
            ObservableCollection<dhSalary> objSalary = ReflectionUtility.DataTableToObservableCollection<dhSalary>(SalaryDataTable);
            dhSalary NSalary;
            //if ((objPassed != null)&& (objPassed!= (new dhSalary())))
            //{
            //    NSalary = objPassed ;//new dhSalary();
            //    NSalary.dSrtDate = ((DateTime)(objPassed.dEndDate)).AddDays(1);
            //    this.dddSrtDate.DisplayDateStart = (DateTime)NSalary.dSrtDate;
            //    NSalary.dEndDate = ((DateTime)(NSalary.dSrtDate)).AddDays(Convert.ToDouble(Globalized.ObjPrefernce.ISalaryDays)) > DateTime.Now ? DateTime.Now : ((DateTime)(NSalary.dSrtDate)).AddDays(Convert.ToDouble(Globalized.ObjPrefernce.ISalaryDays));
            //    this.dddSrtDate.DisplayDateStart = NSalary.dSrtDate;
            //    this.dddEndDate.DisplayDateStart = NSalary.dEndDate;
            //    NSalary.iDays = (((DateTime)(NSalary.dEndDate)) - ((DateTime)(NSalary.dSrtDate))).Days;//Globalized.ObjPrefernce.ISalaryDays;
            //    NSalary.IAbsentdays = 0;
            //    NSalary.iDeduction = 0;
            //    NSalary.iAmount = 0;
            //    NSalary.FOverTime = 0;
            //    this.SalleryBox.DataContext = NSalary;

            //}
            //else
            //{

            DateTime StartDate = DateTime.Now;
            if (objSalary.Count > 0)
            {
                NSalary = objSalary[0];
                StartDate = ((DateTime)NSalary.dEndDate).AddDays(1);
            }
            else
            {
                NSalary = new dhSalary();
                StartDate = GlobalObjEmployee.DDateOfJoining == null ? DateTime.Now : (DateTime)GlobalObjEmployee.DDateOfJoining;
            }

            this.dddSrtDate.DisplayDateStart = StartDate;
            this.dddEndDate.DisplayDateStart = StartDate;
            NSalary.dSrtDate = StartDate;//GlobalObjEmployee.DDateOfJoining;
            DateTime Dend = StartDate.AddDays(Globalized.ObjPrefernce.ISalaryDays);

            NSalary.dEndDate = Dend;
            //NSalary.dSrtDate = GlobalObjEmployee.DDateOfJoining == null ? DateTime.Now : (DateTime)GlobalObjEmployee.DDateOfJoining; // GlobalObjEmployee.DDateOfJoining;
            //DateTime StartDate = GlobalObjEmployee.DDateOfJoining == null ? DateTime.Now : (DateTime)GlobalObjEmployee.DDateOfJoining;
            // NSalary.dSrtDate = ((DateTime)(objPassed.dEndDate)).AddDays(1);
            // NSalary.dEndDate = ((DateTime)(NSalary.dSrtDate)).AddDays(Convert.ToDouble(Globalized.ObjPrefernce.ISalaryDays)) > DateTime.Now ? DateTime.Now : ((DateTime)(NSalary.dSrtDate)).AddDays(Convert.ToDouble(Globalized.ObjPrefernce.ISalaryDays));
            NSalary.iDays = (((DateTime)(NSalary.dEndDate)) - ((DateTime)(NSalary.dSrtDate))).Days;//Globalized.ObjPrefernce.ISalaryDays;
            NSalary.IAbsentdays = 0;
            NSalary.iDeduction = 0;
            NSalary.iAmount = 0;
            NSalary.FOverTime = 0;
            this.SalleryBox.DataContext = NSalary;

            //if (objSalary.Count > 0)
            //{
            //    dhSalary objNewSalary = new dhSalary();
            //    objNewSalary.dSrtDate = objSalary[0].dEndDate;
            //    DateTime StartDate = (DateTime)objNewSalary.dSrtDate;//GlobalObjEmployee.DDateOfJoining == null ? DateTime.Now : (DateTime)GlobalObjEmployee.DDateOfJoining;
            //    DateTime Dend = StartDate.AddDays(Globalized.ObjPrefernce.ISalaryDays);
            //    objNewSalary.dEndDate = Dend;
            //    objNewSalary.iDays = Globalized.ObjPrefernce.ISalaryDays;
            //    objNewSalary.IAbsentdays = 0;
            //    objNewSalary.iDeduction = 0;
            //    objNewSalary.iAmount = 0;
            //    objNewSalary.FOverTime = 0;
            //    this.SalleryBox.DataContext = objNewSalary;
            //    //CalculateSallary();
            //}
            //else
            //{
            //    dhSalary objNewSalary = new dhSalary();
            //    objNewSalary.dSrtDate = GlobalObjEmployee.DDateOfJoining;
            //    DateTime StartDate = GlobalObjEmployee.DDateOfJoining == null ? DateTime.Now : (DateTime)GlobalObjEmployee.DDateOfJoining;
            //    DateTime Dend = StartDate.AddDays(Globalized.ObjPrefernce.ISalaryDays);
            //    objNewSalary.dEndDate = Dend;
            //    objNewSalary.iDays = Globalized.ObjPrefernce.ISalaryDays;
            //    objNewSalary.IAbsentdays = 0;
            //    objNewSalary.iDeduction = 0;
            //    objNewSalary.iAmount = 0;
            //    objNewSalary.FOverTime = 0;
            //    //objNewSalary.
            //    //    int DaysToWork = (DateTime.DaysInMonth(Dend.Year, Dend.Month));
            //    //     objNewSalary.iAmount = (GlobalObjEmployee.IBasicSalary / DaysToWork) * Globalized.ObjPrefernce.ISalaryDays;
            //    this.SalleryBox.DataContext = objNewSalary;

            //}
            //   }
            CalculateSallary();
            gnrtSalary.Content = "Save";
            Globalized.setException("Salary is calculated for the period click to Save to save.", lblSalarymsg, DataHolders.MsgType.Info);
        }
        private void BindSalary()
        {
            dhSalary objSalry = new dhSalary();
            // SalaryDataGrid.DataContext = new dhSalary();
            objSalry.iEmpId = GlobalObjEmployee.IEmpid;
            dsGeneral.dtSalaryDataTable SalaryDataTable;
            SalaryDataTable = iFacede.GetSalary(Globalized.ObjDbName, objSalry);
            ObservableCollection<dhSalary> ListObjSalary = ReflectionUtility.DataTableToObservableCollection<dhSalary>(SalaryDataTable);
            //this.SalaryDataGrid.ItemsSource = ListObjSalary;
            // setup for new salary 
            //if (ListObjSalary.Count > 0)
            //{
            //    dhSalary NSalary = new dhSalary();
            //    GenrateSallary(ListObjSalary[0]);

            //    CalculateSallary();
            //}
        }
        private void PaySalary()
        {
            dhSalary ObjSalaryInsert = new dhSalary();
            ObjSalaryInsert = (dhSalary)this.SalleryBox.DataContext;
            ObjSalaryInsert.iEmpId = GlobalObjEmployee.IEmpid;
            ObjSalaryInsert.IUpdate = 1;
            ObjSalaryInsert.bIsPaid = true;
            DataSet ds = iFacede.InsertUpdateSalary(Globalized.ObjDbName, ObjSalaryInsert);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Globalized.setException("Select Salary is Marked As Paid.", lblSalarymsg, DataHolders.MsgType.Info);
                    return;
                }
            }
        }
        private void SaveSalary()
        {
            dhSalary ObjSalaryInsert = new dhSalary();
            ObjSalaryInsert = (dhSalary)this.SalleryBox.DataContext;
            ObjSalaryInsert.iEmpId = GlobalObjEmployee.IEmpid;
            ObjSalaryInsert.bIsPaid = null;
            ObjSalaryInsert.IUpdate = 0;
            DataSet ds = iFacede.InsertUpdateSalary(Globalized.ObjDbName, ObjSalaryInsert);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.SalleryBox.DataContext = new dhSalary();
                    this.gnrtSalary.Content = "Calculate";
                    BindSalary();
                    return;
                }
            }
        }
        private void CalculateSallary()
        {
            dhSalary OBjSalaryUpdate = new dhSalary();
            OBjSalaryUpdate = (dhSalary)this.SalleryBox.DataContext;
            if (OBjSalaryUpdate != null)
            {
                // per day salary 
                DateTime Dend = (DateTime)OBjSalaryUpdate.dEndDate;
                //objNewSalary.dEndDate = Dend;
                //objNewSalary.iDays = Globalized.ObjPrefernce.ISalaryDays;
                //objNewSalary.IAbsentdays = 0;
                int DaysToWork = (DateTime.DaysInMonth(Dend.Year, Dend.Month));
                double PerDay = (double)(GlobalObjEmployee.IBasicSalary / DaysToWork);
                // salary of working days 
                double? SalaryForWorkingDays = (double)(((PerDay * OBjSalaryUpdate.iDays) - ((PerDay * OBjSalaryUpdate.IAbsentdays) + OBjSalaryUpdate.iDeduction)) + OBjSalaryUpdate.FOverTime);
                OBjSalaryUpdate.iAmount = SalaryForWorkingDays;
                this.SalleryBox.DataContext = OBjSalaryUpdate;
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

        private void txtIAbsentdays_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                CalculateSallary();

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void txtiDeduction_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                CalculateSallary();

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void txtIOverTimeAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateSource(sender);
                CalculateSallary();

            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void dddSrtDate_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            //   CalculateDays();
        }

        private void dddSrtDate_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                CalculateDays();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }

        }

        private void dddEndDate_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                CalculateDays();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }
        dhSalary SelectedSalary = new dhSalary();
        //private void SalaryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        SelectedSalary = SalaryDataGrid.SelectedItem as dhSalary;
        //        ChangeSalary(SelectedSalary);
        //    }
        //    catch (Exception ex)
        //    {
        //        Globalized.setException(ex, lblErrorMsg, MsgType.Error);
        //    }
        //}


        private void ChangeSalary(dhSalary dhsal)
        {
            try
            {
                this.SalleryBox.DataContext = dhsal;
                if (dhsal.bIsPaid == true)
                {
                    txtIAbsentdays.IsEnabled = false;
                    txtIOverTimeAmount.IsEnabled = false;
                    txtiDeduction.IsEnabled = false;
                    dddEndDate.IsEnabled = false;
                    CalculateSallary();
                    this.gnrtSalary.Content = "Paid";
                }
                else
                {
                    txtIAbsentdays.IsReadOnly = true;
                    txtIOverTimeAmount.IsReadOnly = true;
                    txtiDeduction.IsReadOnly = true;
                    dddEndDate.IsEnabled = true;
                    CalculateSallary();
                    this.gnrtSalary.Content = "Pay Salary";
                }
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void ShowAccount_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                dhTransactionList objtoBind = new dhTransactionList();
                objtoBind.IAccountID = ((dhEmployee)EmpInfo.DataContext).IAccountid;
                objtoBind.BShowBlance = true;
                objtoBind.WinTitle = "Account Transactions Detail of ‘" + GlobalObjEmployee.VEmpfName + "’ Account Number ‘" + GlobalObjEmployee.VAccountNo + "’";
                objtoBind.WinHeading = objtoBind.WinTitle;
                objtoBind.WinDetial = "";
                lstTransaction ObjAcctountWin = new lstTransaction(objtoBind);

                //objPre.docview1.Document = xps.GetFixedDocumentSequence();
                Window window = new Window
                {
                    Title = objtoBind.WinTitle,
                    Content = ObjAcctountWin,
                    Height = 600,  // just added to have a smaller control (Window)
                    Width = 915,
                    ResizeMode = ResizeMode.NoResize
                };
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                SalleryBox.DataContext = new dhSalary();
                this.gnrtSalary.Content = "Calculate";

                txtIAbsentdays.IsReadOnly = false;
                txtIOverTimeAmount.IsReadOnly = false;
                txtiDeduction.IsReadOnly = false;
                dddEndDate.IsEnabled = false;

                txtIAbsentdays.IsEnabled = true;
                txtIOverTimeAmount.IsEnabled = true;
                txtiDeduction.IsEnabled = true;
                dddEndDate.IsEnabled = true;
                // BindSalary();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }
    }
}
