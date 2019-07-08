using System;
using System.Linq;
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
        private dhPatient MyPatient;

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
            db.Patients.Add(ObjNewPatient);
            db.SaveChanges();
            MyPatient = ObjNewPatient;
            long? AccountID =  InsertUpdatePatientAccount();
            ObjNewPatient.IAccountid = Convert.ToInt64(AccountID);
            // db.Patients.Attach(ObjNewPatient);
            db.SaveChanges();
            return ObjNewPatient;
        }
        public long? InsertUpdatePatientAccount()
        {
            blAccount objBlAccount =  new blAccount();
            string AccountName = this.MyPatient.vFullName;
            string Desc = MsgTextCollection.MsgsList.Where(xx => xx.Key == "P_A001").FirstOrDefault().Value;
            dhAccount objAccount = objBlAccount.AddNewAccount(MyModuleName, MyActiveModule.IModuleID, Convert.ToInt32( MyPatient.iPatid), 0, AccountName, "jjj", "P-");
            // return new dhAccount();
            return objAccount.IAccountid;
        }

        //public dhAccount InsertUpdateAccount(dhDoctors ObjDoctor)
        //{
        //    //   Boolean ObjReturn =  false;
        //    dhAccount ObjAccount = new dhAccount();
        //    dhModule objModule = this.db.Modules.AsNoTracking().Where(x => x.VModuleName == "Doctors").First();

        //    if (objModule != null)
        //    {
        //        if (db.Accounts.Count() == 0)
        //        {
        //            ObjAccount = new dhAccount();
        //            ObjAccount.IModuleFK_ID = ObjDoctor.IDocid;
        //            ObjAccount.IModuleID = objModule.IModuleID;
        //            ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
        //            ObjAccount.VAccountDesc = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D01DEC").FirstOrDefault().Value;
        //            ObjAccount.VAccountComments = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D02DEC").FirstOrDefault().Value;
        //            ObjAccount.VAccountNo = "D-" + DateTime.Now.ToString("ddmmyy") + "-" + ObjDoctor.IDocid; // D-For DOC and  DMY  - Day month year and Doc Id
        //            ObjAccount.IFinaceType = 3;
        //            ObjAccount.BNominal = false;
        //            ObjAccount.BEditable = false;

        //            // db.Accounts.Add(ObjAccount);
        //            return ObjAccount;


        //        }

        //        ObjAccount = db.Accounts.Where(x => x.IModuleID == objModule.IModuleID && x.IModuleFK_ID == ObjDoctor.IDocid).FirstOrDefault();
        //        if (ObjAccount == null)
        //        {
        //            ObjAccount = new dhAccount();
        //            // create the account
        //            ObjAccount.IModuleFK_ID = ObjDoctor.IDocid;
        //            ObjAccount.IModuleID = objModule.IModuleID;
        //            ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
        //            ObjAccount.VAccountDesc = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D01DEC").FirstOrDefault().Value;
        //            ObjAccount.VAccountComments = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D02DEC").FirstOrDefault().Value;
        //            ObjAccount.VAccountNo = "D-" + DateTime.Now.ToString("ddMMyy") + "-" + ObjDoctor.IDocid; // D-For DOC and  DMY  - Day month year and Doc Id
        //            ObjAccount.IFinaceType = 3;
        //            ObjAccount.BNominal = false;
        //            ObjAccount.BEditable = false;
        //            return ObjAccount;
        //            //  db.Accounts.Add(ObjAccount);
        //        }
        //        else
        //        {
        //            // update existing acccount account title if needed 
        //            ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
        //        }
        //    }
        //    return ObjAccount;
        //    //    return ObjReturn;
        //}
    }
        
}
