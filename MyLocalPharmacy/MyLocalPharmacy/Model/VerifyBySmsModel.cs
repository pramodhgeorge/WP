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
    public class VerifyBySmsModel
    {
        public VerifyBySmsViewModel objVerifyBySmsViewModel;
        public VerifyBySmsModel(VerifyBySmsViewModel verifyBySmsViewModel, string verify)
        {
            objVerifyBySmsViewModel = verifyBySmsViewModel;
            if (verify.Equals("ResentPin"))
            {
                ResetPinWebService();
            }

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

                    objVerifyBySmsViewModel.IsResentPopupOpen = "true";
                    //objVerifyBySmsViewModel.HitVisibility = false;
                }
                else if (objResetPinResponse.status == 324)
                {

                    objVerifyBySmsViewModel.IsRequestPopupOpen = "true";
                    //objVerifyBySmsViewModel.HitVisibility = false;
                }
               

            }
        }
    }
}
