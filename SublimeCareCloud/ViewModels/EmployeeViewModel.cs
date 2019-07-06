using BL;
using Caliburn.Micro;
using DAL;
using DataHolders;
using DataHolders.Interfaces;
using iFacedeLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    public class EmployeeViewModel : Screen, INotifyPropertyChanged, IMyModule
    {
        //private var
        public AppDbContext db = new AppDbContext();
        public blEmployee ObjBLemp = new blEmployee();
        public ObservableCollection<dhEmployee> ListEmptloye  { get; set; }
        //public dhAccount DoctorAccount { get; set; }
        private string MyName = "Employee";
       // public long? DocID { get; set; }
        public dhModule MyModuel { get; set; }


        // constructor
        public EmployeeViewModel()
        {
            dhEmployee objEmployee = new dhEmployee();
          //  ListEmptloye = iFacede.GetEmployee(Globalized.ObjDbName, objEmployee).AsEnumerable().ToObservableCollection<dhEmployee>();
            dsGeneral.dtEmployeeDataTable dtEmployee = iFacede.GetEmployee(Globalized.ObjDbName, objEmployee);
            ListEmptloye = DataHolders.ReflectionUtility.DataTableToObservableCollection<dhEmployee>(dtEmployee);

        }

        public EmployeeViewModel(dhEmployee ObjToDisplay)
        {

        }
        // other fucntions


        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public dhModule ActiveModule(string ModuleName, int? IModuleParentID = 0)
        {
            if (ModuleName == "")
            {
                return new dhModule();
            }
            if (IModuleParentID > 0)
            {
                return this.db.Modules.Where(x => x.VModuleName == ModuleName && x.IModuleParentID == IModuleParentID).FirstOrDefault();
            }
            else
            {
                return this.db.Modules.Where(x => x.VModuleName == ModuleName && x.IModuleParentID == 0).FirstOrDefault();
            }
        }
    }
}
