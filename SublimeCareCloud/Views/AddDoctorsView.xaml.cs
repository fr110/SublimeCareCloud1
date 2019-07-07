using DataHolders;
using FeserWard.Controls;
using SublimeCareCloud.CustomClasses;
using SublimeCareCloud.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddDoctorsView.xaml
    /// </summary>
    public partial class AddDoctorsView : UserControl
    {
        AddDoctorsViewModel MyViewModel;
        public IIntelliboxResultsProvider dbInvestigation { get; private set; }
        public IIntelliboxResultsProvider dbProcedure { get; private set; }

        public AddDoctorsView()
        {
            InitializeComponent();
           
        }
        //private void previewKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
        //        {
        //            //   MessageBox.Show("Shift + Enter pressed");
        //            e.Handled = true;
        //        }

        //    }else
        //    {
        //        e.Handled = false;
        //    }
        //        if (e.Key == Key.Enter || e.Key == Key.Return)
        //    {
        //        e.Handled = true;
        //        //Do your stuff
        //    }
        // }
        private void AddEditDocProcedures()
        {
            // check if it is not update 
            if (this.objNewDoctor.IUpdate ==  0)
            {
                foreach (dhDocProcedures item in objNewDoctor.DocProcedures)
                {
                    item.IDocid = objNewDoctor.IDocid;
                    item.BIsActive = true;
                    MyViewModel.db.DocProcedures.Add(item);
                }
            }

            // check for update 
            if( this.objNewDoctor.IUpdate == 1)
            {
                // check for removel

                // check existing investigation
                ObservableCollection<dhDocProcedures> crntInv = MyViewModel.db.DocProcedures.Where(x => x.IDocid == objNewDoctor.IDocid && x.BIsActive == true).ToObservableCollection();
                foreach (dhDocProcedures item in objNewDoctor.DocProcedures)
                {
                    item.IDocid = objNewDoctor.IDocid;
                    // make this investigation active
                    item.BIsActive = true;
                    if (crntInv.Select(x => x.IDocProceduresId == item.IDocProceduresId).FirstOrDefault() == false)
                    {
                        MyViewModel.db.DocProcedures.Add(item);
                    }
                    else
                    {
                        dhDocProcedures tempDoinv = this.MyViewModel.db.DocProcedures.Find(item.IDocProceduresId);
                        if (tempDoinv != null)
                            tempDoinv = item;
                    }
                    // if(crntInv.fi)
                }
            }
        }
        private dhDoctors objNewDoctor
        {
            get { return (dhDoctors)this.NewDoctorGrid.DataContext; }
            set { this.NewDoctorGrid.DataContext = value; }
        }
        private void BtnSaveDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if(objNewDoctor.IUpdate == 0 || objNewDoctor.IUpdate ==  null) {

                    if (objNewDoctor.TokenStart == "" || objNewDoctor.TokenStart == null)
                    { 
                       objNewDoctor.TokenStart =  objNewDoctor.VfName.Substring(0, 2).ToUpper();
                    }
                    MyViewModel.db.Doctors.Add(objNewDoctor);
                        MyViewModel.db.SaveChanges();;
                    // for investigations
                    foreach (DocInvestigations item in objNewDoctor.DocInvestigations)
                        {
                            item.IDocid = objNewDoctor.IDocid;
                            item.BIsActive = true;
                        MyViewModel.db.DocInvestigations.Add(item);
                        }
                    // for doc procedures
                          dhAccount objAccount = MyViewModel.InsertUpdateAccount(objNewDoctor);
                          MyViewModel.db.Accounts.Add(objAccount);
                    //  need to set for doc proc
                    this.AddEditDocProcedures();
                          Globalized.SetMsg("DOC01", DataHolders.MsgType.Info);
                }
                // if update flag is set 
                if(objNewDoctor.IUpdate == 1)
                {
                    // dhDoctors temp =  MyViewModel.db.Doctors.Find(objNewDoctor.IDocid);
                    objNewDoctor = (dhDoctors)this.NewDoctorGrid.DataContext;
                    if (objNewDoctor.TokenStart == "" || objNewDoctor.TokenStart == null )
                    {
                        objNewDoctor.TokenStart = objNewDoctor.VfName.Substring(0, 2).ToUpper();
                    }
                    MyViewModel.db.Doctors.Attach(objNewDoctor);
                    //.State = EntityState.Added;
                    MyViewModel.db.Entry(objNewDoctor).State = EntityState.Modified;

                    dhAccount objAccount = MyViewModel.InsertUpdateAccount(objNewDoctor);

                    //
                    MyViewModel.db.Accounts.Attach(objAccount);
                    MyViewModel.db.Entry(objAccount).State = EntityState.Modified;


                    // check existing investigation
                    ObservableCollection < DocInvestigations >  crntInv = MyViewModel.db.DocInvestigations.Where(x => x.IDocid == objNewDoctor.IDocid && x.BIsActive ==  true).ToObservableCollection();
                    foreach (DocInvestigations item in objNewDoctor.DocInvestigations)
                    {
                        item.IDocid = objNewDoctor.IDocid;
                        // make this investigation active
                        item.BIsActive = true;
                        if(crntInv.Select(x => x.IDocInvestigationsId == item.IDocInvestigationsId).FirstOrDefault() == false)
                        {
                            MyViewModel.db.DocInvestigations.Add(item);
                        }
                        else
                        {
                            DocInvestigations tempDoinv = this.MyViewModel.db.DocInvestigations.Find(item.IDocInvestigationsId);
                            if (tempDoinv != null)
                                tempDoinv = item;
                        }
                      // if(crntInv.fi)
                    }

                    //  need to set for doc proc
                    this.AddEditDocProcedures();

                    Globalized.SetMsg("DOC02", DataHolders.MsgType.Info);
                    

                }


              
                //  final save and update model
                objNewDoctor.IUpdate = 1; //  now it will ebe update object

                MyViewModel.db.SaveChanges();
                // set Doctor 
                MyViewModel.ObjNewDoctor = objNewDoctor;
                MyViewModel.ObjNewDoctor.DocInvestigations = MyViewModel.GetActiveDocInvestigations();


                MyViewModel.DoctorAccount = MyViewModel.GetDocAccount();
                this.AccountInfo.DataContext = MyViewModel.DoctorAccount;

                Globalized.ShowMsg(lblErrorMsg);
                
                

            }
            catch (Exception ex)
            {

                Globalized.SetMsg(ex.Message, MsgType.Error);
                Globalized.ShowMsg(lblErrorMsg);
            }
             

            //  this.DataContext
        }


        public void RefreshData()
        {

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            this.MyViewModel = (AddDoctorsViewModel)this.DataContext;
            this.dbInvestigation = new InvestigationSearch();
             InvestigationList.DataProvider = this.dbInvestigation;

            // dbProcedure
            this.dbProcedure = new ProcedureSearch();
            ProceduresList.DataProvider = this.dbProcedure;
            // dhDoctors obj =  ((dhDoctors)this.DataContext);
            //  this.NewDoctorGrid.DataContext = new dhDoctors();
            this.DocInvestigations.ItemsSource = MyViewModel.ObjNewDoctor.DocInvestigations;
            this.DocProcedures.ItemsSource = MyViewModel.ObjNewDoctor.DocProcedures;
        }

        private void TxtIInvestigationID_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

            if(this.MyViewModel == null)
            {
                return;
            }
            int InvId;
            int.TryParse(txtIInvestigationID.Text.ToString(), out InvId);


            Investigations ObjInv = this.MyViewModel.db.Investigations.Where(I => I.bIsActive == true && I.IInvid == InvId).FirstOrDefault();
            //iFacede.GetdhItem(Globalized.ObjDbName, new dhItems { IItemID = Convert.ToInt32(ItemList.SelectedValue) });
            //ObjDhItem.IQuantity = 0;
            // creat the new object of doctor investigation
            if(ObjInv == null)
            {
                return;
            }
            DocInvestigations objDocInv = new DocInvestigations();
            
            objDocInv.IInvid = InvId;
            objDocInv.IDocid = this.MyViewModel.ObjNewDoctor.IDocid;
            objDocInv.VInvName = ObjInv.VInvName;
            objDocInv.VInvDesc = ObjInv.VInvDesc;
            objDocInv.IInvCharges = ObjInv.IInvCharges;
            this.MyViewModel.ObjNewDoctor.DocInvestigations.Add(objDocInv);
            // update the source 
            this.DocInvestigations.ItemsSource = this.MyViewModel.ObjNewDoctor.DocInvestigations;
            // clear the source
            // this.InvestigationList.SelectedItem = null;
            // this.InvestigationList.SelectedValue = "";
            
            //this.InvestigationList
        }

        private void InvestigationList_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    //   MessageBox.Show("Shift + Enter pressed");
                    //  return true;
                    e.Handled = true;
                    var child = Globalized.FindChildByType<TextBox>(InvestigationList);
                    child.Text = "";
                    child.Focus();
                    // this.btnSaveDoctor.IsDefault = false;
                }
            

            }
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                { 
                if (objToEditOrRemove != null)
                {
                    DocInvestigations obj = MyViewModel.db.DocInvestigations.Find(objToEditOrRemove.IDocInvestigationsId);
                    if (obj != null)
                    {
                        obj.BIsActive = false;
                        MyViewModel.db.SaveChanges();
                        MyViewModel.ObjNewDoctor.DocInvestigations.Remove(objToEditOrRemove);
                        this.DocInvestigations.ItemsSource = MyViewModel.ObjNewDoctor.DocInvestigations;
                    }
                    else
                    {
                        MyViewModel.ObjNewDoctor.DocInvestigations.Remove(objToEditOrRemove);
                        this.DocInvestigations.ItemsSource = MyViewModel.ObjNewDoctor.DocInvestigations;

                    }
                }
                    MyViewModel.ObjNewDoctor.DocInvestigations = MyViewModel.GetActiveDocInvestigations();
                    Globalized.SetMsg("DOC03", DataHolders.MsgType.Info);
                    Globalized.ShowMsg(lblErrorMsg);
                }


            }
            catch (Exception ex)
            {

               // throw;
            }

        }

        DocInvestigations objToEditOrRemove;
        private void DocInvestigations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            objToEditOrRemove = DocInvestigations.SelectedItem as DocInvestigations;
        }

        private void TxtIProceduresID_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            if (this.MyViewModel == null)
            {
                return;
            }
            int IProId;
            int.TryParse(txtIProceduresID.Text.ToString(), out IProId);


            dhProcedure ObjInv = this.MyViewModel.db.Procedures.Where(I => I.BIsActive == true && I.IProcedureId == IProId).FirstOrDefault();
            //iFacede.GetdhItem(Globalized.ObjDbName, new dhItems { IItemID = Convert.ToInt32(ItemList.SelectedValue) });
            //ObjDhItem.IQuantity = 0;
            // creat the new object of doctor investigation
            if (ObjInv == null)
            {
                return;
            }

            dhDocProcedures objDocProcedure = new dhDocProcedures();

            objDocProcedure.IProcedureId = IProId;
            objDocProcedure.IDocid = this.MyViewModel.ObjNewDoctor.IDocid;
            objDocProcedure.VProcedureName = ObjInv.VProcedureName;
            objDocProcedure.VProcedureDesc = ObjInv.VProcedureDesc;
            objDocProcedure.IProcedureCharges = ObjInv.IProCharges;
            this.MyViewModel.ObjNewDoctor.DocProcedures.Add(objDocProcedure);

            // update the source 
            this.DocProcedures.ItemsSource = this.MyViewModel.ObjNewDoctor.DocProcedures;


            // clear the source
            // this.InvestigationList.SelectedItem = null;
            // this.InvestigationList.SelectedValue = "";

            //this.InvestigationList
        }

        dhDocProcedures ObjToEditPro;
        private void DocProcedures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObjToEditPro =  DocProcedures.SelectedItem as dhDocProcedures;
        }

        private void BtnDeleteProc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (ObjToEditPro != null)
                    {
                        dhDocProcedures obj = MyViewModel.db.DocProcedures.Find(ObjToEditPro.IDocProceduresId);
                        if (obj != null)
                        {
                            obj.BIsActive = false;
                            MyViewModel.db.SaveChanges();
                            MyViewModel.ObjNewDoctor.DocProcedures.Remove(ObjToEditPro);
                            this.DocProcedures.ItemsSource = this.MyViewModel.ObjNewDoctor.DocProcedures;
                        }
                        else
                        {
                            MyViewModel.ObjNewDoctor.DocProcedures.Remove(ObjToEditPro);
                            this.DocProcedures.ItemsSource = this.MyViewModel.ObjNewDoctor.DocProcedures;

                        }
                    }
                    MyViewModel.ObjNewDoctor.DocProcedures = MyViewModel.GetDocProcedures();
                    Globalized.SetMsg("DOC04", DataHolders.MsgType.Info);
                    Globalized.ShowMsg(lblErrorMsg);
                }


            }
            catch (Exception ex)
            {

                // throw;
            }
        }

        private void ProceduresList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    //   MessageBox.Show("Shift + Enter pressed");
                    //  return true;
                    e.Handled = true ;
                    //var child = Globalized.FindChildByType<TextBox>(ProceduresList);
                    //child.Text = "";
                    //child.Focus();
                    //// this.btnSaveDoctor.IsDefault = false;
                }


            }
        }
    }
}
