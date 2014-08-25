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
namespace MyLocalPharmacy.View
{
    public partial class ResetPin : PhoneApplicationPage
    {
        ResetPinViewModel objViewModel = new ResetPinViewModel();
        public ResetPin()
        {
            InitializeComponent();
            this.DataContext = new ResetPinViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string buttonTag = (sender as FrameworkElement).Tag.ToString();
            switch (buttonTag)
            {
                case "Tag1":
                    Append("1");
                    break;
                case "Tag2":
                    Append("2");
                    break;
                case "Tag3":
                    Append("3");
                    break;
                case "Tag4":
                    Append("4");
                    break;
                case "Tag5":
                    Append("5");
                    break;
                case "Tag6":
                    Append("6");
                    break;
                case "Tag7":
                    Append("7");
                    break;
                case "Tag8":
                    Append("8");
                    break;
                case "Tag9":
                    Append("9");
                    break;
                case "Tag0":
                    Append("0");
                    break;
            }
        }

        private void Append(String buttonValue)
        {
            String val = objViewModel.Pin;

            if ((val + buttonValue).Length <= 4)
            {
                objViewModel.Pin = val + buttonValue;
            }
            else
            {
                objViewModel.Pin = val;
            }

            this.DataContext = objViewModel;
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            String val = objViewModel.Pin;

            if (val.Length >= 1)
            {
                objViewModel.Pin = val.Remove(val.Length - 1, 1);
            }
            else
            {
                objViewModel.Pin = val;
            }

            this.DataContext = objViewModel;
        }

        private void btn3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}