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
	public partial class UI_ObservacionesAdicionales : ContentPage
	{
		public UI_ObservacionesAdicionales ()
		{
			InitializeComponent ();
            FinalizarBtn.IsEnabled = false;
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var KeyWord = ObsAdicion.Text;
            if (KeyWord.Length >3)
            {
                FinalizarBtn.IsEnabled = true;
            }
            else
            {
                FinalizarBtn.IsEnabled = false;
            }
        }
    }
}