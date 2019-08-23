using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;

namespace WindowsForms
{
    /// <summary>
    /// Создание наследника класса EventArgs для доступа к полям
    /// </summary>
    public class EventArgsVehicle: EventArgs
	{
        /// <summary>
        /// Экземпляр класса VehicleBase
        /// </summary>
        public VehicleBase Vehicle { get; }

        /// <summary>
        /// Конструктор класса EventArgsVehicle
        /// </summary>
        public EventArgsVehicle(VehicleBase vehicle)
		{
			Vehicle = vehicle;
		}
	}
}
