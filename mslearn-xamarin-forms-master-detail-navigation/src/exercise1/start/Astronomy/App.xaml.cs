using Astronomy.Pages;
using Xamarin.Forms;

namespace Astronomy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AstronomyMasterDetailPage();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}