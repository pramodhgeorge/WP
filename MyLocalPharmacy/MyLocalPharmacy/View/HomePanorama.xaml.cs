using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Globalization;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Globalization;
using MyLocalPharmacy.Model;
using MyLocalPharmacy.Utils;
using MyLocalPharmacy.ViewModel;


namespace MyLocalPharmacy.View
{
    public partial class HomePanorama : PhoneApplicationPage
    {
        PillsDetailsCol pillsCols;
        
        public HomePanorama()
        {
            RequestData();
            InitializeComponent();
            DataContext = new HomePanoramaViewModel();
        }

        private PillsDetailsCol pillsCollection;
        public PillsDetailsCol PillsCollection
        {
            get { return pillsCollection; }
            set
            {
                pillsCollection = value;
                //OnPropertyChanged("PillsCollection");
            }
        }

        public void RequestData()
        {
            //string url = "http://api.patient.co.uk/search/pil/atoz/b?apikey=7a7b35ey-043k-9123ad90";
            string url = "http://api.patient.co.uk/search/pil/all?apikey=7a7b35ey-043k-9123ad90";


            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
            webClient.DownloadStringAsync(new Uri(url));

        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            if (e.Error == null && e.Result != null)
            {
                pillsCols = JsonHelper.Deserialize<PillsDetailsCol>(e.Result);
                //Deployment.Current.Dispatcher.BeginInvoke(() =>
                //{ PillsCollection = pillsCols; });

                List<LeafletsGroup<PillsDetails>> DataSource = LeafletsGroup<PillsDetails>.CreateGroups(pillsCols,
               System.Threading.Thread.CurrentThread.CurrentUICulture,
               (PillsDetails s) => { return s.Title; }, true);
                longListSelectorState.ItemsSource = DataSource;


            }
        }
    }

    public class LeafletsGroup<T> : List<T>
    {
        /// <summary>
        /// The delegate that is used to get the key information.
        /// </summary>
        /// <param name="item">An object of type T</param>
        /// <returns>The key value to use for this object</returns>
        public delegate string GetKeyDelegate(T item);

        /// <summary>
        /// The Key of this group.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="key">The key for this group.</param>
        public LeafletsGroup(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Create a list of LeafletsGroup<T> with keys set by a SortedLocaleGrouping.
        /// </summary>
        /// <param name="slg">The </param>
        /// <returns>Theitems source for a LongListSelector</returns>
        private static List<LeafletsGroup<T>> CreateGroups(SortedLocaleGrouping slg)
        {
            List<LeafletsGroup<T>> list = new List<LeafletsGroup<T>>();

            foreach (string key in slg.GroupDisplayNames)
            {
                list.Add(new LeafletsGroup<T>(key));
            }

            return list;
        }

        /// <summary>
        /// Create a list of LeafletsGroup<T> with keys set by a SortedLocaleGrouping.
        /// </summary>
        /// <param name="items">The items to place in the groups.</param>
        /// <param name="ci">The CultureInfo to group and sort by.</param>
        /// <param name="getKey">A delegate to get the key from an item.</param>
        /// <param name="sort">Will sort the data if true.</param>
        /// <returns>An items source for a LongListSelector</returns>
        public static List<LeafletsGroup<T>> CreateGroups(IEnumerable<T> items, CultureInfo ci, GetKeyDelegate getKey, bool sort)
        {
            SortedLocaleGrouping slg = new SortedLocaleGrouping(ci);
            List<LeafletsGroup<T>> list = CreateGroups(slg);

            foreach (T item in items)
            {
                int index = 0;
                index = slg.GetGroupIndex(getKey(item));
                if (index >= 0 && index < list.Count)
                {
                    list[index].Add(item);
                }
            }

            if (sort)
            {
                foreach (LeafletsGroup<T> group in list)
                {
                    group.Sort((c0, c1) => { return ci.CompareInfo.Compare(getKey(c0), getKey(c1)); });
                }
            }

            return list;
        }

    }
}