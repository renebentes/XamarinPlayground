using GreatQuotes.Factories;
using GreatQuotes.Interfaces;
using GreatQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes.Managers
{
    public class QuoteManager
    {
        private static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        private IQuoteLoader loader;

        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public static QuoteManager Instance => instance.Value;

        public IList<GreatQuoteViewModel> Quotes { get; set; }

        public void Save() => loader.Save(Quotes);
    }
}