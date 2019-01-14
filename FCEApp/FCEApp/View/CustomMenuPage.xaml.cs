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
            this.BindingContext = new CustomMenuPageViewModel();
        }
    }
}