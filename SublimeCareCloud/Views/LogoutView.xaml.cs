﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SublimeCareCloud.Views
{
    /// <summary>
    /// Interaction logic for LogoutViewModel.xaml
    /// </summary>
    public partial class LogoutView : UserControl
    {
        public LogoutView()
        {
            InitializeComponent();
          
           
                // set to null
                Globalized.ObjCurrentUser = null;
                
                System.Windows.Application.Current.Shutdown();
              
           
        }
    }
}
