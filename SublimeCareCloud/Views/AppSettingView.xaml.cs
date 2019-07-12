using DataHolders;
using FluentValidation.Results;
using iFacedeLayer;
using SublimeCareCloud.CustomClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;

//using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AppSettingView.xaml
    /// </summary>
    public partial class AppSettingView : UserControl
    {
        public AppSettingView()
        {
            InitializeComponent();
        }

        

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            BuildAllowdModuleCheckBox();
            loadData();
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void GetAllowdModule()
        {
            List<dhModule> ObjLIst = new List<dhModule>();
            List<CheckBox> obj = new List<CheckBox>();
            getChildListofType<CheckBox>(RightsGrid, obj);

            string Ids = null;

            foreach (CheckBox cb in obj)
            {
                dhModule objModule = (dhModule)cb.Tag;
                ObjLIst.Add(objModule);
                if (objModule.BIsActive == true)
                {
                    if (Ids == null)
                    {
                        Ids = objModule.IModuleID.ToString();
                    }
                    else
                    {
                        Ids = Ids + "," + objModule.IModuleID.ToString();
                    }
                }
                objModule.UriKind = "Relative";
                objModule.IUpdate = 1;
                DataSet ds = iFacede.InsertUpdateModule(Globalized.ObjDbName, objModule);
            }
            vEnableModulesTextBox.Text = "";
            this.GlobalObjPreference.VEnableModules = null;
            this.GlobalObjPreference.VEnableModules = Ids;

            //    VAllowdModule.Text = Ids;
        }

        private void BuildAllowdModuleCheckBox()
        {
            StackPanel OuterStock = new StackPanel();
            //OuterStock. = new Thickness(0, 5, 15, -25);
            dhModule objModule = new dhModule();
            //          if (objUser != null)
            //       {

            #region "Allowed Menu"

            // objModule.AllowdModule = Globalized.objAppPreference.VEnableModules;
            dsGeneral.dtPosModuleDataTable dtm = iFacede.GetModule(Globalized.ObjDbName, objModule);
            EnumerableRowCollection<dsGeneral.dtPosModuleRow> result2 = from r in dtm.AsEnumerable()
                                                                        where (r.Field<int>("iModuleParentID") == 0)
                                                                        select r;
            int CountRow = result2.Count<dsGeneral.dtPosModuleRow>();
            if (CountRow > 0)
            {
                DataTable dtResult2 = result2.CopyToDataTable();
                ObservableCollection<dhModule> sequence = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtResult2);
                if (sequence.Count > 0)
                {
                    foreach (dhModule Module in sequence)
                    {
                        GroupBox objGroup = new GroupBox();
                        objGroup.Header = Module.VDisplayName;
                        objGroup.Margin = new Thickness(0, 0, 0, 15);

                        #region "Grid"

                        Grid grid = new Grid();
                        //  grid.Width = 400;
                        // Create column definitions.
                        ColumnDefinition columnDefinition1 = new ColumnDefinition();
                        ColumnDefinition columnDefinition2 = new ColumnDefinition();
                        columnDefinition1.Width = new GridLength(200);
                        columnDefinition2.Width = new GridLength(200);
                        // Attached definitions to grid.
                        grid.ColumnDefinitions.Add(columnDefinition1);
                        grid.ColumnDefinitions.Add(columnDefinition2);

                        CheckBox cb = new CheckBox();
                        cb.Name = Module.VModuleName.ToString() + Module.IModuleID.ToString();
                        cb.Content = Module.VDisplayName.ToString();
                        //   cb.Width = 100;
                        cb.Margin = new Thickness(5, 5, 5, 5);
                        cb.DataContext = Module;
                        Binding myBinding = new Binding("BIsActive");
                        myBinding.Source = Module;
                        cb.SetBinding(CheckBox.IsCheckedProperty, myBinding);
                        cb.Tag = Module;

                        cb.AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(DynamicCheckBox_Checked));
                        cb.AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(DynamicCheckBox_Unchecked));

                        RowDefinition rowDefinition1 = new RowDefinition();
                        rowDefinition1.Height = new GridLength(30);
                        grid.RowDefinitions.Add(rowDefinition1);

                        grid.Children.Add(cb);
                        Grid.SetColumn(cb, 0);
                        Grid.SetRow(cb, 0);

                        #endregion "Grid"

                        EnumerableRowCollection<dsGeneral.dtPosModuleRow> Filter = from r2 in dtm.AsEnumerable()
                                                                                   where (r2.Field<int>("iModuleParentID") == Module.IModuleID)
                                                                                   select r2;
                        int CountRowInner = result2.Count<dsGeneral.dtPosModuleRow>();
                        if (CountRowInner > 0)
                        {

                            DataTable dtFilter;
                            if (Filter.Count() > 0)
                            {
                                dtFilter = Filter.CopyToDataTable();
                            }else
                            {
                                dtFilter = new DataTable();
                            }


                            ObservableCollection<dhModule> sequencefilter = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtFilter);
                            if (sequencefilter.Count > 0)
                            {
                                // int Bool = 1;

                                int row = 1;
                                int col = 0;
                                RowDefinition rowDefinition = new RowDefinition();
                                rowDefinition.Height = new GridLength(30);
                                grid.RowDefinitions.Add(rowDefinition);

                                #region "Child Module"

                                foreach (dhModule SubModule in sequencefilter)
                                {
                                    //for (int i = 0; i < sequencefilter.Count ; i++)
                                    //{
                                    CheckBox NestedCb = new CheckBox();
                                    //NestedStp.Orientation = Orientation.Horizontal;
                                    NestedCb.Name = "Sub" + SubModule.VModuleName.ToString() + SubModule.IModuleID.ToString();
                                    NestedCb.Content = SubModule.VDisplayName.ToString();
                                    NestedCb.Margin = new Thickness(35, 5, 5, 5);
                                    if (col == 2)
                                    {
                                        row = row + 1;
                                        col = 0;
                                        RowDefinition rowDefinition3 = new RowDefinition();
                                        rowDefinition3.Height = new GridLength(30);
                                        grid.RowDefinitions.Add(rowDefinition3);
                                    }

                                    NestedCb.DataContext = Module;
                                    Binding mySubBinding = new Binding("BIsActive");
                                    mySubBinding.Source = SubModule;
                                    NestedCb.SetBinding(CheckBox.IsCheckedProperty, mySubBinding);
                                    NestedCb.Tag = SubModule;

                                    grid.Children.Add(NestedCb);
                                    Grid.SetColumn(NestedCb, col);
                                    Grid.SetRow(NestedCb, row);
                                    col += 1;
                                }

                                #endregion "Child Module"

                                objGroup.Content = grid;
                            }
                            OuterStock.Children.Add(objGroup);
                        }
                    }
                    RightsGrid.Children.Add(OuterStock);
                }
            }

            #endregion "Allowed Menu"

            //            }
        }

        public T FindVisualParent<T>(DependencyObject sender) where T : DependencyObject
        {
            if (sender == null)
            {
                return (null);
            }
            else if (VisualTreeHelper.GetParent(sender) is T)
            {
                return (VisualTreeHelper.GetParent(sender) as T);
            }
            else
            {
                DependencyObject parent = VisualTreeHelper.GetParent(sender);
                return (FindVisualParent<T>(parent));
            }
        }

        private void DynamicCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)sender);
            List<CheckBox> obj = new List<CheckBox>();
            getChildListofType<CheckBox>(parent, obj);
            foreach (CheckBox cb in obj)
            {
                cb.IsChecked = true;
            }
        }

        private void DynamicCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)sender);
            List<CheckBox> obj = new List<CheckBox>();
            getChildListofType<CheckBox>(parent, obj);
            foreach (CheckBox cb in obj)
            {
                cb.IsChecked = false;
            }
        }

        private T getChildListofType<T>(DependencyObject parent, List<T> cntlList) where T : DependencyObject
        {
            int counter = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < counter; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                {
                    cntlList.Add(child as T);
                }
                DependencyObject grandchild = getChildListofType<T>(child, cntlList);
                if (grandchild != null)
                    cntlList.Add(grandchild as T);
            }
            return null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                InsertUpdatePreference();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
            }
        }

        private dhAppPreference GlobalObjPreference = new dhAppPreference();

        private void loadData()
        {
            // get data
            dsGeneral.dtAppPreferenceDataTable dt = iFacede.GetAppPreference(Globalized.ObjDbName, GlobalObjPreference);
            // intialize object
            if (dt.Rows.Count > 0)
            {
                ObservableCollection<dhAppPreference> listItem = ReflectionUtility.DataTableToObservableCollection<dhAppPreference>(dt);
                if (listItem.Count > 0)
                {
                    GlobalObjPreference = listItem.Cast<dhAppPreference>().SingleOrDefault();
                    GlobalObjPreference.IUpdate = 1;
                    // GlobalObjPreference.ImgCompanyLogo =(byte[])dt.Rows[0]["imgCompanyLogo"];
                    GlobalObjPreference.ImgCompanyLogo = !string.IsNullOrEmpty(dt.Rows[0]["imgCompanyLogo"].ToString()) ? (byte[])dt.Rows[0]["imgCompanyLogo"] : null;
                    GlobalObjPreference.VCompanyName = !string.IsNullOrEmpty(dt.Rows[0]["vCompanyName"].ToString()) ? dt.Rows[0]["VCompanyName"].ToString() : null;
                    GlobalObjPreference.VHeaderAdress = !string.IsNullOrEmpty(dt.Rows[0]["vHeaderAdress"].ToString()) ? dt.Rows[0]["vHeaderAdress"].ToString() : null;
                    GlobalObjPreference.VCompanyMobile = !string.IsNullOrEmpty(dt.Rows[0]["vCompanyMobile"].ToString()) ? dt.Rows[0]["vCompanyMobile"].ToString() : null;
                    //    VSaleType.SelectedItem = GlobalObjPreference.VSaleType;

                    this.DataContext = GlobalObjPreference;
                    cstmUtilities.LoadImage(GlobalObjPreference.ImgCompanyLogo, image1);
                    //VSaleType.SelectedValue = GlobalObjPreference.VSaleType;
                    //Globalized.ObjPrefernce = GlobalObjPreference;
                }
            }
            else
            {
                GlobalObjPreference.IUpdate = 0;
                GlobalObjPreference = new dhAppPreference();
                this.DataContext = GlobalObjPreference;
            }
            Globalized.ShowMsg(lblErrorMsg);

            //Globalized.SetMsg(null);
        }

        private static BitmapFrame CreateResizedImage(ImageSource source, int width, int height, int margin)
        {
            var rect = new Rect(margin, margin, width - margin * 2, height - margin * 2);

            var group = new DrawingGroup();
            RenderOptions.SetBitmapScalingMode(group, BitmapScalingMode.HighQuality);
            group.Children.Add(new ImageDrawing(source, rect));

            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
                drawingContext.DrawDrawing(group);

            var resizedImage = new RenderTargetBitmap(
                width, height,         // Resized dimensions
                96, 96,                // Default DPI values
                PixelFormats.Default); // Default pixel format
            resizedImage.Render(drawingVisual);

            return BitmapFrame.Create(resizedImage);
        }

        private void InsertUpdatePreference()
        {
            //FileStream fs = new FileStream(txtFileName.Text.ToString(), FileMode.Open, FileAccess.Read);
            ////Initialize a byte array with size of stream
            //byte[] imgByteArr = new byte[fs.Length];
            ////Read data from the file stream and put into the byte array
            //fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));
            //fs.Close();

            GetAllowdModule();
            dhAppPreference objInsert = new dhAppPreference();

            objInsert = (dhAppPreference)this.DataContext;
            if (image1.Source != null)
            {
                byte[] imgByteArr = null;
                if ((image1.Source.Width > 250) || (image1.Source.Height > 100)) //(!ValidFile(image1.Source, 250, 100))
                {
                    BitmapFrame bframe = CreateResizedImage(image1.Source, 250, 150, 0);
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    // encoder.Frames.Add(abc);
                    encoder.QualityLevel = 100;
                    imgByteArr = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        encoder.Frames.Add(bframe);
                        encoder.Save(stream);
                        imgByteArr = stream.ToArray();
                        stream.Close();
                    }
                }
                else
                {
                    BitmapFrame bframe = CreateResizedImage(image1.Source, Convert.ToInt32(image1.Source.Width), Convert.ToInt32(image1.Source.Height), 0);
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    // encoder.Frames.Add(abc);
                    encoder.QualityLevel = 100;
                    imgByteArr = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        encoder.Frames.Add(bframe);
                        encoder.Save(stream);
                        imgByteArr = stream.ToArray();
                        stream.Close();
                    }
                }

                objInsert.ImgCompanyLogo = imgByteArr;
            }
            else
            {
                objInsert.ImgCompanyLogo = null;
            }

            dhAppPreferenceValidator validator = new dhAppPreferenceValidator();
            FluentValidation.Results.ValidationResult results = validator.Validate(objInsert);

            bool validationSucceeded = results.IsValid;
            IList<ValidationFailure> failures = results.Errors;

            if (validationSucceeded)
            {
                DataSet ds = iFacede.InsertUpdateAppPreference(Globalized.ObjDbName, objInsert);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    System.Media.SystemSounds.Beep.Play();
                    lblErrorMsg.Visibility = Visibility.Hidden;
                    Globalized.SetMsg("Setting Saved successfully.", MsgType.Info);
                    loadData();
                    //    ModernWindow Obj = (ModernWindow)Application.Current.MainWindow;

                    //    Obj.ContentSource = new Uri("/Pages/Setting/Setting.xaml", UriKind.Relative);
                }
            }
            else
            {
                throw new ApplicationException(failures.First().ErrorMessage);
            }
        }

        private bool ValidFile(string filename, long limitInBytes, int limitWidth, int limitHeight)
        {
            var fileSizeInBytes = new FileInfo(filename).Length;
            if (fileSizeInBytes > limitInBytes) return false;

            using (var img = new Bitmap(filename))
            {
                if (img.Width > limitWidth || img.Height > limitHeight) return false;
            }

            return true;
        }

        private bool ValidFile(ImageSource filename, int limitWidth, int limitHeight)
        {
            BitmapImage myBitmapImage = filename as BitmapImage;

            if (myBitmapImage.Width > limitWidth || myBitmapImage.Height > limitHeight) return false;

            return true;
        }

        private void btnBrows_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp)|*.jpg;*.bmp";
                if ((fldlg.ShowDialog() == true) && (fldlg.FileName != ""))
                {
                    FileInfo fileInfo = new FileInfo(fldlg.FileName);
                    if (ValidFile(fldlg.FileName, 102400, 250, 100))
                    {
                        // Image is valid and U can
                        // Do something with image
                        // For example set it to a picture box
                        txtFileName.Text = fldlg.FileName;
                        ImageSourceConverter isc = new ImageSourceConverter();
                        image1.Source = (ImageSource)isc.ConvertFromString(txtFileName.Text.ToString());
                        // image1.SetValue(Image.SourceProperty, isc.ConvertFromString(txtFileName.Text.ToString()));
                        // pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    }
                    else
                    {
                        throw new ApplicationException("Image Size must be 250 width and 100 height and less than 1 MB in size.");
                        //   MessageBox.Show("Image is invalid");
                    }
                }
                else
                {
                    txtFileName.Text = "";
                    //image1.Source = null;
                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, MsgType.Error);
                // MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}