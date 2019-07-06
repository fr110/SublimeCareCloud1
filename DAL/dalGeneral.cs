// ----------------------------------------------------------------------
// The name of ALLAH Almighty, The Most Beneficient and The Most Merciful
// Author           <Asjad Ali>
// Create Date      <Date>
// Modify Date      <27-Sep-2011>
// ----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataHolders;
using DBConfiguration;
using System.Data;
using System.Collections.ObjectModel;

namespace DAL
{
    /// <summary>
    /// This class belongs to DAL project and help to insert, 
    /// update and getting records from database.
    /// </summary>
    public class dalGeneral
    {
        DBConfiguration.clsDataBase objDatabase;

        #region Employees
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="objDBName">Name of the obj DB.</param>
        /// <param name="objEmployee">The obj employee.</param>
        /// <returns></returns>
        public dsGeneral.dtEmployeeDataTable GetEmployee(dhDBnames objDBName, dhEmployee objEmployee)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objEmployee, "xmlGetEmployee", (DataSet)ds, "dtEmployee");
            dsGeneral.dtEmployeeDataTable retdt = ((dsGeneral)dsreturn).dtEmployee;
            return retdt;
        }

        public DataSet InsertUpdateEmployee(dhDBnames objDBName, dhEmployee objEmployee)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objEmployee, "xmlInsertUpdateEmployee");
            return dsreturn;
        }
        #endregion

        #region "Salary"

        public dsGeneral.dtSalaryDataTable GetSalary(dhDBnames objDBName, dhSalary objSalary)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSalary, "xmlGetSalary", (DataSet)ds, "dtSalary");
            dsGeneral.dtSalaryDataTable retdt = ((dsGeneral)dsreturn).dtSalary;
            return retdt;
        }
        public dsGeneral.dtSalaryDataTable GetSalaryMonthlyReportSheet(dhDBnames objDBName, dhSalary objSalary)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSalary, "xmlGetSalaryMonthlyReportSheet", (DataSet)ds, "dtSalary");
            dsGeneral.dtSalaryDataTable retdt = ((dsGeneral)dsreturn).dtSalary;
            return retdt;
        }
        public dsGeneral.dtSalaryDataTable GetSalarySheetHrEmployee(dhDBnames objDBName, dhSalary objSalary)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSalary, "xmlGetSalarySheetHrEmployee", (DataSet)ds, "dtSalary");
            dsGeneral.dtSalaryDataTable retdt = ((dsGeneral)dsreturn).dtSalary;
            return retdt;
        }
        // insert Sallary On the Singel Person

        public DataSet InsertUpdateSalary(dhDBnames objDBName, dhSalary objSalary)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSalary, "xmlInsertUpdateSalary");
            return dsreturn;
        }

        #endregion

        #region Accounts
        public dsGeneral.dtPosAccountsDataTable GetAccounts(dhDBnames objDBName, dhAccount objAccounts)
        {

            dsGeneral ds = new dsGeneral();
            DataSet dsreturn ;
            dsreturn = objDatabase.GetDataSet(objDBName, objAccounts, "xmlGetAccounts", (DataSet)ds, "dtPosAccounts");
            dsGeneral.dtPosAccountsDataTable retdt = ((dsGeneral)dsreturn).dtPosAccounts;
            return retdt;
        }
        public DataSet GetDailyIncom(dhDBnames dhDBnames, dhAccount objAccount)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objAccount, "xmlGetDailyIncom");
            return dsreturn;
        }
        public DataSet GetAccountsWithBalance(dhDBnames dhDBnames, dhAccount objAccount)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objAccount, "xmlGetAccountBlance");
            return dsreturn;
        }
        public dsGeneral.dtPosAccountsDataTable GetAccountPR(dhDBnames objDBName, dhAccount objAccounts)
        {

            dsGeneral ds = new dsGeneral();
            DataSet dsreturn ;
            dsreturn = objDatabase.GetDataSet(objDBName, objAccounts, "xmlGetAccountPR", (DataSet)ds, "dtPosAccounts");
            dsGeneral.dtPosAccountsDataTable retdt = ((dsGeneral)dsreturn).dtPosAccounts;
            return retdt;
        }
        public dsGeneral.dtPosFinaceTypeDataTable GetFinaceType(dhDBnames objDBName, dhAccount objAccounts)
        {

            dsGeneral ds = new dsGeneral();
            DataSet dsreturn ;
            dsreturn = objDatabase.GetDataSet(objDBName, objAccounts, "xmlGetFinaceType", (DataSet)ds, "dtPosFinaceType");
            dsGeneral.dtPosFinaceTypeDataTable retdt = ((dsGeneral)dsreturn).dtPosFinaceType;
            return retdt;
        }
        
        public DataSet InsertUpdateAccounts(dhDBnames objDBName, dhAccount objAccounts)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBName, objAccounts, "xmlInserUpdateAccounts");
            return dsreturn;
        }


        public dhAccount GetdhAccount(dhDBnames objDBNames, dhAccount objAccount)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objAccount, "xmlGetAccounts", (DataSet)ds, "dtPosAccounts");
       //     dhAccount returnObject = null;
            dsGeneral.dtPosAccountsDataTable retdt = ((dsGeneral)dsreturn).dtPosAccounts;
            ObservableCollection<dhAccount> listAccount = ReflectionUtility.DataTableToObservableCollection<dhAccount>(retdt);
            if (listAccount.Count > 0)
            {
                return listAccount.SingleOrDefault();
            }
            else
            {
                return null;
            }
            //retdt.ToList<dhAccount>();
            //foreach (DataRow row in retdt.Rows)
            //{

            //    returnObject = new dhAccount
            //    {
            //        IItemID = Convert.ToInt32(row["IItemID"]),
            //        FUnitePrice = Convert.ToDouble(row["FUnitePrice"]),
            //        VItemName = Convert.ToString(row["VItemName"]),
            //        FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
            //        IQuantity = 1,
            //        Ammount = Convert.ToDouble(row["FUnitePrice"]) * 1,
            //        IStockIn = Convert.ToInt32(String.IsNullOrEmpty(row["IStockIn"].ToString()) ? 0 : row["IStockIn"]),
            //        IStockOut = Convert.ToInt32(String.IsNullOrEmpty(row["IStockOut"].ToString()) ? 0 : row["IStockOut"]),
            //        ICurrantStock = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]),
            //        IsAvailable = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]) > 0 ? true : false,
            //        StockStatus = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]) > 0 ? "Available" : "Not Available",
            //    };
            //}
      //      return returnObject;
        }
        //public dsGeneral.dtPosAccountsDataTable GetAccountsReport(dhDBnames objDBName, dhAccount objAccounts)
        //{

        //    dsGeneral ds = new dsGeneral();
        //    DataSet dsreturn = objDatabase.GetDataSet(objDBName, objAccounts, "xmlGetAccountsReport", (DataSet)ds, "dtAccounts");
        //    dsGeneral.dtPosAccountsDataTable retdt = ((dsGeneral)dsreturn).dtPosAccounts;
        //    return retdt;
        //}
        #endregion
        
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="dalGeneral"/> class.
        /// </summary>
        public dalGeneral()
        {
            objDatabase = new DBConfiguration.clsDataBase();
        }
        #endregion

        #region User DAL Fucntions
            /// <summary>
            /// Gets the user.
            /// </summary>
            /// <param name="objDBName">Name of the obj DB.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public dsGeneral.dtAppUserDataTable GetUser(dhDBnames objDBName, dhUsers objUser)
            {
                dsGeneral ds = new dsGeneral();
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objUser, "xmlGetAppUser", (DataSet)ds, "dtAppUser");
                dsGeneral.dtAppUserDataTable retdt = ((dsGeneral)dsreturn).dtAppUser;
                return retdt;
            }

            /// <summary>
            /// Adds the edit user.
            /// </summary>
            /// <param name="objDBName">Name of the obj DB.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public DataSet AddEditUser(dhDBnames objDBName, dhUsers objUser)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objUser, "xmlInsertUpdateAppUsers");
                return dsreturn;
            }

            /// <summary>
            /// Changes the password.
            /// </summary>
            /// <param name="objDBName">Name of the obj DB.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public DataSet ChangePassword(dhDBnames objDBName, dhUsers objUser)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objUser, "xmlchgPassword");
                return dsreturn;
            }
        #endregion

        #region Party Dal Function 
            public dsGeneral.dtPosPartyDataTable GetParty(dhDBnames objDBName, dhParty objParty)
            {
                dsGeneral ds = new dsGeneral();
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objParty, "xmlGetParty", (DataSet)ds, "dtPosParty");
                dsGeneral.dtPosPartyDataTable retdt = ((dsGeneral)dsreturn).dtPosParty;
                return retdt;
            }

            public DataSet InsertUpdateParty(dhDBnames objDBName, dhParty objParty)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objParty, "xmlInsertUpdateParty");
                return dsreturn;
            }

          #endregion

        #region SaleMan Dal Function
            public dsGeneral.dtPosSaleManDataTable GetSaleMan(dhDBnames objDBName, dhSaleMan objSaleMan)
            {
                dsGeneral ds = new dsGeneral();
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSaleMan, "xmlGetSaleMan", (DataSet)ds, "dtPosSaleMan");
                dsGeneral.dtPosSaleManDataTable retdt = ((dsGeneral)dsreturn).dtPosSaleMan;
             
                return retdt;
            }

            #endregion

        #region Item Dal Function 

            public DataSet InsertUpdateItem(dhDBnames objDBName, dhItems objItem)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBName, objItem, "xmlInsertUpdateItem");
                return dsreturn;
            }


            public dsGeneral.dtPosItemsDataTable GetItems(dhDBnames objDBNames, dhItems ObjItem)
            {
                dsGeneral ds = new dsGeneral();
                DataSet dsreturn = objDatabase.GetDataSet(objDBNames, ObjItem, "xmlGetItems", (DataSet)ds, "dtPosItems");
                dsGeneral.dtPosItemsDataTable retdt = ((dsGeneral)dsreturn).dtPosItems;
                
                return retdt;
                //dsGeneral.dtPosItemsDataTable dt = objDALGeneral.GetAllItems(objDBNames, ObjItem);
                //return dt;
            }
            public dhItems GetdhItem(dhDBnames objDBNames, dhItems ObjItem)
            {
                dsGeneral ds = new dsGeneral();
                DataSet dsreturn = objDatabase.GetDataSet(objDBNames, ObjItem, "xmlGetItems", (DataSet)ds, "dtPosItems");
                dhItems returnObject = null;
                dsGeneral.dtPosItemsDataTable retdt = ((dsGeneral)dsreturn).dtPosItems;
                foreach (DataRow row in retdt.Rows)
                {

                 returnObject =    new dhItems
                    {
                        IItemID = Convert.ToInt32(row["IItemID"]),
                        FUnitePrice = Convert.ToDouble(row["FUnitePrice"]),
                        VItemName = Convert.ToString(row["VItemName"]),
                        FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
                        FUnitPurchasePrice = Convert.ToDouble(row["fUnitPurchasePrice"]),
                        IQuantity = 1,
                        Ammount = Convert.ToDouble(row["FUnitePrice"]) * 1,
                        IStockIn = Convert.ToInt32(String.IsNullOrEmpty(row["IStockIn"].ToString()) ? 0 : row["IStockIn"]),
                        IStockOut = Convert.ToInt32(String.IsNullOrEmpty(row["IStockOut"].ToString()) ? 0 : row["IStockOut"]),
                        ICurrantStock = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]),
                        IsAvailable = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]) > 0? true : false,
                        StockStatus = Convert.ToInt32(String.IsNullOrEmpty(row["ICurrantStock"].ToString()) ? 0 : row["ICurrantStock"]) > 0 ? "Available" : "Not Available",
                        BIsEditAbleInInvoice = Convert.ToBoolean(row["BIsEditAbleInInvoice"].ToString()),
                   };
                }
                return returnObject;
            }
        #endregion

        #region "Inovice"
        public DataSet InsertUpdateSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objInvoice, "xmlInsertUpdateSaleInovice");
                if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 1))
                {
                    dsreturn.Tables[0].TableName = "dtPosSaleInovice";
                }
                else if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 2))
                {
                    dsreturn.Tables[0].TableName = "dtPosSaleInovice";
                    dsreturn.Tables[1].TableName = "dtPosSaleItem";
                }
                return dsreturn;
            }
        public DataSet InsertUpdateSaleInoviceItem(dhDBnames objDBNames, dhSaleItem objInvoice)
            {
                DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objInvoice, "xmlInsertUpdateSaleInoviceItem");
                return dsreturn;
            }


        public DataSet RemoveSaleInoviceItem(dhDBnames objDBNames, dhSaleItem objInvoiceItem)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objInvoiceItem, "xmlRemoveSaleInoviceItem");
            return dsreturn;
        }


        public DataSet GetSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objInvoice, "xmlGetSaleInovice");
            if ((dsreturn.Tables.Count > 0)&& (dsreturn.Tables.Count ==1))
            {
                dsreturn.Tables[0].TableName = "dtPosSaleInovice";
            }
            else if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 2))
            {
                dsreturn.Tables[0].TableName = "dtPosSaleInovice";
                dsreturn.Tables[1].TableName = "dtPosSaleItem";
            }
            return dsreturn;
        }
        //public dsGeneral.dtPosSaleManDataTable GetSaleMan(dhDBnames objDBName, dhSaleMan objSaleMan)
        //{
        //    dsGeneral ds = new dsGeneral();
        //    DataSet dsreturn = objDatabase.GetDataSet(objDBName, objSaleMan, "xmlGetSaleMan", (DataSet)ds, "dtPosSaleMan");
        //    dsGeneral.dtPosSaleManDataTable retdt = ((dsGeneral)dsreturn).dtPosSaleMan;

        //    return retdt;
        //}
        #endregion

        public dsGeneral.dtPosStockDataTable GetItemStock(dhDBnames objDBNames, dhItemStock objStock)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objStock, "xmlGetItemStock", (DataSet)ds, "dtPosStock");
            dsGeneral.dtPosStockDataTable retdt = ((dsGeneral)dsreturn).dtPosStock;

            return retdt;
        //    throw new NotImplementedException();
        }

        #region "Purchase"
        public DataSet InsertUpdatePurchase(dhDBnames dhDBnames, dhPurchase objPurchase)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objPurchase, "xmlInsertUpdatePurchase");
            return dsreturn;
        }

        public DataSet InsertUpdatePurchaseItem(dhDBnames dhDBnames, dhSaleItem item)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, item, "xmlInsertUpdatePurchaseItem");
            return dsreturn;
        }

        public DataSet GetPurchase(dhDBnames dhDBnames, dhPurchase objPurchase)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objPurchase, "xmlGetPurchase");
            if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 1))
            {
                dsreturn.Tables[0].TableName = "dtPosPurchase";
            }
            else if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 2))
            {
                dsreturn.Tables[0].TableName = "dtPosPurchase";
                dsreturn.Tables[1].TableName = "dtPosPurchaseItem";
            }
            return dsreturn;
        }
        #endregion


        #region "Production"
        public DataSet InsertUpdateProduction(dhDBnames dhDBnames, dhProduction objProduction)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objProduction, "xmlInsertUpdateProduction");
            return dsreturn;
        }

        public DataSet InsertUpdateProductionItem(dhDBnames dhDBnames, dhSaleItem item)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, item, "xmlInsertUpdateProductionItem");
            return dsreturn;
        }

        public DataSet GetProduction(dhDBnames dhDBnames, dhProduction objProduction)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objProduction, "xmlGetProduction");
            
            if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 1))
            {
                dsreturn.Tables[0].TableName = "dtPosProduction";
            }
            else if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 2))
            {
                dsreturn.Tables[0].TableName = "dtPosProduction";
                dsreturn.Tables[1].TableName = "dtPosconsumeItem";
            }
            else if ((dsreturn.Tables.Count > 0) && (dsreturn.Tables.Count == 3))
            {
                dsreturn.Tables[0].TableName = "dtPosProduction";
                dsreturn.Tables[1].TableName = "dtPosConsumeItem";
                dsreturn.Tables[2].TableName = "dtPosProducedItem";
            }
            return dsreturn;
        }
        #endregion


        public DataSet InsertUpdateStock(dhDBnames objDBNames, dhItemStock objStock)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objStock, "xmlInsertUpdateStock");
            return dsreturn;
        }

        public dsGeneral.dtPosPreferenceDataTable GetPreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objPreference, "xmlGetPreference", (DataSet)ds, "dtPosPreference");
            dsGeneral.dtPosPreferenceDataTable retdt = ((dsGeneral)dsreturn).dtPosPreference;
            return retdt;           
        }

        public DataSet InsertUpdatePreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objPreference, "xmlInsertUpdatePreference");
            return dsreturn;
        }
        public DataSet InsertUpdateAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objPreference, "xmlInsertUpdateAppPreference");
            return dsreturn;
        }
        public DataSet CheckItemInvoiced(dhDBnames objDBNames, dhInvoice objInvoice)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objInvoice, "xmlCheckItemInvoiced");
            return dsreturn;
        }

        public dsGeneral.dtPosModuleDataTable GetModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, ObjModule, "xmlGetModule", (DataSet)ds, "dtPosModule");
            dsGeneral.dtPosModuleDataTable retdt = ((dsGeneral)dsreturn).dtPosModule;
            return retdt; 
        }

        public dsGeneral.dtAppPreferenceDataTable GetAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
              dsGeneral ds = new dsGeneral();
              DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objPreference, "xmlGetAppPreference", (DataSet)ds, "dtAppPreference");
            dsGeneral.dtAppPreferenceDataTable retdt = ((dsGeneral)dsreturn).dtAppPreference;
            return retdt; 
        }

        public DataSet InsertUpdateModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, ObjModule, "xmlInsertUpdateModule");
            return dsreturn;
        }

        public DataSet RemoveSaleInovice(dhDBnames dhDBnames, dhInvoice objInvoice)
        {
            DataSet dsreturn = objDatabase.GetDataSet(dhDBnames, objInvoice, "xmlRemoveSaleInovice");
            return dsreturn;
        }

        public dsGeneral.dtPOSCostumerDataTable GetCostumer(dhDBnames objDBNames, dhCostumer objCostumer)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objCostumer, "xmlGetCostumer", (DataSet)ds, "dtPOSCostumer");
            dsGeneral.dtPOSCostumerDataTable retdt = ((dsGeneral)dsreturn).dtPOSCostumer;
            return retdt; 
        }
        public dsGeneral.dtPOSCostumerDataTable GetCostumerAlert(dhDBnames objDBNames, dhCostumer objCostumer)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objCostumer, "xmlGetCostumerAlert", (DataSet)ds, "dtPOSCostumer");
            dsGeneral.dtPOSCostumerDataTable retdt = ((dsGeneral)dsreturn).dtPOSCostumer;
            return retdt; 
        }
        public DataSet InsertUpdateCostumer(dhDBnames objDBNames, dhCostumer objCostumer)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objCostumer, "xmlInsertUpdateCostumer");
            return dsreturn;
        }

        #region "Jurnal"

        public DataSet InsertUpdateJournal(dhDBnames objDBNames, dhJournal objJournal)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objJournal, "xmlInsertUpdateJournal");
            return dsreturn;
        }

        public dsGeneral.dtPosJournalDataTable GetJournal(dhDBnames objDBNames, dhJournal objJournal)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objJournal, "xmlGetJournal", (DataSet)ds, "dtPosJournal");
            dsGeneral.dtPosJournalDataTable retdt = ((dsGeneral)dsreturn).dtPosJournal;
            return retdt;
        }

        public DataSet InsertUpdateJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objJournalDetail, "xmlInsertUpdateJournalDetail");
            return dsreturn;
        }

        public dsGeneral.dtPosJournalDetailDataTable GetJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objJournalDetail, "xmlGetJournalDetail", (DataSet)ds, "dtPosJournalDetail");
            dsGeneral.dtPosJournalDetailDataTable retdt = ((dsGeneral)dsreturn).dtPosJournalDetail;
            return retdt;
        }
        #endregion

        public DataSet InsertUpdateJournalItem(dhDBnames objDBNames, dhJournalDetail item)
        {
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, item, "xmlInsertUpdateJournalDetail");
            return dsreturn;
        }

        public DataTable GetTransactionsList(dhDBnames objDBNames, dhTransactionList objTransactionsList)
        {
           // dsGeneral ds = new dsGeneral();
            DataSet dsreturn = objDatabase.GetDataSet(objDBNames, objTransactionsList, "xmlGetTransactionsList" );
           
            return (dsreturn.Tables.Count > 0 ? dsreturn.Tables[0] : null);
        }

        #region "Doctor"


        #endregion
    }
}
