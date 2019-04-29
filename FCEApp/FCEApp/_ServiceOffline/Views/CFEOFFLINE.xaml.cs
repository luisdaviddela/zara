using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FCEApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CFEOFFLINE
    {
        public CFEOFFLINE()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainOfflineViewModel BindingCont = new MainOfflineViewModel();
            listViewH.ItemsSource = BindingCont.CardDataCollection;
            listViewEqP.ItemsSource = BindingCont.CardDataCollectionEqPrueba;
            listViewHMen.ItemsSource = BindingCont.CardDataCollectionHmenor;
            listViewHMay.ItemsSource = BindingCont.CardDataCollectionHmayor;
            listViewLinV.ItemsSource = BindingCont.CardDataCollectionLineaSViva;
            listViewEqS.ItemsSource = BindingCont.CardDataCollectionEqSeg;

        }
        private void EvetClicked(object s, SelectedItemChangedEventArgs e)
        {
            //var obj = (M_EquipoHerramienta)e.SelectedItem;
            //string UsuarioID = Convert.ToString(Application.Current.Properties["UsuarioId"]);
            //string InventarioID = Convert.ToString(obj.InventarioID);
            //string CantidadEx = Convert.ToString(obj.Cantidad);
            //string MInventarioEstadoID = Convert.ToString(obj.MInventarioEstadoID);
            //string Codigo = Convert.ToString(obj.Codigo);
            //string NombreH = Convert.ToString(obj.Descripcion);

            //App.MasterDetail.Detail.Navigation.PushAsync(new UI_DetalleHerramienta(UsuarioID, InventarioID, MInventarioEstadoID, CantidadEx, Codigo, NombreH));
        }
    }
}