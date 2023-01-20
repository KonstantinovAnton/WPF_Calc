using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc
{
    public static class Model
    {
        // блок с данными

        private static double firstValue;
        private static double secondValue;
        private static double result;

        // блок для обращения к текстовым полям

        public static TextBox textBoxFirstValue;         // Текст. бокс с первым значением
        public static TextBox textBoxSecondValue;        // Текст. бокс с вторым значением
        public static TextBlock textBlockResult;         // Текст. блок с результатом

        public static Label labelOperationSign;          // Лэйбл с знаком операции

        public static ComboBox comboBoxOperations;       // Комбо бокс с арифм. операциями
        


        // блок с бизнес-логикой


        // свойство для получения значение первого числа
        public static double GetSetFirstValue              
        {
            get
            {
                return firstValue;
            }
            set
            {
                firstValue = value;
            }
        }


        // свойство для получения значение второго числа
        public static double GetSetSecondValue            
        {
            get
            {
                return secondValue;
            }
            set
            {
                secondValue = value;
            }
        }

        // свойство для получения и присваивания индекса выбранной операции
        public static int GetComboBoxValue               
        {
            get
            {
                return comboBoxOperations.SelectedIndex;
            }
            set
            {
                comboBoxOperations.SelectedIndex = value;
            }
        }

        // свойство для установки значения результата текстового блока
        public static string GetResultValue              
        {
            get
            {
                return Convert.ToString(result);
            }
           
        }

        // свойство для получения знака текущей операции
        public static string GetLabelOperationSign
        {
            get
            {
                switch (comboBoxOperations.SelectedIndex)
                {
                    case 0:
                        return "+";
                    case 1:
                        return "-";
                    case 2:
                        return "/";
                    case 3:
                        return "*";
                    default:
                        return "&";                          
                }
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
        public static bool isCorrectValue(string value1, string value2)
        {
            try
            {
                double firstValue = Convert.ToDouble(value1);
                double secondValue = Convert.ToDouble(value2);

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
