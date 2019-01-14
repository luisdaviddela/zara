using System;
using System.Collections.Generic;
using System.Text;

namespace FCEApp
{
    public class M_Usuario
    {
        public string RPE { get; set; }
        public string Nombre { get; set; }
        public string Division { get; set; }
        public string Zona { get; set; }
        public string Area { get; set; }
        public string NoEconomico { get; set; }
        public byte[] Foto { get; set; }

        public string ZonaID { get; set; }
        public string AreaID { get; set; }
        public string DivisionID { get; set; }
        public string UbicacionID { get; set; }
    }
}
