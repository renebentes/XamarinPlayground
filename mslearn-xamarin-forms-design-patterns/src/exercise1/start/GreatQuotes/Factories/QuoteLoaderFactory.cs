using GreatQuotes.Interfaces;
using System;

namespace GreatQuotes.Factories
{
    public class QuoteLoaderFactory
    {
        public static Func<IQuoteLoader> Create { get; set; }
    }
}