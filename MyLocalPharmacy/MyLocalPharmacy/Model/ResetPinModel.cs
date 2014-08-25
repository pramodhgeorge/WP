using Microsoft.Phone.Controls;
using MyLocalPharmacy.Entities;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLocalPharmacy.Model
{
    public class ResetPinModel
    {
        public ResetPinLoginViewModel objResetPinLoginViewModel;
        public ResetPinModel(ResetPinLoginViewModel resetPinLoginViewModel)
        {
            objResetPinLoginViewModel = resetPinLoginViewModel;
            ResetPinWebService();
        }

        private void ResetPinWebService()
        {
            string apiUrl = RxConstants.resetPin;
            var pinHashed = Utilities.GetSHA256(objResetPinLoginViewModel.DisplaySignUpPin);
            ResetPinRequest objInputParam = new ResetPinRequest
            {
                mail = objResetPinLoginViewModel.LoginEmail,
                code=objResetPinLoginViewModel.AuthCode,
                pin= pinHashed
            };

            WebClient resetpinswebservicecall = new WebClient();
            var uri = new Uri(apiUrl, UriKind.RelativeOrAbsolute);
            var json = JsonHelper.Serialize(objInputParam);
            //   var result = await RequestData(uri.ToString(),json);

            resetpinswebservicecall.Headers["Content-type"] = "application/json";
            resetpinswebservicecall.UploadStringCompleted += resetpinswebservicecall_UploadStringCompleted;

            resetpinswebservicecall.UploadStringAsync(uri, "POST", json);
        }

        private void resetpinswebservicecall_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            ResetPinResponse objResetPinResponse = new ResetPinResponse();
            if (e.Result != null)
            {
                var response = e.Result.ToString();
                objResetPinResponse = Utils.JsonHelper.Deserialize<ResetPinResponse>(response);

                if (objResetPinResponse.status == 0)
                {
                    //PhoneApplicationFrame frame = (PhoneApplicationFrame)Application.Current.RootVisual;
                    //frame.Navigate(new Uri(PageURL.navigateToResetPinURL, UriKind.Relative));
                    objResetPinLoginViewModel.IsResetPopupOpen = "true";
                    objResetPinLoginViewModel.HitVisibility = false;
                }
                else if (objResetPinResponse.status == 315)
                {
                   
                    objResetPinLoginViewModel.IsIncorrectPopupOpen = "true";
                    objResetPinLoginViewModel.HitVisibility = false;
                }
                else if (objResetPinResponse.status == 310)
                {
                    //objResetPinLoginViewModel.AuthCode = "B1AU59OF";
                    objResetPinLoginViewModel.IsLoginPinTextBoxVisible = Visibility.Collapsed;
                    objResetPinLoginViewModel.IsNoUserPopupOpen = "true";
                    objResetPinLoginViewModel.HitVisibility = false;
                }

            }
        }
    }
}
