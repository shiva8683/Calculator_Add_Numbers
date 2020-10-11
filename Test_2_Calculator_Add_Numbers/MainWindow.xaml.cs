using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace Test_2_Calculator_Add_Numbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Taking input text and passing it to the "Add" service and appending the result to the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CalculatorService.CalculatorClient calculatorClient = new CalculatorService.CalculatorClient();
                var addResult = calculatorClient.Add(Regex.Unescape(txtInput.Text));
                lblResult.Foreground = Brushes.Black;
                lblResult.Content = $"Sum of the Numbers: {addResult}";
            }
            catch (Exception ex)
            {
                lblResult.Foreground = Brushes.Red;
                lblResult.Content = ex.Message;
            }
        }
    }
}
