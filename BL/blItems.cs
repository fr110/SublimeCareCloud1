using DAL;
using DataHolders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BL
{
    public class blItems 
    {
        dalGeneral objDALGeneral;

        public blItems()
        {
            objDALGeneral = new dalGeneral();
        }

        public DataSet InsertUpdateItem(dhDBnames objDBNames, dhItems ObjItem)
        {

            DataSet ds;
            ds = objDALGeneral.InsertUpdateItem(objDBNames, ObjItem);
            return ds;
        }

        public dsGeneral.dtPosItemsDataTable GetItems(dhDBnames objDBNames, dhItems ObjItem)
        {
            dsGeneral.dtPosItemsDataTable dt = objDALGeneral.GetItems(objDBNames, ObjItem);
            return dt;
        }
        public dhItems GetdhItem(dhDBnames objDBNames, dhItems ObjItem)
        {
            dhItems dh = objDALGeneral.GetdhItem(objDBNames, ObjItem);
            return dh;
        }
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
            int SerialCounter = 1;
            double total = 0;
            total = total + Convert.ToDouble(newItem.FGrossAmount);
            SerialCounter = objDataGrid.Items.Count > 0 ? objDataGrid.Items.Count+1 : 1;
            newItem.ISerialNumber = SerialCounter;
            updatedList.Add(newItem);
          
           SerialCounter--;
            if ((ItemsList)objDataGrid.ItemsSource != null)
            {
                ItemsList templist = (ItemsList)objDataGrid.ItemsSource;
                foreach (dhSaleItem item in templist)
                {
                    // dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                    item.ISerialNumber = SerialCounter;
                    SerialCounter = SerialCounter - 1;
                    total = total + Convert.ToDouble(item.FGrossAmount);
                    updatedList.Add(item);
                }
            }
            //else
            //{

            //}

            // add the total ammount 

            //if (null != updatedList)
            //{
            //    //IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(objDataGrid);
            //    ////updatedList.Remove(
            //    ///// go through each row in the datagrid
            //    //        foreach (DataGridRow r in row)
            //    //        {
            //    //            if (r != null)
            //    //            {
            //    //                dhSaleItem gridRowObject = (dhSaleItem)r.Item;
            //    //                gridRowObject.ISerialNumber = SerialCounter ;
            //    //                SerialCounter = SerialCounter + 1;
            //    //                total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
            //    //                updatedList.Add(gridRowObject);
            //    //            }
            //    //        }

            //}

            //  updatedList.Add(newItem);
            ftotalamountTextBox.Text = total.ToString();
            objDataGrid.ItemsSource = updatedList;
            //ItemsList updatedList = new ItemsList();
            //var itemsSource = objDataGrid.ItemsSource as IEnumerable;
            //int SerialCounter = 1;
            //double total = 0;
            //// add the total ammount 
            //total = total + Convert.ToDouble(newItem.FGrossAmount);
            //if (null != itemsSource)  
            //{
            //IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(objDataGrid);
            ////updatedList.Remove(
            ///// go through each row in the datagrid
            //        foreach (DataGridRow r in row)
            //        {
            //            if (r != null)
            //            {
            //                dhSaleItem gridRowObject = (dhSaleItem)r.Item;
            //                gridRowObject.ISerialNumber = SerialCounter ;
            //                SerialCounter = SerialCounter + 1;
            //                total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
            //                updatedList.Add(gridRowObject);
            //            }
            //        }
            //  }
            //newItem.ISerialNumber = SerialCounter;
            //updatedList.Add(newItem);
            //ftotalamountTextBox.Text = total.ToString();
            //objDataGrid.ItemsSource = updatedList;

        }
        public void RemoveItem(DataGrid objDataGrid, dhSaleItem objectToRemove, dhDBnames ObjDbName, bool? isDraft)
        {

            ItemsList updatedList = new ItemsList();
            
            if ((ItemsList)objDataGrid.ItemsSource != null)
            {
                ItemsList templist = (ItemsList)objDataGrid.ItemsSource;
                foreach (dhSaleItem item in templist)
                {
                   // dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                   // item.ISerialNumber = SerialCounter;
                   // SerialCounter = SerialCounter - 1;
                   // total = total + Convert.ToDouble(item.FGrossAmount);
                   updatedList.Add(item);
                }
            }

            //var row = blUtil.GetDataGridRows(objDataGrid);
            //foreach (DataGridRow r in row)
            //{
            //    dhSaleItem gridRowObject = (dhSaleItem)r.Item;
            //    updatedList.Add(gridRowObject);
            //}
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
            
            int SerialCounter = 1;
            double total = 0;
            
            //total = total + Convert.ToDouble(newItem.FGrossAmount);
            SerialCounter = updatedList.Count > 0 ? updatedList.Count : 1;
            //newItem.ISerialNumber = SerialCounter;
                ItemsList NewList = new ItemsList();
            // obj removed now let we sort with serial 
            foreach (dhSaleItem item in updatedList)
            {
                //dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                item.ISerialNumber = SerialCounter;
                SerialCounter = SerialCounter - 1;
                NewList.Add(item);
                // total = total + Convert.ToDouble(item.FGrossAmount);     
            }

            objDataGrid.ItemsSource = NewList;
        }

        internal void InsertNewItemRow(DataGrid grdItems, dhSaleItem newItem)
        {


            //ItemsList updatedList = new ItemsList();

            //var itemsSource = grdItems.ItemsSource as IEnumerable;
            //int SerialCounter = 1;
            //double total = 0;
            //// add the total ammount 
            //total = total + Convert.ToDouble(newItem.FGrossAmount);
            //if (null != itemsSource)
            //{
            //    IEnumerable<DataGridRow> row = blUtil.GetDataGridRows(grdItems);
            //    //updatedList.Remove(
            //    /// go through each row in the datagrid
            //    foreach (DataGridRow r in row)
            //    {
            //        if (r != null)
            //        {
            //            dhSaleItem gridRowObject = (dhSaleItem)r.Item;
            //            gridRowObject.ISerialNumber = SerialCounter;
            //            SerialCounter = SerialCounter + 1;
            //            total = total + Convert.ToDouble(gridRowObject.FGrossAmount);
            //            updatedList.Add(gridRowObject);
            //        }
            //    }
            //}
            //newItem.ISerialNumber = SerialCounter;
            //updatedList.Add(newItem);
            //grdItems.ItemsSource = updatedList;
        }
    }
}
