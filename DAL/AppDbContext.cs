using DataHolders;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
          : base("name=AppDbConn")
        {
            //       Database.SetInitializer<AppDbContext>(new DropCreateDatabaseAlways<AppDbContext>());

        }
     //   public DbSet<dhUsers> AppUsers { get; set; }
        public DbSet<dhDoctors> Doctors { get; set; }
        public DbSet<dhSpecialization> Specialization { get; set; }
        public DbSet<Investigations> Investigations { get; set; }
        public DbSet<DocInvestigations> DocInvestigations { get; set; }
        public DbSet<dhEmployee> Employees { get; set; }
        public DbSet<dhProcedure> Procedures { get; set; }
        public DbSet<dhDocProcedures> DocProcedures { get; set; }
        // Patient
        public DbSet<dhPatient> Patients { get; set; }
        // appointments
        public DbSet<dhAppointment> Appointments { get; set; }
        // our old modules 

        public DbSet<dhAccount>  Accounts { get; set; }
        public DbSet<dhModule> Modules { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          //  modelBuilder.Ignore<dhAccount>();
           // modelBuilder.Ignore<dhModule>();
        }

        }
    }
