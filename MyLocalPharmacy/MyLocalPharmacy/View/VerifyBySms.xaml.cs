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
using MyLocalPharmacy.Utils;

namespace MyLocalPharmacy.View
{
    public partial class VerifyBySms : PhoneApplicationPage
    {
        public VerifyBySms()
        {
            InitializeComponent();
            this.DataContext = new VerifyBySmsViewModel();
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (popupCodeResent.IsOpen)
            {
                popupCodeResent.IsOpen = false;
                LayoutRoot.IsHitTestVisible = true;
                //NavigationService.GoForward();
                // ClosePopup();
                //foreach (var button in ApplicationBar.Buttons)
                //{
                //    ((ApplicationBarIconButton) button).IsEnabled = false;
                //}


                e.Cancel = true;
            }
            else if (popupNoInternet.IsOpen)
            {
                popupNoInternet.IsOpen = false;
                LayoutRoot.IsHitTestVisible = true;
                e.Cancel = true;
            }
            else if (popupIncorrectCode.IsOpen)
            {
                popupIncorrectCode.IsOpen = false;
                LayoutRoot.IsHitTestVisible = false;
                //ApplicationBa = false;
                //((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                e.Cancel = true;
            }
            else if (popupRequestCode.IsOpen)
            {
                popupRequestCode.IsOpen = false;
                LayoutRoot.IsHitTestVisible = false;
                //ApplicationBa = false;
                //((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                e.Cancel = true;
            }
            else if (popupVerified.IsOpen)
            {
                NavigationService.Navigate(new Uri(PageURL.navigateToHomePanoramaURL, UriKind.Relative));
            }

            else if (LayoutRoot.IsHitTestVisible == false)
            {
                Exit();
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