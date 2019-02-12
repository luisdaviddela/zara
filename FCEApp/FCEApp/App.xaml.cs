using System;
using FCEApp.View;
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
		    AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this,
		        AndroidSpecific.WindowSoftInputModeAdjust.Resize);
            //MainPage = new CustomMaster();
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

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
