using System;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        private Button callButton;
        private Entry phoneNumberText;
        private Button translateButton;
        private string translatedNumber;

        public MainPage()
        {
            Padding = new Thickness(20);

            StackLayout panel = new StackLayout() { Spacing = 15 };

            panel.Children.Add(new Label { Text = "Enter a Phoneword", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) });

            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN",
            });

            panel.Children.Add(translateButton = new Button
            {
                Text = "Translate"
            });

            panel.Children.Add(callButton = new Button
            {
                Text = "Call",
                IsEnabled = false,
            });

            translateButton.Clicked += OnTranslate;

            Content = panel;
        }

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = phoneNumberText.Text;
            translatedNumber = PhoneworldTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                // TODO:
            }
            else
            {
                // TODO:
            }
        }
    }
}