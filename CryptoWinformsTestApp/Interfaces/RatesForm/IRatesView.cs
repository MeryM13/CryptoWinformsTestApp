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
        string BaseAsset { get; set; }
        string QuoteAsset { get; set; }
        List<string> AvailableBaseAssets { set; }
        List<string> AvailableQuoteAssets { set; }
        List<CryptoData> Rates { set; }
        void LoadInitialData();
        void StopTimer();
        void StartTimer();

        public event Action GetAvailableAssets;
        public event Action ChangeSymbol;
        public event Action GetCurrentRates;
    }
}
