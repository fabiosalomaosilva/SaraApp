using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SaraApp.Models;
using SaraApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaraApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPage : ContentPage
    {
        public AreaPage()
        {
            InitializeComponent();

            BindingContext = new AreaViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Area;
            if (item == null)
            {
                return;
            }

            App.NavigationId = item.Id;
            App.Objeto = item;

            await Navigation.PushAsync(new Acoes());

            ListaPatologias.SelectedItem = null;
        }
    }
}