using DataHolders;
using FluentValidation.Results;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddAccountView.xaml
    /// </summary>
    public partial class AddAccountView : UserControl
    {
        public AddAccountView()
        {
            InitializeComponent();
            this.objTodisplay = new dhAccount();
            objTodisplay.FinanceTypeList = new ObservableCollection<dhFinanceType>();
            LoadData();

        }

        private dhAccount objTodisplay;
        public AddAccountView(DataHolders.dhAccount objTodisplay)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.objTodisplay = new dhAccount();
            this.objTodisplay = objTodisplay;
            this.objTodisplay.FinanceTypeList = new ObservableCollection<dhFinanceType>();
            this.AccountGrid.DataContext = this.objTodisplay;

            //this.vAccountType.DataContext =  

            dsGeneral.dtPosFinaceTypeDataTable dtF = iFacede.GetFinaceType(Globalized.ObjDbName, objTodisplay);
            objTodisplay.FinanceTypeList = ReflectionUtility.DataTableToObservableCollection<dhFinanceType>(dtF);

            this.vAccountType.ItemsSource = objTodisplay.FinanceTypeList;// iFacede.GetFinaceType(Globalized.ObjDbName, objTodisplay);
            this.vAccountType.DisplayMemberPath = "vFinaceType";
            this.vAccountType.SelectedValuePath = "iFinaceType";
            this.vAccountType.SelectedValue = this.objTodisplay.IFinaceType;
            LoadData();
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dhAccount objFinaceType = new dhAccount();


            dsGeneral.dtPosFinaceTypeDataTable dtF = iFacede.GetFinaceType(Globalized.ObjDbName, objFinaceType);
           
            objTodisplay.FinanceTypeList  = ReflectionUtility.DataTableToObservableCollection<dhFinanceType>(dtF);

            this.vAccountType.ItemsSource = objTodisplay.FinanceTypeList;

            this.vAccountType.DisplayMemberPath = "VFinaceType";
            this.vAccountType.SelectedValuePath = "IFinaceType";
            this.AccountDt.DataContext = this.objTodisplay;
            this.vAccountType.SelectedValue = this.objTodisplay.IFinaceType;
            if (objTodisplay.BEditable == false)
            {
                //accountNameTextBox.IsEnabled = false;
                //vAccountNoTextBox.IsEnabled = false;
                //vAccountDescTextBox.IsEnabled = false;
                //vAccountCommentsTextBox.IsEnabled = false;
                //vAccountType.IsEnabled = false;
                //bNominalCheckBox.IsEnabled = false;
                AccountDt.IsEnabled = false;
                this.btnSaveAcc.IsEnabled = false;
                Globalized.SetMsg("This is non-editable account.", MsgType.Info);
                Globalized.ShowMsg(lblErrorMsg);
            }
            else
            {
                AccountDt.IsEnabled = true;
            }

         if(objTodisplay.IUpdate > 0)
            {
                this.vAccountNoTextBox.IsEnabled = false;
               // this.vAccountNoTextBox.Background = new SolidColorBrush(Colors.Gray);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertUpdateAccount();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private void InsertUpdateAccount()
        {
            dhAccount objInsert = new dhAccount();
            objInsert = (dhAccount)this.AccountDt.DataContext;



            dhAccountValidator validator = new dhAccountValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(objInsert);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if (validationSucceeded)
            {
                if (this.vAccountType.SelectedValue != null)
                {
                    objInsert.IFinaceType = Convert.ToInt32(this.vAccountType.SelectedValue.ToString());
                }
                else
                {
                    throw new ApplicationException("Please Select Account Type.");
                }
                DataSet ds = iFacede.InsertUpdateAccount(Globalized.ObjDbName, objInsert);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (objInsert.IUpdate == 1)
                    {
                        string msg = "Account  '" + objInsert.AccountName + "' information is updated successfully.";
                        Globalized.setException(msg, lblErrorMsg, DataHolders.MsgType.Info);
                        //Globalized.SetMsg(msg, DataHolders.MsgType.Info);
                        //Globalized.ShowMsg(lblErrorMsg);
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play();
                        lblErrorMsg.Visibility = Visibility.Hidden;
                        Globalized.SetMsg("New Acount '" + objInsert.AccountName + "' is added successfully.", DataHolders.MsgType.Info);
                        objTodisplay.IUpdate = 1;
                        this.DataContext = objTodisplay;
                        Globalized.ShowMsg(lblErrorMsg);
                    }
                }
                Globalized.AccountListOptimizated();
            }
            else
            {
                throw new ApplicationException(failures.First().ErrorMessage);
            }

        }

        private void ShowAccount_Click(object sender, RoutedEventArgs e)
        {
            dhTransactionList objtoBind = new dhTransactionList();
            objtoBind.IAccountID = ((dhAccount)AccountDt.DataContext).IAccountid;
            objtoBind.BShowBlance = true;
            objtoBind.WinTitle = "Account Transactions Detail of ‘" + objTodisplay.AccountName + "’ Account Number ‘" + objTodisplay.VAccountNo + "’";
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

        //private void VAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
