using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.Utils
{
    public class WebServiceHelper
    {
        public string ConferenceId { get; set; }   

        public async Task<string> RequestData(string url,string confId)
        {            
            var tcs = new TaskCompletionSource<string>();
            var uri = new UriBuilder(url);
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    ConferenceId = confId;
                    tcs.SetResult(e.Result);
                    string str = e.Result;
                }
                else
                {
                    tcs.SetException(e.Error);
                }
            };
            webClient.DownloadStringAsync(new Uri(url));
            return await tcs.Task;
            
        }
    }
}
