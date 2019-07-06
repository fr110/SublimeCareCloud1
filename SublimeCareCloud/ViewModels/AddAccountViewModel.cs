using System.Collections.ObjectModel;
using DataHolders;

namespace SublimeCareCloud.ViewModels
{
  //  DataContext="{Binding GlobalObj}"
    class AddAccountViewModel
    {
        dhAccount GlobalObjAccount;
        public AddAccountViewModel()
        {
            GlobalObjAccount = new dhAccount();
        }
        public AddAccountViewModel(dhAccount objPassed)
        {
            if(objPassed == null)
            { 
            GlobalObjAccount = new dhAccount();
            }else
            {
                GlobalObjAccount = objPassed;
            }

        }

    }

}
