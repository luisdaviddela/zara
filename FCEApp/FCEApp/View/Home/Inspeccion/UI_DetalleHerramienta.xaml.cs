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
        List<M_Observaciones> infoMala = new List<M_Observaciones>();
        List<M_Observaciones> infoFaltante = new List<M_Observaciones>();
        public ObservableCollection<M_Observaciones> ObservMala;
        public ObservableCollection<M_Observaciones> ObservFaltante;
        string GUsuID = "", GInvent = "", GinventaEst = "";
        int cantidadGlobal = 0;
        int cantidadMalEstado = 1;
        int cantidadFaltante = 1;
        public UI_DetalleHerramienta (string UsuarioID, string InventarioID, string MInventarioEstadoID, string cantidadEx, string cod, string Equip)
		{
			InitializeComponent ();
            InformacionCuadrilla();
            InformacionCuadrillaF();
            cantidadGlobal = Convert.ToInt32(cantidadEx);
            Title = "Detalle";
            Codigolbl.Text = cod;
            NombreEH.Text = Equip;
            Cantidalbl.Text = cantidadEx;
            GUsuID = UsuarioID;
            GInvent = InventarioID;
            GinventaEst = MInventarioEstadoID;
            //----------------------------------
            if (cantidadGlobal <= 1)
            {
                LblMensajeErr.IsVisible = true;
                EntryMalEstado.IsEnabled = false;
                EntryFaltante.IsEnabled = false;
                pickerObs.IsEnabled = false;
                pickerObsOne.IsEnabled = false;
                GuardarInfo.IsEnabled = false;
                GuardarInfo.IsVisible = false;
            }
            else
            {
                LblMensajeErr.IsVisible = false;
                LblMalEstado.Text = Convert.ToString(1);
                LblFaltante.Text = Convert.ToString(1);
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
                ObservMala = new ObservableCollection<M_Observaciones>(Observable);
                for (int i = 0; i < ObservMala.Count; i++)
                {
                    string valueResponsableCuadrilla = Convert.ToString(ObservMala[i].Descripcion);
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
                ObservFaltante = new ObservableCollection<M_Observaciones>(Observable);
                for (int i = 0; i < ObservFaltante.Count; i++)
                {
                    string valueResponsableCuadrilla = Convert.ToString(ObservFaltante[i].Descripcion);
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
                string IdOservacionSelectedLinq = (from pair in ObservMala
                                                   where pair.Descripcion == observacion.ToString()
                                                   select pair.ObservacionId).First();

                Application.Current.Properties["IdObM"] = IdOservacionSelectedLinq;
            }
            catch (Exception ex)
            {
                DisplayAlert("s",ex.Message,"d");
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
                string IdOservacionSelectedLinq = (from pair in ObservFaltante
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
        private void EntryMalEstado_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var cm = EntryMalEstado.Value.ToString();
            cantidadMalEstado = Convert.ToInt32(cm);
            int total = cantidadFaltante + cantidadMalEstado;
            //DisplayAlert("con", total.ToString(), "ok");
            if (total > cantidadGlobal)
            {
                DisplayAlert("CFE Mensaje", "No puede agregar más del inventario existente", "ok");
            }
            else
            {
                LblMalEstado.Text = Convert.ToString(cm);
            }
        }
        private void EntryFaltante_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var cf = EntryFaltante.Value.ToString();
            cantidadFaltante = Convert.ToInt32(cf);
            int total = cantidadFaltante + cantidadMalEstado;
            //DisplayAlert("con",total.ToString(),"ok");
            if (total> cantidadGlobal)
            {
                DisplayAlert("CFE Mensaje", "No puede agregar más del inventario existente", "ok");
            }
            else
            {
                LblFaltante.Text=Convert.ToString(cf);
            }
        }

        private async void GuardarInfo_Clicked(object sender, EventArgs e)
        {
            string cb = "0";
            int numerror = 0;
            string cm = Convert.ToString(LblMalEstado.Text);
            string cf = Convert.ToString(LblFaltante.Text);
            string observacionidM = "";
            string observacionidF = "";
            try
            {
                observacionidM= Convert.ToString(Application.Current.Properties["IdObM"]);
                observacionidF= Convert.ToString(Application.Current.Properties["IdObF"]);
            }
            catch (Exception)
            {
                numerror = numerror + 1;
            }
            if (numerror >= 1)
            {
                await DisplayAlert("CFE Mensaje", "Las observaciones son necesarias", "Ok");
            }
            else
            {
                string numfo = "vacio";
                string respon = "TRIMESTRAL";
                string uriservice = RestService.Authority + Methods.Inspeccion + "UserID=" + GUsuID + "&InventarioID=" + GInvent + "&MInventarioEstadoID=" + GinventaEst + "&ObservacionIDM=" + observacionidM+ "&ObservacionIDF=" +observacionidF + "&cantidadB=" + cb + "&cantidadM=" + cm + "&cantidadF=" + cf + "&Responsable=" + respon + "&NumeroFolio=" + numfo;
                try
                {
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
                catch (Exception ex)
                {
                    await DisplayAlert("CFE Mensaje",ex.Message,"Ok");
                }
            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Application.Current.Properties.Remove("IdObM");
            Application.Current.Properties.Remove("IdObF");
        }
    }
}