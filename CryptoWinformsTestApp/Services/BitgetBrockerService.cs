using Bitget.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class BitgetBrockerService : BaseBrockerService<BitgetSocketClient, BitgetRestClient>
    {
        public BitgetBrockerService() : base (new BitgetSocketClient(), new BitgetRestClient())
        {
            
        }
        public override async Task<List<string>> GetAvailableAssets()
        {
            var exchangeInfo = await RestClient.SpotApiV2.ExchangeData.GetSymbolsAsync();
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
            SharedClient = SocketClient.SpotApiV2.SharedClient;
        }
    }
}
