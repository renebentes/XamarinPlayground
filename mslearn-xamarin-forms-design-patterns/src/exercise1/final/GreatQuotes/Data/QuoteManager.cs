using GreatQuotes.Services;
using GreatQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {
        private static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        private readonly IQuoteLoader loader;

        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public static QuoteManager Instance { get => instance.Value; }

        public IList<GreatQuoteViewModel> Quotes { get; set; }

        public void Save()
        {
            loader.Save(Quotes);
        }

        public void SayQuote(GreatQuoteViewModel quote)
        {
            if (quote == null)
            {
                throw new ArgumentException("no quote set");
            }

            ITextToSpeech textToSpeech = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            if (textToSpeech != null)
            {
                var text = quote.QuoteText;

                if (!string.IsNullOrWhiteSpace(quote.Author))
                {
                    text += $" by {quote.Author}";
                }

                textToSpeech.Speak(text);
            }
        }
    }
}