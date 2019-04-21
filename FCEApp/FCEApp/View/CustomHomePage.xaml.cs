using FCEApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
namespace FCEApp.View
{

	public partial class CustomHomePage : ContentPage
	{
        private static readonly HttpClient client = new HttpClient();
        public ObservableCollection<M_Usuario> Cuadrillas;
        M_Usuario info = new M_Usuario();
        public CustomHomePage ()
		{
			InitializeComponent ();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            string UsuarioID = Convert.ToString(Xamarin.Forms.Application.Current.Properties["UsuarioId"]);
            string URlService = RestService.Authority + Methods.Login + "UsuarioID=" + UsuarioID;
            var resposeString = await client.GetStringAsync(URlService);
            try
            {
                string resp = Convert.ToString(resposeString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);

                info = JsonConvert.DeserializeObject<M_Usuario>(data);

                try
                {
                    NombreUsuario.Text = info.Nombre;
                    Area.Text = info.Zona;
                    RPE.Text = info.RPE;
                    Division.Text = info.Division;
                    Area.Text = info.Area;
                    Xamarin.Forms.Application.Current.Properties["ZonaID"] = info.ZonaID; ;
                }
                catch (Exception ex)
                {

                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("CFE Mensaje", ex.Message, "Ok");
                }

                //for (int i = 0; i < Cuadrillas.Count; i++)
                //{
                //    //string valueResponsableCuadrilla = $"{Cuadrillas[i].rpeResponsable} / {Cuadrillas[i].Nombre}";
                //    RPE.Text = Convert.ToString(Cuadrillas[i].RPE);
                //    NombreUsuario.Text = Convert.ToString(Cuadrillas[i].Nombre);
                //    Division.Text = Convert.ToString(Cuadrillas[i].Division);
                //    Zona.Text = Convert.ToString(Cuadrillas[i].Zona);
                //    Area.Text = Convert.ToString(Cuadrillas[i].Area);
                //    NoEconomico.Text = Convert.ToString(Cuadrillas[i].NoEconomico);
                //    Application.Current.Properties["ZonaID"] = Cuadrillas[i].Zona;
                //}
            }
            catch (Exception ex)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("CFE Mensaje:", ex.Message, "Ok");
            }
        }
    }
}