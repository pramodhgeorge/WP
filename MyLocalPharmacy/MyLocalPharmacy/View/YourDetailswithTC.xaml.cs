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
using System.Windows.Media;
using MyLocalPharmacy.Entities;

namespace MyLocalPharmacy.View
{
    public partial class YourDetailswithTC : PhoneApplicationPage
    {
        public YourDetailswithTC()
        {
            //LoginResponse objlgresponse;
            InitializeComponent();
            (App.Current.Resources["PhoneRadioCheckBoxCheckBrush"] as SolidColorBrush).Color = Colors.Black;
            this.DataContext = new YourDetailswithTCViewModel(App.Objlgresponse);

        }

        //private void btnUpdate_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/View/Menu.xaml", UriKind.Relative));
        //}

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            if (popup.IsOpen)
            {
                popup.IsOpen = false;
                LayoutRoot.IsHitTestVisible = true;
                //NavigationService.GoForward();
                // ClosePopup();
                //foreach (var button in ApplicationBar.Buttons)
                //{
                //    ((ApplicationBarIconButton) button).IsEnabled = false;
                //}


                e.Cancel = true;
            }
            else if (popupSuccess.IsOpen)
            {
                
            }
            else
            {
                Exit();
            } 

        }

        private void Exit()
        {
            while (NavigationService.BackStack.Any())
            {
                NavigationService.RemoveBackEntry();

            }
        }
    }
}