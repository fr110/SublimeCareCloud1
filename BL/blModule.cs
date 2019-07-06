using DataHolders;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;

namespace BL
{

    public class blModule
    {
        dalGeneral objDALGeneral;
        AppDbContext db;
        private string ModuleName { get; set; }
        private int? IModuleParentID { get; set; }
        public blModule()
        {
            objDALGeneral = new dalGeneral();
            this.db = new AppDbContext();
        }
        public blModule(string strModuleName)
        {
            objDALGeneral = new dalGeneral();
            db = new AppDbContext();
            this.ModuleName = strModuleName;

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
                return this.db.Modules.Where(x => x.VModuleName == ModuleName).FirstOrDefault();
            }
        }
        public dhModule ActiveModule()
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

        public dsGeneral.dtPosModuleDataTable GetModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            dsGeneral.dtPosModuleDataTable dt = objDALGeneral.GetModule(objDBNames, ObjModule);
            return dt;
        }

        internal DataSet InsertUpdateModule(dhDBnames objDBNames, dhModule ObjModule)
        {
            DataSet ds = objDALGeneral.InsertUpdateModule(objDBNames, ObjModule);
            return ds;
        }

    }
}
