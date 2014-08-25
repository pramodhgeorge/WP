using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLocalPharmacy.ViewModel
{
    public class MapPharmacyViewModel : BaseViewModel
    {
        private Visibility progressBarVisibilty = Visibility.Visible;
        public Visibility ProgressBarVisibilty
        {
            get
            {
                return progressBarVisibilty;
            }
            set
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    progressBarVisibilty = value;
                    OnPropertyChanged("ProgressBarVisibilty");
                });

            }
        }
    }
}
