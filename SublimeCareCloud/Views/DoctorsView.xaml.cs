using DataHolders;
using SublimeCareCloud.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DoctorsView.xaml
    /// </summary>
    public partial class DoctorsView : UserControl
    {
        
        public DoctorsView()
        {
            InitializeComponent();
        }
        DoctorsViewModel MyViewModel;

        private void DocList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                // get the obect and then Invoice ID opne the Id in readonly mode
                dhDoctors objTodisplay = new dhDoctors();
                // need to update to docview // first get view object then create new doctore obj
                dhDoctorView objtemp = ((dhDoctorView)dgr.Item);
                    

                objTodisplay = this.MyViewModel.db.Doctors.Find(objtemp.IDocid);
                if (objTodisplay != null)
                {
                    objTodisplay.IUpdate = 1;
                    AddDoctorsViewModel ObjSetToEdit = new AddDoctorsViewModel(objTodisplay);
                    //objvm.SelectToEdit(new AddPartyViewModel(objTodisplay));
                    Globalized.LoadThisObject(ObjSetToEdit, "Edit Doctor '" + objTodisplay.VfName + " " + objTodisplay.VlName + "'", Globalized.AppModuleList.Where(xx => xx.VModuleName == "Doctors").FirstOrDefault().VShortDescription);
                }
               
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.MyViewModel = (DoctorsViewModel)this.DataContext;
            this.MyViewModel.loadData();
            this.DocList.ItemsSource = this.MyViewModel.DoctorList;
        }
    }
}
