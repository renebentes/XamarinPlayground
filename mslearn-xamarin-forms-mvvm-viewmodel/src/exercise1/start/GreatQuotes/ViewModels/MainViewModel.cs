using GreatQuotes.Data;
using GreatQuotes.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        private QuoteViewModel _selectedQuote;

        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(
                QuoteManager.Load()
                            .Select(q => new QuoteViewModel(q)));
        }

        public IList<QuoteViewModel> Quotes { get; private set; }

        public QuoteViewModel SelectedQuote
        {
            get { return _selectedQuote; }
            set { SetPropertyValue(ref _selectedQuote, value); }
        }
    }
}