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
using Microsoft.Phone.Tasks;

namespace MyLocalPharmacy.View
{
    public partial class PharmacyDetails : PhoneApplicationPage
    {
        public PharmacyDetails()
        {
            InitializeComponent();
            this.DataContext = new PharmacyDetailsViewModel();
        }

        private void txtPhone_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

            PharmacyDetailsViewModel objPharmacyDetails = new PharmacyDetailsViewModel();
            try
            {
                string phNumber = objPharmacyDetails.PhoneNumber;
                if (!string.IsNullOrEmpty(phNumber))
                {
                    PhoneCallTask phoneCallTask = new PhoneCallTask();
                    phoneCallTask.PhoneNumber = phNumber;
                    //phoneCallTask.DisplayName = "Abhi";
                    phoneCallTask.Show();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}