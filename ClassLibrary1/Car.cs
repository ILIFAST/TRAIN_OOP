using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Класс машина
    /// </summary>
    public class Car : VehicleBase
    {
        /// <summary>
        /// Конструктор для инициализации машины
        /// </summary>
        /// <param name="typeOfVehicle">Тип</param>
        /// <param name="name">Имя</param>
        /// <param name="oilConsumption">Потребление на км</param>
        /// <param name="speed">Скорость</param>
        public Car(VehicleType typeOfVehicle, string name , double oilConsumption, double speed)
            : base(typeOfVehicle,name, oilConsumption, speed)
        { }

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
                                TypeOfVehicle, Name, Speed * t * OilConsumption);
            }
        }
        /// <summary>
        /// Рандомное создание объекта Car
        /// </summary>
        public static Car RandomCar()
        {

            Randomizer random = new Randomizer();
            var numberMark = random.Next(0, 5);
            var oilConsumption = random.Next(1, 10);
            var speed = random.Next(1, 200);
            VehicleType type = VehicleType.Car;
            string[] mark = new string[] {"Toyota Corolla", "Toyota Mark 2"
                                          , "Mitsubishi Lancer", "Mitsubishi Padjero" 
                                          ,"Honda Civic","Nissan Terano"};
            return new Car(type, mark[numberMark],oilConsumption, speed);
        }
    }
}
