
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace FCEApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		    Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
		    On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
	}
}