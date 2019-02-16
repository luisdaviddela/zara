using System;
using System.Windows.Input;
using FCEApp.ViewModel.Base;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
namespace FCEApp.ViewModel
{
    public class HomePageViewModel : BindableBase
    {
        public ICommand TapMenuHamburguerCommand { get; set; }
        private string nombre;
        private string zona;
        private string rpe;
        private string division;
        private string area;
        


        public HomePageViewModel()
        {
            TextHeader = "Perfil";
            TapMenuHamburguerCommand = new Command(TapMenuHamburguer);
            
            try
            {
                M_Usuario info = new M_Usuario();
                string UsuarioID = Convert.ToString(Application.Current.Properties["UsuarioId"]);
                string URlService = RestService.Authority + Methods.Login + "UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                string data = "";
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    data = Convert.ToString(obj);
                    info = JsonConvert.DeserializeObject<M_Usuario>(data);
                    try
                    {
                        nombre = info.Nombre;
                        zona = info.Zona;
                        rpe = info.RPE;
                        division = info.Division;
                        area = info.Area;
                        Application.Current.Properties["ZonaID"] = info.ZonaID; ;
                    }
                    catch (Exception ex)
                    {

                        Application.Current.MainPage.DisplayAlert("CFE Mensaje", ex.Message, "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("CFE Mensaje",ex.Message,"Ok");
            }
        }
        #region CargaInfo
        //public async void CargarPerfilUsuario()
        //{
        //    string UsuarioID= Convert.ToString(Application.Current.Properties["UsuarioId"]);
        //    string URlService = RestService.Authority+Methods.Login + "UsuarioID=" + UsuarioID;
        //    try
        //    {
        //        M_Usuario info = new M_Usuario();
        //        //await Application.Current.MainPage.DisplayAlert("Url",URlService,"ok");
        //        var responeString = await client.GetStringAsync(URlService);
        //        string resp = Convert.ToString(responeString);
        //        var obj = JsonConvert.DeserializeObject<object>(resp);
        //        string data = Convert.ToString(obj);
        //        info = JsonConvert.DeserializeObject<M_Usuario>(data);
        //        try
        //        {
        //            nombre= info.Nombre;
        //            zona= info.Zona;
        //            rpe = info.RPE;
        //            division = info.Division;
        //            area = info.Area;
        //        }
        //        catch (Exception ex)
        //        {

        //            await Application.Current.MainPage.DisplayAlert("CFE Mensaje", ex.Message, "Ok");
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #endregion
        public string RPE
        {

            get { return rpe; }
            set { rpe = value; }
        }
        public string NombreUsuario
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string  Division
        {
            get { return division; }
            set { division = value; }
        }
        public string Zona
        {
            get { return zona; }
            set { zona = value; }
        }
        public string Area
        {
            get { return area; }
            set { area = value; }
        }
        private string noeconomico;
        public string NoEconomico
        {
            get { return noeconomico; }
            set { noeconomico = value; }
        }
        //-------------------MENU TAP
        private void TapMenuHamburguer()
        {
            try
            {
                App.MasterDetail.IsPresented = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
