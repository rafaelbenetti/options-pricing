using OptionsPricing.Application.FileReader;
using OptionsPricing.Application.FileReader.Base;
using OptionsPricing.Application.Models.BlackScholes;
using OptionsPricing.Application.Options;
using OptionsPricing.Infrastructure.Consts;
using OptionsPricing.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OptionsPricing.Presentation.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnInputFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogCsv.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    FileReaderTypeEnum fileReaderTypeEnum = GetFileReaderTypeFor(openFileDialogCsv.FileName);
                    IFileReader reader = FileReaderFactory.GetReader(fileReaderTypeEnum);
                    List<BlackScholesInput> blackScholesInputData = reader.Read<BlackScholesInput>(openFileDialogCsv.FileName);

                    var optionPricingCalculator = new BlackScholesCalculator();
                    List<BlackScholesResult> blackScholesResultData = optionPricingCalculator.CalculateFor(blackScholesInputData);

                    ShowResultsOnScreen(blackScholesResultData);
                }
                catch (Exception ex)
                {
                    string message = $"{ErrorsResource.ErrorToProcessData} Error: {ex.Message}";
                    MessageBox.Show(message, ErrorsResource.TitleErrorToProcessData, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowResultsOnScreen(List<BlackScholesResult> blackScholesResultData)
        {
            dataGridViewResuls.DataSource = blackScholesResultData;
            lblResultPortfolio.Text = blackScholesResultData.Sum((d) => d.Result).ToString("C");
        }

        private FileReaderTypeEnum GetFileReaderTypeFor(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            if (extension == FileExtensionConst.Csv)
                return FileReaderTypeEnum.Csv;

            return FileReaderTypeEnum.Xml;
        }
    }
}
