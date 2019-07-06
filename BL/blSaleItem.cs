using DataHolders;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Collections;

namespace BL
{
    class blSaleItem
    {
         dalGeneral objDALGeneral;

         public blSaleItem()
        {
            objDALGeneral = new dalGeneral();
        }

         #region  "Dynamic Adding Grid"
         public void SetInitialRow(DataGrid objDataGrid)
         {
             //dsGeneral.dtPosSaleItemDataTable dt = new dsGeneral.dtPosSaleItemDataTable();
             //dsGeneral.dtPosSaleItemRow dtRow = (dsGeneral.dtPosSaleItemRow)dt.NewRow();

             //dtRow[0] = 0;
             //dt.AdddtPosSaleItemRow(dtRow);
             //objDataGrid.ItemsSource = dt;
             objDataGrid.ItemsSource = new blSaleItemList();
         }
        // helping function to get data table
         //private static DataTable DataViewAsDataTable(DataView dv)
         //{
         //    DataTable dt = dv.Table.Clone();
         //    foreach (DataRowView drv in dv)
         //    {
         //        dt.ImportRow(drv.Row);
         //    }
         //    return dt;
         //}
        
         public void InsertNewRow(DataGrid objDataGrid)
         {
            // create Empty data 
            dsGeneral.dtPosSaleItemDataTable dt = new dsGeneral.dtPosSaleItemDataTable();
            blSaleItemList updatedList = new blSaleItemList();
           // DataView view = (DataView) objDataGrid.ItemsSource;
           //  DataTable objDT = DataViewAsDataTable(view);
            
          //   dt = (dsGeneral.dtPosSaleItemDataTable)objDataGrid.ItemsSource;// (dsGeneral.dtPosSaleItemDataTable)objDT;
            // create a new row
            //dsGeneral.dtPosSaleItemRow dtRow = (dsGeneral.dtPosSaleItemRow)dt.NewRow();
            //dtRow[0] = Convert.ToInt64(dt.Rows[dt.Rows.Count - 1][0];
            //dt.AdddtPosSaleItemRow(dtRow);

            var row = blUtil.GetDataGridRows(objDataGrid);
            /// go through each row in the datagrid
            foreach (DataGridRow r in row)
            {
                dhSaleItem gridRowObject = (dhSaleItem)r.Item;
                updatedList.Add(gridRowObject);
                // Get the state of what's in column 1 of the current row (in my case a string)
              //  string t = rv.Row[1].ToString();


            }

             // create a new object and add to list 
            dhSaleItem objNewRow = new dhSaleItem();
            updatedList.Add(objNewRow);
            objDataGrid.ItemsSource = updatedList;
            
         }

         //private void DeleteNewRow(int eRowNumber)
         //{

         //    DataTable DataTable_temp = new DataTable();
         //    DataRow dr2 = null;
         //    DataRow dr = null;
         //    DataTable_temp.Columns.Add(new DataColumn("iInvid", typeof(int)));
         //    DataTable_temp.Columns.Add(new DataColumn("iInvCharges", typeof(int)));
         //    DataTable_temp.Columns.Add(new DataColumn("dDate", typeof(DateTime)));
         //    //  DataTable_temp.Columns.Add(new DataColumn("vTime", typeof(string)));
         //    DataTable_temp.Columns.Add(new DataColumn("vDesccription", typeof(string)));
         //    DataTable_temp.Columns.Add(new DataColumn("vResults", typeof(string)));
         //    int Count = 0;
         //    foreach (GridViewRow row in DataGrid_.Rows)
         //    {
         //        if (row.RowIndex != eRowNumber)
         //        {


         //            dr = DataTable_temp.NewRow();
         //            Count = Convert.ToInt32(DataGrid_.Rows.Count);
         //            DropDownList ddInvestigation_ = (DropDownList)row.FindControl("ddInvestigation_");
         //            dr["iInvid"] = ddInvestigation_.SelectedValue;
         //            TextBox txtChanrges = (TextBox)row.FindControl("txtChanrges");
         //            int iChargers;
         //            int.TryParse(txtChanrges.Text.ToString(), out iChargers);
         //            if (iChargers != 0)
         //            {
         //                dr["iInvCharges"] = iChargers;
         //            }
         //            TextBox txtResult = (TextBox)row.FindControl("txtResult");
         //            TextBox txtDes = (TextBox)row.FindControl("txtDes");


         //            dr["vDesccription"] = txtDes.Text;
         //            dr["vResults"] = txtDes.Text;
         //            DataTable_temp.Rows.Add(dr);
         //        }
         //    }

         //    this.DataGrid_.DataSource = DataTable_temp;
         //    this.DataGrid_.DataBind();
         //    Calculate_Total();
        //}
        #endregion
    }
}
