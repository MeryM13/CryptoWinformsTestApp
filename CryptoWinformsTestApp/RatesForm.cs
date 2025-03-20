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

        public string Symbol
        {
            get => SymbolCmb.SelectedItem.ToString();
            set
            {
                try
                {
                    SymbolCmb.SelectedItem = value;
                }
                catch { }
            }
        }

        public List<string> AvailableSymbols
        {
            set
            {
                SymbolCmb.Items.Clear();
                foreach (string symbol in value)
                {
                    SymbolCmb.Items.Add(symbol);
                }
            }
        }

        public List<CryptoData> Rates
        {
            set
            {
                RatesDGrid.DataSource = value;
                RatesDGrid.Refresh();
            }
        }

        public event Action SetAvailableSymbols;
        public event Action ChangeSymbol;
        public event Action SetRates;

        public void ShowError(string ErrorMessage)
        {
            MessageBox.Show(ErrorMessage);
        }

        private void UpdateAvailableSymbolsBtn_Click(object sender, EventArgs e)
        {
            SetAvailableSymbols?.Invoke();
            SymbolCmb.SelectedIndex = 1;
        }

        private void SymbolCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSymbol?.Invoke();
            SetRates?.Invoke();
        }

        private void RatesTimer_Tick(object sender, EventArgs e)
        {
            SetRates?.Invoke();
        }

        public void LoadInitialData()
        {
            SetAvailableSymbols?.Invoke();
        }
    }
}
