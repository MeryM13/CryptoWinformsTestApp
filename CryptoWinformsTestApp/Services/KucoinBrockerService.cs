using Kucoin.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class KucoinBrockerService : BaseBrockerService<KucoinSocketClient, KucoinRestClient>
    {
        public KucoinBrockerService() : base(new KucoinSocketClient(), new KucoinRestClient())
        {
            
        }
        public override async Task<List<string>> GetAvailableAssets()
        {
            var exchangeInfo = await RestClient.SpotApi.ExchangeData.GetSymbolsAsync();
            if (exchangeInfo.Data != null)
            {
                var bases = exchangeInfo.Data.Select(x => x.BaseAsset).ToList();
                var quotes = exchangeInfo.Data.Select(x => x.QuoteAsset).ToList();
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
