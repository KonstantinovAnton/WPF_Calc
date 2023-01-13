using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    internal class Model
    {
        // блок с данными

        public static double firstValue;
        public static double secondValue;
        public static double result;

        // блок для обращения к текстовым полям и лэйблу

        public static TextBlock textBoxFirstValue;       // Текст. блок с первым значением
        public static TextBlock textBoxSecondValue;      // Текст. блок с вторым значением
        public static TextBlock textBlockResult;         // Текст. блок с результатом

        public static Label labelOperationSign;          // Лэйбл с знаком операции

        public static ComboBox comboBoxOperations;       // Комбо бокс с арифм. операциями


        // блок с бизнес-логикой


        // свойство для получения значение первого числа
        public static double GetFirstValue              
        {
            get
            {
                return firstValue;
            }       
        }

        // свойство для получения значение второго числа
        public static double GetSecondValue            
        {
            get
            {
                return secondValue;
            }
        }

        // свойство для получения индекса выбранной операции
        public static int GetComboBoxValue               
        {
            get
            {
                return comboBoxOperations.SelectedIndex;
            }
        }

        // свойство для установки значения результата текстового блока
        public static double SetResultValue              
        {
            set
            {
                result = value;
                textBlockResult.Text = result.ToString();
            }
        }

        // метод для определения выполняется ли деление на ноль
        public static bool isDivisionWithZero()                 
        {
            if (secondValue == 0 && GetComboBoxValue == 2)
            {
                MessageBox.Show("Деление на ноль невозможно");
                return true;
            }
            return false;
        }

        // метод для подсчета значений
        public static void calcValues()
        {
            switch (GetComboBoxValue)
            {
                case 0:
                    result =  firstValue + secondValue;
                    break;
                case 1:
                    result = firstValue - secondValue;
                    break;
                case 2:
                    result = firstValue / secondValue;
                    break;
                case 3:
                    result = firstValue * secondValue;
                    break;
            }
        }

        // метод для определения корректности значений
        public static bool isCorrectValue()
        {
            try
            {
                double firstValue = Convert.ToDouble(textBoxFirstValue.Text);
                double secondValue = Convert.ToDouble(textBoxSecondValue.Text);

                return true;
            }
            catch
            {
                MessageBox.Show("Некорректные значения. Введите численные значения");
                return false;
            }
        }


    }
}
