using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace SublimeCareCloud.ViewModels
{
    class FirstViewModel : Screen
    {

        public FirstViewModel()
        {
            DisplayName = "First";
            MyLabel = "THIS IS THE FIRST VM!";
        }

        private string _label;

        public string MyLabel
        {
            get
            {
                return _label;
            }
            set
            {
                if (_label == value)
                {
                    return;
                }
                _label = value;
                NotifyOfPropertyChange();
            }
        }
    }
}
