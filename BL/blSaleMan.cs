using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BL
{
   public class blSaleMan
    {
         dalGeneral objDALGeneral;

         public blSaleMan()
        {
            objDALGeneral = new dalGeneral();
        }
         public dsGeneral.dtPosSaleManDataTable GetSaleMan(dhDBnames objDBNames, dhSaleMan objSaleMan)
        {
            dsGeneral.dtPosSaleManDataTable dt = objDALGeneral.GetSaleMan(objDBNames, objSaleMan);
            return dt;
        }
          public void GetSaleMan(dhDBnames objDBNames, dhSaleMan objSaleMan, ComboBox objSaleManList)
        {
            dsGeneral.dtPosSaleManDataTable dt = objDALGeneral.GetSaleMan(objDBNames, objSaleMan);
            
            objSaleManList.ItemsSource = dt;
            objSaleManList.DisplayMemberPath = "vSaleManName";
            objSaleManList.SelectedValuePath = "iSaleManID";
           
        }
    }
        
    }

