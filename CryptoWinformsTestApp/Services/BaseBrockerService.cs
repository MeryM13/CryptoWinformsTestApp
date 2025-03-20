using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoWinformsTestApp.Interfaces;
using CryptoWinformsTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Services
{
    internal abstract class BaseBrockerService<TSocketClient, TRestClient> : IBrockerService
        where TSocketClient : BaseSocketClient
        where TRestClient : BaseRestClient
    {
        public ITickerSocketClient SharedClient;
        public TSocketClient SocketClient;
        public TRestClient RestClient;

        bool _connectionOpen;
        SharedSymbol _sharedSymbol = new SharedSymbol(TradingMode.Spot, "BTC", "USDT");
        CryptoData CryptoData;
        CancellationTokenSource _cancelTocken = new();

        public BaseBrockerService(TSocketClient socketClient, TRestClient restClient)
        {
            SocketClient = socketClient;
            RestClient = restClient;
            GetSharedClient();
        }

        public abstract void GetSharedClient();

        public async void OpenConnection()
        {
            if (!_connectionOpen)
            {
                _connectionOpen = true;
                var result = await SharedClient.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(_sharedSymbol), update =>
                {
                    CryptoData = new CryptoData()
                    {
                        Brocker = SharedClient.Exchange,
                        Symbol = update.Data.Symbol,
                        Rate = update.Data.LastPrice ?? 0,
                        AcquiredAt = update.ReceiveTime
                    };
                    Thread.Sleep(1000);
                }, _cancelTocken.Token);

                if (!result.Success)
                    CryptoData = new()
                    {
                        Brocker = SharedClient.Exchange,
                        Symbol = "not found",
                        Rate = -1,
                        AcquiredAt = DateTime.MinValue
                    };
            }
        }

        public void CloseConnection()
        {
            if (_connectionOpen)
            {
                _cancelTocken.Cancel();
                _cancelTocken = new();
            }
        }

        public bool CoonectionOpen()
        {
            return _connectionOpen;
        }

        public void ChangeSymbol(string baseAsset, string quoteAsset)
        {
            var newSymbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
            if (_sharedSymbol != newSymbol)
            {
                _sharedSymbol = newSymbol;
                CloseConnection();
                OpenConnection();
            }
        }

        public abstract Task<List<string>> GetAvailableAssets();

        public CryptoData GetRate()
        {
            return CryptoData;
        }
    }
}
