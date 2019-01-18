using System;
using System.Collections.Generic;
using System.Text;

namespace FCEApp
{
    public static class RestService
    {
        public static string Authority = "http://192.168.2.169/";
    }
    public static class HttpMethods
    {
        public static string Get = "GET";
        public static string Post = "POST";
        public static string PutModify = "PUT";
        public static string Patch = "PATCH";
        public static string Delete = "DELETE";
    }
    public static class Methods
    {
        public static string Login = "api/sesion/?";
        public static string Cuadrillaszona = "api/Cuadrillaszona/?";
        public static string Inventariotrimestral = "api/Inventariotrimestral/?";
        public static string Observaciones = "api/Observaciones/?Clave=";
        public static string Inspeccion = "api/Inspeccion/?";
    }
}
