using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPair
{/// <summary>
/// Класс, производящий умножение пары четных чисел
/// </summary>
    public class Pair
    {
        int _value1;
        int _value2;
        /// <summary>
        /// Упрощенный доступ к тексу сообщения об "некорректности, 
        /// который может использоваться в различных задачах по отображению на экране        
        /// </summary>
        public static string InfoUser { get; } = "У вас некорректно введены значения для проведения произведения! Нужны четные числа!";
        public int Value1
        {
            get => _value1;
            set => _value1 = ProveValues(value) ? value : throw new Exception("Число не является четным!");
        }
        /// <summary>
        /// Свойство с оператором "if" в новом представлении
        /// </summary>
        public int Value2
        {
            get => _value2;
            set => _value2 = ProveValues(value) ? value : throw new Exception("Число не является четным!");
        }
        /// <summary>
        /// Пустой конструктор со значениями "0" у полей
        /// </summary>
        public Pair() { }
        public Pair(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        /// <summary>
        /// Происходит проверка числа на четность
        /// </summary>
        /// <param name="value">Число для проверки</param>
        /// <returns>true - в случае, когда число четное и false - в случае, когда число нечетное</returns>
        private bool ProveValues(int value)
        {
            return value % 2 == 0;
        }/// <summary>
         /// Произведение чисел, находящихся внутри объекта
         /// </summary>
         /// <returns>Вывод результата произведения с типом int</returns>
        public int PairCalculate()
        {
            return _value1 * _value2;
        }
        /// <summary>
        /// Выполнение умножения пар четных чисел
        /// </summary>
        /// <param name="secondpair">Объект, хранящий в себе 2 числа</param>
        public Pair PairCalculate(Pair secondpair)
        {
            return new Pair(_value1 * secondpair.Value1, _value2 * secondpair.Value2);
        }/// <summary>
         /// Занесение чисел в объект
         /// </summary>
         /// <param name="value1">Первое число</param>
         /// <param name="value2">Второе число</param>
        public void AddValue(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }/// <summary>
        /// Инкременция (a, b) = (a + b, b)
        /// </summary>
        /// <param name="value">value - объект, несущий с собой значения первого и второго чисел</param>
        /// <returns>Возвращает значения в новый объект</returns>
        public static Pair operator ++(Pair value)
        {            
                return new Pair(value.Value1, value.Value2) { Value1 = value.Value1 + value.Value2};            
        }
    }
}
