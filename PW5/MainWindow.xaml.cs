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
using LibPair;
/// <summary>
/// Практическая работа №6. Задание 8. 
/// Использовать класс Pair (пара четных чисел). 
/// Разработать операцию инкремента - (a, b) = (a + b, b). 
/// Разработать операцию для вычисления произведения 2-х пар чисел - (a, b) * (c, d) = (a * c, b * d)"
/// </summary>
namespace PW5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа имеет следующие особенности:\n1) Необходимо вводить только четные числа для вычисления.\n2) Максимальное число для ввода в полях - пятизначное.\n3) Первое произведение - умножение первого числа на третье. Второе произведение - умножение второго числа на четвертое.\n4) Для вычисления инкременции используются первое и второе числа.", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №6. Задание 8. Использовать класс Pair (пара четных чисел). Разработать операцию инкремента - (a, b) = (a + b, b). Разработать операцию для вычисления произведения 2-х пар чисел - (a, b) * (c, d) = (a * c, b * d)", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FirstValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstResult.Clear();
            SecondResult.Clear();
            if (e.Source != ThirdValue && e.Source != ForthValue)
                ResultOfIncremention.Clear();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {            
            bool ProveValue1 = int.TryParse(FirstValue.Text, out int value1);
            bool ProveValue2 = int.TryParse(SecondValue.Text, out int value2);
            bool ProveValue3 = int.TryParse(ThirdValue.Text, out int value3);
            bool ProveValue4 = int.TryParse(ForthValue.Text, out int value4);
            if (ProveValue1 == true && ProveValue2 == true && ProveValue3 == true && ProveValue4 == true)
            {
                int[] mas = Pair.PairCalculateWithoutObject(value1, value2, value3, value4);
                if (mas != null)
                {
                    FirstResult.Text = mas[0].ToString();
                    SecondResult.Text = mas[1].ToString();
                }
                else MessageForUser(false);
            }
            else MessageForUser(true);
        }

        private void FirstValue_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source == FirstValue || e.Source == SecondValue)
            {
                Calculate.IsDefault = false;
                CalculateIncremention.IsDefault = true;
            }
            else
            {
                Calculate.IsDefault = true;
                CalculateIncremention.IsDefault = false;
            }
        }

        private void CalculateIncremention_Click(object sender, RoutedEventArgs e)
        {
            bool ProveValue1 = int.TryParse(FirstValue.Text, out int value1);
            bool ProveValue2 = int.TryParse(SecondValue.Text, out int value2);
            if (ProveValue1 == true && ProveValue2 == true)
            {
                Pair firstvalue = new Pair(value1, value2);
                firstvalue++;
                if (firstvalue == null) MessageForUser(false);
                else ResultOfIncremention.Text = firstvalue.Value1.ToString();
            }
            else MessageForUser(true);
        }
        /// <summary>
        /// Используется для уведомления пользователя о конкретных ошибках, 
        /// вызванных неправильным общением с программой
        /// </summary>
        /// <param name="isemptystring">isemptystring - значение пустой строки, true - пустая строка, false - не пустая строка</param>
        public static void MessageForUser(bool isemptystring)
        {
            if(isemptystring == true)
                MessageBox.Show("У вас некорректно введены значения для проведения произведения! Подробности об особенностях работы программы написаны в справке!", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
            else 
                MessageBox.Show("У вас введены нечетные(ое) числа(о)! Пожалуйства, введите значения в соответствии с требованиями!", "ОШИБКА!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
