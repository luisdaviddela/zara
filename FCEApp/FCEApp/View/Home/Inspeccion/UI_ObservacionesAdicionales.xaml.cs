using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_ObservacionesAdicionales : ContentPage
	{
        private static readonly HttpClient client = new HttpClient();
        string UserId = "";
        string RPE_Responsable = "";
        string RPE_Jefe = "";
        string NumeroFolio = "";
        string Trimestre = "";
        string anio = "";
        string Formato = "vacio";
        string Evidencia = "vacio";
        string ObservacionesAdicionales = "";

        public UI_ObservacionesAdicionales ()
		{
			InitializeComponent ();
            UserId = Convert.ToString(Application.Current.Properties["UsuarioId"]);
            RPE_Responsable = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            RPE_Jefe = Convert.ToString(Application.Current.Properties["UsuarioId"]);
            anio = Convert.ToString(Application.Current.Properties["Anio"]);
            Trimestre = Convert.ToString(Application.Current.Properties["Trimestre"]);
            NumeroFolio = $"{anio}{Trimestre}{UserId}";
            FinalizarBtn.IsEnabled = false;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var KeyWord = ObsAdicion.Text;
            if (KeyWord.Length >1)
            {
                FinalizarBtn.IsEnabled = true;
            }
            else
            {
                FinalizarBtn.IsEnabled = false;
            }
        }

        private async void FinalizarBtn_Clicked(object sender, EventArgs e)
        {
            ObservacionesAdicionales = ObsAdicion.Text;
            string Params = $"UserID={UserId}&RPE_Responsable={RPE_Responsable}&RPE_Jefe={RPE_Jefe}&NumeroFolio={NumeroFolio}&Trimestre={Trimestre}&anio={anio}&Formato={Formato}&Evidencia={Evidencia}&ObservacionesAdicionales={ObservacionesAdicionales}";
            string uriservice = RestService.Authority + Methods.Observacionesadicionales+ Params;
            try
            {
                var resposeString = await client.GetStringAsync(uriservice);
                string resp = Convert.ToString(resposeString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                await DisplayAlert("CFE Mensaje",data, "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("CFE Mensaje", ex.Message, "Ok");
            }
        }
    }
}