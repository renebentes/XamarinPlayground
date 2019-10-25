using GreatQuotes.ViewModels;
using System;

using Xamarin.Forms;

namespace GreatQuotes.Views
{
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage()
        {
            InitializeComponent();
            BindingContext = App.GreatQuotesViewModel.ItemSelected;
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private void Handle_Tapped(object sender, EventArgs e)
        {
            App.GreatQuotesViewModel.SayQuotes(BindingContext as GreatQuoteViewModel);
        }

        private async void Handle_ToolbarItem_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PushModalAsync(new NavigationPage(new EditQuotePage()));
        }
    }
}