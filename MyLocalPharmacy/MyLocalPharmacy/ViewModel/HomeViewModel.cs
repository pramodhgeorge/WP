using MyLocalPharmacy.Utils;
using MyLocalPharmacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLocalPharmacy.ViewModel
{
    [DataContract]
    public class HomeViewModel : BaseViewModel
    {
        #region Constructors
        public HomeViewModel()
        {
         RequestData();
        } 
        #endregion

        private PillsDetailsCol pillsCollection;

        public PillsDetailsCol PillsCollection
        {
            get { return pillsCollection; }
            set { pillsCollection = value; OnPropertyChanged("PillsCollection"); }
        }

       
        
        public void RequestData()
        {
            string url = "http://api.patient.co.uk/search/pil/atoz/b?apikey=7a7b35ey-043k-9123ad90";


            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri(url));

        }
        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            if (e.Error == null && e.Result != null)
            {
                PillsDetailsCol pillsCols = JsonHelper.Deserialize<PillsDetailsCol>(e.Result);
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                { PillsCollection = pillsCols; });


            }
        }

    }
}
