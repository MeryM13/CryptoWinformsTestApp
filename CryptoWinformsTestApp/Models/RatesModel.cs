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
        public string SymbolPair { get; set; } = string.Empty;
        public List<CryptoData> Rates { get; set; } = new();

        //public void GetData()
        //{
        //    Rates.Clear();
        //}

        //public void GetSymbols()
        //{
        //    AvailableSymbols.Clear();
        //    foreach (var brocker in Brockers)
        //    {
        //        AvailableSymbols.AddRange(brocker.GetAvailableSymbols());
        //    }
        //    AvailableSymbols = AvailableSymbols.Distinct().ToList();
        //}
    }
}
