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

        public override async Task<List<string>> GetAvailableAssets()
        {
            var exchangeInfo = await RestClient.SpotApi.ExchangeData.GetExchangeInfoAsync();
            if (exchangeInfo.Data != null)
            {
                var bases = exchangeInfo.Data.Symbols.Select(x => x.BaseAsset).ToList();
                var quotes = exchangeInfo.Data.Symbols.Select(x => x.QuoteAsset).ToList();
                return bases.Union(quotes).Distinct().ToList();
            }
            return [];
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.SpotApi.SharedClient;
        }
    }
}
