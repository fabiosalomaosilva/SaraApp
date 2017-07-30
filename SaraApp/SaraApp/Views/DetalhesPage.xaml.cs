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
    public partial class DetalhesPage : ContentPage
    {
        public DetalhesPage()
        {
            InitializeComponent();
            var vm = new AcaoViewModel();
            vm.Acao = App.Objeto as Acao;
            BindingContext = vm;
            if (vm.Acao != null && vm.Acao.Recomendacao)
            {
                vm.Autorizado = true;
                vm.NaoAutorizado = false;
            }
            if (vm.Acao == null || vm.Acao.Recomendacao == false)
            {
                vm.Autorizado = false;
                vm.NaoAutorizado = true;
            }
        }
        


    }
}