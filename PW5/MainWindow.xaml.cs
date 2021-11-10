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
        Pair result;
        Pair firstpair = new Pair();
        Pair secondpair = new Pair();
        private void Support_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программа имеет следующие особенности:\n1) Необходимо вводить только четные числа для вычисления.\n2) Максимальное число для ввода в полях - пятизначное.\n3) Первое произведение - умножение первого числа на третье. Второе произведение - умножение второго числа на четвертое.\n4) Для вычисления инкременции используются первое и второе числа.", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №6. Задание 8. Использовать класс Pair (пара четных чисел). Разработать операцию инкремента - (a, b) = (a + b, b). Разработать операцию для вычисления произведения 2-х пар чисел - (a, b) * (c, d) = (a * c, b * d)", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Используется для очистки результатов
        /// при изменении начальных значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            FirstResult.Clear();
            SecondResult.Clear();
            if (e.Source != ThirdValue && e.Source != ForthValue) //Проверка на очистку результата при изменении 1 или 2 строки
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
                firstpair.AddValue(value1, value2);
                secondpair.AddValue(value3, value4);
                result = firstpair.PairCalculate(secondpair);//Занесение результатов в объект result
                FirstResult.Text = result.Value1.ToString();//Вывод результатов
                SecondResult.Text = result.Value2.ToString();
            }
            else MessageForUser();
        }
        /// <summary>
        /// Изменение дефолтного Enter при фокусировании на разных TextBox'ах
        /// Используется для удобного переключения посредством Tab и нажатия Enter после ввода значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                firstpair.AddValue(value1, value2);
                result = ++firstpair;
                ResultOfIncremention.Text = result.Value1.ToString();
            }
            else MessageForUser();
        }
        /// <summary>
        /// Метод для сообщения пользователю об некорректности значений, введенных им
        /// </summary>
        public void MessageForUser()
        {
            MessageBox.Show(Pair.InfoUser, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }        
    }
}
