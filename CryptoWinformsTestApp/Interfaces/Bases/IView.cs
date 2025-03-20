using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWinformsTestApp.Interfaces.Bases
{
    internal interface IView
    {
        void Show();
        void Close();
        void ShowError(string ErrorMessage);
    }
}
