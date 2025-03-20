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
            SymbolCmb = new ComboBox();
            label1 = new Label();
            symbolTxt = new TextBox();
            UpdateAvailableSymbolsBtn = new Button();
            RatesTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)RatesDGrid).BeginInit();
            SuspendLayout();
            // 
            // RatesDGrid
            // 
            RatesDGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RatesDGrid.Location = new Point(37, 118);
            RatesDGrid.Name = "RatesDGrid";
            RatesDGrid.Size = new Size(736, 307);
            RatesDGrid.TabIndex = 0;
            // 
            // SymbolCmb
            // 
            SymbolCmb.FormattingEnabled = true;
            SymbolCmb.Location = new Point(146, 74);
            SymbolCmb.Name = "SymbolCmb";
            SymbolCmb.Size = new Size(121, 23);
            SymbolCmb.TabIndex = 1;
            SymbolCmb.SelectedIndexChanged += SymbolCmb_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 77);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Выберите пару";
            // 
            // symbolTxt
            // 
            symbolTxt.Location = new Point(146, 45);
            symbolTxt.Name = "symbolTxt";
            symbolTxt.Size = new Size(100, 23);
            symbolTxt.TabIndex = 3;
            // 
            // UpdateAvailableSymbolsBtn
            // 
            UpdateAvailableSymbolsBtn.Location = new Point(308, 59);
            UpdateAvailableSymbolsBtn.Name = "UpdateAvailableSymbolsBtn";
            UpdateAvailableSymbolsBtn.Size = new Size(75, 23);
            UpdateAvailableSymbolsBtn.TabIndex = 4;
            UpdateAvailableSymbolsBtn.Text = "Load symbols";
            UpdateAvailableSymbolsBtn.UseVisualStyleBackColor = true;
            UpdateAvailableSymbolsBtn.Click += UpdateAvailableSymbolsBtn_Click;
            // 
            // RatesTimer
            // 
            RatesTimer.Interval = 5000;
            RatesTimer.Tick += RatesTimer_Tick;
            // 
            // RatesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateAvailableSymbolsBtn);
            Controls.Add(symbolTxt);
            Controls.Add(label1);
            Controls.Add(SymbolCmb);
            Controls.Add(RatesDGrid);
            Name = "RatesForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)RatesDGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RatesDGrid;
        private ComboBox SymbolCmb;
        private Label label1;
        private TextBox symbolTxt;
        private Button UpdateAvailableSymbolsBtn;
        private System.Windows.Forms.Timer RatesTimer;
    }
}
