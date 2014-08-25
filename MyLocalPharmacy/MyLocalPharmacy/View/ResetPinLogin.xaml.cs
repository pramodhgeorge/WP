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
    public partial class ResetPinLogin : PhoneApplicationPage
    {
        public ResetPinLogin()
        {
            InitializeComponent();
            this.DataContext = new ResetPinLoginViewModel();
            ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = true;
        }
        private void tbxPIN_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            App.resetLoginAuthCode = tbxID.Text;
            NavigationService.Navigate(new Uri(PageURL.navigateToResetPinURL, UriKind.Relative));
            
                //   tbxID.BorderThickness = 5.0;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (popupIncorrectCode.IsOpen)
            {
                popupIncorrectCode.IsOpen=false;
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
                popupNoInternet.IsOpen= false;
                LayoutRoot.IsHitTestVisible = true;
                e.Cancel = true;
            }
            else if (popupReset.IsOpen)
            {
                popupReset.IsOpen = false;
                LayoutRoot.IsHitTestVisible = false;
                //ApplicationBa = false;
                ((ApplicationBarIconButton)this.ApplicationBar.Buttons[0]).IsEnabled = false;
                e.Cancel = true;
            }
            else if (LayoutRoot.IsHitTestVisible == false)
            {
                Exit();
            }
            else
            {
                NavigationService.Navigate(new Uri(PageURL.navigateToLoginPanelURL, UriKind.Relative));
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