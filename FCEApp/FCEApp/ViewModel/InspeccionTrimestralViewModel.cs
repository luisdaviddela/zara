using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FCEApp.ViewModel
{
    public class InspeccionTrimestralViewModel: INotifyPropertyChanged
    {
        public static string IdClasificacion = "";
        public string CodigoHerramienta { get; set; }
        public String DescripcionHerramienta { get; set; }
        public String UnidadHerramienta { get; set; }
        public String CantidadHerramienta { get; set; }
        public int MalEstadoHerramienta { get; set; }
        public String ObservacionesHerramienta { get; set; }
        public int FaltanteHerramienta { get; set; }
        public String ObservacionesFaltante { get; set; }
        //-----------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        
        public IList<M_EquipoHerramienta> CardDataCollection { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacion;

        public IList<M_EquipoHerramienta> CardDataCollectionEqPrueba { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacionEqPrueba;

        public IList<M_EquipoHerramienta> CardDataCollectionHmenor { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacionHmenor;

        public IList<M_EquipoHerramienta> CardDataCollectionHmayor { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacionHmayor;

        public IList<M_EquipoHerramienta> CardDataCollectionLineaSViva { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacionLineaSViva;

        public IList<M_EquipoHerramienta> CardDataCollectionEqSeg { get; set; }
        private ObservableCollection<M_EquipoHerramienta> aprobacionEqSeg;

        public InspeccionTrimestralViewModel()
        {
            CardDataCollection = new List<M_EquipoHerramienta>();
            CardDataCollectionEqPrueba = new List<M_EquipoHerramienta>();
            CardDataCollectionHmenor = new List<M_EquipoHerramienta>();
           
            GenerateCardModel();
            GenerateCardModelEqPrueba();
            GenerateCardModelHmenor();
            GenerateCardModelHmayor();
            GenerateCardModelLineasVivsa();
            GenerateCardModelEqSeg();
        }

        public void GenerateCardModel()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "43D6B390-6323-4A64-B6E5-44E2C2E0B2BF";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;
                
                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacion = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacion)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollection.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);
                
            }

        }
        public void GenerateCardModelEqPrueba()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "9FD80E90-DC34-47C0-A16C-45E864B5A63F";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacionHmenor = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacionHmenor)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollectionEqPrueba.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);

            }

        }
        public void GenerateCardModelHmenor()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "A814A21C-CD2D-4394-AFED-4B97EEB34236";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacionHmenor = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacionHmenor)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollectionHmenor.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);

            }

        }
        public void GenerateCardModelHmayor()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "CF46F328-48B4-42B3-A056-4D517C6AAB81";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacionHmayor = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacionHmayor)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollectionHmayor.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);

            }

        }
        public void GenerateCardModelLineasVivsa()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "C2E747F0-B538-49A7-9BB3-B09B695A25F5";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacionLineaSViva = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacionLineaSViva)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollectionLineaSViva.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);

            }

        }
        public void GenerateCardModelEqSeg()
        {
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "3A7700C4-1B88-4DEE-80C1-D32469FAE2C6";
            try
            {
                string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
                HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

                string resp;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    resp = reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject<object>(resp);
                    string data = Convert.ToString(obj);
                    List<M_EquipoHerramienta> Observable = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                    aprobacionEqSeg = new ObservableCollection<M_EquipoHerramienta>(Observable);
                    foreach (var item in aprobacionEqSeg)
                    {

                        var cardDataAprobaciones = new M_EquipoHerramienta()
                        {
                            Codigo = item.
                            Codigo,
                            Descripcion = item.
                            Descripcion,
                            DescUnidad = $"Unidad: {item.DescUnidad}",
                            Cantidad = item.
                            Cantidad
                        };
                        CardDataCollectionEqSeg.Add(cardDataAprobaciones);
                    }
                }
            }
            catch (Exception ex)
            {
                //DependencyService.Get<IMessage>().ShortAlert(ex.Message);

            }

        }
        public static InspeccionTrimestralViewModel[] GetEqHerramientas()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "9FD80E90-DC34-47C0-A16C-45E864B5A63F";


            string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
            HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                data = Convert.ToString(obj);
                equipoherramienta = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                cantidadRows = equipoherramienta.Count;

                InspeccionTrimestralViewModel[] herramientas = new InspeccionTrimestralViewModel[cantidadRows];

                for (int i = 0; i < cantidadRows; i++)
                {
                    herramientas[i] = new InspeccionTrimestralViewModel()
                    {
                        CodigoHerramienta = Convert.ToString(equipoherramienta[i].Codigo),
                        DescripcionHerramienta = equipoherramienta[i].Descripcion,
                        UnidadHerramienta = Convert.ToString(equipoherramienta[i].DescUnidad),
                        CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                        MalEstadoHerramienta = 0
                    };
                }
                return herramientas;
            }
        }
        public static InspeccionTrimestralViewModel[] GetHMenor()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "A814A21C-CD2D-4394-AFED-4B97EEB34236";


            string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
            HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                data = Convert.ToString(obj);
                equipoherramienta = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                cantidadRows = equipoherramienta.Count;

                InspeccionTrimestralViewModel[] herramientas = new InspeccionTrimestralViewModel[cantidadRows];

                for (int i = 0; i < cantidadRows; i++)
                {
                    herramientas[i] = new InspeccionTrimestralViewModel()
                    {
                        CodigoHerramienta = Convert.ToString(equipoherramienta[i].Codigo),
                        DescripcionHerramienta = equipoherramienta[i].Descripcion,
                        UnidadHerramienta = Convert.ToString(equipoherramienta[i].DescUnidad),
                        CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                        MalEstadoHerramienta = 0
                    };
                }
                return herramientas;
            }
        }
        public static InspeccionTrimestralViewModel[] GetHMayor()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "CF46F328-48B4-42B3-A056-4D517C6AAB81";


            string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
            HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                data = Convert.ToString(obj);
                equipoherramienta = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                cantidadRows = equipoherramienta.Count;

                InspeccionTrimestralViewModel[] herramientas = new InspeccionTrimestralViewModel[cantidadRows];

                for (int i = 0; i < cantidadRows; i++)
                {
                    herramientas[i] = new InspeccionTrimestralViewModel()
                    {
                        CodigoHerramienta = Convert.ToString(equipoherramienta[i].Codigo),
                        DescripcionHerramienta = equipoherramienta[i].Descripcion,
                        UnidadHerramienta = Convert.ToString(equipoherramienta[i].DescUnidad),
                        CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                        MalEstadoHerramienta = 0
                    };
                }
                return herramientas;
            }
        }
        public static InspeccionTrimestralViewModel[] GetLineaViva()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "C2E747F0-B538-49A7-9BB3-B09B695A25F5";


            string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
            HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                data = Convert.ToString(obj);
                equipoherramienta = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                cantidadRows = equipoherramienta.Count;

                InspeccionTrimestralViewModel[] herramientas = new InspeccionTrimestralViewModel[cantidadRows];

                for (int i = 0; i < cantidadRows; i++)
                {
                    herramientas[i] = new InspeccionTrimestralViewModel()
                    {
                        CodigoHerramienta = Convert.ToString(equipoherramienta[i].Codigo),
                        DescripcionHerramienta = equipoherramienta[i].Descripcion,
                        UnidadHerramienta = Convert.ToString(equipoherramienta[i].DescUnidad),
                        CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                        MalEstadoHerramienta = 0
                    };
                }
                return herramientas;
            }
        }
        public static InspeccionTrimestralViewModel[] GetEqSeg()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "3A7700C4-1B88-4DEE-80C1-D32469FAE2C6";


            string URlService = RestService.Authority + Methods.Inventariotrimestral + "ZonaID=" + zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID=" + UsuarioID;
            HttpWebRequest request = WebRequest.Create(URlService) as HttpWebRequest;

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string data = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                data = Convert.ToString(obj);
                equipoherramienta = JsonConvert.DeserializeObject<List<M_EquipoHerramienta>>(data);
                cantidadRows = equipoherramienta.Count;

                InspeccionTrimestralViewModel[] herramientas = new InspeccionTrimestralViewModel[cantidadRows];

                for (int i = 0; i < cantidadRows; i++)
                {
                    herramientas[i] = new InspeccionTrimestralViewModel()
                    {
                        CodigoHerramienta = Convert.ToString(equipoherramienta[i].Codigo),
                        DescripcionHerramienta = equipoherramienta[i].Descripcion,
                        UnidadHerramienta = Convert.ToString(equipoherramienta[i].DescUnidad),
                        CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                        MalEstadoHerramienta = 0
                    };
                }
                return herramientas;
            }
        }
    }
}

