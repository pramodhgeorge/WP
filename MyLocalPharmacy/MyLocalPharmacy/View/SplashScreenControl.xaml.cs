﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace MyLocalPharmacy.View
{
    public partial class SplashScreenControl : UserControl
    {
        public SplashScreenControl()
        {
            InitializeComponent();
            this.progressBar1.IsIndeterminate = true;
            //this.panelSplashScreen.Background =
            // new SolidColorBrush((Color)new PhoneApplicationPage().Resources["PhoneBackgroundColor"]);

            //// Adjust the code to the width of the actual screen
            //this.progressBar1.Width = this.panelSplashScreen.Width =
            //  Application.Current.Host.Content.ActualWidth;
        }
    }
}
