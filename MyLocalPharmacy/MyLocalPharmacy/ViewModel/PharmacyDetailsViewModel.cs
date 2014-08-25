using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.ViewModel 
{
    public class PharmacyDetailsViewModel : BaseViewModel
    {
        private string number = "09544088458";
        public string PhoneNumber
        {
            get 
            { 
                return number; 
            }
            set
            {
                number = value;
                OnPropertyChanged(PhoneNumber);
            }
        }
    }
}
