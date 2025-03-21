using CryptoWinformsTestApp.Interfaces;
using CryptoWinformsTestApp.Interfaces.RatesForm;
using CryptoWinformsTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Presenters
{
    internal class RatesPresenter : BasePresenter<IRatesView>
    {
        RatesModel _model = new();
        public RatesPresenter(IRatesView view, List<IBrockerService> brokerServices) : base(view)
        {
            _model.Brockers = brokerServices;

            View.GetAvailableAssets += () => OnGetAvailableAssets();
            View.GetCurrentRates += () => OnGetCurrentRates();
            View.ChangeSymbol += () => OnChangeSymbol(View.BaseAsset, View.QuoteAsset);

            View.LoadInitialData();

            //_ = _model.ActivateBrockers();
        }

        async void OnGetAvailableAssets()
        {
            var response = await _model.GetAssets();
            if (response == "Success")
            {
                View.AvailableBaseAssets = _model.AvailableAssets;
                View.AvailableQuoteAssets = _model.AvailableAssets;
            }
            else
            {
                View.ShowError(response);
            }
        }

        async void OnGetCurrentRates()
        {
            await _model.GetData();
            View.Rates = _model.Rates;
        }

        async void OnChangeSymbol(string baseAsset, string quoteAsset)
        {
            if (!string.IsNullOrEmpty(baseAsset) && !string.IsNullOrEmpty(quoteAsset))
            {
                Console.WriteLine($"Presenter: changing symbol to {View.BaseAsset}-{View.QuoteAsset}");
                await _model.ChangeSymbol(baseAsset, quoteAsset);
                View.ResetTimer();
                OnGetCurrentRates();
            }
        }
    }
}
