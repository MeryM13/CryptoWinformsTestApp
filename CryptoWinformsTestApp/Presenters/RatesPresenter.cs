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
            _ = _model.ActivateBrockers();

            View.SetAvailableSymbols += () => OnSetAvailableSymbols();
            View.SetRates += () => OnSetRates();
            View.ChangeSymbol += () => OnChangeSymbol();

            View.LoadInitialData();

            View.Symbol = _model.AssetFrom + _model.AssetTo;
        }

        async void OnSetAvailableSymbols()
        {
            var response = await _model.GetSymbols();
            if (response == "Success")
            {
                View.AvailableSymbols = _model.AvailableSymbols;
            }
            else
            {
                View.ShowError(response);
            }
        }

        async void OnSetRates()
        {
            await _model.GetData();
            View.Rates = _model.Rates;
        }

        async void OnChangeSymbol()
        {

        }
    }
}
