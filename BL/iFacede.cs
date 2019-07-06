
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BL;
using DataHolders;

using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
namespace iFacedeLayer
{
    /// <summary>
    /// 
    /// </summary>
    public static class iFacede
    {
        #region Employee
        //ProgressBarfrm objProBar = 
        // public static ModernWindow objModernWindow;
        private static blEmployee objBLEmployee = null;
        private static T FindChildByType<T>(DependencyObject parent) where T : DependencyObject
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

       

        //private static void HideProgressBarfrm()
        //{
        //    if (objModernWindow != null)
        //    {
        //        ProgressBar ProgressBarfrm = FindChildByType<ProgressBar>(objModernWindow);
        //        ProgressBarfrm.Visibility = Visibility.Hidden;
        //    }
        //}
        //private static void ShowProgressBarfrm()
        //{
        //    if (objModernWindow != null)
        //    {
        //        ProgressBar ProgressBarfrm = FindChildByType<ProgressBar>(objModernWindow);
        //        ProgressBarfrm.Visibility = Visibility.Visible;
        //    }

        //}
        public static dsGeneral.dtEmployeeDataTable GetEmployee(dhDBnames objDBNames, dhEmployee objEmployee)
        {
            try
            {
               // //  ShowProgressBarfrm();
                dsGeneral.dtEmployeeDataTable var_ret = new dsGeneral.dtEmployeeDataTable();

                if (objBLEmployee == null) { objBLEmployee = new blEmployee(); }
                var_ret = objBLEmployee.GetEmployee(objDBNames, objEmployee);
              ////  HideProgressBarfrm();
                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static DataSet InsertUpdateEmployee(dhDBnames objDBNames, dhEmployee objEmployee)
        {
            try
            {
                DataSet var_ret;

                if (objBLEmployee == null) { objBLEmployee = new blEmployee(); }
                var_ret = objBLEmployee.InsertUpdateEmployee(objDBNames, objEmployee);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion

        #region "Salary"
        private static blSalary objBLSalary = null;
        public static dsGeneral.dtSalaryDataTable GetSalary(dhDBnames objDBNames, dhSalary objSalary)
        {
            try
            {
                dsGeneral.dtSalaryDataTable var_ret;
                if (objBLSalary == null)
                {
                    objBLSalary = new blSalary();
                }
                var_ret = objBLSalary.GetSalary(objDBNames, objSalary);
                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static dsGeneral.dtSalaryDataTable GetSalaryMonthlyReportSheet(dhDBnames objDBNames, dhSalary objSalary)
        {
            try
            {
                dsGeneral.dtSalaryDataTable var_ret;
                if (objBLSalary == null)
                {
                    objBLSalary = new blSalary();
                }
                var_ret = objBLSalary.GetSalaryMonthlyReportSheet(objDBNames, objSalary);
                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static dsGeneral.dtSalaryDataTable GetSalarySheetHrEmployee(dhDBnames objDBNames, dhSalary objSalary)
        {
            try
            {
                dsGeneral.dtSalaryDataTable var_ret;
                if (objBLSalary == null)
                {
                    objBLSalary = new blSalary();
                }
                var_ret = objBLSalary.GetSalarySheetHrEmployee(objDBNames, objSalary);
                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static DataSet InsertUpdateSalary(dhDBnames objDBNames, dhSalary objSalary)
        {
            try
            {
                DataSet var_ret;

                if (objBLSalary == null) { objBLSalary = new blSalary(); }
                var_ret = objBLSalary.InsertUpdateSalary(objDBNames, objSalary);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        // end salary Inser
        #endregion
        #region  Application
        private static blModule ObjBlModule = null;
        public static dsGeneral.dtPosModuleDataTable GetModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            try
            {
                dsGeneral.dtPosModuleDataTable var_ret;

                if (ObjBlModule == null) { ObjBlModule = new blModule(); }
                var_ret = ObjBlModule.GetModule(objDBNames, ObjModule);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }

        public static ObservableCollection<dhModule> GetAllModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            try
            {
                dsGeneral.dtPosModuleDataTable var_ret;

                if (ObjBlModule == null) { ObjBlModule = new blModule(); }
                var_ret = ObjBlModule.GetModule(objDBNames, ObjModule);
                ObservableCollection<dhModule> returnlist = BL.ReflectionUtility.DataTableToObservableCollection<dhModule>(var_ret);
                return returnlist;
            }
            catch (Exception ex) { throw ex; }
        }

        public static ObservableCollection<dhModule> GetUserSubMenu(dhDBnames objDbName, dhAppPreference objAppPreference, dhUsers objCurrentUser, dhModule objdhModule)
        {
            try
            {
                if (objBLUser == null) { objBLUser = new blUser(); }
                return objBLUser.GetUserSubMenu(objDbName, objAppPreference, objCurrentUser, objdhModule);
            }
            catch (Exception ex) { throw ex; }
        }

        public static DataSet InsertUpdateModule(dhDBnames objDBNames, dhModule ObjModule)
            {
                try
                {
                    DataSet var_ret;

                    if (ObjBlModule == null) { ObjBlModule = new blModule(); }
                    var_ret = ObjBlModule.InsertUpdateModule(objDBNames, ObjModule);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
        #endregion

        #region User
        private static blUser objBLUser = null;

            /// <summary>
            /// Authentications the specified obj DB names.
            /// </summary>
            /// <param name="objDBNames">The obj DB names.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public static dhUsers Authentication(dhDBnames objDBNames, dhUsers objUser)
            {
                try
                {
                    //  ShowProgressBarfrm();
                    dhUsers var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.Authentication(objDBNames, objUser);
                  //  HideProgressBarfrm();
                    return var_ret;
                }
                catch (Exception ex) {
                   // throw new ApplicationException("Invalid Username/Password");
                    throw ex;
                }
            }


            public static DataSet InsertUpdateUsers(dhDBnames dhDBnames, dhUsers objInsert)
            {
                try
                {
                    DataSet var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.AddEditUser(dhDBnames, objInsert);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static DataTable getUserType(dhUsers CrntUser, string RequestType)
            {
            try
                {
                    DataTable var_ret;
                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.GetTable(CrntUser, RequestType);
                    return var_ret;
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
            /// <summary>
            /// Changes the password.
            /// </summary>
            /// <param name="objDBNames">The obj DB names.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public static bool ChangePassword(dhDBnames objDBNames, dhUsers objUser)
            {
                try
                {
                    bool var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.ChangePassword(objDBNames, objUser);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }

            /// <summary>
            /// Getalls the user.
            /// </summary>
            /// <param name="objDBNames">The obj DB names.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public static dsGeneral.dtAppUserDataTable GetallUser(dhDBnames objDBNames, dhUsers objUser)
            {
                try
                {
                    dsGeneral.dtAppUserDataTable var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.GetallUser(objDBNames, objUser);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }

            /// <summary>
            /// CHKs the login name_available.
            /// </summary>
            /// <param name="objDBNames">The obj DB names.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public static bool chkLoginName_available(dhDBnames objDBNames, dhUsers objUser)
            {
                try
                {
                    bool var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.chkLoginName_available(objDBNames, objUser);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }

            /// <summary>
            /// Adds the edit user.
            /// </summary>
            /// <param name="objDBNames">The obj DB names.</param>
            /// <param name="objUser">The obj user.</param>
            /// <returns></returns>
            public static DataSet AddEditUser(dhDBnames objDBNames, dhUsers objUser)
            {
                try
                {
                    DataSet var_ret;

                    if (objBLUser == null) { objBLUser = new blUser(); }
                    var_ret = objBLUser.AddEditUser(objDBNames, objUser);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static ObservableCollection<dhModule> GetUserMenu(dhDBnames objDBNames = null, dhAppPreference objAppPreference = null, dhUsers objuser = null)
            {
                try
                {
                    if (objBLUser == null) { objBLUser = new blUser(); }
                   return objBLUser.GetUserMenu(objDBNames, objAppPreference, objuser);                    
                }
                catch (Exception ex) { throw ex; }

            }
            //public static void GetUserMenu(ModernWindow obj, string menuType, dhUsers objuser = null)
            //{
            //    try
            //    {
            //        if (objBLUser == null) { objBLUser = new blUser(); }
            //        objBLUser.GetUserMenu(obj, menuType, objuser);
            //    }
            //    catch (Exception ex) { throw ex; }

            //}
        #endregion
        
        #region Costumer
            private static blCostumer objBLCostumer = null;
            public static dsGeneral.dtPOSCostumerDataTable GetCostumer(dhDBnames objDBNames, dhCostumer objCostumer)
            {
                try
                {
                    dsGeneral.dtPOSCostumerDataTable var_ret = null;

                    if (objBLCostumer == null) { objBLCostumer = new blCostumer(); }
                    {
                        var_ret = objBLCostumer.GetCostumer(objDBNames, objCostumer);
                    }

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static dsGeneral.dtPOSCostumerDataTable GetCostumerAlert(dhDBnames objDBNames, dhCostumer objCostumer)
            {
                try
                {
                    dsGeneral.dtPOSCostumerDataTable var_ret = null;

                    if (objBLCostumer == null) { objBLCostumer = new blCostumer(); }
                    {
                        var_ret = objBLCostumer.GetCostumerAlert(objDBNames, objCostumer);
                    }

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static DataSet InsertUpdateCostumer(dhDBnames objDBNames, dhCostumer objCostumer)
            {
                try
                {
                    DataSet var_ret;

                    if (objBLCostumer == null) { objBLCostumer = new blCostumer(); }
                    var_ret = objBLCostumer.InsertUpdateCostumer(objDBNames, objCostumer);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            #endregion
        
        #region Party

            private static blParty objBLParty = null;
            public static dsGeneral.dtPosPartyDataTable  GetParty(dhDBnames objDBNames, dhParty objParty)
            {
                try
                {
                    dsGeneral.dtPosPartyDataTable var_ret = null ;

                    if (objBLParty == null) { objBLParty = new blParty(); }
                    {
                        var_ret = objBLParty.GetParty(objDBNames, objParty);
                    }

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static void GetParty(dhDBnames objDBNames, dhParty objParty, ComboBox ObjPartylist)
            {
                try
                {
                   // dsGeneral.dtPosPartyDataTable var_ret = null ;

                    if (objBLParty == null) { objBLParty = new blParty(); }
                    {
                         objBLParty.GetParty(objDBNames, objParty, ObjPartylist);
                    }

                   // return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static DataSet InsertUpdateParty(dhDBnames objDBNames, dhParty objParty)
            {
                try
                {
                    DataSet var_ret;

                    if (objBLParty == null) { objBLParty = new blParty(); }
                    var_ret = objBLParty.InsertUpdateParty(objDBNames, objParty);

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
  
        #endregion

        #region Sale Man 
            private static blSaleMan objBLSaleMan = null;
            public static dsGeneral.dtPosSaleManDataTable GetSaleMan(dhDBnames objDBNames, dhSaleMan objSaleMan)
            {
                try
                {
                    dsGeneral.dtPosSaleManDataTable var_ret = null;

                    if (objBLSaleMan == null) { objBLSaleMan = new blSaleMan(); }
                    {
                        var_ret = objBLSaleMan.GetSaleMan(objDBNames, objSaleMan);
                    }

                    return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
            public static void GetSaleMan(dhDBnames objDBNames, dhSaleMan objSaleMan, ComboBox ObjPartylist)
            {
                try
                {
                    // dsGeneral.dtPosPartyDataTable var_ret = null ;

                    if (objBLSaleMan == null) { objBLSaleMan = new blSaleMan(); }
                    {
                        objBLSaleMan.GetSaleMan(objDBNames, objSaleMan, ObjPartylist);
                    }

                    // return var_ret;
                }
                catch (Exception ex) { throw ex; }
            }
        #endregion

        #region "SaleItem Region"

             #region DynamicGrid
             private static blSaleItem obBlSaleItem = null;
             public static void SetInitialRow(DataGrid objDataGrid)
            {
                try
                {


                    if (obBlSaleItem == null) { obBlSaleItem = new blSaleItem(); }
                    {
                        obBlSaleItem.SetInitialRow(objDataGrid);
                    }
                }
                catch (Exception ex) { throw ex; }
            }
             public static void InsertNewRow(DataGrid objDataGrid)
            {
                try
                {


                    if (obBlSaleItem == null) { obBlSaleItem = new blSaleItem(); }
                    {
                        obBlSaleItem.InsertNewRow(objDataGrid);
                    }
                }
                catch (Exception ex) { throw ex; }
            }

         #endregion

        #endregion

        #region Items
             private static blItems objblItems = null;
                // insert Item 
             public static DataSet InsertUpdateItem(dhDBnames objDBNames, dhItems ObjItem)
             {
                 try
                 {
                     DataSet var_ret = null;
                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         var_ret = objblItems.InsertUpdateItem(objDBNames, ObjItem);
                     }

                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }
             public static dsGeneral.dtPosItemsDataTable GetItems(dhDBnames objDBNames, dhItems objItem)
             {
                 try
                 {
                     dsGeneral.dtPosItemsDataTable var_ret = null;

                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         var_ret = objblItems.GetItems(objDBNames, objItem);
                     }

                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }
             public static dhItems GetdhItem(dhDBnames objDBNames, dhItems objItem)
             {
                 try
                 {
                     dhItems var_ret = null;

                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         var_ret = objblItems.GetdhItem(objDBNames, objItem);
                     }

                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }

             public static void SetInitialItemRow(DataGrid objDataGrid)
             {
                 try
                 {
                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         objblItems.SetInitialItemRow(objDataGrid);
                     }
                 }
                 catch (Exception ex) { throw ex; }
             }
             public static void InsertNewItemRow(DataGrid objDataGrid, dhSaleItem neItem, TextBox ftotalamountTextBox)
             {
                 try
                 {
                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         objblItems.InsertNewItemRow(objDataGrid, neItem, ftotalamountTextBox);
                     }
                 }
                 catch (Exception ex) { throw ex; }
                
             }
             public static void RemoveItem(DataGrid objDataGrid, dhSaleItem objectToRemove,dhDBnames ObjDbName , bool? iSDraft)
             {
                 try
                 {
                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         objblItems.RemoveItem(objDataGrid, objectToRemove,ObjDbName, iSDraft);
                     }
                 }
                 catch (Exception ex) { throw ex; }
                
             }
        #endregion
        
        #region "Stock Item"
             private static blStock objblStock = null;
             public static dsGeneral.dtPosStockDataTable GetItemStock(dhDBnames objDBNames, dhItemStock objStock)
             {
                 try
                 {
                     dsGeneral.dtPosStockDataTable var_ret = null;

                     if (objblStock == null) { objblStock = new blStock(); }
                     {
                         var_ret = objblStock.GetItemStock(objDBNames, objStock);
                     }

                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }

             public static DataSet InsertUpdateStock(dhDBnames objDBNames, dhItemStock objStock)
             {
                 try
                 {
                     DataSet var_ret = null;

                     if (objblStock == null) { objblStock = new blStock(); }
                     {
                         var_ret = objblStock.InsertUpdateStock(objDBNames, objStock);
                     }

                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }
        #endregion
        
        #region "Invoice"
             private static blInvoice objblInvoice = null;
             public static DataSet InsertUpdateSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice , Boolean InsertItems = false)
             {
                 try
                 {
                     DataSet var_ret , ItemDs;

                     if (objblInvoice == null) { objblInvoice = new blInvoice(); }
                     var_ret = objblInvoice.InsertUpdateSaleInovice(objDBNames, objInvoice);
                     
                     if (InsertItems)
                     {
                         // get the SaleID 
                         long ID = Convert.ToInt64(var_ret.Tables[0].Rows[0]["iSaleid"].ToString()); ;
                         // get the observerable collection 
                         ItemsList ItemCollection = objInvoice.ItemsOfInvoice;
                         int ItemID = 1;
                         foreach (dhSaleItem item in ItemCollection)
                         {
                             item.ISaleid = ID;
                             if (item.ISaleItemid != 0)
                             {
                                 item.IUpdate = !string.IsNullOrEmpty(objInvoice.IUpdate.ToString()) ? objInvoice.IUpdate : 0;
                             }
                             else
                             {
                                 item.IUpdate = 0;
                             }
                             ItemID = ItemID + 1;
                             item.IUserId = Convert.ToInt32(objInvoice.IUserid);
                             if (objblInvoice == null) { objblInvoice = new blInvoice(); }
                             {
                                 ItemDs = objblInvoice.InsertUpdateSaleInoviceItem(objDBNames, item); 
                             }
                         }
                     }
                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }
             public static DataSet RemoveSaleInovice(dhDBnames dhDBnames, dhInvoice objInvoice)
             {
                 try
                 {
                  
                     DataSet var_ret ;

                     if (objblInvoice == null) { objblInvoice = new blInvoice(); }
                     var_ret = objblInvoice.RemoveSaleInovice(dhDBnames, objInvoice);
                     return var_ret;
                 }
                 catch (Exception)
                 {
                     
                     throw;
                 }
             }
             //public static DataSet InsertUpdateSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice, Boolean InsertItems = false)
             //{
             //    try
             //    {
             //        DataSet var_ret;

             //        if (objblInvoice == null) { objblInvoice = new blInvoice(); }
             //        var_ret = objblInvoice.InsertUpdateSaleInovice(objDBNames, objInvoice);

             //        if (InsertItems)
             //        {
             //            // get the SaleID 
             //            long ID = Convert.ToInt64(var_ret.Tables[0].Rows[0]["iSaleid"].ToString()); ;
             //            // get the observerable collection 
             //            ItemsList ItemCollection = objInvoice.ItemsOfInvoice;
             //            int ItemID = 1;

             //            // check is it draft 
             //            if (objInvoice.BIsDraft == true)
             //            {
             //                // check if the item are there already
             //                if ((var_ret.Tables.Count == 1) && (var_ret.Tables["dtPosSaleItem"].Rows.Count > 0))
             //                {
             //                    ObservableCollection<dhSaleItem> objlist = ReflectionUtility.DataTableToObservableCollection<dhSaleItem>(var_ret.Tables["dtPosSaleItem"]);
             //                    //ItemsList ToDelete = objlist.ToObservableCollectio();
             //                    //List<dhSaleItem> abc = (List<dhSaleItem>)ItemCollection;
             //                    foreach (dhSaleItem item in ItemCollection)
             //                    {
             //                        item.ISaleid = ID;
             //                        //int.TryParse(
             //                        item.IUpdate = !string.IsNullOrEmpty(objInvoice.IUpdate.ToString()) ? objInvoice.IUpdate : 0;
             //                        // item.ISerialNumber = ItemID;
             //                        ItemID = ItemID + 1;
             //                        item.IUserId = Convert.ToInt32(objInvoice.IUserid);
             //                        if (objblInvoice == null) { objblInvoice = new blInvoice(); }
             //                        {
             //                            var_ret = objblInvoice.InsertUpdateSaleInoviceItem(objDBNames, item);

             //                        }
             //                    }
             //                    //foreach (dhSaleItem item in objlist)
             //                    //{

             //                    //}
             //                }
             //            }
             //        }
             //        return var_ret;
             //    }
             //    catch (Exception ex) { throw ex; }
             //}

             public static DataSet GetSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice)
             {

                 DataSet var_ret;
                 if (objblInvoice == null) { objblInvoice = new blInvoice(); }
                 {
                     var_ret = objblInvoice.GetSaleInovice(objDBNames, objInvoice);
                 }
                 return var_ret;
             }
             public static DataSet CheckItemInvoiced(dhDBnames objDBNames, dhInvoice objInvoice)
             {
                 DataSet var_ret;
                 if (objblInvoice == null) { objblInvoice = new blInvoice(); }
                 {
                     var_ret = objblInvoice.CheckItemInvoiced(objDBNames, objInvoice);
                 }
                 return var_ret;
             }

        #endregion
        
        #region "Purchase"

            private static  blPurchase objblPurchase;
             public static DataSet InsertUpdatePurchase(dhDBnames dhDBnames, dhPurchase objPurchase, Boolean InsertItems = false)
             {
                 try
                 {
                     DataSet var_ret;

                     if (objblPurchase == null) { objblPurchase = new blPurchase(); }
                     var_ret = objblPurchase.InsertUpdatePurchase(dhDBnames, objPurchase);
                     if (InsertItems)
                     {
                         // get the SaleID 
                         Int64? ID = Convert.ToInt64(var_ret.Tables[0].Rows[0]["iPurchaseid"].ToString()); ;
                         // get the observerable collection 
                         ItemsList ItemCollection = objPurchase.ItemsOfPurchase;
                         int ItemID = 1;
                         foreach (dhSaleItem item in ItemCollection)
                         {
                             item.IProductionId = ID;
                             item.IUpdate = 0;
                             // item.ISerialNumber = ItemID;
                             ItemID = ItemID + 1;
                             item.IUserId = Convert.ToInt32(objPurchase.IUserid);
                             if (objblPurchase == null) { objblPurchase = new blPurchase(); }
                             {
                                 var_ret = objblPurchase.InsertUpdatePurchaseItem(dhDBnames, item);
                             }
                         }
                     }
                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }

             public static DataSet GetPurchase(dhDBnames dhDBnames, dhPurchase objPurchase)
             {
                 DataSet var_ret;
                 if (objblPurchase == null) { objblPurchase = new blPurchase(); }
                 {
                     var_ret = objblPurchase.GetPurchase(dhDBnames, objPurchase);
                 }
                 return var_ret;
             }

        #endregion
       
        #region "Production"

             private static blProduction objblProduction;
             public static DataSet InsertUpdateProduction(dhDBnames dhDBnames, dhProduction objProduction, Boolean InsertItems = false)
             {
                 try
                 {
                     DataSet var_ret;

                     if (objblProduction == null) { objblProduction = new blProduction(); }
                     var_ret = objblProduction.InsertUpdateProduction(dhDBnames, objProduction);

                     if ((var_ret.Tables.Count > 0)&&(var_ret.Tables[0].Rows.Count > 0) && (InsertItems))
                         {
                            Int64? ID = Convert.ToInt64(var_ret.Tables[0].Rows[0]["iProductionid"].ToString()); ;
                            DateTime ddate = (DateTime)(var_ret.Tables[0].Rows[0]["ddate"]); ;
                             if (objProduction.ItemsConsumed != null)
                             {
                                 ItemsList ItemCollection = objProduction.ItemsConsumed;
                                 foreach (dhSaleItem item in ItemCollection)
                                 {
                                    // dhItemStock ObjInsertItem = new dhItemStock();
                                   item.IProductionId = ID;
                                   item.IProductionItemid = 0;
                                   item.DDate = ddate;
                                   item.IUserId = objProduction.IUserid;
                                    if (objblProduction == null) { objblProduction = new blProduction(); }
                                     objblProduction.InsertUpdateProductionItem(dhDBnames, item);
                                 }
                             }

                             if (objProduction.ItemsProduced != null)
                             {
                                 ItemsList ItemCollection = objProduction.ItemsProduced;

                                 foreach (dhSaleItem item in ItemCollection)
                                 {

                                     item.IProductionId = ID;
                                     item.IProductionItemid = 1;
                                     item.DDate = ddate;
                                     item.IUserId = objProduction.IUserid;
                                     if (objblProduction == null) { objblProduction = new blProduction(); }
                                     objblProduction.InsertUpdateProductionItem(dhDBnames, item);
                                 }
                             }
                             //// get the SaleID 
                             //Int64? ID = Convert.ToInt64(var_ret.Tables[0].Rows[0]["iProductionid"].ToString()); ;
                             //// get the observerable collection 
                             //ItemsList ItemCollection = objProduction.ItemsOfProduction;
                             //int ItemID = 1;
                             //foreach (dhSaleItem item in ItemCollection)
                             //{
                             //    item.IProductionId = ID;
                             //    item.IUpdate = 0;
                             //    // item.ISerialNumber = ItemID;
                             //    ItemID = ItemID + 1;
                             //    item.IUserId = Convert.ToInt32(objProduction.IUserid);
                             //    if (objblProduction == null) { objblProduction = new blProduction(); }
                             //    {
                             //        var_ret = objblProduction.InsertUpdateProductionItem(dhDBnames, item);
                             //    }
                             //}
                         }
                    
                     return var_ret;
                 }
                 catch (Exception ex) { throw ex; }
             }
             public static DataSet GetProduction(dhDBnames dhDBnames, dhProduction objProduction)
             {
                 DataSet var_ret;
                 if (objblProduction == null) { objblProduction = new blProduction(); }
                 {
                     var_ret = objblProduction.GetProduction(dhDBnames, objProduction);
                 }
                 return var_ret;
             }

             #endregion


        public static void InsertNewItemRow(DataGrid grdItems, dhSaleItem newItem)
             {
                 try
                 {
                     if (objblItems == null) { objblItems = new blItems(); }
                     {
                         objblItems.InsertNewItemRow(grdItems, newItem);
                     }
                 }
                 catch (Exception ex) { throw ex; }                
             }


        #region Setting
        private static blPreference objBLPreference = null;

        public static dsGeneral.dtPosPreferenceDataTable GetPreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            try
            {
                dsGeneral.dtPosPreferenceDataTable var_ret = null;

                if (objBLPreference == null) { objBLPreference = new blPreference(); }
                {
                    var_ret = objBLPreference.GetPreference(objDBNames, objPreference);
                }

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }

        public static DataSet InsertUpdatePreference(dhDBnames objDBNames, dhPreference objPreference)
        {
            try
            {
                DataSet var_ret;

                if (objBLPreference == null) { objBLPreference = new blPreference(); }
                var_ret = objBLPreference.InsertUpdatePreference(objDBNames, objPreference);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        // application prefrenas
        
        private static blAppPreference objBLAppPreference = null;
        public static dsGeneral.dtAppPreferenceDataTable GetAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            try
            {
                dsGeneral.dtAppPreferenceDataTable var_ret = null;

                if (objBLAppPreference == null) { objBLAppPreference = new blAppPreference(); }
                {
                    var_ret = objBLAppPreference.GetAppPreference(objDBNames, objPreference);
                }

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }

     
        public static DataSet InsertUpdateAppPreference(dhDBnames objDBNames, dhAppPreference objPreference)
        {
            try
            {
                DataSet var_ret;

                if (objBLAppPreference == null) { objBLAppPreference = new blAppPreference(); }
                var_ret = objBLAppPreference.InsertUpdateAppPreference(objDBNames, objPreference);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        #endregion


        #region Accounts

        private static blAccount objblAccount = null;
        public static dsGeneral.dtPosAccountsDataTable GetAccount(dhDBnames objDBNames, dhAccount objAccounts)
        {
            try
            {
                dsGeneral.dtPosAccountsDataTable var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.GetAccounts(objDBNames, objAccounts);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }

        public static DataSet GetAccountsWithBalance(dhDBnames dhDBnames, dhAccount objAccount)
        {
            try
            {
                DataSet var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.GetAccountsWithBalance(dhDBnames, objAccount);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static DataSet GetDailyIncom(dhDBnames dhDBnames, dhAccount objAccount)
        {
            try
            {
                DataSet var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.GetDailyIncom(dhDBnames, objAccount);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static dsGeneral.dtPosAccountsDataTable GetAccountPR(dhDBnames objDBNames, dhAccount objAccounts)
        {
            try
            {
                dsGeneral.dtPosAccountsDataTable var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.GetAccountPR(objDBNames, objAccounts);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }
        public static dsGeneral.dtPosFinaceTypeDataTable GetFinaceType(dhDBnames objDBNames, dhAccount objAccounts)
        {
            try
            {
                dsGeneral.dtPosFinaceTypeDataTable var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.GetFinaceType(objDBNames, objAccounts);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }
        public static DataSet InsertUpdateAccount(dhDBnames objDBNames, dhAccount objAccounts)
        {
            try
            {
                DataSet var_ret;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                var_ret = objblAccount.InsertUpdateAccounts(objDBNames, objAccounts);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        //public static string GetProcessorID()
        //{

        //    string sProcessorID = "";

        //    string sQuery = "SELECT ProcessorId FROM Win32_Processor";

        //    ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);

        //    ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();

        //    foreach (ManagementObject oManagementObject in oCollection)
        //    {

        //        sProcessorID = (string)oManagementObject["ProcessorId"];

        //    }

        //    return (sProcessorID);

        //}

        public static void InsertNewAccount(DataGrid grdItems, dhJournalDetail newItem)
        {
            try
            {
                if (objblAccount == null) { objblAccount = new blAccount(); }
                {
                    objblAccount.InsertNewAccount(grdItems, newItem);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static void RemoveAccountFromGrid(DataGrid objDataGrid, dhJournalDetail objectToRemove, dhDBnames ObjDbName, bool? iSDraft)
        {
            try
            {
                if (objblAccount == null) { objblAccount = new blAccount(); }
                {
                    objblAccount.RemoveAccountFromGrid(objDataGrid, objectToRemove, ObjDbName, iSDraft);
                }
            }
            catch (Exception ex) { throw ex; }

        }

        public static dhAccount GetdhAccount(dhDBnames objDBNames, dhAccount objAccount)
        {
            try
            {
                dhAccount var_ret = null;

                if (objblAccount == null) { objblAccount = new blAccount(); }
                {
                    var_ret = objblAccount.GetdhAccount(objDBNames, objAccount);
                }

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region "Journal"
        private static blJournal objblJournal = null;
        public static DataSet InsertUpdateJournal(dhDBnames objDBNames, dhJournal objJournal, dhJournalDetail CRDetail, dhJournalDetail DRDetail)
        {
            try
            {
                DataSet var_ret;

                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.InsertUpdateJournal(objDBNames, objJournal, CRDetail, DRDetail);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static dsGeneral.dtPosJournalDataTable GetJournal(dhDBnames objDBNames, dhJournal objJournal)
        {
            try
            {
                dsGeneral.dtPosJournalDataTable var_ret;

                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.GetJournal(objDBNames, objJournal);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }
        public static DataTable GetTransactionsList(dhDBnames objDBNames, dhTransactionList objTransactionsList)
        {
            try
            {
                DataTable var_ret;

                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.GetTransactionsList(objDBNames, objTransactionsList);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }

        public static DataSet InsertUpdateJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            try
            {
                DataSet var_ret;

                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.InsertUpdateJournalDetail(objDBNames, objJournalDetail);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }
        }
        public static dsGeneral.dtPosJournalDetailDataTable GetJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            try
            {
                dsGeneral.dtPosJournalDetailDataTable var_ret;

                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.GetJournalDetail(objDBNames, objJournalDetail);

                return var_ret;
            }
            catch (Exception ex) { throw ex; }

        }

        public static DataTable GetPaymentMod()
        {
            try
            {
                DataTable var_ret;
                if (objblJournal == null) { objblJournal = new blJournal(); }
                var_ret = objblJournal.GetPaymentMod();
                return var_ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}