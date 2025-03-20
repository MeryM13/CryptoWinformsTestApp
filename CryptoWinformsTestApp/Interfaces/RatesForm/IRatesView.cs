using CryptoWinformsTestApp.Interfaces.Bases;
using CryptoWinformsTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Interfaces.RatesForm
{
    internal interface IRatesView : IView
    {
        string Symbol { get; set; }
        List<string> AvailableSymbols { set; }
        List<CryptoData> Rates { set; }

        void LoadInitialData();

        event Action SetAvailableSymbols;
        event Action ChangeSymbol;
        event Action SetRates;
    }
}
