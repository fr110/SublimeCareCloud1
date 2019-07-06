using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using System.Data;
using DAL;

namespace BL
{
   public class blInvoice
    {
        dalGeneral objDALGeneral;

        public blInvoice()
        {
            objDALGeneral = new dalGeneral();
        }
        public DataSet InsertUpdateSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice)
        {

            DataSet ds;
            ds = objDALGeneral.InsertUpdateSaleInovice(objDBNames, objInvoice);
            return ds;
        }
        public DataSet InsertUpdateSaleInoviceItem(dhDBnames objDBNames, dhSaleItem objInvoiceItem)
        {

            DataSet ds;
            ds = objDALGeneral.InsertUpdateSaleInoviceItem(objDBNames, objInvoiceItem);
            return ds;
        }


        public DataSet RemoveSaleInoviceItem(dhDBnames objDBNames, dhSaleItem objInvoiceItem)
        {

            DataSet ds;
            ds = objDALGeneral.RemoveSaleInoviceItem(objDBNames, objInvoiceItem);
            return ds;
        }


        public DataSet GetSaleInovice(dhDBnames objDBNames, dhInvoice objInvoice)
        {

            DataSet ds;
              ds = objDALGeneral.GetSaleInovice(objDBNames, objInvoice);
            return ds;
        }


        internal DataSet CheckItemInvoiced(dhDBnames objDBNames, dhInvoice objInvoice)
        {
           DataSet ds;
           ds = objDALGeneral.CheckItemInvoiced(objDBNames, objInvoice);
            return ds;
        }

        internal DataSet RemoveSaleInovice(dhDBnames dhDBnames, dhInvoice objInvoice)
        {
             DataSet ds;
             ds = objDALGeneral.RemoveSaleInovice(dhDBnames, objInvoice);
            return ds;
        }
    }
}
