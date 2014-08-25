using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyLocalPharmacy.Utils;

namespace MyLocalPharmacy.View
{
    public partial class PharmacySupportPage : PhoneApplicationPage
    {
        public PharmacySupportPage()
        {
            InitializeComponent();
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            //webBrowser.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            webBrowser.Navigate(new Uri(RxConstants.myLocalPharmacySupport, UriKind.Absolute));

            webBrowser.Navigated += new EventHandler<NavigationEventArgs>(NavigateHandler);
            //ScrollBarVisibility = ScrollBarVisibility.Visible;

            webBrowser.Visibility = Visibility.Visible;
            webBrowser.Margin.Top.Equals(-12);
            //webBrowser.Height = 543;
            //webBrowser.Width = 456;
            webBrowser.IsScriptEnabled = true;

            ContentPanel.Children.Add(webBrowser);

        }

        private void NavigateHandler(object sender, NavigationEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            if (wb != null)
            {
                wb.Visibility = Visibility.Visible;
            }
        }

        private void imgback_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}