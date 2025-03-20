namespace CryptoWinformsTestApp
{
    partial class Form1
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
            RatesDGrid = new DataGridView();
            SymbolCmb = new ComboBox();
            label1 = new Label();
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
            SymbolCmb.Location = new Point(142, 31);
            SymbolCmb.Name = "SymbolCmb";
            SymbolCmb.Size = new Size(121, 23);
            SymbolCmb.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 34);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Выберите пару";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(SymbolCmb);
            Controls.Add(RatesDGrid);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)RatesDGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView RatesDGrid;
        private ComboBox SymbolCmb;
        private Label label1;
    }
}
