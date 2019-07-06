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
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using SublimeCareCloud.Views;


namespace SublimeCareCloud.Classes
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
            MenuItems = new HamburgerMenuItemCollection();
            MenuOptionItems = new HamburgerMenuItemCollection();
            // Create Mune Herre 
            ObservableCollection<dhModule> dtMenu = iFacede.GetUserMenu(Globalized.ObjDbName, Globalized.objAppPreference, objdhUsers);
            foreach (dhModule Module in dtMenu)
            {
                BitmapImage image = new BitmapImage(new Uri("/SublimeCareCloud;component/Images/" + Module.VIconName, UriKind.Relative));

                this.MenuItems.Add(
                new HamburgerMenuImageItem()
                {
                    Thumbnail = image,
                    Label = Module.VModuleName,
                    ToolTip = Module.VModuleName,
                    CommandParameter = Module.VModuleName,
                    Tag = "ShowFirst",

                }
            );
            }// end main menu
            

        }
        private HamburgerMenuItemCollection _menuItems;
        private HamburgerMenuItemCollection _menuOptionItems;
      //  public Symbol Icon { get; set; }
        public string Name { get; set; }
        public Type PageType { get; set; }
        public HamburgerMenuItemCollection MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (Equals(value, _menuItems)) return;
                _menuItems = value;
                NotifyPropertyChanged();
            }
        }

     

        public HamburgerMenuItemCollection MenuOptionItems
        {
            get { return _menuOptionItems; }
            set
            {
                if (Equals(value, _menuOptionItems)) return;
                _menuOptionItems = value;
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
