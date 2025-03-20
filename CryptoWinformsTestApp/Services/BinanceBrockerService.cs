using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class BinanceBrockerService : BaseBrockerService<BinanceSocketClient>
    {
        public BinanceBrockerService() : base(new BinanceSocketClient())
        {
            
        }

        public override async Task<List<string>> GetAvailableSymbols()
        {
            var restClient = new BinanceRestClient();
            var exchangeInfo = await restClient.SpotApi.ExchangeData.GetExchangeInfoAsync();
            return exchangeInfo.Data.Symbols.Select(x => x.Name).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = Client.SpotApi.SharedClient;
        }
    }
}
