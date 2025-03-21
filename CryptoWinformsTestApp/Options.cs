using CryptoExchange.Net.SharedApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp
{
    internal static class Options
    {
        public static bool DebugMode { get; set; } = false;
        public static SharedSymbol DefaultSymbol { get; set; } = new(TradingMode.Spot, "BTC", "USDT");
        public static int DefaultTimerDelay { get; set; } = 5;
    }
}
