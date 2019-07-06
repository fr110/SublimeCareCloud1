using DataHolders;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SublimeCareCloud.Controls
{
    /// <summary>
    /// Interaction logic for ModuleControl.xaml
    /// </summary>
    public partial class ModuleControl : UserControl
    {
        dhModule objModule = new dhModule();
        public ModuleControl()
        {
            InitializeComponent();
            this.DataContext = objModule;
        }
        public ModuleControl(int MuduleID)
        {
            InitializeComponent();
            
            LoadData(MuduleID);
            this.DataContext = objModule; 
        }
        private void border1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ClickCount == 2)
            //    MessageBox.Show("Double Click");
            //ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
            //LinkGroupCollection MenuLinkGroups = new LinkGroupCollection();
            //MenuLinkGroups = Obj.MenuLinkGroups;
            //foreach (LinkGroup item in MenuLinkGroups)
            //{
            //    if (item.DisplayName.ToString() == this.lblHeading.Content.ToString())
            //    {
            //        if (item.Links.Count > 0){
            //        Obj.ContentSource = item.Links[0].Source;
            //            }
            //    }
            //    //foreach (Link item in LinkGroup)
            //    //{
                    
            //    //}
            //}
            //LinkGroup abc = new LinkGroup();
           
            //var f = NavigationHelper.FindFrame(null, this);
            //NavigationCommands.
          //  f.Source = new Uri(((ModernButton)sender).Tag.ToString(), UriKind.Relative);
        }
        public void LoadData(int MuduleID)
        {
            dhModule objMod = new dhModule();
            objMod.IModuleID = MuduleID;
            //          if (objUser != null)
            //       {
            //#region "Allowed Menu"
            objMod.AllowdModule = Globalized.objAppPreference.VEnableModules;
            objMod.IModuleParentID = 0;
            dsGeneral.dtPosModuleDataTable dtm = iFacede.GetModule(Globalized.ObjDbName, objMod);
            ObservableCollection<dhModule> sequence = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtm);
            if(sequence.Count > 0)
            {
                objModule = sequence[0];
                if((objModule.VIconName == null) ||(objModule.VIconName == "")){
                this.Img1.Source = new BitmapImage(new Uri("/SublimeCareCloud;component/images/DumyIcon.png", UriKind.Relative));
                }else{
                    BitmapImage image = new BitmapImage(new Uri("/SublimeCareCloud;component/Images/" + objModule.VIconName, UriKind.Relative));
                    this.Img1.Source = image;
                }
            }
        }

    }
}
