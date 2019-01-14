using System.Threading.Tasks;
using FCEApp.ViewModel.Base;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace FCEApp.ViewModel
{
    public class LoginPageViewModel : BindableBase
    {
        private static readonly HttpClient client = new HttpClient();
        #region Properties
        private string rPEUserName;
        private string password;

        
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        public string RPEUserName
        {
            get { return rPEUserName; }
            set { SetProperty(ref rPEUserName, value); }
        }
        //public bool IsEnabled
        //{
        //    get { return isEnabled; }
        //    set { SetProperty(ref isEnabled, value); }
        //}

        #endregion

        #region Commands
        public ICommand LoginCommand { get; set; }

        #endregion

        #region Contructors

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => { await Login(); });
        }

        #endregion

        #region Methods

        private async Task Login()
        {
            //IsEnabled = false;
            if (!string.IsNullOrEmpty(RPEUserName))
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    //IsEnabled = true;
                    M_SesionResult info = new M_SesionResult();

                    string URLservise = RestService.Authority + Methods.Login + "RPE=" + rPEUserName + "&Contrasena=" + password;
                    var resposeString = await client.GetStringAsync(URLservise);
                    try
                    {
                        string resp = Convert.ToString(resposeString);
                        var obj = JsonConvert.DeserializeObject<object>(resp);
                        string data = Convert.ToString(obj);
                        info = JsonConvert.DeserializeObject<M_SesionResult>(data);
                        if (info.UsuarioID !="0")
                        {
                            string UsuarioID = info.UsuarioID;
                            Application.Current.Properties["UsuarioId"] = UsuarioID;
                            App.Current.MainPage = new View.CustomMaster();
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("CFE Mensaje:","Verifique usuario y contraseña","Ok");
                        }
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("CFE Mensaje:",ex.Message,"Ok");
                    }
                }
                else
                {
                    //IsEnabled = true;
                    await App.Current.MainPage.DisplayAlert("Error", "Ingrese su contraseña", "Ok");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingrese su RPE", "Ok");
                //IsEnabled = true;
            }
        }
        #endregion
    }
}
