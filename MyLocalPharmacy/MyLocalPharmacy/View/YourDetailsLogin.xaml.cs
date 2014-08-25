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

namespace MyLocalPharmacy.View
{
    public partial class YourDetailsLogin : PhoneApplicationPage
    {
        public YourDetailsLogin()
        {
            InitializeComponent();
            (App.Current.Resources["PhoneRadioCheckBoxCheckBrush"] as SolidColorBrush).Color = Colors.Black;
            this.DataContext = new YourDetailsLoginViewModel();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
         
            BaseViewModel viewModel = this.DataContext as BaseViewModel;
            viewModel.Initialize(this.NavigationContext.QueryString);

        }

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