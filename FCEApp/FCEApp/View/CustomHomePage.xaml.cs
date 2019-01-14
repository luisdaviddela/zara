using FCEApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace FCEApp.View
{

	public partial class CustomHomePage : ContentPage
	{
		public CustomHomePage ()
		{
			InitializeComponent ();
            this.BindingContext = new HomePageViewModel();
        }
	}
}