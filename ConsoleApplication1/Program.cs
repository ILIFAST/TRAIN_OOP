using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    /// <summary>
    /// Programm lab 3
    /// </summary>
    class DataOfVehicle
    {   
        /// <summary>
        /// Начало работы программы
        /// </summary>
        private static void Main()
        {
            var vehicleList = new List<VehicleBase>();
            Console.WriteLine("Сколько нужно ввести транспорта в БД?");
            Func<int, bool> func = (val) =>
            {
                return val > 0;
            };
            int lenghtList = GetValidValue(func, int.TryParse, "Введи целое неотрицательное количество ТС)");
            for (int i = 0; i < lenghtList; i++)
            {
                vehicleList.Add(AddVehicleFromConsole());
            }
            Console.WriteLine("Введи  неотрицательное время движения");
            Func<double, bool> doblefunc = (val) =>
            {
                return val > 0;
            };
            var time = GetValidValue(doblefunc, double.TryParse, "Время задано не верно");
            foreach (var vehicle in vehicleList)
            {
                vehicle.GetOilConsumption(time);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Ввод транспортного средства
        /// </summary>
        public static VehicleBase AddVehicleFromConsole()
        {
            Console.WriteLine("Введите поочередно  Тип ТС: {1}, Расход ГСМ ТС: {2}, Скорость ТС: {3}");
            Console.WriteLine("Введите тип ТС. Тип - 0 - Машина; 1 - Вертолет; 2 - Гибрид");
            Func<int, bool> func = (val) =>
            {
                return (val == 0 || val == 1 || val == 2);
            };
            int numOfVehicle = GetValidValue(func, int.TryParse, "Введен несуществующий тип Т.С.)");

            var typeOfVehicle = VehicleType.Car;

            Func<double, bool> doublefunc = (val) =>
            {
                return val > 0;
            };
            var consumption = GetValidValue(doublefunc, double.TryParse, "Введите потребление( больше ноля)");
            var speed = GetValidValue(doublefunc, double.TryParse, "Введите скорость( больше ноля)");
            Console.WriteLine("Введите название ТС");
            string name = Console.ReadLine();
            return CreateVehicle(numOfVehicle, ref typeOfVehicle, consumption, speed, name);
        }
        /// <summary>
        /// Создание транспортного средства
        /// </summary> //TODO: RSDN - Checked
        private static VehicleBase CreateVehicle(int numOfVehicle, ref VehicleType typeOfVehicle, double consumption, double speed, string name)
        {
            switch(numOfVehicle)
            {
                case 0:
                    {
                        typeOfVehicle = VehicleType.Car;
                        return new Car(typeOfVehicle, name, consumption, speed);
                    }
                case 1:
                    {
                        typeOfVehicle = VehicleType.Helicopter;
                        Console.WriteLine("Введите количество двигателей вертолета(от одного)");
                        Func<int, bool> func = (val) =>
                        {
                            return (val >= 1);
                        };

                        int numOfEngines = GetValidValue(func, int.TryParse, "Неверное количество двигателей(от одного)");
                        return new Helicopter(typeOfVehicle, name, consumption, speed, numOfEngines);
                    }

                case 2:
                    {
                        Func<double, bool> doublefunc = (val) =>
                        {
                            return val < 1 && val > 0;
                        };
                        Console.WriteLine("Экономичность гибрида(от ноля до одного)");
                        double economy = GetValidValue(doublefunc, double.TryParse, "Неверная экономичность( от ноля до одного)");
                        typeOfVehicle = VehicleType.HybridCar;
                        return new HybridCar(typeOfVehicle, name, consumption, speed, economy);
                    }
                default:
                    {
                        return null;
                    }
            }         
        }
        /// <summary>
        /// Проверка Int на соотвествие условию
        /// </summary>
        private static T GetValidValue<T>(Func<T, bool> func, OutFunc<string, T> parseFunc, string message)
        {
            T value;
            while (true)
            {
                if (parseFunc.Invoke(Console.ReadLine(), out value) && func.Invoke(value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
            return value;
        }

        private delegate bool OutFunc<T1, T2>(T1 consoleLine, out T2 value);
    }
}
