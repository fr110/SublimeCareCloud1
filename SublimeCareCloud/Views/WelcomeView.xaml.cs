using DataHolders;
using iFacedeLayer;
using SublimeCareCloud.Controls;
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

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            dhModule objMod = new dhModule();
            //objMod.IModuleID = MuduleID;
            //          if (objUser != null)
            //       {
            //#region "Allowed Menu"
            objMod.AllowdModule = Globalized.objAppPreference.VEnableModules;
            objMod.IModuleParentID = 0;
            dsGeneral.dtPosModuleDataTable dtm = iFacede.GetModule(Globalized.ObjDbName, objMod);
            ObservableCollection<dhModule> sequence = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtm);
            List<string> Ids = Globalized.ObjCurrentUser.VAllowdModule.Split(',').ToList<string>();

            ModuleControl objModuleToadd = new ModuleControl();
            MControls.Children.Clear();
            foreach (dhModule item in sequence)
            {
                string Contian = Ids.Distinct<string>().Cast<string>().Where(i => i.Equals(item.IModuleID.ToString())).SingleOrDefault();
                if ((Contian == null) || (item.IModuleParentID != 0))
                {
                    continue;
                }
                else
                {
                    MControls.Children.Add(objModuleToadd = new ModuleControl(item.IModuleID));
                }
            }

            //int length = 7;
            ////MControls
            //ModuleControl Test = new ModuleControl();
            //for (int i = 0; i < length; i++)
            //{

            //}
        }
    }
}
