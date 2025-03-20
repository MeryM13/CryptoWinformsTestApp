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

        // public List<string> AvailableSymbols { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Symbol
        {
            get => symbolTxt.Text;
            set
            {
                symbolTxt.Text = value;
                //SymbolCmb.SelectedItem = value; 
            }
        }
        public List<CryptoData> Rates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public System.Windows.Forms.Timer RatesUpdateTimer { get => RatesTimer; set => RatesTimer = value; }

        public event Action UpdateAvailableSymbols;
        public event Action OnSymbolChanged;
        public event Action UpdateRates;

        public void ShowError(string ErrorMessage)
        {
            MessageBox.Show(ErrorMessage);
        }

        private void UpdateAvailableSymbolsBtn_Click(object sender, EventArgs e)
        {
           // UpdateAvailableSymbols();
        }

        private void SymbolCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
           // OnSymbolChanged();
        }

        private void RatesTimer_Tick(object sender, EventArgs e)
        {
            UpdateRates();
        }
    }
}
