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
        public List<string> AvailableAssets { get; set; } = new();
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
                Console.WriteLine($"{rate.Brocker} {rate.Symbol} {rate.AcquiredAt} {rate.Rate}");
            }
        }

        public async Task ChangeSymbol(string baseAsset, string quoteAsset)
        {
            Console.WriteLine($"Model: changing symbol to {baseAsset}-{quoteAsset}");
            foreach (var brocker in Brockers)
            {
                await brocker.ChangeSymbol(baseAsset, quoteAsset);
            }
        }

        public async Task<string> GetAssets()
        {
            Console.WriteLine("Getting symbols");
            string response = "";
            AvailableAssets.Clear();
            foreach (var brocker in Brockers)
            {
                try
                {
                    var symb = await brocker.GetAvailableAssets();
                    AvailableAssets.AddRange(symb);
                    foreach (var symbol in symb)
                        Console.WriteLine(symbol);
                }
                catch (OperationCanceledException ex)
                {
                    response += $"Error: {ex.Message}";
                }
            }
            Console.WriteLine("Finished");
            AvailableAssets = AvailableAssets.Distinct().Order().ToList();
            if (string.IsNullOrEmpty(response))
                response = "Success";
            return response;
        }
    }
}
