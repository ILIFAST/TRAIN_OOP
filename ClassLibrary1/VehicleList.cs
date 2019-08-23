using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class VehicleList
    {
        /// <summary>
        /// Создание массива людей
        /// </summary>
        //TODO: - Исправлено
        VehicleBase[] _arrayOfVehicle = new VehicleBase[0];
        /// <summary>
        /// Добавление взрослой персоны (Перегрузка метода)
        /// </summary>
        public void AddPerson(VehicleBase vehicle)
        {
            Array.Resize(ref _arrayOfVehicle, _arrayOfVehicle.Length + 1);
            _arrayOfVehicle[_arrayOfVehicle.Length - 1] = vehicle;
        }
        /// <summary>
        /// Узнать тип персоны по индексу в списке
        /// </summary>
        /// <param name="index">Индекс персоны в списке</param>
        /// <returns>Тип персоны (Adult/Child)</returns>
       
        /// <summary>
        /// Проверка есть ли элемент с заданным номером в массиве
        /// </summary>
        private bool BorderCheck(int index)
        {
            if ((index >= 0) & (index <= (_arrayOfVehicle.Length - 1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Возврат количества элементов в массиве
        /// </summary>
        public int Lenght
        {
            get
            {
                return _arrayOfVehicle.Length;
            }
        }

        /// <summary>
        /// Поиск значения персона по указанному индексу
        /// </summary>
        public VehicleBase ReturnVehicle(int index)
        {
            return _arrayOfVehicle[index];
        }
}
}
