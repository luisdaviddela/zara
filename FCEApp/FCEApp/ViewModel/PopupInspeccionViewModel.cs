using System;
using System.Windows.Input;
using FCEApp.ViewModel.Base;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace FCEApp.ViewModel
{
 public class PopupInspeccionViewModel : BindableBase
    {
        public PopupInspeccionViewModel()
        {
            
            ComenzarInspeccionCommand = new Command(ComenzarInspeccionCommandExecuted);
        }
        #region Commands
        public ICommand ComenzarInspeccionCommand { get; set; }
        #endregion
        #region Methods
        private async void ComenzarInspeccionCommandExecuted()
        {
            await App.Current.MainPage.Navigation.PopAllPopupAsync(true);
            await App.MasterDetail.Detail.Navigation.PushAsync(new View.Home.Inspeccion.InspeccionTrimestral());
        }
        #endregion
    }
}
