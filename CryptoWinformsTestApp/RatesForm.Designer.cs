namespace CryptoWinformsTestApp
{
    partial class RatesForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            RatesDGrid = new DataGridView();
            BaseAssetsCmb = new ComboBox();
            label1 = new Label();
            UpdateAvailableSymbolsBtn = new Button();
            RatesTimer = new System.Windows.Forms.Timer(components);
            QuoteAssetsCmb = new ComboBox();
            UpdateRatesBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)RatesDGrid).BeginInit();
            SuspendLayout();
            // 
            // RatesDGrid
            // 
            RatesDGrid.AllowUserToAddRows = false;
            RatesDGrid.AllowUserToDeleteRows = false;
            RatesDGrid.AllowUserToOrderColumns = true;
            RatesDGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            RatesDGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RatesDGrid.Location = new Point(12, 118);
            RatesDGrid.Name = "RatesDGrid";
            RatesDGrid.ReadOnly = true;
            RatesDGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            RatesDGrid.Size = new Size(442, 307);
            RatesDGrid.TabIndex = 0;
            // 
            // BaseAssetsCmb
            // 
            BaseAssetsCmb.FormattingEnabled = true;
            BaseAssetsCmb.Location = new Point(225, 34);
            BaseAssetsCmb.Name = "BaseAssetsCmb";
            BaseAssetsCmb.Size = new Size(187, 23);
            BaseAssetsCmb.TabIndex = 1;
            BaseAssetsCmb.SelectedIndexChanged += BaseAssetsCmb_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(272, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Выберите пару";
            // 
            // UpdateAvailableSymbolsBtn
            // 
            UpdateAvailableSymbolsBtn.Location = new Point(53, 33);
            UpdateAvailableSymbolsBtn.Name = "UpdateAvailableSymbolsBtn";
            UpdateAvailableSymbolsBtn.Size = new Size(137, 23);
            UpdateAvailableSymbolsBtn.TabIndex = 4;
            UpdateAvailableSymbolsBtn.Text = "Загрузить символы";
            UpdateAvailableSymbolsBtn.UseVisualStyleBackColor = true;
            UpdateAvailableSymbolsBtn.Click += UpdateAvailableSymbolsBtn_Click;
            // 
            // RatesTimer
            // 
            RatesTimer.Interval = 5000;
            RatesTimer.Tick += RatesTimer_Tick;
            // 
            // QuoteAssetsCmb
            // 
            QuoteAssetsCmb.FormattingEnabled = true;
            QuoteAssetsCmb.Location = new Point(225, 72);
            QuoteAssetsCmb.Name = "QuoteAssetsCmb";
            QuoteAssetsCmb.Size = new Size(187, 23);
            QuoteAssetsCmb.TabIndex = 5;
            QuoteAssetsCmb.SelectedIndexChanged += QuoteAssetsCmb_SelectedIndexChanged;
            // 
            // UpdateRatesBtn
            // 
            UpdateRatesBtn.AutoSize = true;
            UpdateRatesBtn.Location = new Point(54, 70);
            UpdateRatesBtn.Name = "UpdateRatesBtn";
            UpdateRatesBtn.Size = new Size(136, 25);
            UpdateRatesBtn.TabIndex = 6;
            UpdateRatesBtn.Text = "Обновить данные";
            UpdateRatesBtn.UseVisualStyleBackColor = true;
            UpdateRatesBtn.Click += UpdateRatesBtn_Click;
            // 
            // RatesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 450);
            Controls.Add(UpdateRatesBtn);
            Controls.Add(QuoteAssetsCmb);
            Controls.Add(UpdateAvailableSymbolsBtn);
            Controls.Add(label1);
            Controls.Add(BaseAssetsCmb);
            Controls.Add(RatesDGrid);
            Name = "RatesForm";
            Text = "Курсы криптовалют";
            ((System.ComponentModel.ISupportInitialize)RatesDGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RatesDGrid;
        private ComboBox BaseAssetsCmb;
        private Label label1;
        private Button UpdateAvailableSymbolsBtn;
        private System.Windows.Forms.Timer RatesTimer;
        private ComboBox QuoteAssetsCmb;
        private Button UpdateRatesBtn;
    }
}
