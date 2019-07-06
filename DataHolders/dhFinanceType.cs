using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhFinanceType : INotifyPropertyChanged
    {
        private int _iFinaceType;
        [Key]
        public int IFinaceType
        {
            get { return _iFinaceType; }
            set { _iFinaceType = value; OnPropertyChanged("VFinaceType"); }
        }
        private string _vFinaceType;
       
        public string VFinaceType
        {
            get { return _vFinaceType; }
            set { _vFinaceType = value; OnPropertyChanged("VFinaceType"); }
        }

        private string _vFinaceTypeDes;
       
        public string VFinaceTypeDes
        {
            get { return _vFinaceTypeDes; }
            set { _vFinaceTypeDes = value; OnPropertyChanged("VFinaceTypeDes"); }
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
