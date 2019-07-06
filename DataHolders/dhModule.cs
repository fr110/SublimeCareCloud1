using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
  
    [Table("posModule")]
    public class dhModule : INotifyPropertyChanged
    {
       public dhModule()
       {

       }
       private int _iDisplayOrder;

       public int IDisplayOrder
       {
           get { return _iDisplayOrder; }
           set { _iDisplayOrder = value; OnPropertyChanged("IDisplayOrder"); }
       }
       private int _iUpdate;
        [NotMapped]
        public int IUpdate
       {
           get { return _iUpdate; }
           set { _iUpdate = value; OnPropertyChanged("IUpdate"); }
       }
       private int _iModuleID;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IModuleID
       {
           get { return _iModuleID; }
           set { _iModuleID = value; OnPropertyChanged("IModuleID"); }
       }

       private string _vModuleName;

       public string VModuleName
       {
           get { return _vModuleName; }
           set { _vModuleName = value; OnPropertyChanged("VModuleName"); }
       }

       private System.Nullable<bool> _bIsActive;

       public System.Nullable<bool> BIsActive
       {
           get { return _bIsActive; }
           set { _bIsActive = value; OnPropertyChanged("BIsActive"); }
       }

       private System.Nullable<int> _iModuleParentID;

       public System.Nullable<int> IModuleParentID
       {
           get { return _iModuleParentID; }
           set { _iModuleParentID = value; OnPropertyChanged("IModuleParentID"); }
       }

       private string _vUrlPath;

       public string VUrlPath
       {
           get { return _vUrlPath; }
           set { _vUrlPath = value; OnPropertyChanged("VUrlPath"); }
       }

       private string _UriKind;

       public string UriKind
       {
           get { return _UriKind; }
           set { _UriKind = value; OnPropertyChanged("UriKind"); }
       }

       private string _vDisplayName;

       public string VDisplayName
       {
           get { return _vDisplayName; }
           set { _vDisplayName = value; OnPropertyChanged("VDisplayName"); }
       }


       private string _AllowdModule;
        [NotMapped]
        public string AllowdModule
       {
           get { return _AllowdModule; }
           set { _AllowdModule = value; OnPropertyChanged("AllowdModule"); }
       }

       private string _vShortDescription;

       public string VShortDescription
       {
           get { return _vShortDescription; }
           set { _vShortDescription = value; OnPropertyChanged("VShortDescription"); }
       }

       private string _vIconName;

       public string VIconName
       {
           get { return _vIconName; }
           set { _vIconName = value; OnPropertyChanged("VIconName"); }
       }

       private string _vLoadScreen;

       public string VLoadScreen
       {
           get { return _vLoadScreen; }
           set { _vLoadScreen = value; OnPropertyChanged("VLoadScreen"); }
       }
     

       


        
       public event PropertyChangedEventHandler PropertyChanged;
       protected void OnPropertyChanged(string name)
       {
           PropertyChangedEventHandler handler = PropertyChanged;
           if (handler != null)
           {
               handler(this, new PropertyChangedEventArgs(name));
           }
       }
    }
}
