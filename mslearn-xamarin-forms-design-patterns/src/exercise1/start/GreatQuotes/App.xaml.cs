using GreatQuotes.Managers;
using GreatQuotes.ViewModels;
using GreatQuotes.Views;
using Xamarin.Forms;

namespace GreatQuotes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GreatQuotesViewModel = new MainViewModel();
            MainPage = new NavigationPage(new QuoteListPage());
        }

        public static MainViewModel GreatQuotesViewModel { get; internal set; }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            QuoteManager.Instance.Save();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}