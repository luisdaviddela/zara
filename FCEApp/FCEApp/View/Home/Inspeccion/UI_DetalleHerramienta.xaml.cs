using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UI_DetalleHerramienta : ContentPage
	{
        private static readonly HttpClient client = new HttpClient();
        List<M_Observaciones> info = new List<M_Observaciones>();
        string GUsuID = "", GInvent = "", GinventaEst = "";
        public ObservableCollection<M_Observaciones> Observ;
        public UI_DetalleHerramienta (string UsuarioID, string InventarioID, string MInventarioEstadoID, string cantidadEx, string cod, string Equip)
		{
			InitializeComponent ();
            InformacionCuadrilla();
            Title = "Detalle";
            Codigolbl.Text = cod;
            NombreEH.Text = Equip;
            Cantidalbl.Text = cantidadEx;
        }
        public async void InformacionCuadrilla()
        {

            string URLservise = RestService.Authority + Methods.Observaciones;
            var resposeString = await client.GetStringAsync(URLservise);
            try
            {
                string resp = Convert.ToString(resposeString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);

                List<M_Observaciones> Observable = JsonConvert.DeserializeObject<List<M_Observaciones>>(data);
                Observ = new ObservableCollection<M_Observaciones>(Observable);

                for (int i = 0; i < Observ.Count; i++)
                {
                    string valueResponsableCuadrilla = Convert.ToString(Observ[i].Descripcion);
                    pickerObs.Items.Add(valueResponsableCuadrilla);
                    pickerObsOne.Items.Add(valueResponsableCuadrilla);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("CFE Mensaje:", ex.Message, "Ok");
            }
            GuardarInfo.IsEnabled = true;
        }
        private void pickerObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = sender as Picker;
            if (Application.Current.Properties.ContainsKey("IdObservacionSess"))
            {
                Application.Current.Properties.Remove("IdObservacionSess");
            }
            var observacion = pic.SelectedItem;
            try
            {
                string IdOservacionSelectedLinq = (from pair in Observ
                                                   where pair.Descripcion == observacion.ToString()
                                                   select pair.ObservacionId).First();

                Application.Current.Properties["IdObservacionSess"] = IdOservacionSelectedLinq;
            }
            catch (Exception)
            {
                if (Application.Current.Properties.ContainsKey("IdObservacionSess"))
                {
                    Application.Current.Properties.Remove("IdObservacionSess");
                }
            }
        }
        private void pickerObsOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = sender as Picker;
            if (Application.Current.Properties.ContainsKey("IdObservacionSess"))
            {
                Application.Current.Properties.Remove("IdObservacionSess");
            }
            var observacion = pic.SelectedItem;
            try
            {
                string IdOservacionSelectedLinq = (from pair in Observ
                                                   where pair.Descripcion == observacion.ToString()
                                                   select pair.ObservacionId).First();

                Application.Current.Properties["IdObservacionSess"] = IdOservacionSelectedLinq;
            }
            catch (Exception)
            {
                if (Application.Current.Properties.ContainsKey("IdObservacionSess"))
                {
                    Application.Current.Properties.Remove("IdObservacionSess");
                }
            }
        }
        private async void GuardarInfo_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Información guardada correctamente", "Desea añadir observaciones adicionales", "Si, añadir", "No, regresar");
            if (answer)
            {
                await Navigation.PushAsync(new UI_ObservacionesAdicionales());
            }
        }
    }
}