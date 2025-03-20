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
        List<CryptoData> Rates { get; set; }
      //  List<string> AvailableSymbols { get; set; }
        string Symbol {  get; set; }
        System.Windows.Forms.Timer RatesUpdateTimer { get; set; }

       // event Action UpdateAvailableSymbols;
       // event Action OnSymbolChanged;
        event Action UpdateRates;
    }
}
