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
        RatesModel _model;
        public RatesPresenter(IRatesView view, List<IBrockerService> brokerServices) : base(view)
        {
            _model.Brockers = brokerServices;
        }


    }
}
