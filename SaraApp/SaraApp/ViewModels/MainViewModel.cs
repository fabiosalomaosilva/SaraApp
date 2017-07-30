using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaraApp.Helpers;
using SaraApp.Models;
using SaraApp.Services;

namespace SaraApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private PatologiaDataStore _db;
        private Patologia _patologia;
        private ObservableCollection<Patologia> _patologias;
        private string _titulo;

        public Patologia Patologia
        {
            get => _patologia;
            set => SetProperty(ref _patologia, value);
        }
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public ObservableCollection<Patologia> Patologias
        {
            get => _patologias;
            set => SetProperty(ref _patologias, value);
        }

        public MainViewModel()
        {
            _db = new PatologiaDataStore();
            ListarPatologias();
            Titulo = "Patologias";
        }

        private async void ListarPatologias()
        {
            var lista = await _db.GetItemsAsync();
            Patologias = new ObservableCollection<Patologia>(lista);
        }
    }
}
