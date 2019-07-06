using DataHolders;
using iFacedeLayer;
using MahApps.Metro.Controls;
using SublimeCareCloud.CustomClasses;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    /// 

    public partial class MainView 
    {
        SublimeMenu myMenu;
        dhAppPreference objAppPreference = new dhAppPreference();
        dhUsers objUser = new dhUsers();
        
        public MainView()
        {
            InitializeComponent();
           // CreateMenuItems();
           
       //     iFacede.GetUserMenu(Globalized.ObjDbName, Obj, Globalized.objAppPreference, Globalized.ObjCurrentUser);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
                   
                    LoadComponent();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        //private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UserControl usc = null;
        //    GridMain.Children.Clear();

        //    switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
        //    {
        //        case "ItemHome":
        //            usc = new PartyView();
        //            GridMain.Children.Add(usc);
        //            break;
        //        case "ItemCreate":
        //            usc = new PartyView();
        //            GridMain.Children.Add(usc);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        private void LoadComponent()
        {
            dhDBnames objDBNames = new dhDBnames();
            objDBNames.ServerName = System.Configuration.ConfigurationManager.AppSettings["ServerName"].ToString();
            objDBNames.Default_DB_Name = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
            objDBNames.DBUser = System.Configuration.ConfigurationManager.AppSettings["DBUser"].ToString();
            objDBNames.DBPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"].ToString();
            string path = AppDomain.CurrentDomain.BaseDirectory;//System.Reflection.Assembly.GetExecutingAssembly().Location;
            objDBNames.XmlFilePath = path + "XMLFiles\\" + System.Configuration.ConfigurationManager.AppSettings["DBXmlFilePath"].ToString();
            Globalized.ObjDbName = objDBNames;

            if (Globalized.objAppPreference == null)
            {


                dsGeneral.dtAppPreferenceDataTable dtApp = iFacede.GetAppPreference(Globalized.ObjDbName, objAppPreference);
                ObservableCollection<dhAppPreference> sequence = ReflectionUtility.DataTableToObservableCollection<dhAppPreference>(dtApp);
                if (sequence.Count > 0)
                {
                    objAppPreference = sequence[0];
                    //objAppPreference.ImgCompanyLogo = (System.Byte[])dtApp.Rows[0]["ImgCompanyLogo"];
                    objAppPreference.VEnableModules = string.IsNullOrEmpty(dtApp.Rows[0]["vEnableModules"].ToString()) ? "" : dtApp.Rows[0]["vEnableModules"].ToString();
                    objAppPreference.ImgCompanyLogo = !string.IsNullOrEmpty(dtApp.Rows[0]["imgCompanyLogo"].ToString()) ? (byte[])dtApp.Rows[0]["imgCompanyLogo"] : null;
                    objAppPreference.VCompanyName = !string.IsNullOrEmpty(dtApp.Rows[0]["vCompanyName"].ToString()) ? dtApp.Rows[0]["VCompanyName"].ToString() : null;
                    Globalized.objAppPreference = objAppPreference;
                   // cstmUtilities.LoadImage(Globalized.objAppPreference.ImgCompanyLogo, Image1);

                   //  this.AppName.Text = String.IsNullOrEmpty(Globalized.objAppPreference.VApplicationName) ? "POS" : Globalized.objAppPreference.VApplicationName;
                     this.CompanyName.Text = String.IsNullOrEmpty(Globalized.objAppPreference.VCompanyName) ? "ABFA" : Globalized.objAppPreference.VCompanyName;
                    // ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
                    // Obj.Title = String.IsNullOrEmpty(Globalized.objAppPreference.VApplicationName) ? "POS" : Globalized.objAppPreference.VApplicationName;
                    ////this.lblErrorMsg.Visibility = Visibility.Hidden;
                    ////this.UserName.Text = "";
                    ////this.Password.Password = "";
                    //= sequence;
                }
                else
                {
                    Globalized.SetMsg("Application is Not Initialized Properly please contact support team. ", CustomClasses.MsgType.Error);
                   // lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
                  //  Globalized.ShowMsg(lblErrorMsg);
                  
                }
            }
            //byte[] img = (byte[])objAppPreference.ImgCompanyLogo;
            //MemoryStream str = new MemoryStream();
            // str.Write(img, 0, img.Length);
            // BitmapImage  bit = new BitmapImage(str);
            //byte[] objimg = (byte[])objAppPreference.ImgCompanyLogo;
            //imgCompanyLogo.DataContext = ImageFromBytearray(objimg);

            //  byte[] bytImageDataBytes =   objAppPreference.ImgCompanyLogo;
            ////  byte[] bytImageDataBytes = (byte[])objAppPreference.ImgCompanyLogo.;
            //  System.IO.MemoryStream ms = new System.IO.MemoryStream(bytImageDataBytes);
            //  ms.Seek(0, System.IO.SeekOrigin.Begin);
            //  BitmapImage newBitmapImage = new BitmapImage();
            //  newBitmapImage.BeginInit();
            //  newBitmapImage.StreamSource = ms;
            //  newBitmapImage.EndInit();
            //  imgCompanyLogo.Source = newBitmapImage;//ConvertToImage(objAppPreference.ImgCompanyLogo);






        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dhUsers objUser = new dhUsers();
            try
            {
                if (String.IsNullOrEmpty(UserName.Text.Trim()))
                {
                    throw new ApplicationException("Please Enter User Name.");
                }
                if (String.IsNullOrEmpty(Password.Password.Trim()))
                {
                    throw new ApplicationException("Please Enter Password.");

                }
                objUser.VLogin = UserName.Text.Trim();
                objUser.VPassword = Password.Password.Trim();
                objUser = iFacede.Authentication(Globalized.ObjDbName, objUser);
                if (objUser.LoginStatus == true)
                {
                    LoadComponent();
                    if ((objUser.BIsActive != true) && (objUser.VUserType != "Super"))
                    {
                        throw new ApplicationException("Your account status is inactive, contact to administrator/ Support.");
                    }
                    // set the current user 
                    Globalized.ObjCurrentUser = objUser;
                   // ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;
                    dhPreference GlobalObjPreference = new dhPreference();
                    dsGeneral.dtPosPreferenceDataTable dt = iFacede.GetPreference(Globalized.ObjDbName, GlobalObjPreference);
                    // intialize object 
                    if (dt.Rows.Count > 0)
                    {
                        ObservableCollection<dhPreference> listItem = ReflectionUtility.DataTableToObservableCollection<dhPreference>(dt);
                        if (listItem.Count > 0)
                        {
                            GlobalObjPreference = listItem.Cast<dhPreference>().SingleOrDefault();
                        }
                    }
                    else
                    {
                        GlobalObjPreference = new dhPreference();
                    }
                    Globalized.ObjPrefernce = GlobalObjPreference;
                    //iFacede.GetUserMenu(Globalized.ObjDbName, Obj, objAppPreference, objUser);
                    myMenu = new SublimeMenu(Globalized.ObjCurrentUser);
                    if (myMenu.MenuItems.Count > 0)
                    {
                          this.ListViewMenu.ItemsSource = myMenu.MenuItems;
                          // this.SideMenu.ItemsSource = myMenu.MenuItems;
                          // this.SideMenu.Visibility = System.Windows.Visibility.Visible;
                          this.MainGrid.Visibility = System.Windows.Visibility.Hidden;
                        this.DocLogin.Visibility = Visibility.Visible;


                    }
                    else
                    {
                            // this.SideMenu.Visibility = System.Windows.Visibility.Hidden;
                            this.MainGrid.Visibility = System.Windows.Visibility.Visible;
                        this.DocLogin.Visibility = Visibility.Hidden;
                    }
                    //Obj.ContentSource
                    Globalized.AccountListOptimizated();

                }
                else
                {
                    throw new ApplicationException("Invalid Username/Password");
                }
            }
            catch (Exception ex)
            {
                lblErrorMsg.Visibility = System.Windows.Visibility.Visible;
                lblErrorMsg.Foreground = Brushes.Red;
                lblErrorMsg.Content = ex.Message;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


       
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button abc = sender as Button;
          //  Type type = Type.GetType(abc.CommandParameter.ToString(), true);

            //// create an instance of that type
            //object instance = Activator.CreateInstance(type);

            string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, abc.CommandParameter.ToString());
            Type type = Type.GetType(formTypeFullName, true);
            var instance =  Activator.CreateInstance(type);
         //   ActiveItem.Content = instance;
        }
    }
}
