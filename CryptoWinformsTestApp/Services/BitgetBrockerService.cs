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
        public override async Task<List<string>> GetAvailableSymbols()
        {
            var exchangeInfo = await RestClient.SpotApiV2.ExchangeData.GetSymbolsAsync();
            return exchangeInfo.Data.Select(x => x.Symbol).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = SocketClient.SpotApiV2.SharedClient;
        }
    }
}
