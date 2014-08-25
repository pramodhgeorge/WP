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
using Windows.Storage.Streams;
using Windows.Security;
using MyLocalPharmacy.Utils;

namespace MyLocalPharmacy.View
{
    public partial class Verification : PhoneApplicationPage
    {
        public Verification()
        {
            InitializeComponent();
            //EncodeDecodeBase64();
            this.DataContext = new VerificationViewModel();
        }




        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (popupMailResent.IsOpen)
            {
                popupMailResent.IsOpen = false;
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
            else if (popupConfirmationSend.IsOpen)
            {
                popupConfirmationSend.IsOpen = false;
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