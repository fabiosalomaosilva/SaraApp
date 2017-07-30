using SaraApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SaraApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static string BackendUrl { get; set; } = "http://saraapi.azurewebsites.net/";
        public static int NavigationId { get; set; }
        public static object Objeto { get; set; }

        public static void SetMainPage()
        {
            Current.MainPage = new NavigationPage(new Main());
            /**
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Patologias",
                        Icon = Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "FAQ",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
            **/
        }
    }
}
