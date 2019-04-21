using System;
using FCEApp.View;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using AndroidSpecific=Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FCEApp
{
	public partial class App : Application
	{
	    public static CustomMaster MasterDetail { get; set; }
        public App ()
		{
			InitializeComponent();
            //MainPage = new CustomMaster();
            if (!CrossConnectivity.Current.IsConnected)
            {
                MainPage = new CFEOFFLINE();
            }
            else
            {
                if (Application.Current.Properties.ContainsKey("IsLoggedIn"))
                {
                    var LogedAppProp = Application.Current.Properties["IsLoggedIn"];
                    bool isLoggedIn = Convert.ToBoolean(LogedAppProp);
                    if (isLoggedIn)
                    {
                        MainPage = new NavigationPage(new CustomMaster());
                    }
                    else
                    {
                       MainPage = new View.LoginPage();
                    }
                }
                else
                {

                    MainPage = new View.LoginPage();
                }
            }
		    AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this,
		        AndroidSpecific.WindowSoftInputModeAdjust.Resize);
		}

		protected override void OnStart ()
		{
            if (!CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NavigationPage(new CFEOFFLINE());
            }
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            if (!CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NavigationPage(new CFEOFFLINE());
            }
        }
	}
}
