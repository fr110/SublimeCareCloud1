using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHolders;
using System.Windows.Input;
using SublimeCareCloud.CustomClasses;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Data;
using iFacedeLayer;
using MahApps.Metro.Controls;
using System.Windows;
using SublimeCareCloud.ViewModels;
using System.Reflection;
using System.ComponentModel;
using FeserWard.Controls;
using System.Windows.Media;
using MahApps.Metro.IconPacks;
using DAL;

namespace SublimeCareCloud
{
    public static class WSetting
    {
        public static double GridHeightAccount
        {
            get
            {
                return Convert.ToDouble(System.Windows.SystemParameters.PrimaryScreenHeight - 500);
            }

        }

        public static double ScrollViewerHeight
        {
            get
            {
                return Convert.ToDouble(GridHeight - 120);
            }

        }
        public static double GridHeight
        {
            get
            {
                return Convert.ToDouble(System.Windows.SystemParameters.PrimaryScreenHeight - 300);
            }

        }
        public static double InnerHeight
        {
            get
            {
                return Convert.ToDouble(System.Windows.SystemParameters.PrimaryScreenHeight - 300);
            }

        }
        public static double OrignalHeight
        {
            get
            {
                return Convert.ToDouble(System.Windows.SystemParameters.PrimaryScreenHeight - 30);
            }

        }
        public static double OrignalWidth
        {
            get
            {
                return Convert.ToDouble(System.Windows.SystemParameters.PrimaryScreenWidth);
            }

        }

        public static uint RowsNumberPerPage
        {
            get
            {
                uint rvalue = 50;
                //string str = Math.Round((GridHeight / 25)).ToString();
                // uint.TryParse(str,out rvalue);
                return rvalue;
            }

        }


    }
    public static class Something<T>
    {
       // public static Something CreatNew(Class<T> type) { };
       
    }
    public static class MsgTextCollection
    {
        public static Dictionary<string, string> MsgsList = new Dictionary<string, string>
        {
            //party
            { "P01", "Party Information is Saved Successfully!" },
            { "P02", "Party Information is Updated Successfully!" },
            { "I03", "Item with the same name or with same item barcode already exists. Please change and try agian." },
            { "I02", "Item Information is Updated Successfully!" },
            { "I01", "Item Information is Saved Successfully!" },
            { "DP01", "Parties List" },
            // Docotr 
            { "DOC01", "Docotor Information is Saved Successfully!" },
            { "DOC02", "Docotor Information is Updated Successfully!" },
            { "DOC03", "Investigation is deleted and Doctor information Updated Successfully!" },

            // for account user of doctor

            {"M_D01DEC","Account Created By System for Doctor." },
            {"M_D02DEC","Account Created By System for Doctor." }

        };
    }

    public static class Globalized
    {
        public static MetroWindow Objw = (MetroWindow)Application.Current.MainWindow;
        public static dhUsers ObjCurrentUser;
        public static dhDBnames ObjDbName;
        public static object ObjectToFocus = null;
        public static Boolean LastPageLeaved = false;
        public static dhPreference ObjPrefernce;
        public static dhAppPreference objAppPreference = null;
        public static DateTime StartDateTrial = Convert.ToDateTime("6/27/2014");
        public static DateTime EndDateTrial = Convert.ToDateTime("11/15/2014");
        public static List<int> LiftNumbers = new List<int>();
        public static ObservableCollection<dhAccount> listAccount;
        private static dhAccount objAccount = new dhAccount();

        // close button for tab in c#
        public static PackIconMaterial GetCloseButtonIcon()
        {
            PackIconMaterial packIconMaterial = new PackIconMaterial()
                 {
                    Kind = PackIconMaterialKind.Close,
                    Margin = new Thickness(2, 2, 2, 2),
                    Width = 14,
                    Height = 14,
                    Foreground = new SolidColorBrush(Colors.Black),
                    Background = new SolidColorBrush(Colors.White)
                };

            return packIconMaterial;
    }

        //  public static Boolean BLoadDoc = false;
        // changes after mahaaaps 
        public static ObservableCollection<dhModule> AppModuleList;

        //public static String lastMsg = null;
        public static void AccountListOptimizated()
        {
            if (listAccount == null) { listAccount = new ObservableCollection<dhAccount>(); }
           // objAccount.BCloseAccount = true;//(bool)IncClosedAccount;
            //objAccount.VFilterOperator = "==";
            //objAccount.Balance = 0.0;
          //  objAccount.BIncludeNull = true;
            dsGeneral.dtPosAccountsDataTable dt = iFacede.GetAccount(Globalized.ObjDbName, objAccount);
            listAccount.Clear();
            listAccount = ReflectionUtility.DataTableToObservableCollection<dhAccount>(dt);
        }
        #region "msg Region"
        public static AppMassage GlobalMsg;

