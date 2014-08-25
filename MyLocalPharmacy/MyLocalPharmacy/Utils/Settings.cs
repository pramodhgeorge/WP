using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Utils
{
    public static class Settings
    {

        public const string conferenceBaseApiUri = "https://staging.apps.wv.gov/Portal/ConferenceAPI/rest/conferences";
        public const string conferenceBaseApiKey = "B43CF6F5-54BF-455F-8081-E02FFB850435";
        public const string txtAdd = "Save";
        public const string txtOpen = "Open";
        public const string hintHexColorValue = "#FFA9A9A9";
        public const string txtNoNetwork = "Please check your network connection and try again.";
        public const string txtNoPin = "Please enter PIN to continue.";
        public const string txtServerNullResponse = "No response from server.";
      
        public const string txtPinHint = "Enter pin here";
        public const string txtPinInvalid = "Error while loading data.";
        public const string fetchFailedError = "Error while loading data.";
        public const string fetchFailedErrorDB = "Error while loading data.";
        public const string errorDateList = "Error on adding dates.";
        public const string errorOnDatePickerChange = "Error while loading data.";
        public const string errorOnDisplayingSession = "Error while loading data.";
        public const string errorOnPivotChanged = "Error while loading data.";
        public const string errorOnScheduleEdit = "Error while editing data.";
        
        public const string errorOnMineSchedule = "Error while loading data.";
        public const string errorOnAllSchedule = "Error while loading data.";
        public const string bindingErrorVM = "Error while loading data.";
        public const string txtBindError = "Sorry, not fetched.";
        public static readonly string FacebookAppId = "344192489034345";
        public static readonly string FacebookLogInUri = "https://www.facebook.com/connect/login_success.html";
        public static readonly string FacebookUri = "https://graph.facebook.com";

        public const string navigateToSignUpPanelURL = "/View/SignUp.xaml?ToPanel=SignUp";
        public const string navigateToLoginPanelURL = "/View/SignUp.xaml?ToPanel=login";
        public const string navigateToConfirmPinURL = "/View/ConfirmPin.xaml";
        public const string navigateToYourDetailsLoginURL = "/View/YourDetailsLogin.xaml";
        public const string navigateToYourDetailswithTCURL = "/View/YourDetailswithTC.xaml";
        public const string navigateToTermsandConditionURL = "/View/TermsAndConditions.xaml";
        public const string navigateToEnterPinURL = "/View/EnterPin.xaml";
        public const string navigateToSetPinPin = "/View/SetPin.xaml";
        public const string navigateToMenuURL = "/View/Menu.xaml";
    }
}
