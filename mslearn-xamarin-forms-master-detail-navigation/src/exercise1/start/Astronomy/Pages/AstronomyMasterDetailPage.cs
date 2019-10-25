using Xamarin.Forms;

namespace Astronomy.Pages
{
    public class AstronomyMasterDetailPage : MasterDetailPage
    {
        public AstronomyMasterDetailPage()
        {
            var master = new AstronomyMasterPage();

            if (Device.RuntimePlatform == Device.iOS)
            {
                master.IconImageSource = ImageSource.FromFile("nav-menu-icon.png");
            }

            Master = master;

            Detail = new NavigationPage(new AboutPage());

            MasterBehavior = MasterBehavior.Popover;
        }
    }
}