using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Абстрактный базовый класс транспортных средств
    /// </summary>
    public abstract class VehicleBase
    {
        /// <summary>
        /// Имя транспортного средства
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public double Speed { get; private set; }

        /// <summary>
        /// Потребление топлива
        /// </summary>
        public double OilConsumption { get; private set; }

        /// <summary>
        /// Тип транспортного средства
        /// </summary>
        public VehicleType TypeOfVehicle { get; private set; }

        /// Конструктор для инициализации объекта Транспортное средство
        /// <param name="typeOfVehicle">Тип </param>
        /// <param name="oilConsumption">Потребление топлива</param>
        /// <param name="speed">Скорость</param>
        public VehicleBase(VehicleType typeOfVehicle,string name ,double oilConsumption, double speed)
        {
            if (speed <= 0  )
            {
                throw new System.ArgumentException("speed cannot be negative");
            }
            if (Double.IsNaN(speed) || Double.IsInfinity(speed) )
            {
                throw new System.ArgumentException("speed cannot be NaN or Infinity");
            }
            else
            {
                Speed = speed;
            }

            if (oilConsumption <= 0)
            {
                throw new System.ArgumentException("oilConsumption cannot be negative");
            }
            if (Double.IsNaN(oilConsumption) || Double.IsInfinity(oilConsumption))
            {
                throw new System.ArgumentException("oilConsumption cannot be NaN or Infinity");
            }
            else
            {
                OilConsumption = oilConsumption;
            }
            if (TypeOfVehicle == VehicleType.Car || TypeOfVehicle == VehicleType.Helicopter 
                                                 || typeOfVehicle == VehicleType.Car)
            {
                TypeOfVehicle = typeOfVehicle;
            }
            else
            {
                throw new System.ArgumentException("Type of vehicle is bad"); 
            }
            Name = name;
        }
        /// <summary>
        /// Расчет топлива
        /// </summary>
        public abstract void GetOilConsumption(double time);
    }
}
