using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using LinqToVisualTree;
using System.Windows.Input;

namespace MyLocalPharmacy.Utils
{
    public class WebBrowserHelper
    {
        private WebBrowser _browser;

        /// <summary>
        /// Gets or sets whether to suppress the scrolling of
        /// the WebBrowser control;
        /// </summary>
        public bool ScrollDisabled { get; set; }

        public WebBrowserHelper(WebBrowser browser)
        {
            _browser = browser;
            browser.Loaded += new RoutedEventHandler(browser_Loaded);
        }

        private void browser_Loaded(object sender, RoutedEventArgs e)
        {
            var border = _browser.Descendants<Border>().Last() as Border;

            border.ManipulationDelta += Border_ManipulationDelta;
            border.ManipulationCompleted += Border_ManipulationCompleted;
        }

        private void Border_ManipulationCompleted(object sender,
                                                  ManipulationCompletedEventArgs e)
        {
            
        }

        private void Border_ManipulationDelta(object sender,
                                              System.Windows.Input.ManipulationDeltaEventArgs e)
        {
           
            e.Complete();
            _browser.IsHitTestVisible = false;
           
        }
    }
}
