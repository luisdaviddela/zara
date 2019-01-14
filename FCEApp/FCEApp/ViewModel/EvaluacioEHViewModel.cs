using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using FCEApp.View.Home.Evaluacion;

namespace FCEApp.ViewModel
{
    public class EvaluacioEHViewModel
    {
        public string CodigoHerramienta { get; set; }
        public String DescripcionHerramienta { get; set; }
        public String UnidadHerramienta { get; set; }
        public String CantidadHerramienta { get; set; }
        public int MalEstadoHerramienta{ get; set; }
        public String ObservacionesHerramienta { get; set; }
        public int FaltanteHerramienta { get; set; }
        public String ObservacionesFaltante { get; set; }

        public static EvaluacioEHViewModel[] GetDataList()
        {
            return new EvaluacioEHViewModel[]
            {
                new EvaluacioEHViewModel {CodigoHerramienta ="457868", DescripcionHerramienta="SOLDADURA 650 DE 3/32 PARA ACERO INOXIDA", UnidadHerramienta="KG", CantidadHerramienta="1", MalEstadoHerramienta= 0},
                new EvaluacioEHViewModel {CodigoHerramienta ="816283", DescripcionHerramienta="DADO CORTO 10 MM ENTRADA 3/8 PGD 6P", UnidadHerramienta="PZ", CantidadHerramienta="2",  MalEstadoHerramienta= 0},
                new EvaluacioEHViewModel {CodigoHerramienta ="684774", DescripcionHerramienta="LLAVE INGLESA DE 12", UnidadHerramienta="PZ", CantidadHerramienta="2",  MalEstadoHerramienta= 0},
            };
        }

    }
    public class EvaluacionEHViewModel
    { 
    public static Page GetMainPage()
        {
            return new EvaluacionEH();
        }
    }
}
