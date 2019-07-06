using BL;
using DataHolders;
using FeserWard.Controls;
using SublimeCareCloud.CustomClasses;
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
    /// Interaction logic for NewAppointmentView.xaml
    /// </summary>
    public partial class NewAppointmentView : UserControl
    {
        // private objects
        NewAppointmentViewModel MyViewModel;
        blDoctor MyBlDoctor;
        public IIntelliboxResultsProvider dbDoctorSearch { get; private set; }
        public IIntelliboxResultsProvider dbPatientSearch { get; private set; }
      //  public IIntelliboxResultsProvider dbProcedure { get; private set; }

        public NewAppointmentView()
        {
            InitializeComponent();
            //this.MyViewModel = (NewAppointmentViewModel)this.DataContext;
            //dbDoctorSearch = new blDoctorSearch(MyViewModel.db);
        }

        private void SaveAppointment(object sender, RoutedEventArgs e)
        {
            try
            {
                dhAppointment ObjNewAppointment = (dhAppointment)this.AppointmentInfo.DataContext;
                // cehck for patient
                dhPatient ObjPatient = (dhPatient)this.PatientInformationGrid.DataContext;
                if (ObjPatient.iPatid == 0 || ObjPatient.iPatid < 0)
                {
                    // need to save the patient first 
                    MyViewModel.db.Patients.Add(ObjPatient);
                    MyViewModel.db.SaveChanges();
                    // set for patatient id
                    ObjNewAppointment.IPatid = ObjPatient.iPatid;
                }

                // check for doctors
                if (ObjNewAppointment != null)
                {
                    MyViewModel.db.Appointments.Add(ObjNewAppointment);
                    MyViewModel.db.SaveChanges();
                }

                Globalized.SetMsg("AOC01", CustomClasses.MsgType.Info);
                Globalized.ShowMsg(lblErrorMsg);
            }
            catch (Exception ex)
            {
                Globalized.SetMsg(ex.Message, CustomClasses.MsgType.Error);
                Globalized.ShowMsg(lblErrorMsg);

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.MyViewModel = (NewAppointmentViewModel)this.DataContext;
            MyBlDoctor = new blDoctor();
            dbDoctorSearch = new blDoctorSearch(MyBlDoctor);
            dbPatientSearch = new blPatSearch();
            srcDoctore.DataProvider = this.dbDoctorSearch;
            srcPatient.DataProvider = this.dbPatientSearch;


            //BlPatient abc = new BlPatient();
            //dhPatient TestObj = new dhPatient();
            //TestObj.vFullName = "saqib Ali";
            //TestObj.vGender = "Male";
            //TestObj.iPatAge = 14;
            //TestObj.bActive = true;

            //abc.AddNewPatient(TestObj);

            this.AppointmentInfo.DataContext = new dhAppointment();
            this.PatientInformationGrid.DataContext = new dhPatient();

        }

        private void TxtIDocID_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            long iDocID;
            long.TryParse(txtbox.Text.ToString(), out iDocID);
            if(iDocID>0)
            {
                // find the doc
                dhDoctorView objDoc = this.MyBlDoctor.DoctorList.Where(d => d.IDocid ==  iDocID).FirstOrDefault();
                // bind the information 
                if(objDoc != null)
                {
                    this.DoctorInformationGrid.DataContext = objDoc;
                    ((dhAppointment)this.AppointmentInfo.DataContext).IDocid = objDoc.IDocid;
                    ((dhAppointment)this.AppointmentInfo.DataContext).IPayment_Due = objDoc.IPatient_Fee;

                }
            }

        }

        private void TxtiPatid_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            long iPatid;
            long.TryParse(txtbox.Text.ToString(), out iPatid);
            if (iPatid > 0)
            {
                // find the doc
                dhPatient objPat = this.MyViewModel.db.Patients.Where(d => d.iPatid == iPatid).FirstOrDefault();
                // bind the information 
                if (objPat != null)
                {
                    this.PatientInformationGrid.DataContext = objPat;
                    ((dhAppointment)this.AppointmentInfo.DataContext).IPatid = objPat.iPatid;
                }
            }
        }

        private void VFullName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
