using CryptoWinformsTestApp.Interfaces.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Presenters
{
    internal class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }

        public BasePresenter(TView view)
        {
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }
}
