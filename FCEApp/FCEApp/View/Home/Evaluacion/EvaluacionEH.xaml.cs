using FCEApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp.View.Home.Evaluacion
{
	
	public partial class EvaluacionEH 
    {
		public EvaluacionEH ()
		{
			InitializeComponent ();
            //this.CurrentPageChanged += (object sender, EventArgs e) => {
            //    var i = this.Children.IndexOf(this.CurrentPage);

            //    DisplayAlert("Mensjae", i.ToString(), "ok");
            //    System.Diagnostics.Debug.WriteLine("Page No:" + i);
            //};
        }

    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            datagrid.Rows = EvaluacioEHViewModel.GetDataList();
            this.CurrentPageChanged += (object sender, EventArgs e) =>
            {
                var i = this.Children.IndexOf(this.CurrentPage);

                DisplayAlert("Mensjae", i.ToString(), "ok");
                System.Diagnostics.Debug.WriteLine("Page No:" + i);
            };
        }
        private void SwitchGuardar_OnChanged (object sender, ToggledEventArgs e)
        {
            //true = encendido
            if (e.Value)
            {
                DisplayAlert("Mensaje", "Cambios Guardados", "ok");
            }
        }
    }
}