using FlagData;
using FlagFacts.Extensions;
using System;
using System.Collections;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FlagFacts
{
    public partial class MainPage : ContentPage
    {
        private int currentFlag;
        private FlagRepository repository;

        public MainPage()
        {
            InitializeComponent();

            // Load our data
            repository = new FlagRepository();

            // Setup the view
            InitializeData();
        }

        public Flag CurrentFlag
        {
            get
            {
                return repository.Flags[currentFlag];
            }
        }

        private void InitializeData()
        {
            country.ItemsSource = (IList)repository.Countries;

            flagImage.Source = CurrentFlag.GetImageSource();

            BindingContext = CurrentFlag;
        }

        private void OnMoreInformation(object sender, EventArgs e)
        {
            Launcher.OpenAsync(CurrentFlag.MoreInformationUrl);
        }

        private void OnNext(object sender, EventArgs e)
        {
            currentFlag++;
            if (currentFlag >= repository.Flags.Count)
                currentFlag = repository.Flags.Count - 1;
            InitializeData();
        }

        private void OnPrevious(object sender, EventArgs e)
        {
            currentFlag--;
            if (currentFlag < 0)
                currentFlag = 0;
            InitializeData();
        }

        private async void OnShow(object sender, EventArgs e)
        {
            await DisplayAlert(CurrentFlag.Country,
                $"{CurrentFlag.DateAdopted:D} - {CurrentFlag.IncludesShield}: {CurrentFlag.MoreInformationUrl}",
                "OK");
        }
    }
}