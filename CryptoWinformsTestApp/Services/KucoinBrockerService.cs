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
        public override async Task<List<string>> GetAvailableSymbols()
        {
            var exchangeInfo = await RestClient.SpotApi.ExchangeData.GetSymbolsAsync();
            return exchangeInfo.Data.Select(x => x.Name).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.SpotApi.SharedClient;
        }
    }
}
