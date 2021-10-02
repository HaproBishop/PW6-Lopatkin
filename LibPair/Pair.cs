using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPair
{/// <summary>
/// Класс, производящий умножение пары четных чисел и инкременцию
/// </summary>
    public class Pair
    {        
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
        public int Value4 { get; set; }
        public int[] Result { get; set; }
        public Pair() { }                    
        public Pair(int value1)
        {
            Value1 = value1;           
        }
        public Pair(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public Pair(int value1, int value2, int value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
        public Pair(int value1, int value2, int value3, int value4)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }/// <summary>
         /// Проверяет на четность числа при созданном экземпляре объекта</summary>
         /// <returns>true - в случае, если все числа четные, false - в случае, если есть нечетные числа</returns>
        private bool ProveValuesEvenWithObject()
        {            
            if (Value1 % 2 == 0)
                if (Value2 % 2 == 0)
                    if (Value3 % 2 == 0)
                        if (Value4 % 2 == 0) return true;
            return false;
        }/// <summary>
        /// Производит умножение 2 пар чисел при созданном экземпляре объекта
        /// </summary>
        /// <returns>Result - массив, где Result[0] - первое произведение, а Result[1] - второе произведение; Иначе - null, если числа не являются четными</returns>
        public int[] PairCalculateWithObject()
        {            
            if (ProveValuesEvenWithObject() == true)
            {
                Result = new int[2];
                Result[0] = Value1 * Value3;
                Result[1] = Value2 * Value4;
                return Result;
            }
            else return null;
        }/// <summary>
         /// Проверяет на четность числа без создания экземпляра объекта
         /// </summary>
         /// <param name="value1">Первое число</param>
         /// <param name="value2">Второе число</param>
         /// <param name="value3">Третье число</param>
         /// <param name="value4">Четвертое число</param>
         /// <returns>true - в случае, если все числа четные, false - в случае, если есть нечетные числа</returns>
        private static bool ProveValuesEvenWithoutObject(int value1, int value2, int value3, int value4)
        {
            if (value1 % 2 == 0)
                if (value2 % 2 == 0)
                    if (value3 % 2 == 0)
                        if (value4 % 2 == 0) return true;
            return false;
        }/// <summary>
         ///  Производит умножение 2 пар чисел без созданного экземпляра объекта
         /// </summary>
         /// <param name="value1">Первое число</param>
         /// <param name="value2">Второе число</param>
         /// <param name="value3">Третье число</param>
         /// <param name="value4">Четвертое число</param>
         /// <returns>null - в случае, если числа не являются четными, mas - в случае, если числа являются четными</returns>
        public static int[] PairCalculateWithoutObject(int value1, int value2, int value3, int value4)
        {
            if (ProveValuesEvenWithoutObject(value1, value2, value3, value4) == true)
            {
                int[] mas = new int[2];
                mas[0] = value1 * value3;
                mas[1] = value2 * value4;
                return mas;
            }
            else return null;
        }
        /// <summary>
        /// Инкременция (a, b) = (a + b, b)
        /// </summary>
        /// <param name="value">value - объект, несущий с собой значения первого и второго чисел</param>
        /// <returns>null - при отсутствии четных чисел, new Pair { Value1 = value.Value1 + value.Value2 }- при наличии четных чисел</returns>
        public static Pair operator ++(Pair value)
        {
            if (value.Value1 % 2 == 0 && value.Value2 % 2 == 0)
                return new Pair { Value1 = value.Value1 + value.Value2 };
            else return null;
        }
    }
}
