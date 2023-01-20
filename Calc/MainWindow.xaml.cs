using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Model.comboBoxOperations = comboBoxOperations;
            Model.GetComboBoxValue = 0;

            Model.textBoxFirstValue = textBoxFirstValue;
            Model.textBoxSecondValue = textBoxSecondValue;
            Model.textBlockResult = textBlockResult;

            Model.labelOperationSign = labelOperationSign;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            labelOperationSign.Content = Model.GetLabelOperationSign;
        }

        private void buttonCalc_Click(object sender, RoutedEventArgs e)
        {
            if (!Model.isCorrectValue(textBoxFirstValue.Text, textBoxSecondValue.Text))
                return;

            Model.GetSetFirstValue = Convert.ToDouble(textBoxFirstValue.Text);
            Model.GetSetSecondValue = Convert.ToDouble(textBoxSecondValue.Text);

            if (Model.isDivisionWithZero())
                    return;

            Model.calcValues();

            textBlockResult.Text = Model.GetResultValue;
                     
        }
    }
}
