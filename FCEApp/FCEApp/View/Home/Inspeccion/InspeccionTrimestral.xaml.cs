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
            ToolbarItem itemStudy = new ToolbarItem
            {
                Icon = "sara.png",
                Text="Finalizar",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(() => Navigation.PushAsync(new UI_ObservacionesAdicionales()))
            };
            ToolbarItems.Add(itemStudy);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InspeccionTrimestralViewModel BindingCont = new InspeccionTrimestralViewModel();
            listViewH.ItemsSource = BindingCont.CardDataCollection;
            listViewEqP.ItemsSource = BindingCont.CardDataCollectionEqPrueba;
            listViewHMen.ItemsSource = BindingCont.CardDataCollectionHmenor;
            listViewHMay.ItemsSource = BindingCont.CardDataCollectionHmayor;
            listViewLinV.ItemsSource = BindingCont.CardDataCollectionLineaSViva;
            listViewEqS.ItemsSource = BindingCont.CardDataCollectionEqSeg;
        }
        private void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {
            var obj = (M_EquipoHerramienta)e.SelectedItem;
            string UsuarioID = Convert.ToString(Application.Current.Properties["UsuarioId"]);
            string InventarioID = Convert.ToString(obj.InventarioID);
            string CantidadEx = Convert.ToString(obj.Cantidad);
            string MInventarioEstadoID = Convert.ToString(obj.MInventarioEstadoID);
            string Codigo = Convert.ToString(obj.Codigo);
            string NombreH = Convert.ToString(obj.Descripcion);

            App.MasterDetail.Detail.Navigation.PushAsync(new UI_DetalleHerramienta(UsuarioID, InventarioID, MInventarioEstadoID, CantidadEx, Codigo, NombreH));
        }
    }
}




    
