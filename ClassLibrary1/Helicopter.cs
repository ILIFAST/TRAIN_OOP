using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Класс Вертолет производный 
    /// </summary>
    public class Helicopter : VehicleBase
    {
        /// <summary>
        /// Количество двигателей
        /// </summary>
        public int NumbersOFEngine { get; private set; }
        /// <summary>
        /// Конструктор для инициализации вертолета
        /// </summary>
        /// <param name="typeOfVehicle">Тип</param>
        /// <param name="name">Имя</param>
        /// <param name="oilConsumption">Потребление</param>
        /// <param name="speed">Скорость</param>
        public Helicopter(VehicleType typeOfVehicle, string name ,double oilConsumption, double speed, int nubmerOFEngine)
            : base(typeOfVehicle, name, oilConsumption, speed)
        {
            if (nubmerOFEngine <= 0)
            {
                throw new System.ArgumentException("nubmerOFEngine cannot be negative or zero");
            }
            if (Double.IsNaN(nubmerOFEngine) || Double.IsInfinity(nubmerOFEngine))
            {
                throw new System.ArgumentException("nubmerOFEngine cannot be NaN or Infinity");
            }
            else
            {
                NumbersOFEngine = nubmerOFEngine;
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
                Console.WriteLine("Топлива израсходовано, Л {0} = {1}",
                                  TypeOfVehicle, Name, Speed * t * OilConsumption * NumbersOFEngine);
            }
        }
        /// <summary>
        /// Рандомное создание объекта Helicopter
        /// </summary>
        public static Helicopter RandomHelicopter()
        {
            Randomizer random = new Randomizer();
            var numberMark = random.Next(0, 5);
            var oilConsumption = random.Next(150, 1000);
            var speed = random.Next(300, 600);
            var nubmerOFEngine = random.Next(1, 4);
            VehicleType type = VehicleType.Helicopter;
            string[] mark = new string[] {"Ми-24", "Ми-8", "Апач", "Ка-52"
                                          ,"SA 330 Puma  ","AH-1 Cobra"};
            return new Helicopter(type, mark[numberMark], oilConsumption, speed, nubmerOFEngine);
        }
    }
}