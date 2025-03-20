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
        public string AssetFrom { get; set; } = "BTC";
        public string AssetTo { get; set; } = "USDT";
        public List<CryptoData> Rates { get; set; } = new();

        public async Task<string> ActivateBrockers()
        {
            string response = "";
            foreach (var brocker in Brockers)
            {
                brocker.OpenConnection();
            }
            if (string.IsNullOrEmpty(response))
                response = "Success";
            Console.WriteLine(response);
            return response;
        }

        public async Task GetData()
        {
            Console.WriteLine("Getting rates");
            Rates.Clear();
            foreach (var brocker in Brockers)
            {
                var rate = brocker.GetRate();
                Rates.Add(rate);
                Console.WriteLine($"{rate.Brocker} {rate.AcquiredAt} {rate.Rate}");
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

        public async Task<string> GetSymbols()
        {
            Console.WriteLine("Getting symbols");
            string response = "";
            AvailableSymbols.Clear();
            foreach (var brocker in Brockers)
            {
                try
                {
                    var symb = await brocker.GetAvailableSymbols();
                    AvailableSymbols.AddRange(symb);
                    foreach (var symbol in symb)
                        Console.WriteLine(symbol);
                }
                catch (OperationCanceledException ex)
                {
                    response += $"Error: {ex.Message}";
                }
            }
            Console.WriteLine("Finished");
            AvailableSymbols = AvailableSymbols.Distinct().ToList();
            if (string.IsNullOrEmpty(response))
                response = "Success";
            return response;
        }
    }
}
