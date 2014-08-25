using Microsoft.Phone.Controls;
using MyLocalPharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalPharmacy.ViewModel
{
    [DataContract]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Declarations
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region INotifyImplementation


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


      public  virtual void Initialize(IDictionary<string, string> dictionary)
        {
            
        }
    }
    
}
