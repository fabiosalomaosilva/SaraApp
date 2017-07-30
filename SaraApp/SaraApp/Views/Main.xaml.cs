using SaraApp.Models;
using SaraApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaraApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        private MainViewModel _mv;
        public Main()
        {
            _mv = new MainViewModel();
            this.BindingContext = _mv;
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Patologia;
            if (item == null)
            {
                return;
            }

            App.NavigationId = item.Id;
            App.Objeto = item;

            await Navigation.PushAsync(new AreaPage());

            ListaPatologias.SelectedItem = null;
        }
    }
}