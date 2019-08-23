using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Класс Random
    /// </summary>
    public class Randomizer
    {
        /// <summary>
        /// Переменная Random
        /// </summary>
        Random random;
        /// <summary>
        /// Конструктор класса Randomizer
        /// </summary>
        public Randomizer()
        {
            if (random == null)
                random = new Random();
        }
        /// <summary>
        /// Метод Next класса NextDouble
        /// </summary>
        public double NextDouble()
        {
            return random.NextDouble();
        }
        /// <summary>
        /// Метод Next класса NextDouble
        /// </summary>
        public int Next()
        {
            return random.Next();
        }
        /// <summary>
        /// Метод Next класса NextDouble
        /// </summary>
        public int Next(int maxValue)
        {
            return random.Next(maxValue);
        }
        /// <summary>
        /// Метод Next класса NextDouble
        /// </summary>
        public int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        /// <summary>
        /// Метод NextBytes класса NextDouble
        /// </summary>
        public void NextBytes(byte[] buffer)
        {
            random.NextBytes(buffer);
        }
    }
}
