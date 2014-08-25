using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyLocalPharmacy.ViewModel;

namespace MyLocalPharmacy.View
{
    public partial class YourDetails : PhoneApplicationPage
    {
        public YourDetails()
        {
            InitializeComponent();
            this.DataContext = new YourDetailsUpdateViewModel();
        }      
    }
}