using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients.SpotApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class BinanceBrockerService : BaseBrockerService<BinanceSocketClient, BinanceRestClient>
    {
        public BinanceBrockerService() : base(new BinanceSocketClient(), new BinanceRestClient())
        {
            
        }

        public override async Task<List<string>> GetAvailableSymbols()
        {
            var exchangeInfo = await RestClient.SpotApi.ExchangeData.GetExchangeInfoAsync();
            return exchangeInfo.Data.Symbols.Select(x => x.Name).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.SpotApi.SharedClient;
        }
    }
}
