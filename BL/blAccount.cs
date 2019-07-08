using DAL;
using DataHolders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BL
{
    public  class blAccount
    {
        dalGeneral objDALGeneral;
        blModule MyModuleObj;
        string MyModuleName;
        public dhModule MyActiveModule { get; set; }
        AppDbContext db;

        public blAccount()
        {
            objDALGeneral = new dalGeneral();
            this.MyModuleName = "Account";
            MyModuleObj = new blModule(MyModuleName);
            MyActiveModule = MyModuleObj.ActiveModule();
            this.db = new AppDbContext();
        }
        public dhAccount AddNewAccount(dhAccount ObjNewAccount)
        {
            if (ObjNewAccount == null)
            {
                return new dhAccount();
            }
            this.db.Accounts.Add(ObjNewAccount);
            this.db.SaveChanges();
            return new dhAccount();

        }
        public dhAccount AddNewAccount(string ModuleName , int iModuleId,int IModuleFK_ID, int? IModuleParentID = 0,
            string AccountName = "",string VAccountDesc = "",string AccountNoStart = "A-")
        {

            dhAccount ObjAccount = new dhAccount();
            dhAccount objAccount = this.db.Accounts.AsNoTracking()
                                    .Where(x => x.IModuleID == iModuleId && x.IModuleFK_ID == IModuleFK_ID).FirstOrDefault();

            //if (objModule != null)
            //{
            if (objAccount == null)
            {
                ObjAccount = new dhAccount();
                ObjAccount.IModuleFK_ID = IModuleFK_ID;
                ObjAccount.IModuleID = iModuleId;
                ObjAccount.AccountName = AccountName;
                ObjAccount.VAccountDesc = VAccountDesc; // MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D01DEC").FirstOrDefault().Value;
                ObjAccount.VAccountComments = VAccountDesc;//MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D02DEC").FirstOrDefault().Value;
                ObjAccount.VAccountNo = AccountNoStart + DateTime.Now.ToString("ddmmyy") + "-" + IModuleFK_ID; // D-For DOC and  DMY  - Day month year and Doc Id
                ObjAccount.IFinaceType = 3;
                ObjAccount.BNominal = false;
                ObjAccount.BEditable = false;
                // finally save 
                this.AddNewAccount(ObjAccount);
                // db.Accounts.Add(ObjAccount);
                return ObjAccount;


            }

            return ObjAccount;

        }

        public dsGeneral.dtPosAccountsDataTable GetAccounts(dhDBnames objDBNames,  dhAccount objAccounts)
        {
            dsGeneral.dtPosAccountsDataTable dt = objDALGeneral.GetAccounts(objDBNames, objAccounts);
            return dt;
        }

        public dsGeneral.dtPosAccountsDataTable GetAccountPR(dhDBnames objDBNames, dhAccount objAccounts)
        {
            dsGeneral.dtPosAccountsDataTable dt = objDALGeneral.GetAccountPR(objDBNames, objAccounts);
            return dt;
        }
        public dsGeneral.dtPosFinaceTypeDataTable GetFinaceType(dhDBnames objDBNames, dhAccount objAccounts)
        {
            dsGeneral.dtPosFinaceTypeDataTable dt = objDALGeneral.GetFinaceType(objDBNames, objAccounts);
            return dt;
        }


        public DataSet InsertUpdateAccounts(dhDBnames objDBNames, dhAccount objAccounts)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateAccounts(objDBNames, objAccounts);
            return ds;
        }

    
        internal dhAccount GetdhAccount(dhDBnames objDBNames, dhAccount objAccount)
        {
            dhAccount dh = objDALGeneral.GetdhAccount(objDBNames, objAccount);
            return dh;
        }

        //internal void InsertNewAccount(DataGrid grdItems, dhAccount newItem)
        //{
           
        //}

        public void SetInitialItemRow(DataGrid objDataGrid)
        {
            //dsGeneral.dtPosSaleItemDataTable dt = new dsGeneral.dtPosSaleItemDataTable();
            //dsGeneral.dtPosSaleItemRow dtRow = (dsGeneral.dtPosSaleItemRow)dt.NewRow();

            //dtRow[0] = 0;
            //dt.AdddtPosSaleItemRow(dtRow);
            //objDataGrid.ItemsSource = dt;
            objDataGrid.ItemsSource = new ItemsList();
        }
        public void InsertNewItemRow(DataGrid objDataGrid, dhSaleItem newItem, TextBox ftotalamountTextBox)
        {

            ItemsList updatedList = new ItemsList();

            var itemsSource = objDataGrid.ItemsSource as IEnumerable;
            int SerialCounter = 1;
            double total = 0;
            // add the total ammount 
            total = total + Convert.ToDouble(newItem.FGrossAmount);
            if (null != itemsSource)
            {
                IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(objDataGrid);
                //updatedList.Remove(
                /// go through each row in the datagrid
                foreach (DataGridRow r in row)
                {
                    if (r != null)
                    {
                        dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                        gridRowObject.ISerialNumber = SerialCounter;
                        SerialCounter = SerialCounter + 1;
                        total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
                        updatedList.Add(gridRowObject);
                    }
                }
            }
            newItem.ISerialNumber = SerialCounter;
            updatedList.Add(newItem);
            ftotalamountTextBox.Text = total.ToString();
            objDataGrid.ItemsSource = updatedList;

        }
        public void RemoveItem(DataGrid objDataGrid, dhSaleItem objectToRemove, dhDBnames ObjDbName, bool? isDraft)
        {

            ItemsList updatedList = new ItemsList();
            var row = blUtil.GetDataGridRows(objDataGrid);
            foreach (DataGridRow r in row)
            {
                dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                updatedList.Add(gridRowObject);
            }
            //ftotalamountTextBox.Text = total.ToString();
            if (isDraft == true)
            {
                blInvoice objblInovice = new blInvoice();
                objectToRemove.BIsDraft = isDraft;
                DataSet ds = objblInovice.RemoveSaleInoviceItem(ObjDbName, objectToRemove);
                updatedList.Remove(objectToRemove);
                //bl objblItems = null;
            }
            else
            {
                updatedList.Remove(objectToRemove);
            }
            objDataGrid.ItemsSource = updatedList;
        }

        internal void InsertNewItemRow(DataGrid grdItems, dhSaleItem newItem)
        {
            ItemsList updatedList = new ItemsList();

            var itemsSource = grdItems.ItemsSource as IEnumerable;
            int SerialCounter = 1;
            double total = 0;
            // add the total ammount 
            total = total + Convert.ToDouble(newItem.FGrossAmount);
            if (null != itemsSource)
            {
                IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(grdItems);
                //updatedList.Remove(
                /// go through each row in the datagrid
                foreach (DataGridRow r in row)
                {
                    if (r != null)
                    {
                        dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                        gridRowObject.ISerialNumber = SerialCounter;
                        SerialCounter = SerialCounter + 1;
                        total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
                        updatedList.Add(gridRowObject);
                    }
                }
            }
            newItem.ISerialNumber = SerialCounter;
            updatedList.Add(newItem);
            grdItems.ItemsSource = updatedList;
        }

        internal void InsertNewAccount(DataGrid grdIAccount, dhJournalDetail newItem)
        {
            JournalDetailList updatedList = new JournalDetailList();

            var itemsSource = grdIAccount.ItemsSource as IEnumerable;
            int SerialCounter = 1;
        //    double total = 0;
            // add the total ammount 
         //   total = total + Convert.ToDouble(newItem.FGrossAmount);
            if (null != itemsSource)
            {
                IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(grdIAccount);
                //updatedList.Remove(
                /// go through each row in the datagrid
                foreach (DataGridRow r in row)
                {
                    if (r != null)
                    {
                        dhJournalDetail gridRowObject = (dhJournalDetail)r.Item;
                     //   gridRowObject.ISerialNumber = SerialCounter;
                        SerialCounter = SerialCounter + 1;
                    //    total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
                        updatedList.Add(gridRowObject);
                    }
                }
            }
       //     newItem.ISerialNumber = SerialCounter;
            updatedList.Add(newItem);
            grdIAccount.ItemsSource = updatedList;


        }

        internal void RemoveAccountFromGrid(DataGrid objDataGrid, dhJournalDetail objectToRemove, dhDBnames ObjDbName, bool? iSDraft)
        {
            JournalDetailList updatedList = new JournalDetailList();
            var row = blUtil.GetDataGridRows(objDataGrid);
            foreach (DataGridRow r in row)
            {
                dhJournalDetail gridRowObject = (dhJournalDetail)r.Item;
                updatedList.Add(gridRowObject);
            }
            //ftotalamountTextBox.Text = total.ToString();
            //if (isDraft == true)
            //{
            //    blInvoice objblInovice = new blInvoice();
            //    objectToRemove.BIsDraft = isDraft;
            //    DataSet ds = objblInovice.RemoveSaleInoviceItem(ObjDbName, objectToRemove);
            //    updatedList.Remove(objectToRemove);
            //    //bl objblItems = null;
            //}
            //else
            //{
            updatedList.Remove(objectToRemove);
            //}
            objDataGrid.ItemsSource = updatedList;
        }

        internal DataSet GetAccountsWithBalance(dhDBnames dhDBnames, dhAccount objAccount)
        {
            DataSet ds = objDALGeneral.GetAccountsWithBalance(dhDBnames, objAccount);
            return ds;
        }
        internal DataSet GetDailyIncom(dhDBnames dhDBnames, dhAccount objAccount)
        {
            DataSet ds = objDALGeneral.GetDailyIncom(dhDBnames, objAccount);
            return ds;
        }
    }
}
