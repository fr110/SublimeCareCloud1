using Caliburn.Micro;
using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.ViewModels
{
    class NewAppointmentViewModel : Screen, INotifyPropertyChanged
    {
        public AppDbContext db = new AppDbContext();
        public dhAppointment ObjNewAppointment { get; set; }
        //public dhAccount DoctorAccount { get; set; }

        private string MyName = "Appointment";
        public long? DocID { get; set; }
        public dhModule MyModuel { get; set; }


        public NewAppointmentViewModel()
        {
            this.ObjNewAppointment = new dhAppointment();
        }

    }
}
