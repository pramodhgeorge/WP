using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MyLocalPharmacy.Resources;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;
using MyLocalPharmacy.View;

namespace MyLocalPharmacy
{
    public partial class MainPage : PhoneApplicationPage
    {

        private Popup popup;
        private BackgroundWorker backroungWorker;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            ShowSplash();
          
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
       
        /// <summary>
        /// Method to load the data in the background
        /// </summary>
        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        public void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(4000);
        }
        public void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;
            });
        }

        /// <summary>
        /// Method to show the Splash screen
        /// </summary>
        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreenControl();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SignUp.xaml", UriKind.Relative));
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}