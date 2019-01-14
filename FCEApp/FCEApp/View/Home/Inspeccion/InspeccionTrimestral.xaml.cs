using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCEApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zumero;

namespace FCEApp.View.Home.Inspeccion
{

    public partial class InspeccionTrimestral
    {
        public static int IndexClasificacion = 0;
        
		public InspeccionTrimestral ()
		{
			InitializeComponent ();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.CurrentPageChanged += (object sender, EventArgs e) =>
            {
                var i = this.Children.IndexOf(this.CurrentPage);
                IndexClasificacion = Convert.ToInt32(i);
            };


            datagridHerramientas.Rows = InspeccionTrimestralViewModel.GetHerramientas();
            datagridEPrueba.Rows = InspeccionTrimestralViewModel.GetEqHerramientas();
            datagridHMenor.Rows = InspeccionTrimestralViewModel.GetHMenor();
            datagridHMayor.Rows = InspeccionTrimestralViewModel.GetHMayor();
            datagridLineaviva.Rows = InspeccionTrimestralViewModel.GetLineaViva();
            datagridESeguimiento.Rows = InspeccionTrimestralViewModel.GetEqSeg();
            
        }

        private void SwitchGuardar_OnChanged(object sender, ToggledEventArgs e)
        {
            //true = encendido
            if (e.Value)
            {
                DisplayAlert("Mensaje", "Cambios Guardados", "ok");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int counter = 0;
            var dt = datagridHerramientas.Rows.ToList();
            var val = dt[1];
            DisplayAlert("ds",Convert.ToString(val),"d");
        }

        //private async void Picker_Focused(object sender, FocusEventArgs e)
        //{
        //    var picker = sender as Picker;
        //    var tt = picker.Title;
        //}

    }
}




    
