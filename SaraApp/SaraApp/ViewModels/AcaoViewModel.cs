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
    public class AcaoViewModel : ObservableObject
    {
        private AcaoDataStore _db;
        private Acao _acao;
        private Area _area;
        private ObservableCollection<Acao> _recomendados;
        private ObservableCollection<Acao> _naoRecomendados;
        private string _titulo;
        private bool _autorizado;
        private bool _naoAutorizado;

        public Acao Acao
        {
            get => _acao;
            set => SetProperty(ref _acao, value);
        }
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
        public bool Autorizado
        {
            get => _autorizado;
            set => SetProperty(ref _autorizado, value);
        }
        public bool NaoAutorizado
        {
            get => _naoAutorizado;
            set => SetProperty(ref _naoAutorizado, value);
        }

        public ObservableCollection<Acao> Recomendados
        {
            get => _recomendados;
            set => SetProperty(ref _recomendados, value);
        }
        public ObservableCollection<Acao> NaoRecomendados
        {
            get => _naoRecomendados;
            set => SetProperty(ref _naoRecomendados, value);
        }

        public AcaoViewModel()
        {
            _db = new AcaoDataStore();
            ListarAcoes();
            Titulo = "Ações";
            Autorizado = false;
            NaoAutorizado = false;
        }

        private async void ListarAcoes()
        {
            var lista = await _db.GetItemsAsync();
            Recomendados = new ObservableCollection<Acao>(lista.Where(p => p.AreaID == App.NavigationId && p.Recomendacao));
            NaoRecomendados = new ObservableCollection<Acao>(lista.Where(p => p.AreaID == App.NavigationId && p.Recomendacao == false));
        }
    }
}
