using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
namespace FCEApp.ViewModel
{
   public class InspeccionTrimestralViewModel
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

        public static InspeccionTrimestralViewModel[] GetHerramientas()
        {
            int cantidadRows = 0;
            List<M_EquipoHerramienta> equipoherramienta = new List<M_EquipoHerramienta>();
            string UsuarioID = Convert.ToString(Application.Current.Properties["IdUsuarioResp"]);
            string zonaID = Convert.ToString(Application.Current.Properties["ZonaID"]);
            string Clasificacion = "43D6B390-6323-4A64-B6E5-44E2C2E0B2BF";


            string URlService = RestService.Authority + Methods.Inventariotrimestral+ "ZonaID="+ zonaID + "&ClasificacionId=" + Clasificacion + "&UsuarioID="+UsuarioID;
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
                            UnidadHerramienta = Convert.ToString( equipoherramienta[i].DescUnidad),
                            CantidadHerramienta = equipoherramienta[i].Cantidad.ToString(),
                            MalEstadoHerramienta = 0
                        };
                    }
                    return herramientas;
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

