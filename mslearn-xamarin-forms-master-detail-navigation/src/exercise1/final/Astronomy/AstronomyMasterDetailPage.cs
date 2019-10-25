﻿using Astronomy.Enums;
using Astronomy.Pages;
using Xamarin.Forms;

namespace Astronomy
{
    public class AstronomyMasterDetailPage : MasterDetailPage
    {
        public AstronomyMasterDetailPage()
        {
            var master = new AstronomyMasterPage();
            master.PageSelected += Master_PageSelected;
            PresentDetailPage(PageType.Sunrise);

            if (Device.RuntimePlatform == Device.iOS)
            {
                master.IconImageSource = ImageSource.FromFile("nav-menu-icon.png");
            }

            this.Master = master;

            this.MasterBehavior = MasterBehavior.Popover;

            this.Detail = new NavigationPage(new AboutPage());
        }

        private void Master_PageSelected(object sender, PageType e)
        {
            PresentDetailPage(e);
        }

        private void PresentDetailPage(PageType pageType)
        {
            Page page;

            switch (pageType)
            {
                case PageType.Sunrise:
                    page = new SunrisePage();
                    break;

                case PageType.MoonPhase:
                    page = new MoonPhasePage();
                    break;

                case PageType.Earth:
                    page = new AstronomicalBodyPage(SolarSystemData.Earth);
                    break;

                case PageType.Moon:
                    page = new AstronomicalBodyPage(SolarSystemData.Moon);
                    break;

                case PageType.Sun:
                    page = new AstronomicalBodyPage(SolarSystemData.Sun);
                    break;

                case PageType.About:
                default:
                    page = new AboutPage();
                    break;
            }

            Detail = new NavigationPage(page);
            IsPresented = false;
        }
    }
}