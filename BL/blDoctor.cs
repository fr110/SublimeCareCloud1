using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class blDoctor
    {
        AppDbContext db;
        private string MyName = "Doctors";
        public dhModule MyModuel { get; set; }

        public blDoctor()
        {
            this.db = new AppDbContext();
            this.MyModuel = this.ActiveModule(MyName);
            LoadDoctors();
        }


        private ObservableCollection<dhDoctorView> _DoctorList;
        public ObservableCollection<dhDoctorView> DoctorList
        {
            get { return _DoctorList; }
            set { _DoctorList = value; OnPropertyChanged("DoctorList"); }
        }


        // private methodes
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
                return this.db.Modules.Where(x => x.VModuleName == ModuleName).FirstOrDefault();
            }
        }
        public void LoadDoctors()
        {
            // DoctorList = db.Doctors.Where(xx => xx.BActive == true).ToObservableCollection();
            //  dsGeneral.dtPosPartyDataTable dtparty = iFacede.GetParty(Globalized.ObjDbName, objParty);
            // Parties = ReflectionUtility.DataTableToObservableCollection<dhParty>(dtparty);
            //this.db.SaveChanges();
            this.DoctorList = new ObservableCollection<dhDoctorView>();
            this.DoctorList = (

                               from Doc in db.Doctors
                               join sep in db.Specialization
                               on Doc.ISpecializationId equals sep.iSpecializationId

                               join acc in db.Accounts
                               on Doc.IDocid equals acc.IModuleFK_ID

                               where acc.IModuleID == MyModuel.IModuleID
                               select new
                               {
                                   Doc.VSuffix,
                                   Doc.VGender,
                                   // (Doc.VfName + ' ' + Doc.VlName) as VFullName,
                                   Doc.IDocid,
                                   Doc.VTitle,
                                   Doc.VfName,
                                   Doc.VlName,
                                   Doc.VFatherName,
                                   Doc.DDOB,
                                   Doc.ISpecializationId,
                                   Doc.VMobile,
                                   Doc.VEmail,
                                   Doc.BActive,
                                   Doc.IPatient_Fee,
                                   Doc.IReturning_Patient_Fee,
                                   Doc.IPatient_Token_Limit,
                                   Doc.IHospital_Charges,
                                   Doc.DJoiningDate,

                                   //dSep.iSpecializationId,
                                   sep.vSpecializationName,

                                   acc.IAccountid,
                                   acc.AccountName,
                                   acc.VAccountNo,
                                   acc.IFinaceType


                               }
                                      ).ToList()
                                      .Select(x =>
                                      new dhDoctorView
                                      {
                                          IDocid = x.IDocid,
                                          VTitle = x.VTitle,
                                          VfName = x.VfName,
                                          VFullName = x.VfName + " " + x.VlName,
                                          VlName = x.VlName,
                                          VFatherName = x.VFatherName,
                                          DDOB = x.DDOB,
                                          ISpecializationId = x.ISpecializationId,
                                          VMobile = x.VMobile,
                                          VEmail = x.VEmail,
                                          BActive = x.BActive,
                                          IPatient_Fee = x.IPatient_Fee,
                                          IReturning_Patient_Fee = x.IReturning_Patient_Fee,
                                          IPatient_Token_Limit = x.IPatient_Token_Limit,
                                          IHospital_Charges = x.IHospital_Charges,
                                          DJoiningDate = x.DJoiningDate,
                                          VSpecializationName = x.vSpecializationName,
                                          IAccountid = x.IAccountid,
                                          AccountName = x.AccountName,
                                          VAccountNo = x.VAccountNo,
                                          IFinaceType = x.IFinaceType,

                                      }
                                    ).ToObservableCollection();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
