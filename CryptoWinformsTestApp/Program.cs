using CryptoWinformsTestApp.Interfaces;
using CryptoWinformsTestApp.Presenters;
using CryptoWinformsTestApp.Services;

namespace CryptoWinformsTestApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //uncomment to enable console outputs
            //Options.DebugMode = true;

            List<IBrockerService> brockers = 
                [
                new BinanceBrockerService(),
                new BybitBrockerService(),
                new KucoinBrockerService(),
                new BitgetBrockerService()
                ];

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var view = new RatesForm();
            var presenter = new RatesPresenter(view, brockers);
            Application.Run(view);
        }
    }
}