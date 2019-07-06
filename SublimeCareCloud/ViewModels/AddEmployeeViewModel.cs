using BL;
using Caliburn.Micro;
using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    public class AddEmployeeViewModel:Screen
    {

        public AppDbContext db = new AppDbContext();
        public blEmployee ObjBLemp = new blEmployee();
        public ObservableCollection<dhEmployee> ListEmptloye { get; set; }
        //public dhAccount DoctorAccount { get; set; }
        private string MyName = "Employee";
        // public long? DocID { get; set; }
        public dhModule MyModuel { get; set; }
        public dhAccount EmployeeAccount { get; set; }

        public dhEmployee ObjAddEdit { get; set; }
        // constructor

        public AddEmployeeViewModel()
        {
            this.ObjAddEdit = new dhEmployee();
            this.MyModuel = Globalized.ActiveModule(this.db, MyName, 0);

        }

        public AddEmployeeViewModel(dhEmployee objEmp)
        {
            this.ObjAddEdit = new dhEmployee();
            this.MyModuel = Globalized.ActiveModule(this.db, MyName, 0);
            this.EmployeeAccount = Globalized.GetAccountByMdule(this.db, objEmp.IEmpid, MyModuel.IModuleID);
        }



    }
}
