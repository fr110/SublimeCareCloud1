using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class blJournal
    {
        dalGeneral objDALGeneral;


        public blJournal()
        {
            objDALGeneral = new dalGeneral();
        }
        public DataSet InsertUpdateJournal(dhDBnames objDBNames, dhJournal objJournal, dhJournalDetail CRDetail, dhJournalDetail DRDetail)
        {

            DataSet ds;
            ds = objDALGeneral.InsertUpdateJournal(objDBNames, objJournal);



            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0) )
            {
                int? ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ijournalid"].ToString()); ;
                //DateTime ddate = (DateTime)(ds.Tables[0].Rows[0]["ddate"]); ;
                if (objJournal.CRList != null)
                {
                    JournalDetailList ItemCollection = objJournal.CRList;
                    foreach (dhJournalDetail item in ItemCollection)
                    {
                        CRDetail.IJournalId = ID;
                        CRDetail.IAccountID = item.IAccountID;
                        CRDetail.FAmount = item.FAmount;
                        CRDetail.IUpdate = objJournal.IUpdate;
                        CRDetail.VTransactionType = "CR";
                        DataSet dsitem = InsertUpdateJournalDetail(objDBNames, CRDetail);
                    }
                }

                if (objJournal.DrList != null)
                {
                    JournalDetailList ItemCollection = objJournal.DrList;
                    foreach (dhJournalDetail item in ItemCollection)
                    {
                        DRDetail.IJournalId = ID;
                        DRDetail.IAccountID = item.IAccountID;
                        DRDetail.FAmount = item.FAmount;
                        DRDetail.IUpdate = objJournal.IUpdate;
                        DRDetail.VTransactionType = "DR";
                        DataSet dsitem = InsertUpdateJournalDetail(objDBNames, DRDetail);
                    }
                }

            }
            return ds;


          //  return ds;
        }

        //private DataSet InsertUpdateJournalItem(dhDBnames objDBNames, dhJournalDetail item)
        //{
        //    DataSet ds;
        //    ds = objDALGeneral.InsertUpdateJournalItem(objDBNames, item);
        //    return ds;
        //}

        public dsGeneral.dtPosJournalDataTable GetJournal(dhDBnames objDBNames, dhJournal objJournal)
        {
            dsGeneral.dtPosJournalDataTable dt = objDALGeneral.GetJournal(objDBNames, objJournal);
            return dt;
        }
        public DataSet InsertUpdateJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateJournalDetail(objDBNames, objJournalDetail);
            return ds;
        }

        internal dsGeneral.dtPosJournalDetailDataTable GetJournalDetail(dhDBnames objDBNames, dhJournalDetail objJournalDetail)
        {
            dsGeneral.dtPosJournalDetailDataTable dt = objDALGeneral.GetJournalDetail(objDBNames, objJournalDetail);
            return dt;
        }

        internal DataTable GetPaymentMod()
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("PaymentModKey", typeof(string));
            table.Columns.Add("PaymentMod", typeof(string));

            //
            // Here we add DataRows.Super/DD/Check//)
            //
            table.Rows.Add("", "Select");
            table.Rows.Add("Cash", "Cash");
            table.Rows.Add("Check", "Check");

            return table;
         //   return new DataTable();
        }

        internal DataTable GetTransactionsList(dhDBnames objDBNames, dhTransactionList objTransactionsList)
        {
            DataTable dt = objDALGeneral.GetTransactionsList(objDBNames, objTransactionsList);
            return dt;
        }
    }
}
