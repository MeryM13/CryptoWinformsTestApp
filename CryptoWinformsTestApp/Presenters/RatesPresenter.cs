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
        readonly RatesModel _model = new();
        public RatesPresenter(IRatesView view, List<IBrockerService> brokerServices) : base(view)
        {
            _model.Brockers = brokerServices;

            View.GetAvailableAssets += async () => await OnGetAvailableAssets();
            View.GetCurrentRates += async () => await OnGetCurrentRates();
            View.ChangeSymbol += async () => await OnChangeSymbol(View.BaseAsset, View.QuoteAsset);

            View.LoadInitialData();
        }

        async Task OnGetAvailableAssets()
        {
            View.StopTimer();
            var response = await _model.GetAssets();
            if (response == "Success")
            {
                View.AvailableBaseAssets = _model.AvailableAssets;
                View.AvailableQuoteAssets = _model.AvailableAssets;

                await OnChangeSymbol(Options.DefaultSymbol.BaseAsset, Options.DefaultSymbol.QuoteAsset);
            }
            else
            {
                View.ShowError(response);
            }
            View.StartTimer();
        }

        async Task OnGetCurrentRates()
        {
            await _model.GetData();

            View.Rates = _model.Rates;
        }

        async Task OnChangeSymbol(string baseAsset, string quoteAsset)
        {
            if (!string.IsNullOrEmpty(baseAsset) && !string.IsNullOrEmpty(quoteAsset))
            {
                if (Options.DebugMode)
                    Console.WriteLine($"Presenter: changing symbol to {View.BaseAsset}-{View.QuoteAsset}");

                View.StopTimer();

                await _model.ChangeSymbol(baseAsset, quoteAsset);

                View.StartTimer();

                await OnGetCurrentRates();
            }
        }
    }
}
