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
   public class blProduction
    {  dalGeneral objDALGeneral;

    public blProduction()
        {
            objDALGeneral = new dalGeneral();
        }
        internal System.Data.DataSet GetProduction(DataHolders.dhDBnames dhDBnames,dhProduction objProduction)
        {
            DataSet ds;
            ds = objDALGeneral.GetProduction(dhDBnames, objProduction);
            return ds;
        }

        internal System.Data.DataSet InsertUpdateProduction(DataHolders.dhDBnames dhDBnames, dhProduction objProduction)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateProduction(dhDBnames, objProduction);
            return ds;
        }

        internal DataSet InsertUpdateProductionItem(DataHolders.dhDBnames dhDBnames, dhSaleItem objProductionitem)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateProductionItem(dhDBnames, objProductionitem);
            return ds;
        }
    }
}
