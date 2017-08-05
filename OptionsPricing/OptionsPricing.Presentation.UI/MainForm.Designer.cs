namespace OptionsPricing.Presentation.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.dataGridViewResuls = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResultPortfolio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResuls)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(72, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 29);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Options Pricing Calculator";
            // 
            // openFileDialogCsv
            // 
            this.openFileDialogCsv.FileName = "Choose your file";
            this.openFileDialogCsv.Filter = "Files|*.csv;*.xml;";
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(77, 106);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(188, 67);
            this.btnInputFile.TabIndex = 2;
            this.btnInputFile.Text = "Input File Data";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // dataGridViewResuls
            // 
            this.dataGridViewResuls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResuls.Location = new System.Drawing.Point(77, 301);
            this.dataGridViewResuls.Name = "dataGridViewResuls";
            this.dataGridViewResuls.RowTemplate.Height = 24;
            this.dataGridViewResuls.Size = new System.Drawing.Size(1262, 270);
            this.dataGridViewResuls.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Results per trade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Results for the portfolio:";
            // 
            // lblResultPortfolio
            // 
            this.lblResultPortfolio.AutoSize = true;
            this.lblResultPortfolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultPortfolio.Location = new System.Drawing.Point(360, 198);
            this.lblResultPortfolio.Name = "lblResultPortfolio";
            this.lblResultPortfolio.Size = new System.Drawing.Size(0, 29);
            this.lblResultPortfolio.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 691);
            this.Controls.Add(this.lblResultPortfolio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewResuls);
            this.Controls.Add(this.btnInputFile);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "Options Pricing Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResuls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialogCsv;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.DataGridView dataGridViewResuls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResultPortfolio;
    }
}