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
            InformacionCuadrillaF();
            Title = "Detalle";
            Codigolbl.Text = cod;
            NombreEH.Text = Equip;
            Cantidalbl.Text = cantidadEx;
            GUsuID = UsuarioID;
            GInvent = InventarioID;
            GinventaEst = MInventarioEstadoID;
            //----------------------------------
            if (cantidadEx == "0")
            {
                LblMensajeErr.IsVisible = true;
                EntryMale.IsEnabled = false;
                EntryFaltante.IsEnabled = false;
                pickerObs.IsEnabled = false;
                pickerObsOne.IsEnabled = false;
                GuardarInfo.IsEnabled = false;
            }
            else
            {
                LblMensajeErr.IsVisible = false;
            }

        }
        public async void InformacionCuadrilla()
        {

            string URLservise = RestService.Authority + Methods.Observaciones + "M";
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
                    pickerObsOne.Items.Add(valueResponsableCuadrilla);
                    
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("CFE Mensaje:", ex.Message, "Ok");
            }
            GuardarInfo.IsEnabled = true;
        }
        public async void InformacionCuadrillaF()
        {

            string URLservise = RestService.Authority + Methods.Observaciones + "F";
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
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("CFE Mensaje:", ex.Message, "Ok");
            }
            GuardarInfo.IsEnabled = true;
        }
        private void pickerObsOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = sender as Picker;
            if (Application.Current.Properties.ContainsKey("IdObM"))
            {
                Application.Current.Properties.Remove("IdObM");
            }
            var observacion = pic.SelectedItem;
            try
            {
                string IdOservacionSelectedLinq = (from pair in Observ
                                                   where pair.Descripcion == observacion.ToString()
                                                   select pair.ObservacionId).First();

                Application.Current.Properties["IdObM"] = IdOservacionSelectedLinq;
            }
            catch (Exception)
            {
                if (Application.Current.Properties.ContainsKey("IdObM"))
                {
                    Application.Current.Properties.Remove("IdObM");
                }
            }
        }
        private void pickerObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = sender as Picker;
            if (Application.Current.Properties.ContainsKey("IdObF"))
            {
                Application.Current.Properties.Remove("IdObF");
            }
            var observacion = pic.SelectedItem;
            try
            {
                string IdOservacionSelectedLinq = (from pair in Observ
                                                   where pair.Descripcion == observacion.ToString()
                                                   select pair.ObservacionId).First();

                Application.Current.Properties["IdObF"] = IdOservacionSelectedLinq;
            }
            catch (Exception)
            {
                if (Application.Current.Properties.ContainsKey("IdObF"))
                {
                    Application.Current.Properties.Remove("IdObF");
                }
            }
        }
        private async void GuardarInfo_Clicked(object sender, EventArgs e)
        {
            string cm = EntryMale.Text;
            string cb = "0";
            string cf = EntryFaltante.Text;
            string observacionidM = Convert.ToString(Application.Current.Properties["IdObM"]);
            string observacionidF = Convert.ToString(Application.Current.Properties["IdObF"]);
            string numfo = "vacio";
            string respon = "TRIMESTRAL";
            string uriservice = RestService.Authority + Methods.Inspeccion + "UserID=" + GUsuID + "&InventarioID=" + GInvent + "&MInventarioEstadoID=" + GinventaEst + "&ObservacionIDM=" + observacionidM+ "&ObservacionIDF=" +observacionidF + "&cantidadB=" + cb + "&cantidadM=" + cm + "&cantidadF=" + cf + "&Responsable=" + respon + "&NumeroFolio=" + numfo;
            var resposeString = await client.GetStringAsync(uriservice);
            string resp = Convert.ToString(resposeString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            var answer = await DisplayAlert(data, "Desea añadir observaciones adicionales", "Si, añadir", "No, regresar");
            if (answer)
            {
                await Navigation.PushAsync(new UI_ObservacionesAdicionales());
            }
        }
    }
}