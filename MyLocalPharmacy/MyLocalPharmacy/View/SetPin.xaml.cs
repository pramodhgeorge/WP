﻿using System;
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
    public partial class SetPin : PhoneApplicationPage
    {
        SetPinViewModel objResetPinVM = new SetPinViewModel();
        public SetPin()
        {
            InitializeComponent();
            this.DataContext = new SetPinViewModel();
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
            String val = objResetPinVM.Pin;

            if ((val + buttonValue).Length <= 4)
            {
                objResetPinVM.Pin = val + buttonValue;
            }
            else
            {
                objResetPinVM.Pin = val;
            }

          this.DataContext = objResetPinVM;
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            String val = objResetPinVM.Pin;

            if (val.Length >= 1)
            {
                objResetPinVM.Pin = val.Remove(val.Length - 1, 1);
            }
            else
            {
                objResetPinVM.Pin = val;
            }

            this.DataContext = objResetPinVM;
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