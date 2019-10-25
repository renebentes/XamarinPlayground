using GreatQuotes.ViewModels;
using System.Collections.Generic;

namespace GreatQuotes.Interfaces
{
    public interface IQuoteLoader
    {
        IEnumerable<GreatQuoteViewModel> Load();

        void Save(IEnumerable<GreatQuoteViewModel> quotes);
    }
}