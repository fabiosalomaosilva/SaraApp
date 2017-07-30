using System.Collections.ObjectModel;
using SaraApp.Helpers;
using SaraApp.Models;
using SaraApp.Services;

namespace SaraApp.ViewModels
{
    public class FaqViewModel : ObservableObject
    {
        private FaqDataStore _db;
        private Faq _faq;
        private ObservableCollection<Faq> _faqs;
        private string _titulo;

        public Faq Faq
        {
            get => _faq;
            set => SetProperty(ref _faq, value);
        }
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        public ObservableCollection<Faq> Faqs
        {
            get => _faqs;
            set => SetProperty(ref _faqs, value);
        }

        public FaqViewModel()
        {
            _db = new FaqDataStore();
            ListarFaqs();
            Titulo = "Faq";
        }

        private async void ListarFaqs()
        {
            var lista = await _db.GetItemsAsync();
            Faqs = new ObservableCollection<Faq>(lista);
        }
    }
}