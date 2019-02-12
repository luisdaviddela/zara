using FCEApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace FCEApp.View
{
    
    public partial class CustomMenuPage : ContentPage
    {
        public CustomMenuPage()
        {
            InitializeComponent();
            Xamarin.Forms.Application.Current.Properties["IsLoggedIn"] = true;
            this.BindingContext = new CustomMenuPageViewModel();
        }
    }
}