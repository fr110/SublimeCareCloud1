using DataHolders;
using FluentValidation.Results;
using SublimeCareCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for AddItemView.xaml
    /// </summary>
    public partial class AddItemView : UserControl
    {


        public static dhItems GlobalDhItem = new dhItems();

        public AddItemView()
        {
            InitializeComponent();
            Globalized.ShowMsg(lblErrorMsg);
        }

        public AddItemView(dhItems Obj)
        {
            Globalized.ShowMsg(lblErrorMsg);
            //  GlobalDhItem.VItemName = "asdasd";
            //GlobalDhItem = Obj;
            //InitializeComponent();
            //this.DataContext = GlobalDhItem;
            //btnCancel.Visibility = Visibility.Hidden;
            //if (Obj.IUpdate == 1)
            //{
            //    //lblHeading.Text = "Edit Item";
            //    ShowStock.Visibility = Visibility.Visible;

            //    // lblInStock.Visibility = Visibility.Hidden;
            //    //  vItemBarcodeTextBox_Copy1.Visibility = Visibility.Hidden;
            //}
            //if (Globalized.ObjCurrentUser.BCanMakeEditAble != false)
            //{
            //    this.bIsEditable.Visibility = Visibility.Visible;
            //}
        }


        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            Globalized.ShowMsg(lblErrorMsg);
            //if ((GlobalDhItem == null) && (GlobalDhItem.IUpdate != 1))
            //{
            //    GlobalDhItem = new dhItems();
            //    if (Globalized.ObjCurrentUser.BCanMakeEditAble != false)
            //    {
            //        this.bIsEditable.Visibility = Visibility.Visible;
            //    }
            //}

        }

        private void SaveButton_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                InsertRecord();
            }
            catch (Exception ex)
            {
                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }

        }
        private void InsertRecord()
        {
                    dhItems objInsert = new dhItems();
                    objInsert = (dhItems)this.ItemGrid_.DataContext;
                    DataSet ds = iFacedeLayer.iFacede.InsertUpdateItem(Globalized.ObjDbName, objInsert);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["iItemID"].ToString() != "-1")
                        {
                                if (objInsert.IUpdate == 1)
                                {
                                     Globalized.SetMsg("I02", CustomClasses.MsgType.Info);
                                }
                                else
                                {
                                     Globalized.SetMsg("I01", CustomClasses.MsgType.Info);
                                     objInsert.IUpdate = 1;
                               }
                               AddItemViewModel ObjSetToEdit = new AddItemViewModel(objInsert);
                               Globalized.LoadThisObject(ObjSetToEdit, "Edit Item '" + objInsert.VItemName + "'", Globalized.AppModuleList.Where(xx => xx.VModuleName == "Store").FirstOrDefault().VShortDescription);
                    }
                    else{
      
                             Globalized.SetMsg("I013", CustomClasses.MsgType.Error);
                             Globalized.ShowMsg(lblErrorMsg);
                    }
                }

          
            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Reset();
            }
            catch (Exception ex)
            {

                Globalized.setException(ex, lblErrorMsg, CustomClasses.MsgType.Error);
            }
        }

        public void Reset()
        {
            this.DataContext = new dhItems();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //////Pages.Stock.ItemStock
            ////dhItemStock obj = new dhItemStock();
            ////obj.IItemID = GlobalDhItem.IItemID;
            ////obj.VItemName = GlobalDhItem.VItemName;
            ////obj.VDetailName = GlobalDhItem.VDetailName;

            ////ItemStock objPre = new ItemStock(obj);

            //////objPre.docview1.Document = xps.GetFixedDocumentSequence();
            ////Window window = new Window
            ////{
            ////    Title = "Stock Detail [ " + obj.VItemName + " ]  ",
            ////    Content = objPre,
            ////    Height = 560,  // just added to have a smaller control (Window)
            ////    Width = 720,
            ////    ResizeMode = ResizeMode.NoResize

            ////};

            ////window.ShowDialog();
        }

    }
}
