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
            int ide = Convert.ToInt32(obj.Codigo);
            DisplayAlert("ds",Convert.ToString(ide),"ds");
        }
    }
}




    
