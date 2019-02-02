using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FCEApp.Model;
using FCEApp.View;
using FCEApp.ViewModel.Base;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FCEApp.ViewModel
{
   
    public class CustomMenuPageViewModel : BindableBase
    {
        private ObservableCollection<MenuModel> listCategories;
        public ObservableCollection<MenuModel> ListCategories
        {
            get { return listCategories; }
            set { SetProperty(ref listCategories, value); }
        }
        private MenuModel selectedCategories;
        public MenuModel SelectedCategories
        {
            get { return selectedCategories; }
            set
            {
                if (selectedCategories != value)
                {
                    SetProperty(ref selectedCategories, value);
                    OnTapSelectedCategories();
                }
            }
        }

        #region Constructor
        public CustomMenuPageViewModel()
        {
            TapCerrarSesionCommand = new Command(TapCerrarSesion);
            ListCategories = new ObservableCollection<MenuModel>();
            ListCategories.Add(new MenuModel
            {
                IdMenu = 1,
                TitleItemMenu = "Pérfil",
                ImageItemMenu = ""
            });
           
            ListCategories.Add(new MenuModel
            {
                IdMenu = 3,
                TitleItemMenu = "Inspección trimestral",
                ImageItemMenu = ""
            });
            //ListCategories.Add(new MenuModel
            //{
            //    IdMenu = 2,
            //    TitleItemMenu = "Obervaciones adicionales",
            //    ImageItemMenu = ""
            //});
        }
        #endregion

        #region Commands
        public ICommand TapCerrarSesionCommand { get; set; }
        #endregion

        #region Methods
        private void TapCerrarSesion()
        {
            try
            {
             
                App.Current.MainPage = new LoginPage();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private async void OnTapSelectedCategories()
        {
            if (SelectedCategories.IdMenu == 1)
            {
                App.MasterDetail.IsPresented = false;
            }
            else if (SelectedCategories.IdMenu == 2)
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new ObservacionesAdi_Pop());
            }
            else if (selectedCategories.IdMenu == 3)
            {
                App.MasterDetail.IsPresented = false;
                await App.MasterDetail.Detail.Navigation.PushAsync(new View.Home.Inspeccion.PopupInspeccion());
            }
        }
        #endregion
    }
}
