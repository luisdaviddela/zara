using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp.View.Home.Inspeccion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupInspeccion : Rg.Plugins.Popup.Pages.PopupPage
    {
        private static readonly HttpClient client = new HttpClient();
        List<M_CuadrillasZona> info = new List<M_CuadrillasZona>();

        public ObservableCollection<M_CuadrillasZona> Cuadrillas;
        public PopupInspeccion()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.PopupInspeccionViewModel();
            InformacionCuadrilla();
        }
        public async void InformacionCuadrilla()
        {
            string IDZona = Convert.ToString( Application.Current.Properties["ZonaID"]);
            
            string URLservise = RestService.Authority + Methods.Cuadrillaszona+ "ZonaID="+IDZona;
            var resposeString = await client.GetStringAsync(URLservise);
            try
            {
                string resp = Convert.ToString(resposeString);
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);

                List<M_CuadrillasZona> Observable = JsonConvert.DeserializeObject<List<M_CuadrillasZona>>(data);
                Cuadrillas = new ObservableCollection<M_CuadrillasZona>(Observable);
                
                for (int i = 0; i < Cuadrillas.Count; i++)
                {
                    //string valueResponsableCuadrilla = $"{Cuadrillas[i].rpeResponsable} / {Cuadrillas[i].Nombre}";
                    string valueResponsableCuadrilla = Convert.ToString(Cuadrillas[i].Nombre);
                    PickerNombres.Items.Add(valueResponsableCuadrilla);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("CFE Mensaje:", ex.Message, "Ok");
            }
        }

        private void PickerNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = sender as Picker;
            if (Application.Current.Properties.ContainsKey("IdUsuarioResp"))
            {
                Application.Current.Properties.Remove("IdUsuarioResp");
            }
            var idresponsable = pic.SelectedItem;

            try
            {
                string IdResp = (from pair in Cuadrillas
                                 where pair.Nombre == idresponsable.ToString()
                                 select pair.UsuarioID).First();

                Application.Current.Properties["IdUsuarioResp"] = IdResp;
            }
            catch (Exception)
            {
                if (Application.Current.Properties.ContainsKey("IdUsuarioResp"))
                {
                    Application.Current.Properties.Remove("IdUsuarioResp");
                }
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string PickNames = Convert.ToString(PickerNombres.SelectedItem);
            string pickYear = Convert.ToString(PickerAnio.SelectedItem);
            string pickTrim = Convert.ToString(pickTrimestre.SelectedItem);

            Application.Current.Properties["Anio"] = PickerAnio.SelectedItem;
            Application.Current.Properties["Trimestre"] = pickTrimestre.SelectedItem;
            if (PickNames!= "" && pickYear != "" && pickTrim != "")
            {
                await App.Current.MainPage.Navigation.PopAllPopupAsync(true);
                await App.MasterDetail.Detail.Navigation.PushAsync(new View.Home.Inspeccion.InspeccionTrimestral());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("CFE mensaje","Todos los campos son necesarios","ok");
            }
        }
    }
        
}