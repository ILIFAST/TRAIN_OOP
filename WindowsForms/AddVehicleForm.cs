using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using System.Collections;
using WindowsForms;

namespace WindowsForms
{
    /// <summary>
    /// Форма добавления ТС
    /// </summary>
    public partial class AddVehicleForm : Form
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddVehicleForm()
        {
            InitializeComponent();
#if DEBUG
            button3.Visible = true;
#else
            button3.Visible = false;
#endif
        }
        /// <summary>
        /// Событие по нажатию кнопки ввода
        /// </summary>
        private void EnterVehicle(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                if (comboBox1.SelectedIndex > -1)
                {
                    bool isDoNotWrite = false;
                    for (int j = 0; j <= dataGridView2.ColumnCount - 1; j++)
                    {
                        isDoNotWrite = dataGridView2.Rows[0].Cells[j].Value == null;
                    }
                    if (!isDoNotWrite)
                    {
                        Func<double, bool> doublefunc = (val) =>
                        {
                            return val > 0;
                        };
                        var consumption = GetValidValue(doublefunc, double.TryParse,
                            "Enter consumption(>0)",
                            Convert.ToString(dataGridView2[1, 0].Value), label1);

                        var speed = GetValidValue(doublefunc, double.TryParse,
                                                "Enter speed(>0)",
                                                 Convert.ToString(dataGridView2[2, 0].Value), label1);

                        switch ((string)comboBox1.SelectedItem)
                        {
                            case "Car":
                                {
                                    if (speed == 0 || consumption == 0)
                                    { return; }

                                    Vehicle = new Car(VehicleType.Car, 
                                                    Convert.ToString(dataGridView2[0, 0].Value), 
                                                    consumption, speed);
                                    this.Close();
                                    break;
                                }
                            case "HybridCar":
                                {
                                    Func<double, bool> doublefuncEconomy = (val) =>
                                    {
                                        return val < 1 && val > 0;
                                    };
                                    double economy =
                                        GetValidValue(doublefuncEconomy,
                                                      double.TryParse,
                                                      "Wrong economy(0-1)",
                                                      Convert.ToString(dataGridView2[3, 0].Value), 
                                                       label1);
                                    if (speed == 0 || consumption == 0 || economy == 0)
                                    { return; }
                                    HybridCar hybrid = 
                                        new HybridCar(VehicleType.HybridCar,
                                                      Convert.ToString(dataGridView2[0, 0].Value),
                                                      consumption, speed, economy);
                                    Vehicle = hybrid;
                                    this.Close();
                                    break;
                                }
                            case "Helicopter":
                                {
                                    Func<int, bool> funcEngines = (val) =>
                                    {
                                        return (val >= 1);
                                    };
                                    int numOfEngines = 
                                        GetValidValue(funcEngines, int.TryParse,
                                                      "Incorrect number of engines (>1)",
                                                       Convert.ToString(dataGridView2[3, 0].Value),
                                                       label1);
                                    if (speed == 0 || consumption == 0 || numOfEngines == 0)
                                    { return; }
                                    Helicopter helicopter = 
                                        new Helicopter(VehicleType.Helicopter,
                                                        Convert.ToString(dataGridView2[0, 0].Value),
                                                        consumption, speed, numOfEngines);
                                    Vehicle = helicopter;
                                    this.Close();
                                    break;
                                }
                            default:
                                {
                                    label1.Text = "Something wrong with data input";
                                    break;
                                }
                        }
                    }
                    else
                    {
                        label1.Text = "Something wrong with data input";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Something wrong");
            }
        }
        /// <summary>
        /// Метод для проверки на соответствие условию значения
        /// </summary>
        private static T GetValidValue<T>(Func<T, bool> func, 
			OutFunc<string, T> parseFunc, 
			string message, 
			string checkString, Label label1)
        {
            T value;

            if (parseFunc.Invoke(checkString, out value) && func.Invoke(value))
            {
                return value;
            }
            else
            {
                label1.Text = label1.Text + message;
                return default(T);
            }
        }

        /// <summary>
        /// Делегат
        /// </summary>
        private delegate bool OutFunc<T1, T2>(T1 consoleLine, out T2 value);

        /// <summary>
        /// Событие при выборе в комбобоксе типа ТС
        /// </summary>
        private void ComboboxChecked(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.AllowUserToAddRows = false;
            var select = (string)comboBox1.SelectedItem;
            AddRow(select);
            dataGridView2.Rows.Add();
        }
        /// <summary>
        /// Добавление строки для заполнения на DaraGriedView
        /// </summary>
        private void AddRow(string select)
        {
            try
            {
                dataGridView2.Columns.Clear();
                switch(select)
                {
                    case "Car":
                        {
							var columnNames = new List<string>()
							{
								"Name",
								"OilConsumption",
								"Speed",
							};
							dataGridView2.Columns.AddRange(GetColumns(columnNames));
                            break;
                        }
                    case "HybridCar":
                        {
                            var columnNames = new List<string>()
                            {
                                "Name",
                                "OilConsumption",
                                "Speed",
                                "Economy"
                            };
                            dataGridView2.Columns.AddRange(GetColumns(columnNames));
                            break;
                        }

                    case "Helicopter":
                        {
                            var columnNames = new List<string>()
                            {
                                "Name",
                                "OilConsumption",
                                "Speed",
                                "NumOfEngine"
                            };
                            dataGridView2.Columns.AddRange(GetColumns(columnNames));
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("It was not possible to add lines to set the vehicle");
            }
        }

        /// <summary>
        /// Метод, хранящий в себе базовые свойства ТС 
        /// </summary>
        public static DataGridViewTextBoxColumn[] GetColumns(List<string> columnNames)
        {
			var columnList = new List<DataGridViewTextBoxColumn>();
			foreach(var columnName in columnNames)
			{
				columnList.Add(new DataGridViewTextBoxColumn()
				{
					Name = columnName
				});
			}
			return columnList.ToArray();
        }

        /// <summary>
        /// Событие по нажатию кнопки рандомного задания ТС
        /// </summary>
        private void GetRandomVehicle(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Columns.Clear();
                dataGridView2.AllowUserToAddRows = true;
                Randomizer randomize = new Randomizer();

				var randomNumber = randomize.Next(0, 3);
                switch(randomNumber)
                {
                    case 0 :
                        {
							Vehicle = Car.RandomCar();
                            break;
                        }
                    case 1:
                        {
							Vehicle = HybridCar.RandomHybridCar();
                            break;
                        }
                    case 2:
                        {
							Vehicle = Helicopter.RandomHelicopter();                            
                            break;
                        }
                }

				dataGridView2.DataSource = Vehicle;
				this.Close();
            }       
            catch
            {
                MessageBox.Show("Что-то пошло не так при рандомной генерации");
            }
        }

        /// <summary>
        /// События при запуске формы
        /// </summary>
        public void AddVehicleForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        /// <summary>
        /// Событие для обмена с главной формой
        /// </summary>
        internal event EventHandler<EventArgsVehicle> ValueAdded;

		/// <summary>
		/// //Экземпляр VehicleBase для передачи во ViewForm
		/// </summary>
		private VehicleBase _vehicle;

		/// <summary>
		/// Значение, передаваемое в главную форму
		/// </summary>
		private VehicleBase Vehicle
        {
			get
			{
				return _vehicle;
			}
            set
            {
				_vehicle = value;
				var eventArgs = new EventArgsVehicle(_vehicle);
                ValueAdded?.Invoke(this, eventArgs);
            }
        }
        /// <summary>
        /// Событие при нажатии кнопки отмены
        /// </summary>
        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
