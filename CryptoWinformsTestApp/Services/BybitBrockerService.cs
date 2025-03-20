using Binance.Net.Clients;
using Bybit.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class BybitBrockerService : BaseBrockerService<BybitSocketClient, BybitRestClient>
    {
        public BybitBrockerService() : base (new BybitSocketClient(), new BybitRestClient())
        {
            
        }

        public async override Task<List<string>> GetAvailableAssets()
        {
            var exchangeInfo = await RestClient.V5Api.ExchangeData.GetSpotSymbolsAsync();
            if (exchangeInfo.Data != null)
            {
                var bases = exchangeInfo.Data.List.Select(x => x.BaseAsset).ToList();
                var quotes = exchangeInfo.Data.List.Select(x => x.QuoteAsset).ToList();
                return bases.Union(quotes).Distinct().ToList();
            }
            return [];
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.V5SpotApi.SharedClient;
        }
    }
}
