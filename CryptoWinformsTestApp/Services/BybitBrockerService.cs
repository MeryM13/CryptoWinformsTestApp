﻿using Binance.Net.Clients;
using Bybit.Net.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal class BybitBrockerService : BaseBrockerService<BybitSocketClient>
    {
        public BybitBrockerService() : base (new BybitSocketClient())
        {
            
        }

        public async override Task<List<string>> GetAvailableSymbols()
        {
            var restClient = new BybitRestClient();
            var exchangeInfo = await restClient.V5Api.ExchangeData.GetSpotSymbolsAsync();
            return exchangeInfo.Data.List.Select(x => x.Name).ToList();
        }

        public override void GetSharedClient()
        {
            SharedClient = Client.V5SpotApi.SharedClient;
        }
    }
}
