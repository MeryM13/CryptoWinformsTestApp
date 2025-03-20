using CryptoExchange.Net.SharedApis;
using CryptoWinformsTestApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Models
{
    internal class RatesModel
    {
        public List<IBrockerService> Brockers {get; set; } = new();
        public List<string> AvailableSymbols { get; set; } = new();
        public string AssetFrom { get; set; } = string.Empty;
        public string AssetTo { get; set; } = string.Empty;
        public List<CryptoData> Rates { get; set; } = new();

        public void GetData()
        {
            Rates.Clear();
            foreach (var brocker in Brockers)
            {
                Rates.Add(brocker.GetRate());
            }
        }

        public void ChangeSymbol()
        {
            var newSymbol = new SharedSymbol(TradingMode.Spot, AssetFrom, AssetTo);
            foreach (var brocker in Brockers)
            {
                brocker.ChangeSymbol(newSymbol);
            }
        }

        public async void GetSymbols()
        {
            AvailableSymbols.Clear();
            foreach (var brocker in Brockers)
            {
                AvailableSymbols.AddRange(await brocker.GetAvailableSymbols());
            }
            AvailableSymbols = AvailableSymbols.Distinct().ToList();
        }
    }
}
