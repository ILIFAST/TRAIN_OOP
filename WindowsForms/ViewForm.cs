using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsForms
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class ViewForm : Form
    {
        /// <summary>
        /// Лист, хранящий экземпляры и связанный с DatagriedView
        /// </summary>
        private BindingList<VehicleBase> _vehicles = new BindingList<VehicleBase>();

        /// <summary>
        /// Форма поиска
        /// </summary>
        private SearchForm _searchForm;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public ViewForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие при нажатии на кнопку добавления ТС
        /// </summary>
        private void AddVehicleForm(object sender, EventArgs e)
        {
            AddVehicleForm addVehicleForm = new AddVehicleForm();

			addVehicleForm.ValueAdded += (sender1, e1) =>
			{
				_vehicles.Add(e1.Vehicle);
				dataGridView1.DataSource = _vehicles;
			};
			addVehicleForm.Owner = this;
            addVehicleForm.Show();
        }
        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        void ViewForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;         
            dataGridView1.Refresh();
        }

        /// <summary>
        /// Событие при нажатии кнопки удаления ТС
        /// </summary>
        protected internal void DeleteVehicle(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow a in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(a.Index);
                }
            }
            catch
            {
                MessageBox.Show("Something wrong with deleted");
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки выгрузки БД
        /// </summary>
        private void CompileDatabase(object sender, EventArgs e)
        {
			try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "Vehicles";
                dt.Columns.Add("Name");
                dt.Columns.Add("OilConsumption");
                dt.Columns.Add("Speed");
                dt.Columns.Add("TypeOfVehicle");
                dt.Columns.Add("Economy");
                dt.Columns.Add("NumbersOfEngine");
                ds.Tables.Add(dt);
                foreach (VehicleBase vehicle in _vehicles)
                {
                    DataRow row = ds.Tables["Vehicles"].NewRow();
                    row["Name"] = vehicle.Name;
                    row["OilConsumption"] = vehicle.OilConsumption;
                    row["Speed"] = vehicle.Speed;
                    row["TypeOfVehicle"] = vehicle.TypeOfVehicle;
                    if (vehicle is HybridCar)
                    {
                        HybridCar Hubrid = vehicle as HybridCar;
                        row["Economy"] = Hubrid.Economy;
                    }
                    if (vehicle is Helicopter)
                    {
                        Helicopter Helicopter = vehicle as Helicopter;
                        row["NumbersOfEngine"] = Helicopter.NumbersOFEngine;
                    }
                    ds.Tables["Vehicles"].Rows.Add(row);
                }
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "myfile (*.myfile)|*.myfile|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        ds.WriteXml(myStream);
                        myStream.Close();
                        MessageBox.Show("MyFile saved succesfully", "Done.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can not save .myfile .", "not success.");
            }
        }

        /// <summary>
        /// Событие при нажатии кнопки загрузки БД
        /// </summary>
        private void LoadVehicles(object sender, EventArgs e)
        {
            LoadButton.Enabled = false;
            try
            {
                ChoiseForm choiseForm = new ChoiseForm("Delete all in you View?", "Yes", "No");
                choiseForm.Show();
                choiseForm.yesEvent += () =>
                {
                    _vehicles.Clear();
                    LoadFile();
                };

                choiseForm.noEvent += () =>
                {
                    LoadFile();
                };
                choiseForm.FormClosing += (sender1, e1) =>
                {
                    LoadButton.Enabled = true;
                };
            }
            catch
            {
                MessageBox.Show(".myfile not found.", "not success.");
            }

        }
        /// <summary>
        /// Метод загружающий файл
        /// </summary>
        private void LoadFile()
        {
            DataSet myData = new DataSet();
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "myfile (*.myfile)|*.myfile|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    myData.ReadXml(myStream);
                    myStream.Close();
                }

                try
                {
                    foreach (DataRow item in myData.Tables["Vehicles"].Rows)
                    {
                        if (Convert.ToString(item["TypeOfVehicle"]) == "Car")
                        {
                            _vehicles.Add(new Car(VehicleType.Car, item["Name"].ToString(),
                              Convert.ToDouble(item["OilConsumption"]),
                              Convert.ToDouble(item["Speed"])));
                        }
                        if (Convert.ToString(item["TypeOfVehicle"]) == "Helicopter")
                        {
                            _vehicles.Add(new Helicopter(VehicleType.Helicopter, item["Name"].ToString(),
                              Convert.ToDouble(item["OilConsumption"]),
                              Convert.ToDouble(item["Speed"]),
                              Convert.ToInt32(item["NumbersOfEngine"])));
                        }
                        if (Convert.ToString(item["TypeOfVehicle"]) == "HybridCar")
                        {
                            _vehicles.Add(new HybridCar(VehicleType.HybridCar, item["Name"].ToString(),
                              Convert.ToDouble(item["OilConsumption"]),
                              Convert.ToDouble(item["Speed"]),
                              Convert.ToDouble(item["Economy"])));
                        }
                        dataGridView1.DataSource = _vehicles;
                    }
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch
                {
                    MessageBox.Show("Something wrong");
                }
            }
           
        }

        /// <summary>
        /// Событие при нажатии кнопки поиска
        /// </summary>
        private void AddSeachForm(object sender, EventArgs e)
        {
            try
            {
                _searchForm = new SearchForm(dataGridView1,_vehicles);
                _searchForm.Show();
                SearchButton.Enabled = false;

                _searchForm.FormClosing += (sender1, e1) =>
                {
                    SearchButton.Enabled = true;
                };
            }
            catch
            {
                MessageBox.Show("Something wrong.");
            }
        }
    }
}
