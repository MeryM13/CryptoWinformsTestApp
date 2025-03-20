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

        public async override Task<List<string>> GetAvailableSymbols()
        {
            var exchangeInfo = await RestClient.V5Api.ExchangeData.GetSpotSymbolsAsync();
            return exchangeInfo.Data.List.Select(x => x.Name).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.V5SpotApi.SharedClient;
        }
    }
}
