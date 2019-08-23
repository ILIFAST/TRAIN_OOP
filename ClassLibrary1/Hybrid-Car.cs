using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Класс гибрид
    /// </summary>
    public class HybridCar : VehicleBase
    {
        /// <summary>
        /// Экономия топлива
        /// </summary>
        public double Economy { get; private set; }

        /// <summary>
        /// Конструктор для инициализации гибридной машины
        /// </summary>
        /// <param name="typeOfVehicle">Тип</param>
        /// <param name="name">Имя</param>
        /// <param name="oilConsumption">Потребление</param>
        /// <param name="speed">Скорость</param>
        public HybridCar(VehicleType typeOfVehicle, string name, double oilConsumption, double speed, double economy)
            : base(typeOfVehicle, name, oilConsumption, speed)
        {
            if (economy <= 0)
            {
                throw new System.ArgumentException(" economy cannot be negative or zero");
            }
            if (Double.IsNaN(economy) || Double.IsInfinity(economy))
            {
                throw new System.ArgumentException("economy cannot be NaN or Infinity");
            }
            else
            {
                Economy = economy;
            }
        }
        /// <summary>
        /// Метод расчёта потребления
        /// </summary>
        public override void GetOilConsumption(double t)
        {
            if (Speed <= 0 || OilConsumption <= 0)
            {
                Console.WriteLine("Ошибка! Скорость или потребление не может быть равными нулю");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Топлива израсходовано, Л = {1}",
                                    TypeOfVehicle, Name, Speed * t * (Economy / OilConsumption));
            }
        }
        /// <summary>
        /// Рандомное создание объекта Hybrid-car
        /// </summary>
        public static HybridCar RandomHybridCar()
        {
            Randomizer random = new Randomizer();
            var numberMark = random.Next(0, 5);
            var oilConsumption = random.Next(1, 10);
            var speed = random.Next(1, 150);
            var economy = random.Next(1,10);
            VehicleType type = VehicleType.HybridCar;
            string[] mark = new string[] {"Toyota Prius", "Mazda Demio"
                                          , "Toyota Yaris", "Lexus RX400h"
                                          ,"Opel Astra ","Nissan Altima Hybrid"};
            return new HybridCar(type, mark[numberMark], oilConsumption, speed, economy);
        }
    }
}