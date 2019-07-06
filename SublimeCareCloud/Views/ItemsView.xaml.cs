using DataHolders;
using SublimeCareCloud.ViewModels;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView : UserControl
    {
        public ItemsView()
        {
            InitializeComponent();
        }


        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode
                dhItems objTodisplay = new dhItems();

                objTodisplay = ((dhItems)dgr.Item);
                if (objTodisplay != null)
                {
                    objTodisplay.IUpdate = 1;
                    AddItemViewModel ObjSetToEdit = new AddItemViewModel(objTodisplay);
                    //objvm.SelectToEdit(new AddPartyViewModel(objTodisplay));
                    Globalized.LoadThisObject(ObjSetToEdit, "Edit Party '" + objTodisplay.VItemName + "'", Globalized.AppModuleList.Where(xx => xx.VModuleName == "Store").FirstOrDefault().VShortDescription);
                    //}
                }
            }
        }
    }
}
