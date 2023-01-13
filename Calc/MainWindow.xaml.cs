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
            comboBoxOperations.SelectedIndex = 0;

            Model model = new Model();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            switch (comboBoxOperations.SelectedIndex)
            {
                case 0:
                    labelOperationSign.Content = "+";
                    break;
                case 1:
                    labelOperationSign.Content = "-";
                    break;
                case 2:
                    labelOperationSign.Content = "/";
                    break;
                case 3:
                    labelOperationSign.Content = "*";
                    break;
             
            }
        }

        private void buttonCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double firstValue = Convert.ToDouble(textBoxFirstValue.Text);
                double secondValue = Convert.ToDouble(textBoxSecondValue.Text);

                if (isDivisionWithZero(secondValue))
                    return;

                switch (comboBoxOperations.SelectedIndex)
                {
                    case 0:
                        textBlockResult.Text = "" + (firstValue + secondValue);
                        break;
                    case 1:
                        textBlockResult.Text = "" + (firstValue - secondValue);
                        break;
                    case 2:
                        textBlockResult.Text = "" + (firstValue / secondValue);
                        break;
                    case 3:
                        textBlockResult.Text = "" + (firstValue * secondValue);
                        break; 
                }
            }
            catch
            {
                MessageBox.Show("Неверные данные");
                return;
            }

        }

        private bool isDivisionWithZero(double secondValue)
        {
            if (secondValue == 0 && comboBoxOperations.SelectedIndex == 2)
            {
                MessageBox.Show("Деление на ноль невозможно"); 
                return true;
            }
            return false;
            
        }
    }
}
