using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataHolders;
using DAL;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace BL
{
    public class blUser
    {
        dalGeneral objDALGeneral;

        public blUser()
        {
            objDALGeneral = new dalGeneral();
        }

        public dhUsers Authentication(dhDBnames objDBNames, dhUsers objUser)
        {
            dsGeneral.dtAppUserDataTable dt = objDALGeneral.GetUser(objDBNames, objUser);
            if (dt.Rows.Count == 1)
            {
               
                ObservableCollection<dhUsers> sequence = ReflectionUtility.DataTableToObservableCollection<dhUsers>(dt);
                if (sequence.Count > 0)
                {
                    objUser = sequence[0];
                }
                objUser.LoginStatus = true;
                //objUser.IUserid = Convert.ToInt32(dt.Rows[0]["iUserID"].ToString());
                //objUser.VfName = dt.Rows[0]["vfName"].ToString();
                //objUser.VlName = dt.Rows[0]["vlName"].ToString();
                //objUser.DDOB = Convert.ToDateTime(dt.Rows[0]["dDOB"].ToString());
                //objUser.VUserType = dt.Rows[0]["vUserType"].ToString();
                //objUser.VLogin = dt.Rows[0]["vLogin"].ToString();
                //objUser.VPassword = dt.Rows[0]["vPassword"].ToString();           
            }
            else
            {
                objUser.LoginStatus = false;
            }
            return objUser;
        }

        public dsGeneral.dtAppUserDataTable GetallUser(dhDBnames objDBNames, dhUsers objUser)
        {
            dsGeneral.dtAppUserDataTable dt = objDALGeneral.GetUser(objDBNames, objUser);
            return dt;
        }

        public bool chkLoginName_available(dhDBnames objDBNames, dhUsers objUser)
        {
            bool result;
            dsGeneral.dtAppUserDataTable dt = objDALGeneral.GetUser(objDBNames, objUser);
            if (dt.Rows.Count == 0)
                result = true;
            else
                result = false;
            return result;
        }

        public DataSet AddEditUser(dhDBnames objDBNames, dhUsers objUser)
        {
            DataSet ds;
            ds = objDALGeneral.AddEditUser(objDBNames, objUser);
            return ds;
        }

        public bool ChangePassword(dhDBnames objDBNames, dhUsers objUser)
        {
            bool result;

            DataSet ds;
            ds = objDALGeneral.ChangePassword(objDBNames, objUser);
            result = false;

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["IUserid"].ToString()) != -1)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public DataTable GetTable(dhUsers CrntUser , string RequestType)
        {
            //
            // Here we create a DataTable with four columns.
            //
            DataTable table = new DataTable();
            table.Columns.Add("UserTypeKey", typeof(string));
            table.Columns.Add("UserType", typeof(string));


            //
            // Here we add DataRows.Super/admin/owner/user/)
            //
            table.Rows.Add("", "Select");
            if (CrntUser.VUserType == "Super")
            {
                table.Rows.Add("Super", "Super");
                table.Rows.Add("Owner", "Owner");
                table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }

            if( (CrntUser.VUserType == "Owner") && (RequestType == "New"))
            {
                table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }
            if ((CrntUser.VUserType == "Owner") && (RequestType == "Edit"))
            {
                table.Rows.Add("Owner", "Owner"); 
                table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }


            if( (CrntUser.VUserType == "Admin") && (RequestType == "New"))
            {
                //table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }

            if ((CrntUser.VUserType == "Admin") && (RequestType == "Edit"))
            {
                table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }

            if (CrntUser.VUserType == "User")
            {
                //table.Rows.Add("Super", "Super");
                //table.Rows.Add("Owner", "Owner");
                //table.Rows.Add("Admin", "Admin");
                table.Rows.Add("User", "User");
            }

            return table;
        }

        private T FindChildByType<T>(DependencyObject parent) where T : DependencyObject
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

        public ObservableCollection<dhModule> GetUserMenu(dhDBnames objDBNames, dhAppPreference objAppPreference, dhUsers objuser = null)
        {
            DataTable temp =  new DataTable();
            blModule ObjblModule = new blModule();
            dhModule objModule = new dhModule();
            ObservableCollection<dhModule> MenuModule = new ObservableCollection<dhModule>();
            if ((objAppPreference != null) && (objAppPreference.VEnableModules != "") && (objuser != null))
            {

                #region "Allowed Menu"
                objModule.AllowdModule = objAppPreference.VEnableModules;
                dsGeneral.dtPosModuleDataTable dtm = ObjblModule.GetModule(objDBNames, objModule);
                EnumerableRowCollection<dsGeneral.dtPosModuleRow> result2 = from r in dtm.AsEnumerable()
                                                                            where (r.Field<int>("iModuleParentID") == 0) && (r.Field<bool>("bIsActive") == true)
                                                                            select r;
                // if there are any allowed
                int CountRow = result2.Count<dsGeneral.dtPosModuleRow>();
                if (CountRow > 0)
                {
                    DataTable dtResult2 = result2.CopyToDataTable();
                    ObservableCollection<dhModule> sequence = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtResult2);
                    if (sequence.Count > 0)
                    {
                        foreach (dhModule Module in sequence)
                        {
                            string grpkey = "POS"; //Module.VModuleName;
                            string strDisplayName = Module.VDisplayName;
                            if (objuser.VAllowdModule == null)
                            {
                                if (objuser.VUserType == "Super")
                                {
                                    objuser.VAllowdModule = objAppPreference.VEnableModules;
                                }
                                else
                                {
                                    throw new ApplicationException("Disable User or have no rights.");
                                }
                            }

                            List<string> RootIds = objuser.VAllowdModule.Split(',').ToList<string>();
                            string RootAllowdUserID = RootIds.Distinct<string>().Cast<string>().Where(i => i.Equals(Module.IModuleID.ToString())).SingleOrDefault();

                            List<string> RootEnableModulesIds = objAppPreference.VEnableModules.Split(',').ToList<string>();
                            string RootAppEnableModulesId = RootEnableModulesIds.Distinct<string>().Cast<string>().Where(i => i.Equals(Module.IModuleID.ToString())).SingleOrDefault();
                            if ((RootAllowdUserID == null) || (RootAppEnableModulesId == null))
                            {continue;}
                            MenuModule.Add(Module);
                        }
                    }// end of dhModule sequence

                }



                #endregion

            }
            return MenuModule;
            
           
            
        }

        internal ObservableCollection<dhModule> GetUserSubMenu(dhDBnames objDBNames, dhAppPreference objAppPreference, dhUsers objuser, dhModule objdhModule)
        {
            DataTable temp = new DataTable();
            blModule ObjblModule = new blModule();
            dhModule objModule = new dhModule();
            ObservableCollection<dhModule> MenuModule = new ObservableCollection<dhModule>();
            if ((objAppPreference != null) && (objAppPreference.VEnableModules != "") && (objuser != null))
            {

                #region "Allowed Menu"

                objModule.AllowdModule = objAppPreference.VEnableModules;
                dsGeneral.dtPosModuleDataTable dtm = ObjblModule.GetModule(objDBNames, objModule);
                EnumerableRowCollection<dsGeneral.dtPosModuleRow> result2 = from r in dtm.AsEnumerable()
                                                                            where (r.Field<int>("iModuleParentID") == objdhModule.IModuleID) && (r.Field<bool>("bIsActive") == true)
                                                                            select r;
                // if there are any allowed
                int CountRow = result2.Count<dsGeneral.dtPosModuleRow>();
                if (CountRow > 0)
                {
                    DataTable dtResult2 = result2.CopyToDataTable();
                    ObservableCollection<dhModule> sequence = ReflectionUtility.DataTableToObservableCollection<dhModule>(dtResult2);
                    if (sequence.Count > 0)
                    {
                        foreach (dhModule Module in sequence)
                        {
                                                       string strDisplayName = Module.VDisplayName;
                            if (objuser.VAllowdModule == null)
                            {
                                if (objuser.VUserType == "Super")
                                {
                                    objuser.VAllowdModule = objAppPreference.VEnableModules;
                                }
                                else
                                {
                                    throw new ApplicationException("Disable User or have no rights.");
                                }
                            }

                            List<string> RootIds = objuser.VAllowdModule.Split(',').ToList<string>();
                            string RootAllowdUserID = RootIds.Distinct<string>().Cast<string>().Where(i => i.Equals(Module.IModuleID.ToString())).SingleOrDefault();

                            List<string> RootEnableModulesIds = objAppPreference.VEnableModules.Split(',').ToList<string>();
                            string RootAppEnableModulesId = RootEnableModulesIds.Distinct<string>().Cast<string>().Where(i => i.Equals(Module.IModuleID.ToString())).SingleOrDefault();
                            if ((RootAllowdUserID == null) || (RootAppEnableModulesId == null))
                            { continue; }
                            MenuModule.Add(Module);
                        }
                    }// end of dhModule sequence

                }



                #endregion

            }
            return MenuModule;
        }
    }
    }
   