        public static void SetMsg(string stringmsg, MsgType type)
        {
            GlobalMsg = new AppMassage();
            GlobalMsg.MsgTypeProperty = type;
            GlobalMsg.Msg = MsgTextCollection.MsgsList.Where(xx=> xx.Key == stringmsg).FirstOrDefault().Value;
            if (GlobalMsg.Msg == null && stringmsg.Length > 6)
            {
                GlobalMsg.Msg = stringmsg;
                
            }
        }

        public static void SetMsg(string stringmsg)
        {
            //if (GlobalMsg == null) { GlobalMsg = new AppMassage(); GlobalMsg.MsgTypeProperty = type; }
            //GlobalMsg.Msg = stringmsg;
            GlobalMsg = null;
        }

        public static void ShowMsg(Label lblErrorMsg)
        {
            if (GlobalMsg != null)
            {
                GlobalMsg.ShowMsg(lblErrorMsg);
                GlobalMsg = null;
            }
        }
        public static void setException(Exception ex, Label lblErrorMsg, MsgType Type , object ObjectToFocus = null)
        {
            if (GlobalMsg == null) { GlobalMsg = new AppMassage(); GlobalMsg.MsgTypeProperty =  Type; }
             GlobalMsg.Msg = ex.Message.ToString();
              GlobalMsg.ShowMsg(lblErrorMsg);
                GlobalMsg = null;
        }
        public static void setException(String msg, Label lblErrorMsg, MsgType Type, object ObjectToFocus = null)
        {
            if (GlobalMsg == null) { GlobalMsg = new AppMassage(); GlobalMsg.MsgTypeProperty = Type; }
            GlobalMsg.Msg = msg;
            GlobalMsg.ShowMsg(lblErrorMsg);
            GlobalMsg = null;
        }

        #endregion 
        public static void ClearMsg(Label lblErrorMsg)
        {
            lblErrorMsg.Content = "";
            if (GlobalMsg != null)
            {
                GlobalMsg = null;
            }
        }

        internal static ObservableCollection<dhModule> LoadSubMenus(dhModule objdhModule)
        {
            ObservableCollection<dhModule> dtMenu = iFacede.GetUserSubMenu(Globalized.ObjDbName, Globalized.objAppPreference, Globalized.ObjCurrentUser , objdhModule);
            //  throw new NotImplementedException();

            return dtMenu;
        }

        public static List<Key> NumaricKey = new List<Key> { Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.Enter, Key.Tab, Key.LeftShift, Key.RightShift, Key.LeftCtrl, Key.RightCtrl, Key.RightAlt, Key.LeftAlt, Key.Left, Key.Right, Key.Up, Key.Down, Key.Decimal, Key.Back, Key.Delete, Key.Home, Key.End, Key.NumPad0, Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.NumPad4, Key.NumPad5, Key.NumPad6, Key.NumPad7, Key.NumPad8, Key.NumPad9, Key.Subtract };

