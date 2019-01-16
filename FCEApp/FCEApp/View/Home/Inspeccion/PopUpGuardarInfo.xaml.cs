using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpGuardarInfo : Rg.Plugins.Popup.Pages.PopupPage
    {
        private static readonly HttpClient client = new HttpClient();
        List<M_Observaciones> info = new List<M_Observaciones>();
        string GUsuID = "", GInvent = "", GinventaEst = "";
        public ObservableCollection<M_Observaciones> Observ;
        public PopUpGuardarInfo (string UsuarioID,string InventarioID,string MInventarioEstadoID, string cantidadEx)
		{
			InitializeComponent ();
            GUsuID = UsuarioID;
            GInvent = InventarioID;
            GinventaEst = MInventarioEstadoID;
            InformacionCuadrilla();
            Cantidadlbl.Text=$"Cantidad: {cantidadEx}";
            GuardarInfo.IsEnabled = false;
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
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int cb= Convert.ToInt32( CanB.Text);
            int cm= Convert.ToInt32( CanM.Text);
            int cf= Convert.ToInt32( CanF.Text);
            string respon = responsableentry.Text;
            string numfo = "vacio";
            string obsrvacionid = Convert.ToString(Application.Current.Properties["IdObservacionSess"]);
            string uriservice = RestService.Authority + Methods.Inspeccion+ "UserID="+ GUsuID+ "&InventarioID="+GInvent+ "&MInventarioEstadoID="+GinventaEst+ "&ObservacionID="+ obsrvacionid+ "&cantidadB="+cb+ "&cantidadM="+cm+ "&cantidadF="+cf+ "&Responsable="+ respon+ "&NumeroFolio="+ numfo;
            try
            {
                var resposeString = await client.GetStringAsync(uriservice);
                string resp = Convert.ToString(resposeString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                await Application.Current.MainPage.DisplayAlert("CFE mensaje", data, "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("CFE mensaje", ex.Message, "Ok");   
            }
        }
    }
}