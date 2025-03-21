using CryptoWinformsTestApp.Interfaces.RatesForm;
using CryptoWinformsTestApp.Models;

namespace CryptoWinformsTestApp
{
    public partial class RatesForm : Form, IRatesView
    {

        public RatesForm()
        {
            InitializeComponent();
        }

        public string BaseAsset
        {
            get => BaseAssetsCmb.SelectedItem?.ToString() ?? "";
            set
            {
                try
                {
                    BaseAssetsCmb.SelectedItem = value;
                    QuoteAssetsCmb.Items.Remove(BaseAsset);
                }
                catch { }
            }
        }

        public List<string> AvailableBaseAssets
        {
            set
            {
                BaseAssetsCmb.Items.Clear();
                foreach (string asset in value)
                {
                    BaseAssetsCmb.Items.Add(asset);
                }
                BaseAssetsCmb.Items.Remove(QuoteAsset);
            }
        }

        public string QuoteAsset
        {
            get => QuoteAssetsCmb.SelectedItem?.ToString() ?? "";
            set
            {
                try
                {
                    QuoteAssetsCmb.SelectedItem = value;
                    BaseAssetsCmb.Items.Remove(QuoteAsset);
                }
                catch { }
            }
        }

        public List<string> AvailableQuoteAssets
        {
            set
            {
                QuoteAssetsCmb.Items.Clear();
                foreach (string asset in value)
                {
                    QuoteAssetsCmb.Items.Add(asset);
                }
                QuoteAssetsCmb.Items.Remove(BaseAsset);
            }
        }

        public List<CryptoData> Rates
        {
            set
            {
                RatesDGrid.DataSource = value;
                RatesDGrid.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
                RatesDGrid.Refresh();
            }
        }

        public event Action GetAvailableAssets;
        public event Action ChangeSymbol;
        public event Action GetCurrentRates;

        public void ShowError(string ErrorMessage)
        {
            MessageBox.Show(ErrorMessage);
        }

        private void UpdateAvailableSymbolsBtn_Click(object sender, EventArgs e)
        {
            GetAvailableAssets?.Invoke();
        }

        private void RatesTimer_Tick(object sender, EventArgs e)
        {
            GetCurrentRates?.Invoke();
        }

        public void LoadInitialData()
        {
            GetAvailableAssets?.Invoke();
            BaseAssetsCmb.SelectedItem = "BTC";
            QuoteAssetsCmb.SelectedItem = "USDT";
            ChangeSymbol?.Invoke();
        }

        public void StopTimer()
        {
            RatesTimer.Stop();
        }

        public void StartTimer()
        {
            RatesTimer.Start();
        }

        private void BaseAssetsCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Base asset changing to {BaseAsset}");
            ChangeSymbol?.Invoke();
        }

        private void QuoteAssetsCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"Quote asset changing to {QuoteAsset}");
            ChangeSymbol?.Invoke();
        }

        private void UpdateRatesBtn_Click(object sender, EventArgs e)
        {
            GetCurrentRates?.Invoke();
        }
    }
}
