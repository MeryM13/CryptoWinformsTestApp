using CryptoWinformsTestApp.Interfaces.RatesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Presenters
{
    internal class RatesPresenter : BasePresenter<IRatesView>
    {
        public RatesPresenter(IRatesView view) : base(view)
        {

        }


    }
}
