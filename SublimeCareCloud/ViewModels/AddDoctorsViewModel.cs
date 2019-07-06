using Caliburn.Micro;
using DAL;
using DataHolders;
using DataHolders.Interfaces;
using FeserWard.Controls;
using iFacedeLayer;
using SublimeCareCloud.CustomClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    public class AddDoctorsViewModel : Screen, INotifyPropertyChanged, IMyModule
    {
        // Properties

        public AppDbContext db = new AppDbContext();
        public dhDoctors ObjNewDoctor { get; set; }
        public dhAccount DoctorAccount { get; set; }
        private string MyName = "Doctors";
        public long? DocID { get; set; }
        public dhModule MyModuel { get; set; }

        // Constractor
        public AddDoctorsViewModel()
        {
            // load the moduel
            this.MyModuel = this.ActiveModule(MyName);
            this.ObjNewDoctor = new dhDoctors();
            //   this.ObjNewDoctor.VfName = "asdasd";
            this.ObjNewDoctor.Specialization = this.db.Specialization.AsNoTracking().Where(X => X.bIsActive == true).ToObservableCollection();
            this.ObjNewDoctor.Investigations = this.db.Investigations.AsNoTracking().Where(i => i.bIsActive == true).ToObservableCollection();
            this.ObjNewDoctor.DocInvestigations = this.db.DocInvestigations.AsNoTracking().Where(d => d.IDocid == this.ObjNewDoctor.IDocid).ToObservableCollection();

            // load the DocProcedures and Procedures
            this.ObjNewDoctor.Procedures = this.db.Procedures.AsNoTracking().Where(x => x.BIsActive == true).ToObservableCollection();

            this.ObjNewDoctor.DocProcedures = this.db.DocProcedures.Where(x => x.BIsActive == true && x.IDocid == this.ObjNewDoctor.IDocid).ToObservableCollection();

            DoctorAccount = GetDocAccount();
        }
        public AddDoctorsViewModel(dhDoctors objTodisplay)
        {
            // load the moduel
            this.MyModuel = this.ActiveModule(MyName);

            this.ObjNewDoctor = objTodisplay;
            this.ObjNewDoctor.Specialization = this.db.Specialization.AsNoTracking().Where(X => X.bIsActive == true).ToObservableCollection();
            this.ObjNewDoctor.Investigations = this.db.Investigations.AsNoTracking().Where(i => i.bIsActive == true).ToObservableCollection();
            this.ObjNewDoctor.DocInvestigations = GetActiveDocInvestigations();

            // load the DocProcedures and Procedures
            this.ObjNewDoctor.Procedures = this.db.Procedures.AsNoTracking().Where(x => x.BIsActive == true).ToObservableCollection();

            //    this.ObjNewDoctor.DocProcedures = this.db.DocProcedures.Where(x => x.BIsActive == true && x.IDocid == this.ObjNewDoctor.IDocid).ToObservableCollection();
            this.ObjNewDoctor.DocProcedures = GetDocProcedures();
            DoctorAccount = GetDocAccount();
        }

        // Functions

        public dhAccount GetDocAccount()
        {
            dhAccount objReturn = new dhAccount();
            if (this.ObjNewDoctor == null)
            {
                return objReturn;
            }
            DocID = this.ObjNewDoctor.IDocid;
            objReturn = this.db.Accounts.AsNoTracking().Where(x => x.IModuleFK_ID == DocID && x.IModuleID == this.MyModuel.IModuleID).FirstOrDefault();
            return objReturn;

        }
        public ObservableCollection<dhDocProcedures> GetDocProcedures()
        {
            ObservableCollection<dhDocProcedures> listReturnProcedures = new ObservableCollection<dhDocProcedures>();

            if (this.ObjNewDoctor != null && this.ObjNewDoctor.IDocid > 0)
            {
                listReturnProcedures = (from Proc in db.Procedures
                                        join DocPro in db.DocProcedures
                                      on Proc.IProcedureId equals DocPro.IProcedureId
                                        where DocPro.IDocid == ObjNewDoctor.IDocid && DocPro.BIsActive == true
                                        select new
                                        {
                                            DocPro.IDocid,
                                            DocPro.IDocCommission,
                                            DocPro.IDocProceduresId,
                                            Proc.IProcedureId,
                                            Proc.VProcedureName,
                                            Proc.VProcedureDesc,
                                            Proc.IProCharges,
                                            Proc.BIsActive
                                        }
                                                                            ).ToList()
                                                                            .Select(x =>
                                                                            new dhDocProcedures
                                                                            {
                                                                                IDocid = x.IDocid,
                                                                                IDocCommission = x.IDocCommission,
                                                                                IDocProceduresId = x.IDocProceduresId,
                                                                                IProcedureId = x.IProcedureId,
                                                                                VProcedureName = x.VProcedureName,
                                                                                VProcedureDesc = x.VProcedureDesc,
                                                                                IProcedureCharges = x.IProCharges,
                                                                                BIsActive = x.BIsActive
                                                                            }
                                                                            ).ToObservableCollection();
            }

            return listReturnProcedures;

        }
        public ObservableCollection<DocInvestigations> GetActiveDocInvestigations()
        {

            ObservableCollection<DocInvestigations> returnList = new ObservableCollection<DocInvestigations>();
            if (this.ObjNewDoctor != null && this.ObjNewDoctor.IDocid > 0)
            {
                returnList = (from Inv in db.Investigations
                              join Dinv in db.DocInvestigations
                            on Inv.IInvid equals Dinv.IInvid
                              where Dinv.IDocid == ObjNewDoctor.IDocid && Dinv.BIsActive == true
                              select new { Dinv.IDocid, Dinv.IDocCommission, Dinv.IDocInvestigationsId, Inv.IInvid, Inv.VInvName, Inv.VInvDesc, Inv.IInvCharges, Inv.bIsActive }
                                                                             ).ToList()
                                                                             .Select(x =>
                                                                             new DocInvestigations
                                                                             {
                                                                                 IDocid = x.IDocid,
                                                                                 IDocCommission = x.IDocCommission,
                                                                                 IDocInvestigationsId = x.IDocInvestigationsId,
                                                                                 IInvid = x.IInvid,
                                                                                 VInvName = x.VInvName,
                                                                                 VInvDesc = x.VInvDesc,
                                                                                 IInvCharges = x.IInvCharges,
                                                                                 BIsActive = x.bIsActive
                                                                             }
                                                                             ).ToObservableCollection();
            }


            return returnList;
        }

        public DocInvestigations GetActiveDocInvestigations(long DocInvId)
        {
            ObservableCollection<DocInvestigations> returnList = new ObservableCollection<DocInvestigations>();
            if (DocInvId > 0)
            {

                if (this.ObjNewDoctor != null && this.ObjNewDoctor.IDocid > 0)
                {
                    returnList = (from Dinv in db.DocInvestigations
                                  join Inv in db.Investigations
                                on Dinv.IInvid equals Inv.IInvid
                                  where Dinv.IDocid == ObjNewDoctor.IDocid && Dinv.BIsActive == true && Dinv.IDocInvestigationsId == DocInvId
                                  select new { Dinv.IDocid, Dinv.IDocCommission, Dinv.IDocInvestigationsId, Inv.IInvid, Inv.VInvName, Inv.VInvDesc, Inv.IInvCharges, Inv.bIsActive }
                                                                                 ).ToList()
                                                                                 .Select(x =>
                                                                                 new DocInvestigations
                                                                                 {
                                                                                     IDocid = x.IDocid,
                                                                                     IDocCommission = x.IDocCommission,
                                                                                     IDocInvestigationsId = x.IDocInvestigationsId,
                                                                                     IInvid = x.IInvid,
                                                                                     VInvName = x.VInvName,
                                                                                     VInvDesc = x.VInvDesc,
                                                                                     IInvCharges = x.IInvCharges,
                                                                                     BIsActive = x.bIsActive
                                                                                 }
                                                                                 ).ToObservableCollection();
                }

            }

            DocInvestigations ObjReturn = new DocInvestigations();
            if (returnList.First() != null)
            {
                ObjReturn = returnList.First();
            }
            return ObjReturn;
        }

        public dhAccount InsertUpdateAccount(dhDoctors ObjDoctor)
        {
            //   Boolean ObjReturn =  false;
            dhAccount ObjAccount = new dhAccount();
            dhModule objModule = this.db.Modules.AsNoTracking().Where(x => x.VModuleName == "Doctors").First();

            if (objModule != null)
            {
                if (db.Accounts.Count() == 0)
                {
                    ObjAccount = new dhAccount();
                    ObjAccount.IModuleFK_ID = ObjDoctor.IDocid;
                    ObjAccount.IModuleID = objModule.IModuleID;
                    ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
                    ObjAccount.VAccountDesc = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D01DEC").FirstOrDefault().Value;
                    ObjAccount.VAccountComments = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D02DEC").FirstOrDefault().Value;
                    ObjAccount.VAccountNo = "D-" + DateTime.Now.ToString("ddmmyy") + "-" + ObjDoctor.IDocid; // D-For DOC and  DMY  - Day month year and Doc Id
                    ObjAccount.IFinaceType = 3;
                    ObjAccount.BNominal = false;
                    ObjAccount.BEditable = false;

                    // db.Accounts.Add(ObjAccount);
                    return ObjAccount;


                }

                ObjAccount = db.Accounts.Where(x => x.IModuleID == objModule.IModuleID && x.IModuleFK_ID == ObjDoctor.IDocid).FirstOrDefault();
                if (ObjAccount == null)
                {
                    ObjAccount = new dhAccount();
                    // create the account
                    ObjAccount.IModuleFK_ID = ObjDoctor.IDocid;
                    ObjAccount.IModuleID = objModule.IModuleID;
                    ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
                    ObjAccount.VAccountDesc = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D01DEC").FirstOrDefault().Value;
                    ObjAccount.VAccountComments = MsgTextCollection.MsgsList.Where(xx => xx.Key == "M_D02DEC").FirstOrDefault().Value;
                    ObjAccount.VAccountNo = "D-" + DateTime.Now.ToString("ddMMyy") + "-" + ObjDoctor.IDocid; // D-For DOC and  DMY  - Day month year and Doc Id
                    ObjAccount.IFinaceType = 3;
                    ObjAccount.BNominal = false;
                    ObjAccount.BEditable = false;
                    return ObjAccount;
                    //  db.Accounts.Add(ObjAccount);
                }
                else
                {
                    // update existing acccount account title if needed 
                    ObjAccount.AccountName = ObjDoctor.VfName + " " + ObjDoctor.VlName;
                }
            }
            return ObjAccount;
            //    return ObjReturn;
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
