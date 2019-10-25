using GreatQuotes.Data;
using System.Collections.ObjectModel;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly QuoteManager quoteManager;

        public MainViewModel()
        {
            quoteManager = QuoteManager.Instance;
            Quotes = quoteManager.Quotes as ObservableCollection<GreatQuoteViewModel>;
        }

        public GreatQuoteViewModel ItemSelected { get; set; }

        public ObservableCollection<GreatQuoteViewModel> Quotes { get; set; }

        public void SaveQuotes()
        {
            quoteManager.Save();
        }

        public void SayQuotes(GreatQuoteViewModel quote)
        {
            quoteManager.SayQuote(quote);
        }
    }
}