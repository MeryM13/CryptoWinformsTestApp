using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Models
{
    internal class LoginModel
    {
        public List<string> AvailableSymbols = new();
        public string SymbolPair { get; set; } = string.Empty;
        public List<CryptoData> Rates { get; set; } = new();

        public void GetData()
        {

        }

        public void GetSymbols()
        {

        }
    }
}
