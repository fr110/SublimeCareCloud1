using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using DataHolders;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SublimeCareCloud.CustomClasses;
using MahApps.Metro.Controls;
using System.Windows;

namespace SublimeCareCloud.ViewModels
{
    [PartCreationPolicy(CreationPolicy.Shared), Export(typeof(MainViewModel))]
    class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        ObservableCollection<dhModule> SubItems = new ObservableCollection<dhModule>();
        List<Button> ListButt = new List<Button>();
        SublimeMenu objSublimeM = new SublimeMenu();
        public string Description;

        //public void ShowFirst() { ActiveItem = new FirstViewModel(); }
        //public void ShowWelcome() { ActiveItem = new WelcomeViewModel(); }
        //public void ShowParty(dhModule obj) {

        //     SubItems =   Globalized.LoadSubMenus(obj);

        //    ListButt = objSublimeM.CreateSubMenuItems(SubItems);
        //        ActiveItem = new PartyViewModel();
        //}
        //public MainViewModel(IEnumerable<IScreen> viewmodels)
        //{
        //    //omitted for brevity. 
        //}

        public void Select(dhModule datacontext)
       {
            if (datacontext != null)
            {
                string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, datacontext.VLoadScreen.ToString());
                Type type = Type.GetType(formTypeFullName, true);
                var instance = Activator.CreateInstance(type);

                // this.ConductWith
                if (instance != null)
                {
                    IScreen objScreenNew = (IScreen)instance;
                    IScreen ObjTOActive = null;
                    ObjTOActive = ScreenItems.Find(xx => xx.DisplayName == objScreenNew.DisplayName);

                    if(ObjTOActive != null)
                    {
                        ActiveItem = ObjTOActive;
                    }else
                    {
                        ActiveItem = objScreenNew;
                        ScreenItems.Add(objScreenNew);
                    }

                   // ActivateItem(OnjScreen);
                   
                    //if ( a )
                    //{
                    //    //Items.Add(OnjScreen);


                    //}else
                    //{

                    //    ActivateItem(OnjScreen);
                    //}

                    // ActiveItem = (IScreen)instance;
                } // need to handle error 

                // load submodules
                MetroWindow Objw = (MetroWindow)Application.Current.MainWindow;
                objSublimeM.CreateSubMenuItems(datacontext);
                if (objSublimeM.SubMenu.Count > 0)
                {

                    ListBox templistbox = (ListBox)Objw.FindName("TopSubMenu");
                    if (templistbox != null)
                    {
                        templistbox.ItemsSource = null;
                        templistbox.ItemsSource = objSublimeM.SubMenu;
                    }
                }

                if ((datacontext.VShortDescription != "") && (datacontext.VShortDescription != null))
                {
                    
                    //this.Description = datacontext.VShortDescription
                    TextBlock VShortDescription = (TextBlock)Objw.FindName("ShortDescription");
                    VShortDescription.Text = datacontext.VShortDescription;
                }
                this.DisplayName = datacontext.VDisplayName;

            }
            else
            {
                ActiveItem = new LogoutViewModel();

            }

        }
        List<IScreen> ScreenItems = new List<IScreen>();
        public void SelectToEdit<T>(T objt) where T : new()
        {

            IScreen OnjScreen = (IScreen)objt;
            if (!Items.Contains(OnjScreen))
            {
                Items.Add(OnjScreen);
            }
            ActivateItem(OnjScreen);
            //ActiveItem = (IScreen)objt;
            //  return new T();
        }


        //public void ActiveChildIsNullAfterSetAsNull()
        //{
        //    var conductor = new Conductor<IScreen>.Collection.OneActive();
        //    var conducted = new Screen();
        //    conductor.Items.Add(conducted);
        //    conductor.ActivateItem(conducted);
        //    Assert.Equal(conducted, conductor.ActiveItem);
        //    conductor.ActivateItem(null);
        //    Assert.Equal(null, conductor.ActiveItem);
        //}

        //private string _ModuleDisplayName;

        //public string Description { get => _Description; set => _Description = value; }


    }
}
