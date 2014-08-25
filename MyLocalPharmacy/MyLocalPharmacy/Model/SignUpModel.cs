using MyLocalPharmacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Entities;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MyLocalPharmacy.Model
{
    public class SignUpModel
    {
        public SignUpViewModel objSignUpViewModel;
      
        #region Login
        /// <summary>
        /// For Login screen
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="forlogin"></param>
        public SignUpModel(SignUpViewModel loginViewModel, string forlogin)
        {
            objSignUpViewModel = loginViewModel;
            if (forlogin == "Loginscreen")
            {
                BrandingInfoWebService();
                
                
            }
            else
            {
                ResetPinWebService();
            }

        }

        /// <summary>
        /// Web service to get the branding info
        /// </summary>
        private void BrandingInfoWebService()
        {
            string apiUrl = RxConstants.getPharmacyInformations;
            GetPharmacyInformationRequest objInputParameters = new GetPharmacyInformationRequest
            {
                Pharmacyid = App.LoginPharId.ToUpper(),// "MGS001",
                Deviceid = "",
                Model = "",
                Os = "",
                Branding_hash = "",
                Advert_hash = "",
                Drugs_hash = ""
            };

            WebClient pharmacyinfoforbrandingwebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

            var json = JsonHelper.Serialize(objInputParameters);
            pharmacyinfoforbrandingwebservicecall.Headers["Content-type"] = "application/json";
            pharmacyinfoforbrandingwebservicecall.UploadStringCompleted += pharmacyinfoforbrandingwebservicecall_UploadStringCompleted;

            pharmacyinfoforbrandingwebservicecall.UploadStringAsync(uri, "POST", json);

        }
        /// <summary>
        /// Response for Branding Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pharmacyinfoforbrandingwebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            GetPharmacyInformationResponse objPhBrandingInfoResponse = null;
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objPhBrandingInfoResponse = Utils.JsonHelper.Deserialize<GetPharmacyInformationResponse>(response);
                if ((objPhBrandingInfoResponse.payload != null) && (objPhBrandingInfoResponse.status == 0))
                {
                    App.Objbrandingesponse = objPhBrandingInfoResponse;
                }
                LoginUserDetailsWebService();
            }
        }

        /// <summary>
        /// To check user emailid validity for resetpin
        /// </summary>
        private void ResetPinWebService()
        {
            string apiUrl = RxConstants.sendResetPinCode;
            SendResetPinCodeRequest objInputParam = new SendResetPinCodeRequest
            {
                mail = objSignUpViewModel.LoginEmail
            };

            WebClient resetpinswebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);
            var json = JsonHelper.Serialize(objInputParam);
            //   var result = await RequestData(uri.ToString(),json);

            resetpinswebservicecall.Headers["Content-type"] = "application/json";
            resetpinswebservicecall.UploadStringCompleted += resetpinswebservicecall_UploadStringCompleted;

            resetpinswebservicecall.UploadStringAsync(uri, "POST", json);
        }

        public async Task<string> RequestData(string url, string data)
        {
            var tcs = new TaskCompletionSource<string>();
            var uri = new UriBuilder(url);
            var webClient = new WebClient();
            webClient.Headers["Content-type"] = "application/json";
            webClient.UploadStringCompleted += resetpinswebservicecall_UploadStringCompleted;
            webClient.UploadStringAsync(new Uri(url), "POST", data);
            return await tcs.Task;

        }
        /// <summary>
        /// Check the response for the emailid in resetpin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetpinswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            SendResetPinCodeResponse objresetpincoderesponse = new SendResetPinCodeResponse();
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objresetpincoderesponse = Utils.JsonHelper.Deserialize<SendResetPinCodeResponse>(response);

                if (objresetpincoderesponse.status == 0)
                {
                    PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                    frame.Navigate(new Uri(PageURL.navigateToResetPinLoginURL, UriKind.Relative));
                }
                else if (objresetpincoderesponse.status == 310)
                {
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = "No such user.";
                    //objSignUpViewModel.IsLoginEmailValidatorVisible = Visibility.Visible;
                    //objSignUpViewModel.EmailValidationMessage = "No such user.";
                    //MessageBox.Show("No such user", "Invalid User", MessageBoxButton.OK);
                }

            }
        }
        /// <summary>
        /// To get the user details while login and display it when "continue" is clciked
        /// </summary>
        private void LoginUserDetailsWebService()
        {
            
            //{"mail":"abhijithg@qburst.com", "pin":"0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c", "pharmacyid":"MGS001"}
            string apiUrl = RxConstants.getUserDetails;
            LoginParameters objLoginparameters = new LoginParameters
            {
                Mail = objSignUpViewModel.LoginEmail,
                Pharmacyid = objSignUpViewModel.LoginPharmacyID.ToUpper(),
                Pin = App.HashPIN

            };

            WebClient userdetailswebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

            var json = JsonHelper.Serialize(objLoginparameters);
            userdetailswebservicecall.Headers["Content-type"] = "application/json";
            userdetailswebservicecall.UploadStringCompleted += userdetailswebservicecall_UploadStringCompleted;

            userdetailswebservicecall.UploadStringAsync(uri, "POST", json);
        }
        /// <summary>
        /// Get the response of user details web service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userdetailswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
           
            LoginResponse objlgresponse = new LoginResponse();
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objlgresponse = Utils.JsonHelper.Deserialize<LoginResponse>(response);
                if (objlgresponse.status == 0)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    App.Objlgresponse = objlgresponse;
                    PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                    frame.Navigate(new Uri(PageURL.navigateToYourDetailswithTCURL, UriKind.Relative));
                }
                else if (objlgresponse.status == 310)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "No such user.";
                    //MessageBox.Show("No such user.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 100)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "At least one of required input argument is not found.";
                    //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 105)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "At least one of required input argument is not found.";
                    //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 106)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "At least one of required input argument is not found.";
                    //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
                } 
                else if (objlgresponse.status == 301)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "Incorrect PIN provided.";
                    //MessageBox.Show("Incorrect PIN provided.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 307)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "No such pharmacy.";
                    //MessageBox.Show("No such pharmacy.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 314)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;
                    //MessageBox.Show("Patient has no accepted nomination.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 319)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "Nomination is disabled.";
                    //MessageBox.Show("Nomination is disabled.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 321)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "You have to get approval for pharmacy " + App.LoginPharmacyname + ".";
                    //MessageBox.Show("You have to get approval for pharmacy " + App.LoginPharmacyname + ".", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 308)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "Patient has not nominated this pharmacy.";
                   // MessageBox.Show("Patient has not nominated this pharmacy.", "Error", MessageBoxButton.OK);
                }
                else if (objlgresponse.status == 320)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objlgresponse.message;// "Your nomination for " + App.LoginPharmacyname + " has to be approved by pharmacist.";
                    //MessageBox.Show("Your nomination for " + App.LoginPharmacyname + " has to be approved by pharmacist.", "Error", MessageBoxButton.OK);
                }
            }

        }
        #endregion

        #region SignUp
        
        /// <summary>
        /// For SignUp Screen
        /// </summary>
        /// <param name="signUpViewModel"></param>
        public SignUpModel(SignUpViewModel signUpViewModel)
        {
            objSignUpViewModel = signUpViewModel;
            CallGetPharmacyInformationWebService();
        }
        
        /// <summary>
        /// Get pharmacy information in signup screen
        /// </summary>
        public void CallGetPharmacyInformationWebService()
        {
           
            string apiUrl = RxConstants.getPharmacyInformations;
           // {"pharmacyid":"MGS001", "deviceid":"jnwub7628fs", "model":"Nexus 7", "os":"Android", "branding_hash":"kheyjfgyagfysg", "advert_hash":"uehu921jdnkg", "drugs_hash":"uhuh89239djg"}

            GetPharmacyInformationRequest objInputParameters = new GetPharmacyInformationRequest
            {
                Pharmacyid =objSignUpViewModel.SignUpPharmacyID.ToUpper(),// "MGS001",
                Deviceid = "",
                Model = "",
                Os = "",
                Branding_hash = "",
                Advert_hash = "",
                Drugs_hash = ""
            };
            //LoginParameters objLoginParameters = new LoginParameters
            //{
            //     Mail = "abhijithg@qburst.com",
            //    Pin = "0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c",
            //    Pharmacyid = "MGS001"
               
            //};


            WebClient pharmacyinfowebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);

            var json = JsonHelper.Serialize(objInputParameters);
            pharmacyinfowebservicecall.Headers["Content-type"] = "application/json";
            pharmacyinfowebservicecall.UploadStringCompleted += pharmacyinfowebservicecall_UploadStringCompleted;

            pharmacyinfowebservicecall.UploadStringAsync(uri, "POST", json);
        }
        /// <summary>
        /// Web service response for pharmacy information in signup screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pharmacyinfowebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            GetPharmacyInformationResponse objLoginResponse = null;
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objLoginResponse = Utils.JsonHelper.Deserialize<GetPharmacyInformationResponse>(response);
                if ((objLoginResponse.payload != null)&&(objLoginResponse.status==0))
                {
                    App.LoginPharmacyname = objLoginResponse.payload.branding_data.pharmacy_name;
                   
                    objSignUpViewModel.PharmacyName = objLoginResponse.payload.branding_data.pharmacy_name;
                    objSignUpViewModel.AddressLine1 = objLoginResponse.payload.branding_data.address1;
                    objSignUpViewModel.AddressLine2 = objLoginResponse.payload.branding_data.address2;
                    //objSignUpViewModel.AddressLine3 = objLoginResponse.payload.branding_data.city;
                    objSignUpViewModel.PinCode = objLoginResponse.payload.branding_data.postcode;
                    objSignUpViewModel.IsPharmacyDetailsVisible = Visibility.Visible;
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                }
                else if (objLoginResponse.status == 105)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objLoginResponse.message;// "At least one of required input argument is not found.";
                    //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
                }
                else if (objLoginResponse.status == 106)
                {
                    objSignUpViewModel.ProgressBarVisibilty = Visibility.Collapsed;
                    objSignUpViewModel.IsPopupOpen = "true";
                    objSignUpViewModel.PopupText = objLoginResponse.message;// "At least one of required input argument is not found.";
                    //MessageBox.Show("At least one of required input argument is not found.", "Error", MessageBoxButton.OK);
                } 
            }
        }
        #endregion

    }
}
