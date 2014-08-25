using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;


namespace ReminderTest1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = dpkDate.Value.Value;
            TimeSpan time = tpkTime.Value.Value.TimeOfDay;
            date = date.Date + time;
            if (date < DateTime.Now)
            {
                MessageBox.Show("Invalid Time !\nEnter again !");
            }
            else
            {
                //ScheduledAction oldReminder = ScheduledActionService.Find("ToDoReminder");
                //ScheduledActionService.Remove(oldReminder.Name);
                Reminder reminder = new Reminder("ToDoReminder")
                {
                    BeginTime = date,
                    Title = "Reminder",
                    Content = "Paracetamol IP: 1",
                    RecurrenceType = RecurrenceInterval.Weekly

                };
                ScheduledActionService.Add(reminder);
                MessageBox.Show("Reminder Set !");
            }

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