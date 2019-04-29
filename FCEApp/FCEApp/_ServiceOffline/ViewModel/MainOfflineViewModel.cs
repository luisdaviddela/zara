using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace FCEApp
{
    public class MainOfflineViewModel : ReactiveObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //ReactiveList<Herramientas> _todos;
        //public ReactiveList<Herramientas> Todos
        //{
        //    get => _todos;
        //    set => this.RaiseAndSetIfChanged(ref _todos, value);
        //}
        //private Herramientas _selectedTodo;
        //public Herramientas SelectedTodo
        //{
        //    get => _selectedTodo;
        //    set => this.RaiseAndSetIfChanged(ref _selectedTodo, value);
        //}
        ServiceHerramientaDB _herramientasS;
        ServiceEqPruebasDB _eqPruebasS;
        ServiceHmenorDB _hMenorS;
        ServiceHmayor _hMayorS;
        ServiceLineaSVivaDB _lineaSVivaS;
        ServiceEqSegDB _eqSergS;

        public IList<Herramientas> CardDataCollection { get; set; }
        private ObservableCollection<Herramientas> aprobacion;
        public IList<EqPrueba> CardDataCollectionEqPrueba { get; set; }
        private ObservableCollection<EqPrueba> aprobacionEqPrueba;

        public IList<HMenor> CardDataCollectionHmenor { get; set; }
        private ObservableCollection<HMenor> aprobacionHmenor;

        public IList<HMayor> CardDataCollectionHmayor { get; set; }
        private ObservableCollection<HMayor> aprobacionHmayor;

        public IList<LineaSViva> CardDataCollectionLineaSViva { get; set; }
        private ObservableCollection<LineaSViva> aprobacionLineaSViva;

        public IList<EqSeg> CardDataCollectionEqSeg { get; set; }
        private ObservableCollection<EqSeg> aprobacionEqSeg;
        public MainOfflineViewModel()
        {
            _herramientasS = new ServiceHerramientaDB();
            _eqPruebasS = new ServiceEqPruebasDB();
            _hMenorS = new ServiceHmenorDB();
            _hMayorS = new ServiceHmayor();
            _lineaSVivaS = new ServiceLineaSVivaDB();
            _eqSergS = new ServiceEqSegDB();

            CardDataCollection = new List<Herramientas>();
            CardDataCollectionEqPrueba = new List<EqPrueba>();
            CardDataCollectionHmenor = new List<HMenor>();
            CardDataCollectionHmayor = new List<HMayor>();
            CardDataCollectionLineaSViva = new List<LineaSViva>();
            CardDataCollectionEqSeg = new List<EqSeg>();

            var todos = _herramientasS.ReadAllItems();
            var todoeqprueba = _eqPruebasS.ReadAllItems();
            var todoHmenor = _hMenorS.ReadAllItems();
            var todoHayor = _hMayorS.ReadAllItems();
            var todoLineaSviva = _lineaSVivaS.ReadAllItems();
            var todoEqSeg = _eqSergS.ReadAllItems();
            //var sg = todos.Count();
            //Application.Current.MainPage.DisplayAlert("dsa",sg.ToString(),"da");
            if (todos.Any())
            {
                //Todos = new ReactiveList<Herramientas>(todos) { ChangeTrackingEnabled = true };
                foreach (var item in todos)
                {
                    var cardDataAprobaciones = new Herramientas()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollection.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<Herramientas>() { ChangeTrackingEnabled = true };*/ }

            if (todoeqprueba.Any())
            {
                foreach (var item in todoeqprueba)
                {
                    var cardDataAprobaciones = new EqPrueba()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollectionEqPrueba.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<EqPrueba>() { ChangeTrackingEnabled = true }; */}
            if (todoHmenor.Any())
            {
                foreach (var item in todoHmenor)
                {
                    var cardDataAprobaciones = new HMenor()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollectionHmenor.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<EqPrueba>() { ChangeTrackingEnabled = true }; */}

            if (todoHayor.Any())
            {
                foreach (var item in todoHayor)
                {
                    var cardDataAprobaciones = new HMayor()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollectionHmayor.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<EqPrueba>() { ChangeTrackingEnabled = true }; */}
            if (todoLineaSviva.Any())
            {
                foreach (var item in todoLineaSviva)
                {
                    var cardDataAprobaciones = new LineaSViva()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollectionLineaSViva.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<EqPrueba>() { ChangeTrackingEnabled = true }; */}

            if (todoEqSeg.Any())
            {
                foreach (var item in todoEqSeg)
                {
                    var cardDataAprobaciones = new EqSeg()
                    {
                        Codigo = item.
                           Codigo,
                        Descripcion = item.
                           Descripcion,
                        DescUnidad = $"Unidad: {item.DescUnidad}",
                        Cantidad = item.
                           Cantidad,
                        MInventarioEstadoID = item.MInventarioEstadoID,
                        InventarioID = item.InventarioID
                    };
                    CardDataCollectionEqSeg.Add(cardDataAprobaciones);
                }
            }
            else { /*Todos = new ReactiveList<EqPrueba>() { ChangeTrackingEnabled = true }; */}
        }
    }
}
