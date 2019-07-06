using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using iFacedeLayer;

namespace SublimeCareCloud.ViewModels
{
    class PartyViewModel: Screen
    {
      
        private ObservableCollection<dhParty> _Parties;
        public ObservableCollection<dhParty> Parties
        {
            get { return _Parties; }
            set { _Parties = value; }
        }
        //= new ObservableCollection<dhParty>();
        public PartyViewModel()
        {
            DisplayName = "Parties";
            dhParty objLoad = new dhParty();
            this.loadData(objLoad);
        }

       
       
       
       
       

        private void loadData(dhParty objParty/* , Boolean ShowResultCount = false*/)
        {

            dsGeneral.dtPosPartyDataTable dtparty = iFacede.GetParty(Globalized.ObjDbName, objParty);
            Parties = ReflectionUtility.DataTableToObservableCollection<dhParty>(dtparty);
        }
       
    }
}
