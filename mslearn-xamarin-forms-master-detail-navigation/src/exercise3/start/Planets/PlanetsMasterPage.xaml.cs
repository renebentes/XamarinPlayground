using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Planets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanetsMasterPage : ContentPage
    {
        public PlanetsMasterPage()
        {
            InitializeComponent();

            MenuItemsListView.ItemSelected += MenuItemsListViewItemSelected;

            BindingContext = PlanetDataRepository.Planets;
        }

        public event EventHandler<int> MasterItemSelected;

        private void MenuItemsListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Planet planet = ((Planet)e.SelectedItem);
            MasterItemSelected?.Invoke(sender, planet.Id);
        }
    }
}