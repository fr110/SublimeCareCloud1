using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DataHolders;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;

namespace BL
{
   public  class blParty
    {
        dalGeneral objDALGeneral;

        public blParty()
        {
            objDALGeneral = new dalGeneral();
        }
        public dsGeneral.dtPosPartyDataTable GetParty(dhDBnames objDBNames, dhParty objParty)
        {
            dsGeneral.dtPosPartyDataTable dt = objDALGeneral.GetParty(objDBNames, objParty);
            return dt;
        }
        public void GetParty(dhDBnames objDBNames, dhParty objParty, ComboBox ObjPartylist)
        {
            dsGeneral.dtPosPartyDataTable dt = objDALGeneral.GetParty(objDBNames, objParty);
            //Binding myBinding = new Binding("Party");
            //myBinding.Source = dt;//cusmo.Customer; // data source from your example
            ObjPartylist.ItemsSource = dt;
            ObjPartylist.DisplayMemberPath = "vPartyName";
            ObjPartylist.SelectedValuePath = "iPartyID";
            //ObjPartylist.SetBinding(ComboBox.ItemsSourceProperty, myBinding);
            //ObjPartylist
            //return dt;
        }
        public DataSet InsertUpdateParty(dhDBnames objDBNames, dhParty objParty)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateParty(objDBNames, objParty);
            return ds;
        }
    }
}