        public static T FindChildByType<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T)
                    return child as T;
                DependencyObject grandchild = FindChildByType<T>(child);
                if (grandchild != null)
                    return grandchild as T;
            }
            return default(T);
        }


        public static List<Button> SubMenu { get; internal set; }

        //= null ;
        static Globalized()
        {
            ObjCurrentUser = null;
            ObjDbName = null;
            GlobalMsg = new AppMassage();
            ObjPrefernce = new dhPreference();
        }

        public static void LoadThisObject<T>(T objt, string NameModule = "", string Discription = "", int? iModuelID = null) where T : new()
        {
            MainViewModel pObject = (MainViewModel)Objw.DataContext;
            pObject.DisplayName = NameModule;
            pObject.SelectToEdit(objt);
            TextBlock VShortDescription = (TextBlock)Objw.FindName("ShortDescription");
            VShortDescription.Text = Discription;
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> list,string dtName = "")
        {
            var entityType = typeof(T);
            string DataTableName;
            if (dtName != "")
            {
                DataTableName = dtName;
            }
            else
            {
                DataTableName = entityType.Name;
            }
            // Lists of type System.String and System.Enum (which includes enumerations and structs) must be handled differently 
            // than primitives and custom objects (e.g. an object that is not type System.Object).
            if (entityType == typeof(String))
            {
                var dataTable = new DataTable(DataTableName);
                dataTable.Columns.Add(DataTableName);

                // Iterate through each item in the list. There is only one cell, so use index 0 to set the value.
                foreach (T item in list)
                {
                    var row = dataTable.NewRow();
                    row[0] = item;
                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
            else if (entityType.BaseType == typeof(Enum))
            {
                
                var dataTable = new DataTable(DataTableName);
                dataTable.Columns.Add(DataTableName);

                // Iterate through each item in the list. There is only one cell, so use index 0 to set the value.
                foreach (string namedConstant in Enum.GetNames(entityType))
                {
                    var row = dataTable.NewRow();
                    row[0] = namedConstant;
                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }

            // Check if the type of the list is a primitive type or not. Note that if the type of the list is a custom 
            // object (e.g. an object that is not type System.Object), the underlying type will be null.
            var underlyingType = Nullable.GetUnderlyingType(entityType);
            var primitiveTypes = new List<Type>
    {
        typeof (Byte),
        typeof (Char),
        typeof (Decimal),
        typeof (Double),
        typeof (Int16),
        typeof (Int32),
        typeof (Int64),
        typeof (SByte),
        typeof (Single),
        typeof (UInt16),
        typeof (UInt32),
        typeof (UInt64),
    };

            var typeIsPrimitive = primitiveTypes.Contains(underlyingType);

            // If the type of the list is a primitive, perform a simple conversion.
            // Otherwise, map the object's properties to columns and fill the cells with the properties' values.
            if (typeIsPrimitive)
            {
                var dataTable = new DataTable(DataTableName);
                dataTable.Columns.Add(DataTableName);

                // Iterate through each item in the list. There is only one cell, so use index 0 to set the value.
                foreach (T item in list)
                {
                    var row = dataTable.NewRow();
                    row[0] = item;
                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
            else
            {
                // TODO:
                // 1. Convert lists of type System.Object to a data table.
                // 2. Handle objects with nested objects (make the column name the name of the object and print "system.object" as the value).

                var dataTable = new DataTable(DataTableName);
                var propertyDescriptorCollection = TypeDescriptor.GetProperties(entityType);

                // Iterate through each property in the object and add that property name as a new column in the data table.
                foreach (PropertyDescriptor propertyDescriptor in propertyDescriptorCollection)
                {
                    // Data tables cannot have nullable columns. The cells can have null values, but the actual columns themselves cannot be nullable.
                    // Therefore, if the current property type is nullable, use the underlying type (e.g. if the type is a nullable int, use int).
                    var propertyType = Nullable.GetUnderlyingType(propertyDescriptor.PropertyType) ?? propertyDescriptor.PropertyType;
                    dataTable.Columns.Add(propertyDescriptor.Name, propertyType);
                }

                // Iterate through each object in the list adn add a new row in the data table.
                // Then iterate through each property in the object and add the property's value to the current cell.
                // Once all properties in the current object have been used, add the row to the data table.
                foreach (T item in list)
                {
                    var row = dataTable.NewRow();

                    foreach (PropertyDescriptor propertyDescriptor in propertyDescriptorCollection)
                    {
                        var value = propertyDescriptor.GetValue(item);
                        row[propertyDescriptor.Name] = value ?? DBNull.Value;
                    }

                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
        }

        public static  dhAccount GetAccountByMdule(AppDbContext db, int IModuleFK_ID, int IModuleID)
        {
            dhAccount objReturn = new dhAccount();
            objReturn = db.Accounts.AsNoTracking().Where(x => x.IModuleFK_ID == IModuleFK_ID && x.IModuleID == IModuleID).FirstOrDefault();
            return objReturn;
        }

        public static dhModule ActiveModule(AppDbContext db, string ModuleName, int? IModuleParentID = 0)
        {
            if (ModuleName == "")
            {
                return new dhModule();
            }
            if (IModuleParentID > 0)
            {
                return db.Modules.Where(x => x.VModuleName == ModuleName && x.IModuleParentID == IModuleParentID).FirstOrDefault();
            }
            else
            {
                return db.Modules.Where(x => x.VModuleName == ModuleName && x.IModuleParentID == 0).FirstOrDefault();
            }
        }
    }

    public static class Extenders
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection, string tableName)
        {
            DataTable tbl = ToDataTable(collection);
            tbl.TableName = tableName;
            return tbl;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            DataTable dt = new DataTable();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            object temp;
            DataRow dr;

            for (int i = 0; i < pia.Length; i++)
            {
                dt.Columns.Add(pia[i].Name, Nullable.GetUnderlyingType(pia[i].PropertyType) ?? pia[i].PropertyType);
                dt.Columns[i].AllowDBNull = true;
            }

            //Populate the table
            foreach (T item in collection)
            {
                dr = dt.NewRow();
                dr.BeginEdit();

                for (int i = 0; i < pia.Length; i++)
                {
                    temp = pia[i].GetValue(item, null);
                    if (temp == null || (temp.GetType().Name == "Char" && ((char)temp).Equals('\0')))
                    {
                        dr[pia[i].Name] = (object)DBNull.Value;
                    }
                    else
                    {
                        dr[pia[i].Name] = temp;
                    }
                }

                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
