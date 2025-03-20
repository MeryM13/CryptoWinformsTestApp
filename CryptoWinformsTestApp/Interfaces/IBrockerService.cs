using CryptoExchange.Net.SharedApis;
using CryptoWinformsTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Interfaces
{
    internal interface IBrockerService
    {
        void OpenConnection();
        bool CoonectionOpen();
        void CloseConnection();
        void ChangeSymbol(string baseAsset, string quoteAsset);
        CryptoData GetRate();
        Task<List<string>> GetAvailableAssets();
    }
}
