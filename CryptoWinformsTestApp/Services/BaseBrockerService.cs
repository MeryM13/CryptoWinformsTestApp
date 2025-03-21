using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
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

        bool _connectionOpen = false;
        SharedSymbol _sharedSymbol;
        CryptoData CryptoData = new();
        CancellationTokenSource _cancelTocken = new();

        public BaseBrockerService(TSocketClient socketClient, TRestClient restClient)
        {
            SocketClient = socketClient;
            SocketClient.ClientOptions.RequestTimeout = TimeSpan.FromSeconds(3);
            SocketClient.ClientOptions.RateLimiterEnabled = true;
            SocketClient.ClientOptions.RateLimitingBehaviour = RateLimitingBehaviour.Wait;

            RestClient = restClient;
            GetSharedClient();
        }

        public abstract void GetSharedClient();

        public async Task OpenConnection()
        {
            if (!_connectionOpen)
            {
                Console.WriteLine($"{SocketClient.Exchange} service: Opening connection");

                CryptoData = new()
                {
                    Brocker = SharedClient.Exchange,
                    Symbol = "not found",
                    Rate = -1,
                    AcquiredAt = DateTime.MinValue
                };

                _connectionOpen = true;
                var result = await SharedClient.SubscribeToTickerUpdatesAsync(new SubscribeTickerRequest(_sharedSymbol), update =>
                {
                    CryptoData = new()
                    {
                        Brocker = SharedClient.Exchange,
                        Symbol = update.Data.Symbol,
                        Rate = update.Data.LastPrice ?? 0,
                        AcquiredAt = update.ReceiveTime
                    };
                    Thread.Sleep(1000);
                }, _cancelTocken.Token);

                if (!result.Success)
                {
                    Console.WriteLine($"{SocketClient.Exchange} service: Connection failed, Error message: {result.Error}");
                }
                else
                {
                    Console.WriteLine($"{SocketClient.Exchange} service: Connection succesful, getting rates for: {_sharedSymbol.BaseAsset}-{_sharedSymbol.QuoteAsset}");
                }
            }
        }

        public async Task CloseConnection()
        {
            if (_connectionOpen)
            {
                Console.WriteLine($"{SocketClient.Exchange} service: Shuting down connection");
                _cancelTocken.Cancel();
                _cancelTocken = new();
                _connectionOpen = false;
            }
        }

        public bool CoonectionOpen()
        {
            return _connectionOpen;
        }

        public async Task ChangeSymbol(string baseAsset, string quoteAsset)
        {
            Console.WriteLine($"{SocketClient.Exchange} service: changing symbol to {baseAsset}-{quoteAsset}");
            if (_sharedSymbol?.BaseAsset != baseAsset || _sharedSymbol?.QuoteAsset != quoteAsset)
            {
                Console.WriteLine("Initiating change");
                _sharedSymbol = new SharedSymbol(TradingMode.Spot, baseAsset, quoteAsset);
                await CloseConnection();
                await OpenConnection();
            }
        }

        public abstract Task<List<string>> GetAvailableAssets();

        public CryptoData GetRate()
        {
            return CryptoData;
        }
    }
}
