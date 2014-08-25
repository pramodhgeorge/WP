using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MyLocalPharmacy.View
{
    public partial class Menu : PhoneApplicationPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconCall_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/PharmacyDetails.xaml", UriKind.Relative));
        }

        private void btnSamplePharmacyDetails_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/MapPharmacyDetails.xaml", UriKind.Relative));
        }

        private void btnSampleOrderRepeat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSampleConditionLeaflet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/ConditionLeaflets.xaml", UriKind.Relative));
        }

        private void btnLocalHealthService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/MapDenthist.xaml", UriKind.Relative));
        }

        private void btnSamplePillsReminder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/PillReminder.xaml", UriKind.Relative));
        }

       
    }
}