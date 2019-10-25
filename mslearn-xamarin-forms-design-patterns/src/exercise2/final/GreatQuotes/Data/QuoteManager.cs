using GreatQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {
        private readonly IQuoteLoader _loader;
        private readonly ITextToSpeech _textToSpeech;

        public QuoteManager(IQuoteLoader loader, ITextToSpeech textToSpeech)
        {
            if (Instance != null)
            {
                throw new Exception("Can only create a single QuoteManager.");
            }

            _loader = loader;
            _textToSpeech = textToSpeech;
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public static QuoteManager Instance { get; private set; }

        public IList<GreatQuoteViewModel> Quotes { get; private set; }

        public void Save()
        {
            _loader.Save(Quotes);
        }

        public void SayQuote(GreatQuoteViewModel quote)
        {
            if (quote == null)
                throw new ArgumentNullException("No quote set");

            var text = quote.QuoteText;

            if (!string.IsNullOrWhiteSpace(quote.Author))
                text += $" by {quote.Author}";

            _textToSpeech.Speak(text);
        }
    }
}