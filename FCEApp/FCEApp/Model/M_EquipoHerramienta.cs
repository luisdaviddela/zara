using System;
using System.Collections.Generic;
using System.Text;

namespace FCEApp
{
    public class M_EquipoHerramienta
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string CatalogoID { get; set; }
        public string ClasificacionID { get; set; }
        public string UnidadMedidaID { get; set; }
        public bool Status { get; set; }
        public string DescUnidad { get; set; }
        public string MUsuarioInventarioID { get; set; }
        public string InventarioID { get; set; }
        public string MInventarioEstadoID { get; set; }
        public int cantB { get; set; }
        public int cantM { get; set; }
        public int cantF { get; set; }
    }
}
