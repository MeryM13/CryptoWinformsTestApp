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
        public List<IBrockerService> Brockers { get; set; } = [];
        public List<string> AvailableAssets { get; set; } = [];
        public List<CryptoData> Rates { get; set; } = [];

        public async Task ActivateBrockers()
        {
            foreach (var brocker in Brockers)
            {
                await brocker.OpenConnection();
            }
        }

        public async Task GetData()
        {
            if (Options.DebugMode)
                Console.WriteLine("Getting rates");

            Rates.Clear();
            foreach (var brocker in Brockers)
            {
                var rate = brocker.GetRate();
                Rates.Add(rate);

                if (Options.DebugMode)
                    Console.WriteLine($"{rate.Brocker} {rate.Symbol} {rate.AcquiredAt} {rate.Rate}");
            }
        }

        public async Task ChangeSymbol(string baseAsset, string quoteAsset)
        {
            if (Options.DebugMode)
                Console.WriteLine($"Model: changing symbol to {baseAsset}-{quoteAsset}");

            foreach (var brocker in Brockers)
            {
                await brocker.ChangeSymbol(baseAsset, quoteAsset);
            }
        }

        public async Task<string> GetAssets()
        {
            if (Options.DebugMode)
                Console.WriteLine("Getting symbols");

            string response = "";

            AvailableAssets.Clear();
            foreach (var brocker in Brockers)
            {
                try
                {
                    var symb = await brocker.GetAvailableAssets();
                    AvailableAssets.AddRange(symb);

                    if (Options.DebugMode)
                        foreach (var symbol in symb)
                            Console.WriteLine(symbol);
                }
                catch (OperationCanceledException ex)
                {
                    response += $"Error: {ex.Message}";
                }
            }
            if (Options.DebugMode)
                Console.WriteLine("Finished");

            AvailableAssets = [.. AvailableAssets.Distinct().Order()];

            if (string.IsNullOrEmpty(response))
                response = "Success";

            return response;
        }
    }
}
