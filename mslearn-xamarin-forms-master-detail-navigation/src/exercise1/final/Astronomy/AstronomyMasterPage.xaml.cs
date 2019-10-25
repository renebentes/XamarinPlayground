using Astronomy.Enums;
using System;
using Xamarin.Forms;

namespace Astronomy
{
    public partial class AstronomyMasterPage : ContentPage
    {
        public AstronomyMasterPage()
        {
            InitializeComponent();

            btnMoonPhase.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.MoonPhase);
            btnSunrise.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Sunrise);
            btnAbout.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.About);

            btnEarth.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Earth);
            btnMoon.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Moon);
            btnSun.Clicked += (s, e) => PageSelected?.Invoke(this, PageType.Sun);
        }

        public event EventHandler<PageType> PageSelected;
    }
}