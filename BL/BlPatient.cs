using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using DAL;
namespace BL
{

    public class BlPatient
    {
        blModule MyModuleObj;
        string MyModuleName;
        public dhModule MyActiveModule { get; set; }
        AppDbContext db; 

        //constructors
        public BlPatient()
        {
            this.MyModuleName = "Patients";
            MyModuleObj = new blModule(MyModuleName);
            MyActiveModule = MyModuleObj.ActiveModule();
            this.db = new AppDbContext();
        }

        //class functions
        public dhPatient AddNewPatient(dhPatient ObjNewPatient)
        {
            if (ObjNewPatient == null)
            {
                return new dhPatient();
            }
            this.db.Patients.Add(ObjNewPatient);
            this.db.SaveChanges();
            return new dhPatient();
        }
     }
        
}
