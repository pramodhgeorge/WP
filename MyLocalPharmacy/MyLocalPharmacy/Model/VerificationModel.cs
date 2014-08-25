using MyLocalPharmacy.Entities;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Model
{
    public class VerificationModel
    {
        public VerificationViewModel objVerificationViewModel;
        public VerificationModel(VerificationViewModel verificationViewModel)
        {
            objVerificationViewModel = verificationViewModel;
            
                ResetPinWebService();
           

        }

        private void ResetPinWebService()
        {
            string apiUrl = RxConstants.resendConfirmationCodes;
            //var pinHashed = Utilities.GetSHA256(App.);
            ResendConfirmationCodesRequest objInputParam = new ResendConfirmationCodesRequest
            {
                mail = App.YourDetailsLoginEmail,
                
                pin = App.HashPIN,
                pharmacyid = App.SignUpPharId.ToUpper()
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

                    objVerificationViewModel.IsResendPopupOpen = "true";
                    //objVerifyBySmsViewModel.HitVisibility = false;
                }
                else if (objResetPinResponse.status == 324)
                {

                    objVerificationViewModel.IsConfirmationPopupOpen = "true";
                    //objVerifyBySmsViewModel.HitVisibility = false;
                }

               

            }
        }
    }
}
