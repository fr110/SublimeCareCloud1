using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataHolders;
using iFacedeLayer;
using JetBrains.Annotations;
using SublimeCareCloud.Views;
using System.Windows.Controls;
using System.Windows;

namespace SublimeCareCloud.CustomClasses
{
    public  class SublimeMenu : INotifyPropertyChanged
    {
        public SublimeMenu()
        {
            this.CreateMenuItems();

        }

        public SublimeMenu(dhUsers objdhUsers)
        {
            // TODO: Complete member initialization
            //this.dhUsers = objdhUsers;
            this.CreateMenuItems(objdhUsers);
        }
        public void CreateMenuItems(dhUsers objdhUsers = null)
        {

            if(objdhUsers!=null)
            { 
                    dhModule objmod = new dhModule();
                    Globalized.AppModuleList= iFacede.GetAllModule(Globalized.ObjDbName,objmod);
                    // Create Mune Herre 
                    ObservableCollection<dhModule> dtMenu = iFacede.GetUserMenu(Globalized.ObjDbName, Globalized.objAppPreference, objdhUsers);
                    List<Button> StackReturn = new List<Button>();
                    foreach (dhModule Module in dtMenu)
                    {
                       // BitmapImage image = new BitmapImage(new Uri("/SublimeCareCloud;component/Images/" + Module.VIconName, UriKind.Relative));
                       // Module.VIconName = new Uri("/SublimeCareCloud;component/Images/" + Module.VIconName, UriKind.Relative).ToString();
                        this.MenuItems.Add(Module);
                    }// end main menu

            }
        }

        public void CreateSubMenuItems(dhModule pModule)
        {
            // need check what sub module are allowed 14,15,29,30,31,26,27,38,1,2,3,4,5,6,7,8,9,10,11,12,13,22,23,24,34,35,19,20,21
            List<string> AllowedModuleIds = Globalized.ObjCurrentUser.VAllowdModule.Split(',').ToList();
            // I have list of module on local
            ObservableCollection<dhModule> submodule = Globalized.AppModuleList.Where(ob => ob.IModuleParentID == pModule.IModuleID).ToObservableCollection<dhModule>();
            SubMenu.Clear();
            foreach (dhModule Module in submodule)
            {
                //BitmapImage image = new BitmapImage(new Uri("/SublimeCareCloud;component/Images/" + Module.VIconName, UriKind.Relative));
                //Module.VIconName = new Uri("/SublimeCareCloud;component/Images/" + Module.VIconName, UriKind.Relative).ToString();

                if(AllowedModuleIds.Contains(Module.IModuleID.ToString()))
                { 
                     this.SubMenu.Add(Module);
                }
            }// end main menu

        }
      
        List<dhModule> _menuItems = new List<dhModule>();
         List<dhModule> _SubMenu = new List<dhModule>();
     
        public string Name { get; set; }
        public Type PageType { get; set; }
        public List<dhModule> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (Equals(value, _menuItems)) return;
                _menuItems = value;
                NotifyPropertyChanged();
            }
        }



        public List<dhModule> SubMenu
        {
            get { return _SubMenu; }
            set
            {
                if (Equals(value, _SubMenu)) return;
                _SubMenu = value;
                NotifyPropertyChanged();
            }
        }


      

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
      

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion
    }
}
