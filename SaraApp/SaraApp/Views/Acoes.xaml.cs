using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaraApp.Models;
using SaraApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaraApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Acoes : TabbedPage
    {
        public Acoes()
        {
            InitializeComponent();
            BindingContext = new AcaoViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Acao;
            if (item == null)
            {
                return;
            }

            App.NavigationId = item.Id;
            App.Objeto = item;

            await Navigation.PushAsync(new DetalhesPage());

            ListaRecomendados.SelectedItem = null;
            ListaNaoRecomendados.SelectedItem = null;
        }
    }
}