using System.Collections.ObjectModel;
using System.Linq;
using SaraApp.Helpers;
using SaraApp.Models;
using SaraApp.Services;

namespace SaraApp.ViewModels
{
    public class AreaViewModel : ObservableObject
    {
        private AreaDataStore _db;
        private Area _area;
        private Patologia _patologia;
        private ObservableCollection<Area> _areas;
        private string _titulo;

        public Area Area
        {
            get => _area;
            set => SetProperty(ref _area, value);
        }
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }
        public Patologia Patologia
        {
            get => _patologia;
            set => SetProperty(ref _patologia, value);
        }
        public ObservableCollection<Area> Areas
        {
            get => _areas;
            set => SetProperty(ref _areas, value);
        }

        public AreaViewModel()
        {
            _db = new AreaDataStore();
            ListarAreas();
            Titulo = "Área de saúde";
            Patologia = App.Objeto as Patologia;
        }

        private async void ListarAreas()
        {
            var lista = await _db.GetItemsAsync();
            Areas = new ObservableCollection<Area>(lista.Where(p => p.PatologiaID == App.NavigationId).OrderBy(p => p.Nome).ToList());
        }
    }
}